using analyticsweb.Data;
using analyticsweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace analyticsweb.Pages.Datasets
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Preserve search term when returning to Index
        [BindProperty(SupportsGet = true)]
        public string? Q { get; set; }

        public Dataset Dataset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var dataset = await _context.Datasets
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dataset == null)
            {
                return NotFound();
            }

            Dataset = dataset;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dataset = await _context.Datasets.FindAsync(id);

            if (dataset != null)
            {
                _context.Datasets.Remove(dataset);
                await _context.SaveChangesAsync();
            }

            // Return to Index and preserve search filter
            return RedirectToPage("./Index", new { q = Q });
        }
    }
}