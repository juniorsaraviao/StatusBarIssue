namespace SampleMaui;

public partial class SecondPage
{
	public SecondPage()
	{
		InitializeComponent();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopAsync();
    }
}
