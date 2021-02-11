using Alura.Loja.Testes.ConsoleApp.Models;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; set; }

        // EF: NxN
        // aqui deve declarar uma lista de Promocoes 
        // e na classe de Promocao uma lista de Produtos

        // substituir a propriedade abaixo para essa nova classe de join
        //public virtual IList<Promocao> Promocoes { get; set; }
        public IList<PromocaoProduto> Promocoes { get; internal set; }

        public IList<Compra> Compras { get; set; }

        public override string ToString()
        {
            return $"Produto: {Id}, {Nome}, {Categoria}, {PrecoUnitario}";
        }
    }
}