namespace _1projekt;

public partial class StartPage : ContentPage
{
	public List<ContentPage> lehed = new List<ContentPage>() { new TekstPage(), new FigurePage(), new TimerPage(), new ValgusfoorPage()};
    public List<string> tekstid= new List<string>() { "Tee lahti leht Tekst'ga", "Tee lahti Figure leht", "K�ivita timer page", "K�ivita valgusfoor page"};
	ScrollView sv;
	VerticalStackLayout vsl;
	public StartPage()
	{
		//InitializeComponent();
		Title = "Avaleht";
		vsl = new VerticalStackLayout { BackgroundColor = Color.FromRgb(120, 30, 50) };
		for (int i = 0; i < lehed.Count; i++)
		{
			Button nupp = new Button
			{
				Text = tekstid[i],
				FontSize = 20,
				BackgroundColor = Color.FromRgb(200, 200, 100),
				TextColor = Colors.Black,
				CornerRadius = 20,
				FontFamily = "premint-Regular",
				ZIndex=i
			};
			vsl.Add(nupp);
			nupp.Clicked += Nupp_Clicked;
        }
		sv = new ScrollView { Content = vsl };
		Content = sv;
    }

	private async void Nupp_Clicked(object? sender, EventArgs e)
	{
		Button nupp = (Button)sender;
		await Navigation.PushAsync(lehed[nupp.ZIndex]);
	}
}