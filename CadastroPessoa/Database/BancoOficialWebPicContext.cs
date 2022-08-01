using CadastroPessoa.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Database
{
    public class BancoOficialWebPicContext : DbContext
    {
        public BancoOficialWebPicContext(DbContextOptions<BancoOficialWebPicContext> opt) : base(opt)   
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
