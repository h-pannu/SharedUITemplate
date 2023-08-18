using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Template.WebAPI.Data;

namespace Template.WebAPI.DBContext
{
    public class TemplateDBContext : IdentityDbContext<Users>
    {
        public TemplateDBContext(DbContextOptions<TemplateDBContext> options) : base(options)
        {
            
        }
    }
}
