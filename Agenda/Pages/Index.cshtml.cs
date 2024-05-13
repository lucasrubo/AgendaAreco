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
                start = t.Data.ToString("yyyy-MM-dd"), // Defina a data inicial do evento
                end = t.Data.AddDays(1).ToString("yyyy-MM-dd"), // Defina a data final do evento
                priority = t.Prioridade, // Adicione qualquer outra propriedade necessária
                backgroundColor = GetBackgroundColor(t.Prioridade, t.TarefaFinalizada) // Defina a cor de fundo com base na prioridade
            }).ToList();

            EventosJson = new JsonResult(eventos);
        }

        private static string GetBackgroundColor(string prioridade, bool finalizada)
        {
            if (finalizada)
            {
                return "#e2ffe0";
            }
            switch (prioridade)
            {
                case "Alta":
                    return "#ffa7a7";
                case "Média":
                    return "#ffffa7";
                case "Baixa":
                    return "#FFFFFF";
                default:
                    return "#FFFFFF";
            }
        }
    }
}
