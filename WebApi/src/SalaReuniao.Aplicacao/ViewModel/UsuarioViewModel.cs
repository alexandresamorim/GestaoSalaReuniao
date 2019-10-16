using System;
using System.Text.RegularExpressions;

namespace SalaReuniao.Aplicacao.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            UsuarioId = Guid.NewGuid();
        }
        public Guid UsuarioId { get; set; }
        public string AccessKey { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Fone { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public string Facebook { get; set; }
        public string LoggedOn { get; set; }
        public string[] Roles { get; set; }
        public bool IsValid => ValidaUsuario();

        private bool ValidaUsuario()
        {
            if (string.IsNullOrEmpty(Email)) return false;

            var emailValid = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return emailValid.IsMatch(Email);
        }
    }
}