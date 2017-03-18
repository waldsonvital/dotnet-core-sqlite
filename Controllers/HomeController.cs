using Microsoft.AspNetCore.Mvc;
using superprojeto.Models;
using System.Linq;
using System.Collections.Generic;

namespace superprojeto.Controllers
{
    [RouteAttribute("api")]
    public class HomeController : Controller
    {
        [HttpGetAttribute]
        public IEnumerable<Produto> Index(){
            var lista = new List<Produto>();
            
            using(var db = new ProdutoContext())
            {
                foreach (var item in db.Produtos)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }
        
        [HttpGetAttribute("{id}")]
        public Produto getById(int id){
           Produto produto;

           using(var db = new ProdutoContext())
           {
               produto = db.Produtos.First(item => item.id == id);
           }

           return produto;
        }

        [HttpPostAttribute]
        public IActionResult Insert([FromBodyAttribute] Produto produto){
            using(var db = new ProdutoContext())
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPutAttribute("{id}")]
        public IActionResult update(int id, [FromBodyAttribute] Produto produto){
            using(var db = new ProdutoContext())
            {
                var itemUpdate = db.Produtos.Where(item => item.id == id).FirstOrDefault();

                itemUpdate.nome = produto.nome;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDeleteAttribute("{id}")]
        public IActionResult delete(int id){
            using(var db = new ProdutoContext())
            {
                var itemDelete = db.Produtos.Where(item => item.id == id).FirstOrDefault();
                db.Produtos.Remove(itemDelete);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}