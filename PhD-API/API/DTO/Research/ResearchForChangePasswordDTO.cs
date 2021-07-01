namespace API.DTO.Research
{
    public class ResearchForChangePasswordDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
