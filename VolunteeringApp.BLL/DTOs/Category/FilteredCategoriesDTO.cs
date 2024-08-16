namespace VolunteeringApp.BLL.DTOs.Category;

public class FilteredCategoriesDTO
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
}
