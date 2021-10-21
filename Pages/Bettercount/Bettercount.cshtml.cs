using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bettercount.Pages.Bettercount
{
    public class BettercountModel : PageModel
    {
        
        public string Uid;
        public void OnGet(string uid)
        {
            this.Uid = uid;
        }
    }
}