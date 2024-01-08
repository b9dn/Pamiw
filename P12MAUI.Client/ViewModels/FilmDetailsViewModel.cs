using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.FilmService;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12MAUI.Client.ViewModels
{
    [QueryProperty(nameof(Film), nameof(Film))]
    [QueryProperty(nameof(FilmsViewModel), nameof(FilmsViewModel))]
    public partial class FilmDetailsViewModel : ObservableObject
    {
        private readonly IFilmService _filmService;
        private readonly IMessageDialogService _messageDialogService;
        //private readonly IGeolocation _geolocation;
        //private readonly IMap _map;
        private FilmsViewModel _filmViewModel;

        public FilmDetailsViewModel(IFilmService filmService, IMessageDialogService messageDialogService)//, IGeolocation geolocation, IMap map)
        {
            //_map = map;
            _filmService = filmService;
            _messageDialogService = messageDialogService;
            //_geolocation = geolocation;

            
        }




//        [RelayCommand]
//       public async Task GetLocation()
//        {
//            var location = await _geolocation.GetLastKnownLocationAsync();
//
//            try
//            {
//                await _map.OpenAsync(52.23564245654427, 21.0112328246909, new MapLaunchOptions
//                {
//                    Name = "ALX",
//                    NavigationMode = NavigationMode.None
//                });
//            }
//            catch (Exception)
//            {
//                 _messageDialogService.ShowMessage("Error opening map");
//            }
//            
//        }

        public FilmsViewModel FilmsViewModel
        {
            get
            {
                return _filmViewModel;
            }
            set
            {
                _filmViewModel = value;
            }
        }


        [ObservableProperty]
        Film film;

        public async Task DeleteFilm()
        {
            await _filmService.DeleteFilmAsync(film.Id);
            await _filmViewModel.GetFilms();
        }

        public async Task CreateFilm()
        {
            var newFilm = new Film()
            {
                Title = film.Title,
                Description = film.Description,
                Barcode = film.Barcode,
                Price = film.Price,
                ReleaseDate = film.ReleaseDate,
            };

            var result = await _filmService.CreateFilmAsync(newFilm);
            if (result.Success)
                await _filmViewModel.GetFilms();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateFilm()
        {
            var filmToUpdate = new Film()
            {
                Id = film.Id,
                Title = film.Title,
                Description = film.Description,
                Barcode = film.Barcode,
                Price = film.Price,
                ReleaseDate = film.ReleaseDate,
            };

            await _filmService.UpdateFilmAsync(filmToUpdate);
            await _filmViewModel.GetFilms();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (film.Id == 0)
            {
                CreateFilm();
                await Shell.Current.GoToAsync("../", true);

            }
            else
            {
                UpdateFilm();
                await Shell.Current.GoToAsync("../", true);
            }

        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteFilm();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
