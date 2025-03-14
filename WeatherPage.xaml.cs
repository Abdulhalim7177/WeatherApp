using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
	public List<Models.List> WeatherList;
	public WeatherPage()
	{
		WeatherList = new List<Models.List>();
		InitializeComponent();
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var result = await ApiService.GetWeather(47.6829, -122.1209);
		foreach(var item in result.list)
		{
			WeatherList.Add(item);
		}
		CvlWeather.ItemsSource = WeatherList;

		lblCity.Text = result.city.name;
		lblWeatherDescription.Text = result.list[0].weather[0].description;
		lblTemperature.Text = result.list[0].main.Temperature + "°C";
		lblHumidity.Text = result.list[0].main.humidity + "%";
		lblWindSpeed.Text = result.list[0].wind.speed + "Km/h";
		imgWeatherIcon.Source = result.list[0].weather[0].fullIconUrl;
	}
}