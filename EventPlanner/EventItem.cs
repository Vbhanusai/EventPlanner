namespace EventPlanner
{
    public class EventItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public System.DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
