using Alura.Loja.Testes.ConsoleApp.Context;
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
            //GravarUsandoEntity();

            var pao = new Produto();
            pao.Nome = "Pão Francês";
            pao.PrecoUnitario = 0.40;
            pao.Unidade = "Unidade";
            pao.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = pao;
            compra.Preco = pao.PrecoUnitario * compra.Quantidade;

            //using (var contexto = new LojaContext())
            //{
            //    contexto.Compras.Add(compra);
            //    contexto.SaveChanges();
            //}
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
