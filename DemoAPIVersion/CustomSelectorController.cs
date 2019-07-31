using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace DemoAPIVersion
{
    public class CustomSelectorController : DefaultHttpControllerSelector
    {
        HttpConfiguration _config;
        public CustomSelectorController(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        //Web API Versioning using Custom Headers
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //returns all possible API Controllers
            var controllers = GetControllerMapping();
            //return the information about the route
            var routeData = request.GetRouteData();
            //get the controller name passed
            var controllerName = routeData.Values["controller"].ToString();
            string apiVersion = "1";
            //Custom Header Name to be check
            string customHeaderForVersion = "X-Employee-Version";
            if (request.Headers.Contains(customHeaderForVersion))
            {
                apiVersion = request.Headers.GetValues(customHeaderForVersion).FirstOrDefault();
                if (!string.IsNullOrEmpty(apiVersion) && apiVersion.Contains(","))
                {
                    apiVersion = apiVersion.Split(',')[0];
                }
            }

            if (apiVersion == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }
            //
            HttpControllerDescriptor controllerDescriptor;
            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }
    }
}