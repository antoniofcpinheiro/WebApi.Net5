using System;

namespace Net5.Application.UsuarioUseCases.Response
{
    public class UsuarioResponse
    {
        public UsuarioResponse(){}
        public UsuarioResponse(string usuario)
        {
            Usuario = usuario;
        }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiraEm { get; set; }
        public bool Autenticado { get; set; }

    }
}
