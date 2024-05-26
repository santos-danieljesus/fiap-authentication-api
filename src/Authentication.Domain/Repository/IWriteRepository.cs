namespace Authentication.Domain.Repository
{
    public interface IWriteRepository
    {
        void RegisterUser();
        void UpdateUser();
        void DeleteUser();
    }
}