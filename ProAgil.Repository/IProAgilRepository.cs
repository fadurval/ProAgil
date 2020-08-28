using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        // GERAL
         void Add <T>(T entity) where T: class;
         void Update <T>(T entity) where T: class;
         void Delete <T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync();

         //EVENTOS
        
        Task<Evento[]> GetEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);

        //PALESTRANTE
        Task<Palestrante[]> GetPalestrantesAsyncByName(string name, bool includeEventos);
        Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool includeEventos);
    }
}