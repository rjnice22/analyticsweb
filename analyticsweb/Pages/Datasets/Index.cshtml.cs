using analyticsweb.Data;
using analyticsweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace analyticsweb.Pages.Datasets
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Results to display on the page
        public IList<Dataset> Datasets { get; set; } = new List<Dataset>();

        // The user’s search input from the query string 
        [BindProperty(SupportsGet = true)]
        public string? Q { get; set; }

        public async Task OnGetAsync()
        {
            //  Looks through all datasets in the beginiing 
            IQueryable<Dataset> query = _context.Datasets;

            // If the user typed something, filter results
            if (!string.IsNullOrWhiteSpace(Q))
            {
                // Allow wildcard: user types * and we convert to SQL wildcard %
                // Examples:
                //   roof*     -> roof%
                //   *clean*   -> %clean%
                // If the user does NOT include *, we default to "contains" search by wrapping with %...%
                string pattern = Q.Trim();

                if (pattern.Contains('*'))
                {
                    pattern = pattern.Replace('*', '%');
                }
                else
                {
                    pattern = $"%{pattern}%";
                }

                // Allows filter by Name OR Description
                query = query.Where(d =>
                    EF.Functions.Like(d.Name, pattern) ||
                    (d.Description != null && EF.Functions.Like(d.Description, pattern))
                );
            }

            // Execute the query and load results
            Datasets = await query
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }
    }
}
