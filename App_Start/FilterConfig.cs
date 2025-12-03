using System.Web;
using System.Web.Mvc;

namespace MvcMovie2.App_Start  // 프로젝트명.App_Start 형식으로 맞춥니다.
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // 에러가 발생했을 때 사용자에게 친숙한 에러 페이지를 보여주는 필터입니다.
            filters.Add(new HandleErrorAttribute());
        }
    }
}