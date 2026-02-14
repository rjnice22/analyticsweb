using analyticsweb.Data;
using analyticsweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace analyticsweb.Pages.Datasets
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bound to the form 
        [BindProperty]
        public Dataset Dataset { get; set; } = new Dataset();

        public void OnGet()
        {
            // shows the empty form
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Server-side validation 
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the new dataset record
            _context.Datasets.Add(Dataset);
            await _context.SaveChangesAsync();

            // Return to the index page after saving
            return RedirectToPage("./Index");
        }
    }
}
