using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs
{
    public class FornecedorDTOs
    {
        [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Responsável é obrigatório.")]
        public string Responsavel { get; set; }
    }
}
