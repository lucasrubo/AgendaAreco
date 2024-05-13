# Objetivo
Desenvolver um programa de agenda de tarefas com opera��es de CRUD (Create, Read,
Update, Delete), seguindo as especifica��es detalhadas abaixo.
## Especifica��es T�cnicas
Campos Essenciais
O programa deve incluir os seguintes campos para cada tarefa:
- T�tulo da Tarefa: Nome da tarefa.
- Descri��o da Tarefa: Detalhes sobre a tarefa.
- Data: Data em que a tarefa est� agendada.
- Hora de In�cio: Hor�rio de in�cio da tarefa.
- Hora de Fim: Hor�rio de conclus�o da tarefa.
- Prioridade: N�vel de import�ncia da tarefa (alta, m�dia, baixa).
- Tarefa Finalizada?: Indicador se a tarefa foi ou n�o conclu�da.
  
## P�ginas Requeridas
O sistema deve contar com as seguintes p�ginas:
1. Listagem de Tarefas Cadastradas: Exibe todas as tarefas agendadas.
2. Inclus�o / Edi��o de Tarefa: Permite adicionar novas tarefas ou editar tarefas
existentes.
3. An�lise de Tarefas: Apresenta estat�sticas sobre as tarefas, incluindo:
    - Total de horas por dia.
    - Total de tarefas por dia.
    - M�dia de horas por dia.
    - Percentual das tarefas conclu�das, considerando o tempo (soma das tarefas
conclu�das dividido pela soma das tarefas do dia).
Esta p�gina deve tamb�m oferecer um filtro por intervalo de datas.

## Regras de Cadastro
- Todos os campos s�o obrigat�rios.
- N�o � permitido o cadastramento de tarefas com in�cio no passado.
- N�o � permitido o cadastramento de tarefas com hor�rios sobrepostos.
- O tempo m�ximo permitido para a dura��o de uma tarefa � de 5 horas.

## Tecnologias a Serem Utilizadas
- Framework: Asp.net MVC ou Blazor.
- Vers�o do .NET: .NET Core 6 ou .NET 8.
- Banco de Dados: SQL (MariaDB, MySQL, PostgreSQL, ou preferencialmente SQL
Server).
- Para avalia��o, pode executar com PHP 8.
  
## Restri��es
- N�o utilizar ferramentas de gera��o de c�digo autom�tico (Scaffolding), para
avalia��o do conhecimento pr�tico.

## Reposit�rio e Documenta��o
- O projeto deve ser disponibilizado em um reposit�rio p�blico utilizando Git
(GitHub, GitLab ou Bitbucket).
- Incluir todas as instru��es necess�rias para executar o projeto no
arquivo Readme.md.
- Se poss�vel, incluir instru��es para a gera��o de um container Docker.

##Tempo Estimado e Prazo de Entrega
- Tempo estimado: 12 horas
- Prazo de Entrega: 2 dias