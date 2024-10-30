namespace TrackingEntitiesEventsDemo.Services;

public interface IUserService
{
    public string GetCurrentUser();
}

public class UserService : IUserService
{
    public string GetCurrentUser()
    {
        return "user@domain.com";
    }
}
