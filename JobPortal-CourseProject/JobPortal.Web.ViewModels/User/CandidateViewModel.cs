namespace JobPortal.Web.ViewModels.User
{
    public class CandidateViewModel
    {
        public string JobId { get; set; } = null!;
        
        public string CandidateId { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public DateTime ApplicationDate { get; set; }
    }
}