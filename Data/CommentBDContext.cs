using Microsoft.EntityFrameworkCore;
using webAppCroosSS.Models;

namespace webAppCroosSS.Data
{
    public class CommentBDContext : DbContext
    {
        public CommentBDContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Comments> comment { get; set; }
    }
}
