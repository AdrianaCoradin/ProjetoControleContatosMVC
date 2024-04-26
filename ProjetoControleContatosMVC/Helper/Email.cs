using Microsoft.Extensions.Configuration;

namespace ProjetoControleContatosMVC.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<string>("SMTP:Porta");

            }
            catch(System.Exception ex) 
            { 
                // Gravar log de erro ao enviar email
                return false;
            }
        }
    }
}
