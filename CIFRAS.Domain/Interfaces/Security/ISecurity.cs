namespace CIFRAS.Domain.Interfaces.Security
{
    public interface ISecurity
    {
        int UserId();
        void LogIn(int userId, bool keepLogged);
        void Logout();
    }
}
