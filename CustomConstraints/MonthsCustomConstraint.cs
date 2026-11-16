using System.Text.RegularExpressions;

namespace HarshaASP.CustomConstraints
{
    //Eg: sales-report/2040/apr
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection
        )
        {
            //{ month: regex(^(apr | jul | oct | jan)$)}
            if (!values.ContainsKey(routeKey)) //month
            {
                return false;
            }

            Regex regex = new Regex($"^(apr | jul | oct | jan)$");

            string? monthValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthValue))
            {
                return true;
            }

            return false;
        }
    }
}
