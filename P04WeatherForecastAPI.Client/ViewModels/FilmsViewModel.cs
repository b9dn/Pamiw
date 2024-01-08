using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.SpeechService;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.MessageBox;
using P06Shop.Shared.Services.FilmService;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class FilmsViewModel : ObservableObject
    {
        private readonly IFilmService _filmService;
        private readonly FilmDetailsView _filmDetailsView;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ISpeechService _speechService;

        public ObservableCollection<Film> Films { get; set; }



        [ObservableProperty]
        private Film selectedFilm;



        public FilmsViewModel(IFilmService filmService, FilmDetailsView filmDetailsView,
            IMessageDialogService messageDialogService, ISpeechService speechService)
        {
            _messageDialogService = messageDialogService;
            _speechService = speechService;
            _filmDetailsView = filmDetailsView;
            _filmService = filmService;
            Films = new ObservableCollection<Film>();
        }

        public async Task GetFilms()
        {
            Films.Clear();
            var filmsResult = await _filmService.GetFilmsAsync();
            if (filmsResult.Success)
                foreach (var p in filmsResult.Data)
                    Films.Add(p);
            else
                _messageDialogService.ShowMessage(filmsResult.Message);
        }


        public async Task CreateFilm()
        {
            var newFilm = new Film()
            {
                Title = selectedFilm.Title,
                Description = selectedFilm.Description,
                Barcode = selectedFilm.Barcode,
                Price = selectedFilm.Price,
                ReleaseDate = selectedFilm.ReleaseDate,
            };

            var result =  await _filmService.CreateFilmAsync(newFilm);
            if (result.Success)
                await GetFilms();
            else
                _messageDialogService.ShowMessage(result.Message);  
        }

        public async Task UpdateFilm()
        {
            var filmToUpdate = new Film()
            {
                Id = selectedFilm.Id,
                Title = selectedFilm.Title,
                Description = selectedFilm.Description,
                Barcode = selectedFilm.Barcode,
                Price = selectedFilm.Price,
                ReleaseDate = selectedFilm.ReleaseDate,
            };

            await _filmService.UpdateFilmAsync(filmToUpdate);
            GetFilms();
        }

        public async Task DeleteFilm()
        {
            await _filmService.DeleteFilmAsync(selectedFilm.Id);
            await GetFilms();
        }

        [RelayCommand]
        public async Task ShowDetails(Film film)
        {
            _filmDetailsView.Show();
            _filmDetailsView.DataContext = this;
            //selectedFilm = film;
            //OnPropertyChanged("SelectedFilm");
            SelectedFilm = film;
        }


        [RelayCommand]
        public async Task Save()
        {
            if (selectedFilm.Id == 0)
            {
                CreateFilm();
            }
            else
            {
                UpdateFilm();
            }

        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteFilm();
        }

        [RelayCommand]
        public async Task New()
        {
            _filmDetailsView.Show();
            _filmDetailsView.DataContext = this;
            //selectedFilm = new Film();
            //OnPropertyChanged("SelectedFilm");
            SelectedFilm = new Film(); 
        }

        [RelayCommand]
        public async Task RecognizeVoice()
        {
            string recognizedText = await _speechService.RecognizeAsync();

            SelectedFilm.Description = recognizedText;

            //SelectedFilm = new Film() { DescriptionTest = "Test" };
        }

    }
}
