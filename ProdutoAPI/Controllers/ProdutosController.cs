using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ProdutoAPI.Controllers
{
    /*
    Criação de um microsserviço para gestão de produtos (CRUD). 
    Um produto deve conter os seguintes campos: ID, Nome, Descrição, Categoria e Preço em Reais. 
    */

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
    };


    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private IMemoryCache _cacheProdutos;

        public ProdutosController(IMemoryCache memoryCache)
        {
            _cacheProdutos = memoryCache;

            Produto produtoTest = new Produto();
            produtoTest.Id = 1;
            produtoTest.Nome = "Produto 1";
            produtoTest.Descricao = "Descrição Produto 1";
            produtoTest.Categoria = "N/A";
            produtoTest.Preco = 99.99;
            _cacheProdutos.Set(produtoTest.Id, produtoTest);
        }

        // GET api/produtos
        [HttpGet]
        public JsonResult Get()
        {
            List<Produto> lstProdutos = new List<Produto>();

            var field = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var collection = field.GetValue(_cacheProdutos) as dynamic;
            if (collection != null)
            foreach (var item in collection)
            {
                var methodInfo = item.GetType().GetProperty("Key");
                var val = methodInfo.GetValue(item);

                Produto produto;
                if(_cacheProdutos.TryGetValue<Produto>((int)val, out produto))
                {
                    lstProdutos.Add(produto);
                }
            }

            return Json(lstProdutos);
        }

        // GET api/produtos/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Produto produto;
            if(_cacheProdutos.TryGetValue<Produto>(id, out produto))
            {
                return Json(produto);
            }
            else
                return Json(new object());
        }

        // POST api/produtos
        // EXEMPLO JSON:
        // {
        //      "id": 99,
        //      "nome": "Produto99",
        //      "descricao": "Descrição Produto99",
        //      "categoria": "N/A",
        //      "preco": 9.99
        // }
        [HttpPost]
        public ActionResult<string> Post(Produto produto)
        {
            Produto produtoFind;
            if(!_cacheProdutos.TryGetValue<Produto>(produto.Id, out produtoFind))
            {
                _cacheProdutos.Set(produto.Id, produto);
                return "Produto de Id = " + produto.Id.ToString() + " foi inserido com sucesso!";
            }

            return "Produto de Id = " + produto.Id.ToString() + " já existe!";
        }

        // PUT api/produtos/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, Produto produto)
        {
            Produto produtoFind;
            if(_cacheProdutos.TryGetValue<Produto>(id, out produtoFind))
            {
                produto.Id = id;
                _cacheProdutos.Set(produto.Id, produto);
                return "Produto de Id = " + id.ToString() + " foi atualizado com sucesso!";
            }

            return "Produto de Id = " + id.ToString() + " não existe!";
        }

        // DELETE api/produtos/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            Produto produtoFind;
            if(_cacheProdutos.TryGetValue<Produto>(id, out produtoFind))
            {
                _cacheProdutos.Remove(id);
                return "Produto Deletado com sucesso";
            }

            return "Produto de Id = " + id.ToString() + " não existe!";
        }
    }
}
