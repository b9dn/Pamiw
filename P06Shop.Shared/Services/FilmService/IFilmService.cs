using P06Shop.Shared;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.FilmService
{
    public interface IFilmService
    {
        Task<ServiceResponse<List<Film>>> GetFilmsAsync();

        Task<ServiceResponse<Film>> UpdateFilmAsync(Film film);

        Task<ServiceResponse<bool>> DeleteFilmAsync(int id);

        Task<ServiceResponse<Film>> CreateFilmAsync(Film film);

        Task<ServiceResponse<Film>> GetFilmByIdAsync(int id);

        Task<ServiceResponse<List<Film>>> SearchFilmsAsync(string text, int page, int pageSize);
    }
}
