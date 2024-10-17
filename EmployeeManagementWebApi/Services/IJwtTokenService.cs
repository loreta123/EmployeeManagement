namespace EmployeeManagementWebApi.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userId, string userRole);
    }
}
