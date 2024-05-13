# Objetivo
Desenvolver um programa de agenda de tarefas com operações de CRUD (Create, Read,
Update, Delete), seguindo as especificações detalhadas abaixo.
## Especificações Técnicas
Campos Essenciais
O programa deve incluir os seguintes campos para cada tarefa:
- Título da Tarefa: Nome da tarefa.
- Descrição da Tarefa: Detalhes sobre a tarefa.
- Data: Data em que a tarefa está agendada.
- Hora de Início: Horário de início da tarefa.
- Hora de Fim: Horário de conclusão da tarefa.
- Prioridade: Nível de importância da tarefa (alta, média, baixa).
- Tarefa Finalizada?: Indicador se a tarefa foi ou não concluída.
  
## Páginas Requeridas
O sistema deve contar com as seguintes páginas:
1. Listagem de Tarefas Cadastradas: Exibe todas as tarefas agendadas.
2. Inclusão / Edição de Tarefa: Permite adicionar novas tarefas ou editar tarefas
existentes.
3. Análise de Tarefas: Apresenta estatísticas sobre as tarefas, incluindo:
    - Total de horas por dia.
    - Total de tarefas por dia.
    - Média de horas por dia.
    - Percentual das tarefas concluídas, considerando o tempo (soma das tarefas
concluídas dividido pela soma das tarefas do dia).
Esta página deve também oferecer um filtro por intervalo de datas.

## Regras de Cadastro
- Todos os campos são obrigatórios.
- Não é permitido o cadastramento de tarefas com início no passado.
- Não é permitido o cadastramento de tarefas com horários sobrepostos.
- O tempo máximo permitido para a duração de uma tarefa é de 5 horas.

## Tecnologias a Serem Utilizadas
- Framework: Asp.net MVC ou Blazor.
- Versão do .NET: .NET Core 6 ou .NET 8.
- Banco de Dados: SQL (MariaDB, MySQL, PostgreSQL, ou preferencialmente SQL
Server).
- Para avaliação, pode executar com PHP 8.
  
## Restrições
- Não utilizar ferramentas de geração de código automático (Scaffolding), para
avaliação do conhecimento prático.

## Repositório e Documentação
- O projeto deve ser disponibilizado em um repositório público utilizando Git
(GitHub, GitLab ou Bitbucket).
- Incluir todas as instruções necessárias para executar o projeto no
arquivo Readme.md.
- Se possível, incluir instruções para a geração de um container Docker.

##Tempo Estimado e Prazo de Entrega
- Tempo estimado: 12 horas
- Prazo de Entrega: 2 dias