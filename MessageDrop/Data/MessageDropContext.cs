using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessageDrop.Models;

namespace MessageDrop.Data
{
    public class MessageDropContext : DbContext
    {
        public MessageDropContext (DbContextOptions<MessageDropContext> options)
            : base(options)
        {
        }

        public DbSet<MessageDrop.Models.Message> Message { get; set; }
    }
}
