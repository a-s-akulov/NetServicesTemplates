using Microsoft.AspNetCore.Authorization;


namespace $safeprojectname$.Auth;


public class ApiAuthorizeAttribute : AuthorizeAttribute
{
    public ApiAuthorizeAttribute(params enAppAction[] actions)
    {
        Roles = string.Join(",", actions.Select(x => x.GetDescription()));
    }
}
