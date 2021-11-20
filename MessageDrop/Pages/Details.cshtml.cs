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
    public class DetailsModel : PageModel
    {
        private readonly MessageDrop.Data.MessageDropContext _context;

        public DetailsModel(MessageDrop.Data.MessageDropContext context)
        {
            _context = context;
        }

        public Message Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Message = await _context.Message.FirstOrDefaultAsync(m => m.ID == id);

            if (Message == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
