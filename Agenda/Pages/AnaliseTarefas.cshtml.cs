using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages
{
    public class AnaliseTarefasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AnaliseTarefasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime? DataInicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? DataFim { get; set; }

        public IList<EstatisticaTarefa> Estatisticas { get; set; }
        public async Task OnGetAsync()
        {
            if (DataInicio == null || DataFim == null)
            {
                // Defina os valores padrão para data de início e fim (por exemplo, o mês atual)
                DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DataFim = DataInicio.Value.AddMonths(1).AddDays(-1);
            }

            var tarefas = await _context.Tarefas
                .Where(t => t.Data >= DataInicio && t.Data <= DataFim)
                .ToListAsync();

            Estatisticas = tarefas
                .GroupBy(t => t.Data)
                .Select(g => new EstatisticaTarefa
                {
                    Dia = g.Key.ToShortDateString(),
                    TotalHoras = g.Sum(t => (t.HoraFim - t.HoraInicio).TotalHours),
                    TotalTarefas = g.Count(),
                    MediaHoras = g.Average(t => (t.HoraFim - t.HoraInicio).TotalHours),
                    PercentualConcluidas = g.Count(t => t.TarefaFinalizada) * 100.0 / g.Count()
                })
                .ToList();
        }

    }

    public class EstatisticaTarefa
    {
        public string Dia { get; set; }
        public double TotalHoras { get; set; }
        public int TotalTarefas { get; set; }
        public double MediaHoras { get; set; }
        public double PercentualConcluidas { get; set; }
    }
}
