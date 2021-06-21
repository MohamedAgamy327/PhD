namespace API.DTO.Researcher
{
    public class ResearcherForChangePasswordDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
