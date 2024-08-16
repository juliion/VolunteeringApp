namespace VolunteeringApp.BLL.DTOs.Category;

public class CategoriesQueryFilters
{
    public int Take { get; set; } = 10;
    public int Skip { get; set; } = 0;
    public string SortColumn { get; set; } = "Name";
    public string? Search { get; set; }
    public string Order { get; set; } = "desc";
}
