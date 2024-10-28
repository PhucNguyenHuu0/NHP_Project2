using System.Web;
using System.Web.Mvc;

namespace NHPhuc_QuanLyBanHang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
