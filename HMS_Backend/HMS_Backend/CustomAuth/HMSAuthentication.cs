using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HMS_Backend.CustomAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class HMSAuthentication : AuthorizationFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public HMSAuthentication()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);

            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers
                                            .Authorization.Parameter;
                if (HotelAuth.Login(authenticationToken))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(authenticationToken), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}