# GerenciadorDeCursos
Um projeto web API em .NET CORE6 criado para gerenciar um curso de idiomas utilizando entity framework na abordagem code-first e arquitetura DDD com MVC.

Para rodar o projeto inicialmente precisa criar a base de dados faça os seguintes passos com o SQL SERVER INSTALADO e a String de conexão configurada no arquivo appsettings.json
Abra o console do gerenciador nugget e digite:
1- add-migration inicial -p GerenciadorDeCurso.Infraestructure -s GerenciadorDeCurso.WebAPI
2- update-database

Feito isso a base de dados estará criada e pronta para ser executada.
