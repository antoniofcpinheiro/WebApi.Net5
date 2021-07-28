using System.ComponentModel.DataAnnotations;

namespace Net5.Application.UsuarioUseCases.Request
{
    public class UsuarioRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
