using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace EmployeeDirectoryProj.Filter
{
    public class Fliters : System.Web.Mvc.AuthorizeAttribute
    {
        public class CustomAuthorizeAttribute : System.Web.Mvc.ActionFilterAttribute, IAuthenticationFilter
        {
            public void OnAuthentication(AuthenticationContext filterContext)
            {
                
            }
            public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
            {
                throw new NotImplementedException();
            }
        }


    }
}
