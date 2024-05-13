using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages
{
    public class ListagemTarefasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ListagemTarefasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Agenda.Data.Tarefa> Tarefas { get; set; }


        public async Task OnGetAsync()
        {
            Tarefas = await _context.Tarefas
                                    .OrderBy(t => t.TarefaFinalizada) // Ordenando por tarefa Crescente
                                    .ThenByDescending(t => t.Data) // Ordenando por data decrescente
                                    .ThenByDescending(t => t.HoraInicio) // Ordenando por horário de início decrescente
                                    .ThenByDescending(t => t.HoraFim) // Em caso de empate, ordenar por horário de término decrescente
                                    .ToListAsync();
        }

        public async Task<IActionResult> OnGetExcluirTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetFinalizarTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            // Marcar a tarefa como finalizada
            tarefa.TarefaFinalizada = true;

            await _context.SaveChangesAsync();


            return RedirectToPage();
        }
    }
}
