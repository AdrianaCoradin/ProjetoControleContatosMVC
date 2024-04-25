using System.ComponentModel.DataAnnotations;

namespace ProjetoControleContatosMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite e-mail")]
        public string Email { get; set; }

    }
}
