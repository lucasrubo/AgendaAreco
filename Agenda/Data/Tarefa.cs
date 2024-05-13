using System;

namespace Agenda.Data
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Prioridade { get; set; }
        public bool TarefaFinalizada { get; set; }
    }

    public enum Prioridade
    {
        Baixa,
        Media,
        Alta
    }
}
