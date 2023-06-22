#CalculoCDB

Aplicação CalculoCDB para realizar cálculos de investimentos em CDB (Certificado de Depósito Bancário).

Padrões e Arquitetura
A aplicação CalculoCDB segue os seguintes padrões e arquitetura:

Arquitetura em Camadas: A aplicação segue uma abordagem de arquitetura em camadas, com separação clara de responsabilidades entre as diferentes camadas, como a camada de Apresentação/API, Camada de Aplicação, Camada de Domínio e Camada de Infraestrutura.

Padrão CQRS (Command Query Responsibility Segregation): O padrão CQRS é utilizado para separar as operações de leitura (queries) das operações de escrita (commands). Isso permite uma melhor modelagem e otimização das operações em cada contexto.

Padrão Mediator: O padrão Mediator é utilizado para facilitar a comunicação e o acoplamento fraco entre as diferentes partes do sistema. Ele permite que comandos e eventos sejam enviados e tratados por meio de um mediador central, tornando o código mais limpo e modular.

Padrão Repository: O padrão Repository é utilizado para abstrair a lógica de acesso a dados, permitindo que as operações de persistência sejam realizadas de forma desacoplada da lógica de negócio.

Injeção de Dependência: A aplicação utiliza a injeção de dependência para facilitar o gerenciamento e a configuração das dependências entre os diferentes componentes do sistema.

Entity Framework Core: O Entity Framework Core é utilizado como ORM (Object-Relational Mapping) para realizar a persistência dos dados no banco de dados.

SQLite (banco de dados em memória para fins de teste): Para os testes, a aplicação utiliza um banco de dados SQLite em memória, o que permite a execução dos testes de forma isolada e rápida.

Configuração e Execução
Para executar a aplicação CalculoCDB, siga as etapas abaixo:

Clone este repositório em sua máquina local.

Abra o projeto da aplicação em seu ambiente de desenvolvimento preferido.

Verifique se você possui o .NET SDK instalado. A aplicação requer o .NET 5. Se necessário, faça o download e instale o .NET 5 a partir do site oficial da Microsoft.

Abra o arquivo appsettings.json na pasta CalculoCDB.API e configure a string de conexão com o banco de dados.

Execute o comando dotnet run no diretório raiz da aplicação (CalculoCDB.API) para iniciar a aplicação.

Acesse a API em http://localhost:5000 (ou na porta configurada) para realizar as requisições.

Testes
A aplicação CalculoCDB possui testes automatizados para garantir a qualidade e a funcionalidade do código. Para executar os testes, siga as etapas abaixo:

Certifique-se de ter executado as etapas de configuração descritas acima.

Execute o comando dotnet test no diretório raiz da aplicação (CalculoCDB.Tests) para iniciar a execução dos testes.

Os resultados dos testes serão exibidos no console.

Contribuição
Contribuições para aprimorar a aplicação CalculoCDB são bem-vindas! Se você encontrar algum problema, tiver ideias de novos recursos ou quiser fazer melhorias no código, fique à vontade para abrir uma issue ou enviar uma pull request.

Licença
Esta aplicação está licenciada sob a MIT License.