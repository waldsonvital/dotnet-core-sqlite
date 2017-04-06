using Microsoft.AspNetCore.Mvc;
using superprojeto.Models;
using System.Linq;
using System.Collections.Generic;

namespace superprojeto.Controllers
{
    [RouteAttribute("api")]
    public class HomeController : Controller
    {
        private ProdutoContext DB { get; set; }
        public HomeController([FromServicesAttribute] ProdutoContext DB){
            this.DB = DB;
        }


        // retona todos os produto
        [HttpGetAttribute]
        public IEnumerable<Produto> Index(){
            var lista = new List<Produto>();
            
            foreach (var item in DB.Produtos)
            {
                lista.Add(item);
            }

            return lista;
        }
        
        // retorno o produto de um id expecifico
        [HttpGetAttribute("{id}")]
        public Produto getById(int id){
            Produto produto;

            produto = DB.Produtos.First(item => item.id == id);

            return produto;
        }

        // insere um produto
        [HttpPostAttribute]
        public IActionResult Insert([FromBodyAttribute] Produto produto){
            if(ModelState.IsValid){
                DB.Produtos.Add(produto);
                DB.SaveChanges();
                return Ok();
            }else{
                return BadRequest(ModelState);
            }
        }

        // atualiza um produto
        [HttpPutAttribute("{id}")]
        public IActionResult update(int id, [FromBodyAttribute] Produto produto){
            if(ModelState.IsValid){
                var itemUpdate = DB.Produtos.Where(item => item.id == id).FirstOrDefault();

                itemUpdate.nome = produto.nome;
                DB.SaveChanges();
            }else{
                return BadRequest(ModelState);
            }
            return Ok();
        }

        // deleta um produto
        [HttpDeleteAttribute("{id}")]
        public IActionResult delete(int id){
            var itemDelete = DB.Produtos.Where(item => item.id == id).FirstOrDefault();
            DB.Produtos.Remove(itemDelete);
            DB.SaveChanges();
            return Ok();
        }
    }
}