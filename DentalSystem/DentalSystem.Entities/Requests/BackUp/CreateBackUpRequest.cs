namespace DentalSystem.Entities.Requests.BackUp
{
    public class CreateBackUpRequest
    {
        public string Path { get; set; }
        public string SqlServerName { get; set; }
    }
}