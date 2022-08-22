using Microsoft.AspNetCore.Mvc;

namespace website_backend.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class BackendUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public BackendUser(int userId, string userName, string firstName, string lastName)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;


            }

        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password
                );
            if (user == null)
            {
                return Unauthorized();
            }
            return null;
        }

        private object ValidateUserCredentials(string? userName, string? password)
        {
            return new BackendUser(
                1,
                userName ?? "",
                "Daniel",
                "monk"
                );
        }
    }
}
