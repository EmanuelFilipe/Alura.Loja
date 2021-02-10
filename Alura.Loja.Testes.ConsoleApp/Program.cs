using Alura.Loja.Testes.ConsoleApp.Context;
using Alura.Loja.Testes.ConsoleApp.Models;
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
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.99, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.99, Unidade = "Gramas" };

            var promo = new Promocao();
            promo.Descricao = "Páscoa Feliz";
            promo.DataInicio = DateTime.Now;
            promo.DataFim = DateTime.Now.AddMonths(3);
            promo.IncluiProduto(p1);
            promo.IncluiProduto(p2);
            promo.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                contexto.Promocoes.Add(promo);
                contexto.SaveChanges();
            }
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
            p.PrecoUnitario = 19.89;

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
