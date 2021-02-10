using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Models
{
    public class PromocaoProduto
    {
        //Vai precisar implementar uma chave primária composta no DbContext
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
