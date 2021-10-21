using Bettercount.Entities.Dispatchers;
using Bettercount.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bettercount.Pages;

public class IndexModel : PageModel
{
    public IEnumerable<BettercountPreviewEntity> Bettercounts;
    private readonly ILogger<IndexModel> _logger;
    private readonly IBettercountDispatcher _bettercountDispatcher;
    public IndexModel(ILogger<IndexModel> logger, IBettercountDispatcher bettercountDispatcher)
    {
        _logger = logger;
        _bettercountDispatcher = bettercountDispatcher;
    }
    
    public void OnGet()
    {
        Bettercounts = _bettercountDispatcher.GetSubscribedBettercountsByUserId("aaab2") 
                        ?? Enumerable.Empty<BettercountPreviewEntity>();
    }
}
