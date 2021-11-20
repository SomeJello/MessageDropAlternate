using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MessageDrop.Data;
using MessageDrop.Models;

namespace MessageDrop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MessageDrop.Data.MessageDropContext _context;

        public IndexModel(MessageDrop.Data.MessageDropContext context)
        {
            _context = context;
        }

        public IList<Message> Messages { get;set; }

        public async Task OnGetAsync()
        {
            Messages = await _context.Message.ToListAsync();
        }


        // Adding a message
        //
        [BindProperty]
        public Message Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
