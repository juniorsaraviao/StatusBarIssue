namespace SampleMaui;

public partial class MainPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SecondPage());
	}
}


