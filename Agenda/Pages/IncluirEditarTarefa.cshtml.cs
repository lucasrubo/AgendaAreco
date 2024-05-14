using System;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages
{
    public class IncluirEditarTarefaModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IncluirEditarTarefaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agenda.Data.Tarefa Tarefa { get; set; } // Certifique-se de que est� referenciando o tipo correto de Tarefa

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                // Criar um novo item se nenhum ID for fornecido
                Tarefa = new Agenda.Data.Tarefa();
            }
            else
            {
                // Carregar o item existente com o ID fornecido
                Tarefa = await _context.Tarefas.FindAsync(id);
                if (Tarefa == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {    
                // Examine ModelState para encontrar os erros de valida��o
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Exiba os erros no console ou no log para diagnosticar
                    Console.WriteLine(error.ErrorMessage);
                }

                return Page();
            }

            // Verificar se os hor�rios est�o sobrepostos
            if (HorariosSobrepostos(Tarefa) == true)
            {
                ModelState.AddModelError(string.Empty, "J� existe uma tarefa cadastrada com hor�rio sobreposto.");
                return Page();
            }

            // Verificar se a dura��o excede 5 horas
            TimeSpan duracao = Tarefa.HoraFim - Tarefa.HoraInicio;
            if (duracao.TotalHours > 5)
            {
                ModelState.AddModelError(string.Empty, "A dura��o m�xima permitida para uma tarefa � de 5 horas.");
                return Page();
            }

            var existingTarefa = await _context.Tarefas.FindAsync(Tarefa.Id);
            if (existingTarefa != null)
            {
                _context.Entry(existingTarefa).CurrentValues.SetValues(Tarefa);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Adicionar novo item se o ID for zero
                _context.Tarefas.Add(Tarefa);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./ListagemTarefas");
        }

        // Verifica se h� sobreposi��o de hor�rios entre a nova tarefa e as tarefas existentes no mesmo dia
        public bool HorariosSobrepostos(Agenda.Data.Tarefa novaTarefa)
        {
            var tarefasNoMesmoDia = _context.Tarefas
                .Where(t => t.Data.Date == novaTarefa.Data.Date)
                .ToList();

            foreach (var tarefaExistente in tarefasNoMesmoDia)
            {
                if (novaTarefa.Id != tarefaExistente.Id)
                {
                    if ((novaTarefa.Data == tarefaExistente.Data && novaTarefa.HoraInicio >= tarefaExistente.HoraInicio && novaTarefa.HoraInicio < tarefaExistente.HoraFim) ||
                        (novaTarefa.Data == tarefaExistente.Data && novaTarefa.HoraFim > tarefaExistente.HoraInicio && novaTarefa.HoraFim <= tarefaExistente.HoraFim))
                    {
                        return true; // Sobreposi��o de hor�rios detectada
                    }
                }
            }

            return false; // N�o h� sobreposi��o de hor�rios
        }
    }
}
