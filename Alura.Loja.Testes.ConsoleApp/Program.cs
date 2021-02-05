using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //GravarUsandoAdoNet();
      GravarUsandoEntity();
    }

    private static void AtualizarProduto()
    {

      using (var repo = new ProdutoDAOEntity())
      {
        Produto primeiro = repo.Produtos().First();
        primeiro.Nome = "Cassino Royale - Editado";
        repo.Atualizar(primeiro);
      }
    }
    private static void GravarUsandoEntity()
    {
      Produto p = new Produto();
      p.Nome = "Cassino Royale";
      p.Categoria = "Filmes";
      p.Preco = 19.89;

      using (var repo = new ProdutoDAOEntity())
      {
        repo.Adicionar(p);
      }
    }

    private static void ExcluirProduto()
    {
      using (var repo = new ProdutoDAOEntity())
      {
        IList<Produto> produtos = repo.Produtos().ToList();
        foreach (var item in produtos)
        {
          repo.Remover(item);
        }
      }
    }

    private static void RecuperarProdutos()
    {
      using (var repo = new ProdutoDAOEntity())
      {
        IList<Produto> produtos = repo.Produtos().ToList();
        Console.WriteLine($"Foram econtrados {produtos.Count} produtos(s)");

        foreach (var item in produtos)
        {
          Console.WriteLine(item.Nome);
        }
      }
    }
  }
}
