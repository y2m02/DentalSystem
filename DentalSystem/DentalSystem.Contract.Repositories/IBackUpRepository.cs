namespace DentalSystem.Contract.Repositories
{
    public interface IBackUpRepository
    {
        void CreateBackUp(string path, string sqlServerName);
    }
}