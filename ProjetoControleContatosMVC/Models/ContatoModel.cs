using System.ComponentModel.DataAnnotations;

namespace ProjetoControleContatosMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")] 
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set;}

        public int? UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
