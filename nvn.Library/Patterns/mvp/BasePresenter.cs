using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web;
//using System.Web.Caching;
//using System.Web.Routing;

namespace nvn.Library.Patterns.MVP
{
    public abstract class BasePresenter<V> where V : IBaseView
    {
        protected virtual V view { get; set; }

        public BasePresenter(V view)
        {
            this.view = view;
        }

        //public HttpContextBase HttpContext { get; set; }

        ///// <summary>
        ///// Gets the <see cref="HttpRequestBase"/> object for the current HTTP request.
        ///// </summary>
        //public HttpRequestBase Request { get { return HttpContext.Request; } }

        ///// <summary>
        ///// Gets the <see cref="HttpResponseBase"/> object for the current HTTP request.
        ///// </summary>
        //public HttpResponseBase Response { get { return HttpContext.Response; } }

        ///// <summary>
        ///// Gets the <see cref="HttpServerUtilityBase"/> object that provides methods that are used during Web request processing.
        ///// </summary>
        //public HttpServerUtilityBase Server { get { return HttpContext.Server; } }

        ///// <summary>
        ///// Gets the cache object for the current web application domain.
        ///// </summary>
        //public Cache Cache { get { return HttpContext.Cache; } }

        ///// <summary>
        ///// Gets the route data for the current request.
        ///// </summary>
        //public RouteData RouteData { get { return RouteTable.Routes.GetRouteData(HttpContext); } }
    }
}
