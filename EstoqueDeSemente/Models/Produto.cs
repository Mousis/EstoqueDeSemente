using System.ComponentModel.DataAnnotations;

namespace EstoqueDeSemente.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha a data de vencimento")]
        public DateTime? DataDeVencimento { get; set; }
        [Required(ErrorMessage = "Preencha o nome do Fornecedor")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Preencha a Quantidade de produto")]
        public int QuantidadeDeProduto { get; set; }
    }
}
