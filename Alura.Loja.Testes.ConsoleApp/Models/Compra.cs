namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Compra
    {
        //PK
        public int Id { get; set; }
        public int Quantidade { get; internal set; }

        public double Preco { get; internal set; }

        // EF: 1x1
        // Classe "Compra" pode ter ""UM"" "Produto"
        // nao precisa configurar nada na classe Produto referente a "Compra"
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
    }
}