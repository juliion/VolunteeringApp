using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VolunteeringApp.BLL.Common.Exceptions;
using VolunteeringApp.BLL.DTOs.Category;
using VolunteeringApp.BLL.Interfaces;
using VolunteeringApp.DLL;
using VolunteeringApp.DLL.Entities;

namespace VolunteeringApp.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly VolunteeringAppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(VolunteeringAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Add(CreateCategoryDTO categoryDTO)
    {
        var newCategory = _mapper.Map<CreateCategoryDTO, Category>(categoryDTO);

        _context.Categories.Add(newCategory);
        await _context.SaveChangesAsync();

        return newCategory.Id;
    }
    private async Task<FilteredCategoriesDTO> ApplyFilters(CategoriesQueryFilters filters)
    {
        var query = _context.Categories
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.SortColumn) && !string.IsNullOrWhiteSpace(filters.Order))
        {
            if (filters.Order == "asc")
            {
                query = query.OrderBy(e => EF.Property<object>(e, filters.SortColumn));
            }
            else if (filters.Order == "desc")
            {
                query = query.OrderByDescending(e => EF.Property<object>(e, filters.SortColumn));
            }
        }

        if (filters.Search != null)
        {
            query = query.Where(t => t.Name.Contains(filters.Search));
        }

        var total = await query.CountAsync();
        var take = filters.Take;
        var skip = filters.Skip;

        var categories = await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        var categoriesDTOs = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);


        var filteredCategories = new FilteredCategoriesDTO
        {
            Take = take,
            Skip = skip,
            Total = total,
            Categories = categoriesDTOs
        };

        return filteredCategories;
    }
    public async Task<FilteredCategoriesDTO> GetFiltered(CategoriesQueryFilters filters)
    {
        var filteredCategories = await ApplyFilters(filters);

        return filteredCategories;
    }

    public async Task Update(Guid id, UpdateCategoryDTO categoryDTO)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            throw new NotFoundException();
        }

        category.Name = categoryDTO.Name;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            throw new NotFoundException();
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
