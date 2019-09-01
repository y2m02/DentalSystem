namespace DentalSystem.Entities.Results.AdminPassword
{
    public class GetAdminPasswordResult
    {
        public GetAdminPasswordResultModel AdminPassword { get; set; }
    }

    public class GetAdminPasswordResultModel
    {
        public int AdminPasswordId { get; set; }
        public string Password { get; set; }
    }
}