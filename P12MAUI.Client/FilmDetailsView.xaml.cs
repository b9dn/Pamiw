using P12MAUI.Client.ViewModels;

namespace P12MAUI.Client;

public partial class FilmDetailsView : ContentPage
{
	public FilmDetailsView(FilmDetailsViewModel filmDetailsViewModel)
	{
		BindingContext = filmDetailsViewModel;
		InitializeComponent();
	}
}