using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace KNK.Sample.MsGraph.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GraphServiceClient _graphServiceClient;

        public HomeController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _graphServiceClient.Groups.Request().Select(g => new { g.Id, g.GroupTypes, g.Members, g.MemberOf }).GetAsync();

            return Json(groups);
        }

        [HttpGet("groupId")]
        public async Task<IActionResult> Index(string groupId)
        {
            var groups = await _graphServiceClient.Groups[groupId].GetMemberGroups(true).Request().PostAsync();
            return Json(groups);
        }
    }
}
