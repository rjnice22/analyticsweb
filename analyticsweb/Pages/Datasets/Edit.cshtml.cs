using analyticsweb.Data;
using analyticsweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace analyticsweb.Pages.Datasets
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Keeps the user on the same filtered results when returning to Index
        [BindProperty(SupportsGet = true)]
        public string? Q { get; set; }

        // Bound to the form fields
        [BindProperty]
        public Dataset Dataset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Load the dataset the user wants to edit
            var dataset = await _context.Datasets.FirstOrDefaultAsync(d => d.Id == id);

            if (dataset == null)
            {
                return NotFound();
            }

            Dataset = dataset;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate inputs based on data annotations
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Attach and mark as modified so EF updates the record
            _context.Attach(Dataset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If record was deleted by someone else, return 404
                bool exists = await _context.Datasets.AnyAsync(d => d.Id == Dataset.Id);
                if (!exists)
                {
                    return NotFound();
                }
                throw;
            }

            // Redirect back to the search/list page and preserve the search term
            return RedirectToPage("./Index", new { q = Q });
        }
    }
}