namespace MyWebServer
{
    public class MethodDetail
    {
        public string GetMethod(string httptype, string method)
        {
            foreach (var prop in typeof(RouteOperations).GetMethods())
            {
                var attrs = (MethodAttribute[])prop.GetCustomAttributes
                    (typeof(MethodAttribute), false);
                foreach (var attr in attrs)
                {

                    if (attr.Type == httptype && method == attr.Method)
                        return prop.Name;
                }
            }
            return "No Such Method";
        }
    }
}
