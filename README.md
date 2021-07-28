# WebApi.Net5
Api demo para validação e geração de senhas, desenvolvida em .Net 5

# Pré-requisitos
[Sdk dotnet 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

# Informações importantes
Linguagem: C#

Versão: .Net 5

Ambiente de Execução: Possível executar em Docker e Kestrel

Autenticação da API: Token JWT

IDE: Visual Studio ou VS Code

Documentação : Swagger

Nuget adicionais : 

    Microsoft.AspNetCore.Authentication
  
    Microsoft.AspNetCore.Authentication.JwtBearer
    
    Swashbuckle.AspNetCore.Swagger
  
    Moq
    
Testes de unidade : 
    Desenvolvido em Xunit  

# UsuarioController 

* ValidarUsuario() - Tem o objetivo de retornar o token de autenticação para os métodos GerarSenha e ValidarSenha.
Este método não exige autenticação.

  Parâmetros de Entrada: usuário e senha

  Parâmetros de Saída: usuário, autenticado (True/False), token e data de expiração do Token

* GerarSenha () - Tem o objetivo de criar uma senha, levando em consideração as mesmas
regras descritas no Método 2.

   Parâmetros de Entrada: nenhum.

   Parâmetros de Saída: senha válida criada.


* ValidarSenha() - Tem o objetivo de validar se determinada senha é válida de acordo com as
regras abaixo:
   Conter no mínimo 15 caracteres.

   No mínimo uma letra maiúscula.

   No mínimo uma letra minúscula.

   No mínimo um dos seguintes caracteres especiais: (@,#,_,- e !).

   Não poder ter caracteres repetidos em sequência, por exemplo: 1111, aaaa, bbbb, @@@@, BBBB.

   Prever case-sensitive, por exemplo: A é diferente de a.

   Parâmetros de Entrada: senha a ser validada.

   Parâmetros de Saída: senha válida (True/False).
  
  

