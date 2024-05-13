using System;

public class Tarefa
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public string Prioridade { get; set; }
    public bool TarefaFinalizada { get; set; }
    public int Id { get; internal set; }

    public static implicit operator Tarefa?(Agenda.Data.Tarefa? v)
    {
        throw new NotImplementedException();
    }
}
