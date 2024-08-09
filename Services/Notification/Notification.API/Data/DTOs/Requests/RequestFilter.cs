namespace notification.API.Data.DTOs.Requests
{
    public class RequestFilter
    {
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
