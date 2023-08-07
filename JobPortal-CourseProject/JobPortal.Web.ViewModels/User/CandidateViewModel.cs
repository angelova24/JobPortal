namespace JobPortal.Web.ViewModels.User
{
    public class CandidateViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public DateTime ApplicationDate { get; set; }
    }
}