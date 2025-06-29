using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Beneficiário
    /// </summary>
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "CPF em formato inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome do beneficiário é obrigatório")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "ID do cliente é obrigatório")]
        public long IdCliente { get; set; }
    }
}
