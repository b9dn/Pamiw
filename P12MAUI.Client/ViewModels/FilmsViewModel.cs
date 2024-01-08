using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.FilmService;
using P06Shop.Shared.Shop;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace P04WeatherForecastAPI.Client.ViewModels
{
   
 public partial class FilmsViewModel : ObservableObject
    {
        private readonly IFilmService _filmService;
        private readonly FilmDetailsView _filmDetailsView;
        private readonly IMessageDialogService _messageDialogService;
        //private readonly IConnectivity _connectivity;
        public ObservableCollection<Film> Films { get; set; }

        [ObservableProperty]
        private Film selectedFilm;

        public FilmsViewModel(IFilmService filmService, FilmDetailsView filmDetailsView, IMessageDialogService messageDialogService)//,
            //IConnectivity connectivity)
        {
            _messageDialogService = messageDialogService;
            _filmDetailsView = filmDetailsView;
            _filmService = filmService;
            //_connectivity = connectivity; // set the _connectivity field
            Films = new ObservableCollection<Film>();
            GetFilms();
        }

        public async Task GetFilms()
        {
            Films.Clear();
            //if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    _messageDialogService.ShowMessage("Internet not available!");
            //    return;
            //}

            var filmsResult = await _filmService.GetFilmsAsync();
            if (filmsResult.Success)
            {
                foreach (var p in filmsResult.Data)
                {
                    Films.Add(p);
                }
            }
            else
            {
                _messageDialogService.ShowMessage(filmsResult.Message);
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Film film)
        {
            //if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    _messageDialogService.ShowMessage("Internet not available!");
            //    return;
            //}

            await Shell.Current.GoToAsync(nameof(FilmDetailsView), true, new Dictionary<string, object>
            {
                {"Film", film },
                {nameof(FilmsViewModel), this }
            });
            SelectedFilm = film;
        }

        [RelayCommand]
        public async Task New()
        {
            //if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //   _messageDialogService.ShowMessage("Internet not available!");
            //    return;
            //}

            SelectedFilm = new Film();
            await Shell.Current.GoToAsync(nameof(FilmDetailsView), true, new Dictionary<string, object>
            {
                {"Film", SelectedFilm },
                {nameof(FilmsViewModel), this }
            });
        }

    }
}
