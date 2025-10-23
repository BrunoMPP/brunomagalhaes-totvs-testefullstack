using System.ComponentModel.DataAnnotations;

namespace Totvs.TesteFullStack.API.Entities
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

    }
}
