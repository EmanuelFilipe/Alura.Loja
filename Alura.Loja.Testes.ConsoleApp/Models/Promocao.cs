using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataFim { get; internal set; }

        // EF: NxN
        // aqui deve declarar uma lista de Produtos 
        // e na classe de Produtos uma lista de Promocao
        // precisa ser feito uma classe de join para o EF reconhecer esse relacionamento de NxN
        public IList<PromocaoProduto> Produtos { get; internal set; }


        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }
        public void IncluiProduto(Produto p)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = p });
        }
    }
}
