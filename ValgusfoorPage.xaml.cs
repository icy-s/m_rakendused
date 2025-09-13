using Microsoft.Maui.Controls;

namespace _1projekt;

public partial class ValgusfoorPage : ContentPage
{
    private bool _isOn = false;

    public ValgusfoorPage()
    {
        InitializeComponent();
    }

    private void OnTurnOnClicked(object sender, EventArgs e)
    {
        _isOn = true;
        RedLight.BackgroundColor = Colors.Red;
        YellowLight.BackgroundColor = Colors.Yellow;
        GreenLight.BackgroundColor = Colors.Green;
        TitleLabel.Text = "Vali valgus";
    }

    private void OnTurnOffClicked(object sender, EventArgs e)
    {
        _isOn = false;
        RedLight.BackgroundColor = Colors.Gray;
        YellowLight.BackgroundColor = Colors.Gray;
        GreenLight.BackgroundColor = Colors.Gray;
        TitleLabel.Text = "Lülita esmalt foor sisse";
    }

    private void OnRedTapped(object sender, EventArgs e)
    {
        if (_isOn)
            TitleLabel.Text = "Seisa";
    }

    private void OnYellowTapped(object sender, EventArgs e)
    {
        if (_isOn)
            TitleLabel.Text = "Valmista";
    }

    private void OnGreenTapped(object sender, EventArgs e)
    {
        if (_isOn)
            TitleLabel.Text = "Sõida";
    }
}
