namespace APIREST_PlanningPocker.Models
{
    public class Votes
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CardID { get; set; }
        public int StoryID { get; set; }
    }
}