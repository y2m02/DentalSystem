namespace DentalSystem.Entities.Results.User
{
    public class GetUserByUserIdResult
    {
        public GetUserByUserIdResultModel UserModel { get; set; }
    }

    public class GetUserByUserIdResultModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string IdentificationCard { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}