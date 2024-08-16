using VolunteeringApp.PL.ViewModels.Organization;

namespace VolunteeringApp.PL.ViewModels.Category;

public class FilteredCategoriesViewModel
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public long Total { get; set; }
    public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}
