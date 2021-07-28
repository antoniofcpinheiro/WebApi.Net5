namespace Net5.Application.UsuarioUseCases.Response
{
    public class SenhaResponse
    {
        public SenhaResponse(bool valida)
        {
            SenhaValida = valida;
        }
        public bool SenhaValida { get; set; }
    }
}
