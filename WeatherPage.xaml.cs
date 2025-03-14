using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var result = await ApiService.GetWeather(47.6829, -122.1209);

		lblCity.Text = result.city.name;
		lblWeatherDescription.Text = result.list[0].weather[0].description;
	}
}