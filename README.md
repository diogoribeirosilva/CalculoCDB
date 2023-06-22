# CalculoCDB

Aplicação CalculoCDB para realizar cálculos de investimentos em CDB (Certificado de Depósito Bancário).

## Backend

O backend da aplicação CalculoCDB é construído com .NET7 e fornece as APIs necessárias para realizar o cálculo de investimento em CDB.

### Configuração e Execução do Backend

Siga as etapas abaixo para configurar e executar o backend da aplicação CalculoCDB:

1. Certifique-se de ter o .NET SDK instalado em sua máquina. Você pode fazer o download do .NET SDK em https://dotnet.microsoft.com/download.

2. Abra uma janela de terminal e navegue até a pasta do backend (CalculoCDB.API).

3. Execute o comando `dotnet run` para iniciar o servidor.

4. O servidor será executado e estará disponível em https://localhost:5001.
Além disso, a aplicação CalculoCDB oferece uma documentação interativa com Swagger, que facilita a visualização e teste dos endpoints da API. Para acessar a documentação do Swagger, siga as etapas abaixo:

Certifique-se de que o servidor do backend esteja em execução.

Abra um navegador da web e acesse a URL https://localhost:5001/swagger.

A documentação do Swagger será exibida, mostrando todos os endpoints disponíveis, seus parâmetros e exemplos de uso.

Através da documentação do Swagger, você pode explorar os endpoints da API, enviar requisições e ver as respostas correspondentes, o que facilita o entendimento e teste da aplicação.

### Testes do Backend

A aplicação CalculoCDB possui testes automatizados para garantir a qualidade e a funcionalidade do código do backend. Para executar os testes, siga as etapas abaixo:

1. Certifique-se de ter concluído as etapas de configuração e instalação do .NET SDK descritas acima.

2. Abra uma janela de terminal e navegue até a pasta do backend (CalculoCDB.Tests).

3. Execute o comando `dotnet test` para iniciar a execução dos testes.

4. Os resultados dos testes serão exibidos no terminal.

### Uso da API
A API do backend da aplicação CalculoCDB oferece um endpoint para realizar o cálculo de investimento em CDB.

Endpoint: https://localhost:5001/api/Investimento

Método: POST

Corpo da Requisição (exemplo):

json
Copy code
{
  "valorInicial": 500,
  "prazoMeses": 5
}
Resposta (exemplo):

json
Copy code
{
  "valorBruto": 504.86,
  "valorLiquido": 391.2665,
  "valorInicial": 0,
  "prazoMeses": 0
}
O corpo da requisição deve incluir o valor inicial do investimento em "valorInicial" e o prazo em meses em "prazoMeses". A resposta incluirá o valor bruto do investimento em "valorBruto" e o valor líquido do investimento em "valorLiquido".

## Frontend

O frontend da aplicação CalculoCDB é uma interface de usuário construída com Angular. Ele permite que os usuários insiram os valores necessários para realizar o cálculo de investimento em CDB e exibe os resultados.

### Configuração e Execução do Frontend

Siga as etapas abaixo para configurar e executar o frontend da aplicação CalculoCDB:

1. Certifique-se de ter o Node.js instalado em sua máquina. Você pode fazer o download do Node.js em https://nodejs.org/.

2. Abra uma janela de terminal e navegue até a pasta do frontend (calculocdb-frontend).

3. Execute o comando `npm install` para instalar as dependências do projeto.

4. Após a conclusão da instalação das dependências, execute o comando `npm start` para iniciar o servidor de desenvolvimento.

5. O servidor de desenvolvimento será executado e o frontend estará disponível em http://localhost:4200.

### Testes do Frontend

A aplicação CalculoCDB possui testes automatizados para garantir a qualidade e a funcionalidade do código do frontend. Para executar os testes, siga as etapas abaixo:

1. Certifique-se de ter concluído as etapas de configuração e instalação das dependências descritas acima.

2. Abra uma janela de terminal e navegue até a pasta do frontend (calculocdb-frontend).

3. Execute o comando `npm test` para iniciar a execução dos testes.

4. Os resultados dos testes serão exibidos no terminal.

## Padrões e Arquitetura

A aplicação CalculoCDB segue os seguintes padrões e arquitetura:

MinimalAPI: A aplicação CalculoCDB utiliza o recurso Minimal API no .NET 7, que simplifica a construção de APIs eliminando a necessidade de configurar rotas, middlewares e outros componentes tradicionais do ASP.NET. Isso resulta em um código mais conciso e facilita o desenvolvimento e a manutenção da aplicação. Além disso, a abordagem Minimal API oferece um melhor desempenho, reduzindo o overhead e o processamento desnecessário.

Arquitetura em Camadas: A aplicação segue uma abordagem de arquitetura em camadas, com separação clara de responsabilidades entre as diferentes camadas, como a camada de Apresentação/API, Camada de Aplicação, Camada de Domínio e Camada de Infraestrutura.

Padrão CQRS (Command Query Responsibility Segregation): O padrão CQRS é utilizado para separar as operações de leitura (queries) das operações de escrita (commands). Isso permite uma melhor modelagem e otimização das operações em cada contexto.

Padrão Mediator: O padrão Mediator é utilizado para facilitar a comunicação e o acoplamento fraco entre as diferentes partes do sistema. Ele permite que comandos e eventos sejam enviados e tratados por meio de um mediador central, tornando o código mais limpo e modular.

Padrão Repository: O padrão Repository é utilizado para abstrair a lógica de acesso a dados, permitindo que as operações de persistência sejam realizadas de forma desacoplada da lógica de negócio.

Injeção de Dependência: A aplicação utiliza a injeção de dependência para facilitar o gerenciamento e a configuração das dependências entre os diferentes componentes do sistema.


## Contribuição

Contribuições para aprimorar a aplicação CalculoCDB são bem-vindas! Se você encontrar algum problema, tiver ideias de novos recursos ou quiser fazer melhorias no código, fique à vontade para abrir uma issue ou enviar uma pull request.

## Licença

Esta aplicação está licenciada sob a MIT License.
