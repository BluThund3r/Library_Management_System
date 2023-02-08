using Library_Management_System.Models;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_Management_System.Helpers.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> roles;

        public Authorization(params Role[] _roles)
        {
            roles = _roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new {Message = "Unauthorized"}){ StatusCode = StatusCodes.Status401Unauthorized};

            if(roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }

            var user = (UserInfoDTO)context.HttpContext.Items["User"];

            if (user == null || !roles.Contains(user.Role))
                context.Result = unauthorizedStatusObject;
        }
    }
}
