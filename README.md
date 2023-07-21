# desafio-tech-parana-banco
Segue abaixo as instruções para realização da atividade:

O objetivo construir uma WebApi desenvolvida em .net 6.0 para efetuar o registro de clientes que deverão informar o nome completo, e-mail e uma lista de telefones para receber informações.

Para isso você deverá aplicar o conceito de CRUD:

a. Create;
b. Read;
c. Update;
d. Delete.

Você deverá entregar uma WebApi que tenha as seguintes funções:

1. Cadastrar o cliente informando o nome completo, e-mail e uma lista de telefones informando o DDD, número e o tipo [fixo ou celular];
2. Permitir consultar todos os clientes com seus respectivos e-mails e telefones;
3. Permitir a consulta de um cliente através do DDD e número;
4. Permitir a atualização do e-mail do cliente cadastrado;
5. Permitir a atualização do telefone do cliente cadastrado;
6. Permitir a exclusão de um cliente através do e-mail.

Requisitos técnicos:

1- Desenvolver em .Net 6.0;
2- Utilizar base de dados local;
3- Criar testes de unidade;
4- Documentar a WebApi via Swagger.


## Pré-Requisitos
- SQL Server
- .Net 6

## Docker Compose
- Caso queira usar o [Docker](https://www.docker.com/products/docker-desktop/)
- docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d 

Na raiz do projeto registroClientes.API