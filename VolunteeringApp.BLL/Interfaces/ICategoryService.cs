using VolunteeringApp.BLL.DTOs.Category;

namespace VolunteeringApp.BLL.Interfaces;

public interface ICategoryService
{
    public Task<Guid> Add(CreateCategoryDTO categoryDTO);
    public Task<FilteredCategoriesDTO> GetFiltered(CategoriesQueryFilters filters);
    public Task Update(Guid id, UpdateCategoryDTO categoryDTO);
    public Task Delete(Guid id);
}
