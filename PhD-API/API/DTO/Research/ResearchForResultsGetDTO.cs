namespace API.DTO.Research
{
    public class ResearchForResultsGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? First { get; set; }
        public decimal? Second { get; set; }
        public decimal? Third { get; set; }
        public decimal? Final { get; set; }
    }
}
