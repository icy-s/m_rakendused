using System;

namespace _1projekt;

public partial class ValgusfoorPage : ContentPage
{
    Label infoLabel;
	BoxView boxView;
	VerticalStackLayout vsl;
	public ValgusfoorPage()
	{
        infoLabel = new Label
        {
            Text = "punane",
            FontSize = 30,
            TextColor = Colors.Black,
            FontFamily = "premint-Regular",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        boxView = new BoxView
		{
			Color = Colors.Red,
			WidthRequest = DeviceDisplay.MainDisplayInfo.Width / 4,
			HeightRequest = DeviceDisplay.MainDisplayInfo.Height / 4,
			CornerRadius = 100,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,

		};

        TapGestureRecognizer tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += Klik_punane_ringi_peal;
        boxView.GestureRecognizers.Add(tapGesture);

        vsl = new VerticalStackLayout
        {
            Children = { infoLabel, boxView },
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        Content = vsl;
    }
    bool on_off = true;
    private void Klik_punane_ringi_peal(object? sender, TappedEventArgs e)
    {
        if (on_off)
        {
            infoLabel.Text = "Seis!";
            boxView.Color = Colors.Gray;
        }
        else
        {
            infoLabel.Text = "punane";
            boxView.Color = Colors.Red;
        }
        on_off = !on_off;
    }
}