using Microsoft.EntityFrameworkCore;

namespace superprojeto.Models
{
    public class ProdutoContext : DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder option){
            option.UseSqlite("Filename=./superbanco.db");
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}