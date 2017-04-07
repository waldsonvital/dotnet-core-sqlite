using Microsoft.AspNetCore.Mvc;
using superprojeto.Models;
using System.Linq;
using System.Collections.Generic;

namespace superprojeto.Controllers
{
    [RouteAttribute("api")]
    public class HomeController : Controller
    {
        public ProdutoContext db { get; set; }
        public HomeController([FromServicesAttribute]ProdutoContext db){
            this.db = db;
        }
        // retona todos os produto
        [HttpGetAttribute]
        public IEnumerable<Produto> Index(){
            var lista = new List<Produto>();
            
            foreach (var item in db.Produtos)
            {
                lista.Add(item);
            }

            return lista;
        }
        
        // retorno o produto de um id expecifico
        [HttpGetAttribute("{id}")]
        public Produto getById(int id){
           Produto produto;

            produto = db.Produtos.First(item => item.id == id);

           return produto;
        }

        // insere um produto
        [HttpPostAttribute]
        public IActionResult Insert([FromBodyAttribute] Produto produto){
            if(ModelState.IsValid){
                db.Produtos.Add(produto);
                db.SaveChanges();
            }else{
                return BadRequest(ModelState);
            }
            return Ok();
        }

        // atualiza um produto
        [HttpPutAttribute("{id}")]
        public IActionResult update(int id, [FromBodyAttribute] Produto produto){
            var itemUpdate = db.Produtos.Where(item => item.id == id).FirstOrDefault();

            itemUpdate.nome = produto.nome;
            db.SaveChanges();
            return Ok();
        }

        // deleta um produto
        [HttpDeleteAttribute("{id}")]
        public IActionResult delete(int id){
            var itemDelete = db.Produtos.Where(item => item.id == id).FirstOrDefault();
            db.Produtos.Remove(itemDelete);
            db.SaveChanges();
            return Ok();
        }
    }
}