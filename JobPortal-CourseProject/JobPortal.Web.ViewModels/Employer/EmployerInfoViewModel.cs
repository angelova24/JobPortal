using System.ComponentModel.DataAnnotations;

namespace JobPortal.Web.ViewModels.Employer;

public class EmployerInfoViewModel
{
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; } = null!;

    [Display(Name = "Company")]
    public string CompanyName { get; set; } = null!;

    [Display(Name = "Company address")]
    public string CompanyAddress { get; set; } = null!;
}