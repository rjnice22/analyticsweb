using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleAnalyticsWeb.Pages.Datasets
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
