using Microsoft.Maui.Layouts;

namespace _1projekt;

public partial class SnowmanPage : ContentPage
{
    Button kaivita_tegevus;
	BoxView amber;
	Frame pea;
	Frame keha1;
	Frame keha2;
	Picker picker;
	AbsoluteLayout al;
	public SnowmanPage()
	{
        kaivita_tegevus = new Button
        {
            Text = "Käivita tegevus",
            FontSize = 20,
            BackgroundColor = Color.FromRgb(200, 200, 100),
            TextColor = Colors.Black,
            FontFamily = "Lovin Kites 400",
        };

        amber = new BoxView
        {
            BackgroundColor = Colors.Black,
            WidthRequest = 80,
            HeightRequest = 60,
            CornerRadius = 0,
            Rotation = -15
        };

		pea = new Frame
		{
			BackgroundColor = Colors.White,
			WidthRequest = 150,
			HeightRequest = 150,
			CornerRadius = 75,
			BorderColor = Colors.Black,
			HasShadow = false
		};

		keha1 = new Frame
		{
			BackgroundColor = Colors.White,
			WidthRequest = 175,
			HeightRequest = 175,
			CornerRadius = 125,
			BorderColor = Colors.Black,
			HasShadow = false
		};

        keha2 = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 225,
            HeightRequest = 225,
            CornerRadius = 125,
            BorderColor = Colors.Black,
            HasShadow = false
        };

        picker = new Picker
        {
            Title = "Vali tegevus",
            FontSize = 20,
            BackgroundColor = Color.FromRgb(200, 200, 100),
            TextColor = Colors.Black,
            FontFamily = "Lovin Kites 400",
            ItemsSource = new List<string> { "Peida lumememm", "Näita lumememm", "Muuda värvi", "Sulata", "Tantsi" }
        };

        al = new AbsoluteLayout { Children = {picker, kaivita_tegevus, amber, pea, keha1, keha2 } };

        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.025, 0.0, 0.42, 0.1));
        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(kaivita_tegevus, new Rect(0.025, 0.2, 0.3, 0.1));
        AbsoluteLayout.SetLayoutFlags(kaivita_tegevus, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(amber, new Rect(0.45, 0.0, 0.3, 0.35));
		AbsoluteLayout.SetLayoutFlags(amber, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(pea, new Rect(0.5, 0.2, 0.3, 0.3));
        AbsoluteLayout.SetLayoutFlags(pea, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(keha1, new Rect(0.5, 0.4, 0.5, 0.5));
		AbsoluteLayout.SetLayoutFlags(keha1, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(keha2, new Rect(0.5, 0.75, 0.5, 0.5));
        AbsoluteLayout.SetLayoutFlags(keha2, AbsoluteLayoutFlags.All);
        Content = al;
	}
}