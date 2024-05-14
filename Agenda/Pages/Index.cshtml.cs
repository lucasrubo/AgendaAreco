using Agenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Propriedade para armazenar os eventos do calendário
        public JsonResult EventosJson { get; private set; }
        public void OnGet()
        {
            var eventos = _context.Tarefas.Select(t => new
            {
                id = t.Id,
                title = t.Titulo,
                start = t.Data.ToString("yyyy-MM-dd") + "T" + t.HoraInicio.ToString(@"hh\:mm"), // Data e hora de início do evento
                end = t.Data.ToString("yyyy-MM-dd") + "T" + t.HoraFim.ToString(@"hh\:mm"), // Data e hora de término do evento
                priority = t.Prioridade, // Adicione qualquer outra propriedade necessária
                color = "black",
                eventDisplay = "block",
                classNames = GetBackgroundColor(t.Prioridade, t.TarefaFinalizada)
            }).ToList();

            EventosJson = new JsonResult(eventos);
        }

        private static string GetBackgroundColor(string prioridade, bool finalizada)
        {
            if (finalizada)
            {
                //return "#e2ffe0";
                return "finalizada";
            }
            switch (prioridade)
            {
                case "Alta":
                    //return "#ffa7a7";
                    return "alta";
                case "Média":
                    //return "#ffffa7";
                    return "media";
                case "Baixa":
                    //return "#FFFFFF";
                    return "baixa";
                default:
                    //return "#FFFFFF";
                    return "default";
            }
        }
    }
}
