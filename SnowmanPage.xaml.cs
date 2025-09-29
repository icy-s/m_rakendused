using Microsoft.Maui.Layouts;

namespace _1projekt;

public partial class SnowmanPage : ContentPage
{
    Button kaivita_tegevus;
    Frame amber;
    Frame pea;
    Frame keha1;
    Frame keha2;
    Picker picker;
    AbsoluteLayout al;
    Slider opacitySlider;
    Stepper speedStepper;
    Switch nightModeSwitch;
    Label nightModeLabel;
    Label speedLabel;
    Label opacityLabel;
    BoxView eyeLeft, eyeRight;
    BoxView button1, button2, button3;

    double actionSpeed = 1000.0; // по умолчанию 1 секунда

    public SnowmanPage()
    {
        // кнопка
        kaivita_tegevus  = new Button
        {
            Text = "Käivita tegevus",
            FontSize = 20,
            BackgroundColor = Color.FromRgb(200, 200, 100),
            TextColor = Colors.Black,
            FontFamily = "Lovin Kites 400",
        };
        kaivita_tegevus.Clicked += OnButtonClicked;

        // ведро
        amber = new Frame
        {
            BackgroundColor = Colors.Black,
            WidthRequest = 80,
            HeightRequest = 60,
            CornerRadius = 15,
            Rotation = -15,
            HasShadow = false
        };

        // голова
        pea = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 150,
            HeightRequest = 150,
            CornerRadius = 75,
            BorderColor = Colors.Black,
            HasShadow = false
        };

        // тело 1
        keha1 = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 175,
            HeightRequest = 175,
            CornerRadius = 125,
            BorderColor = Colors.Black,
            HasShadow = false
        };

        // тело 2
        keha2 = new Frame
        {
            BackgroundColor = Colors.White,
            WidthRequest = 225,
            HeightRequest = 225,
            CornerRadius = 125,
            BorderColor = Colors.Black,
            HasShadow = false
        };

        // глаза
        eyeLeft = new BoxView { Color = Colors.Black, WidthRequest = 15, HeightRequest = 15, CornerRadius = 7.5 };
        eyeRight = new BoxView { Color = Colors.Black, WidthRequest = 15, HeightRequest = 15, CornerRadius = 7.5 };

        // пуговицы
        button1 = new BoxView { Color = Colors.Black, WidthRequest = 18, HeightRequest = 18, CornerRadius = 9 };
        button2 = new BoxView { Color = Colors.Black, WidthRequest = 18, HeightRequest = 18, CornerRadius = 9 };
        button3 = new BoxView { Color = Colors.Black, WidthRequest = 18, HeightRequest = 18, CornerRadius = 9 };

        // выбор действий
        picker = new Picker
        {
            Title = "Vali tegevus",
            FontSize = 20,
            BackgroundColor = Color.FromRgb(200, 200, 100),
            TextColor = Colors.Black,
            FontFamily = "Lovin Kites 400",
            ItemsSource = new List<string>
              { "Peida lumememm",
                "Näita lumememm",
                "Muuda värvi",
                "Sulata",
                "Tantsi" }
        };

        // слайдер прозрачности
        opacitySlider = new Slider { Minimum = 0, Maximum = 1, Value = 1 };
        opacitySlider.ValueChanged += (s, e) =>
        {
            double val = e.NewValue;
            pea.Opacity = val;
            keha1.Opacity = val;
            keha2.Opacity = val;
            amber.Opacity = val;
            eyeLeft.Opacity = val;
            eyeRight.Opacity = val;
            button1.Opacity = val;
            button2.Opacity = val;
            button3.Opacity = val;

            opacityLabel.Text = $"Läbipaistvus: {val * 100:F0}%";
        };

        // степпер для скорости (через отдельное присвоение свойств)
        speedStepper = new Stepper();
        speedStepper.Minimum = 200.0;
        speedStepper.Maximum = 2000.0;
        speedStepper.Increment = 200.0;
        speedStepper.Value = 1000.0;
        speedStepper.ValueChanged += (s, e) =>
        {
            actionSpeed = e.NewValue;
            speedLabel.Text = $"Kiirus: {actionSpeed} ms";
        };

        speedLabel = new Label
        {
            Text = $"Kiirus: {speedStepper.Value} ms",
            FontSize = 16,
            TextColor = Colors.Black
        };

        // ночной режим
        nightModeLabel = new Label
        {
            Text = "Öörežiim",
            FontSize = 16,
            TextColor = Colors.Black
        };

        opacityLabel = new Label
        {
            Text = $"Läbipaistvus: {opacitySlider.Value * 100:F0}%",
            FontSize = 16,
            TextColor = Colors.Black
        };

        nightModeSwitch = new Switch { IsToggled = false };
        nightModeSwitch.Toggled += OnNightModeToggled;

        // AbsoluteLayout
        al = new AbsoluteLayout
        {
            Children = { picker, kaivita_tegevus, amber, pea, keha1, keha2,
                         opacitySlider, speedStepper, speedLabel, opacityLabel,
                         eyeLeft, eyeRight, button1, button2, button3,
                         nightModeLabel, nightModeSwitch }
        };

        // расположение элементов
        AbsoluteLayout.SetLayoutBounds(picker, new Rect(0.1, 0.0, 0.42, 0.1));
        AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(kaivita_tegevus, new Rect(0.9, 0, 0.3, 0.1));
        AbsoluteLayout.SetLayoutFlags(kaivita_tegevus, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(opacitySlider, new Rect(0.9, 0.85, 0.5, 0.05));
        AbsoluteLayout.SetLayoutFlags(opacitySlider, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(opacityLabel, new Rect(0.05, 0.865, 0.4, 0.05));
        AbsoluteLayout.SetLayoutFlags(opacityLabel, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(speedStepper, new Rect(0.9, 0.9, 0.5, 0.05));
        AbsoluteLayout.SetLayoutFlags(speedStepper, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(speedLabel, new Rect(0.05, 0.915, 0.4, 0.05));
        AbsoluteLayout.SetLayoutFlags(speedLabel, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(nightModeLabel, new Rect(0.1, 0.96, 0.25, 0.05));
        AbsoluteLayout.SetLayoutFlags(nightModeLabel, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(nightModeSwitch, new Rect(0.65, 0.95, 0.15, 0.05));
        AbsoluteLayout.SetLayoutFlags(nightModeSwitch, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(amber, new Rect(160, 100, 80, 60));
        AbsoluteLayout.SetLayoutFlags(amber, AbsoluteLayoutFlags.None);

        AbsoluteLayout.SetLayoutBounds(pea, new Rect(0.5, 0.2, 0.3, 0.3));
        AbsoluteLayout.SetLayoutFlags(pea, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(keha1, new Rect(0.5, 0.4, 0.5, 0.5));
        AbsoluteLayout.SetLayoutFlags(keha1, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(keha2, new Rect(0.5, 0.75, 0.5, 0.5));
        AbsoluteLayout.SetLayoutFlags(keha2, AbsoluteLayoutFlags.All);

        // глаза
        AbsoluteLayout.SetLayoutBounds(eyeLeft, new Rect(0.46, 0.25, 0.05, 0.05));
        AbsoluteLayout.SetLayoutFlags(eyeLeft, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(eyeRight, new Rect(0.54, 0.25, 0.05, 0.05));
        AbsoluteLayout.SetLayoutFlags(eyeRight, AbsoluteLayoutFlags.All);

        // пуговицы
        AbsoluteLayout.SetLayoutBounds(button1, new Rect(0.5, 0.43, 0.05, 0.05));
        AbsoluteLayout.SetLayoutFlags(button1, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(button2, new Rect(0.5, 0.58, 0.05, 0.05));
        AbsoluteLayout.SetLayoutFlags(button2, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(button3, new Rect(0.5, 0.70, 0.05, 0.05));
        AbsoluteLayout.SetLayoutFlags(button3, AbsoluteLayoutFlags.All);

        Content = al;
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
        if (picker.SelectedItem == null) return;

        string tegevus = picker.SelectedItem.ToString();

        switch (tegevus)
        {
            case "Peida lumememm":
                SetSnowmanVisible(false);
                break;

            case "Näita lumememm":
                SetSnowmanVisible(true);
                break;

            case "Muuda värvi":
                var rnd = new Random();
                Color randomColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                pea.BackgroundColor = randomColor;
                keha1.BackgroundColor = randomColor;
                keha2.BackgroundColor = randomColor;
                break;

            case "Sulata":
                await FadeSnowman(0);
                break;

            case "Tantsi":
                await DanceSnowman();
                break;
        }
    }

    void SetSnowmanVisible(bool visible)
    {
        pea.IsVisible = visible;
        keha1.IsVisible = visible;
        keha2.IsVisible = visible;
        amber.IsVisible = visible;
        eyeLeft.IsVisible = visible;
        eyeRight.IsVisible = visible;
        button1.IsVisible = visible;
        button2.IsVisible = visible;
        button3.IsVisible = visible;
    }

    async Task FadeSnowman(double target)
    {
        await pea.FadeTo(target, (uint)actionSpeed);
        await keha1.FadeTo(target, (uint)actionSpeed);
        await keha2.FadeTo(target, (uint)actionSpeed);
        await amber.FadeTo(target, (uint)actionSpeed);
        await eyeLeft.FadeTo(target, (uint)actionSpeed);
        await eyeRight.FadeTo(target, (uint)actionSpeed);
        await button1.FadeTo(target, (uint)actionSpeed);
        await button2.FadeTo(target, (uint)actionSpeed);
        await button3.FadeTo(target, (uint)actionSpeed);
    }

    async Task DanceSnowman()
    {
        await Dance(pea);
        await Dance(keha1);
        await Dance(keha2);
        await Dance(amber);
        await Dance(eyeLeft);
        await Dance(eyeRight);
        await Dance(button1);
        await Dance(button2);
        await Dance(button3);
    }

    async Task Dance(View v)
    {
        await v.TranslateTo(-50, 0, (uint)actionSpeed);
        await v.TranslateTo(50, 0, (uint)actionSpeed);
        await v.TranslateTo(0, 0, (uint)actionSpeed);
    }

    void OnNightModeToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value) // включен ночной режим
        {
            this.BackgroundColor = Colors.Black;
            pea.BackgroundColor = Colors.White;
            keha1.BackgroundColor = Colors.White;
            keha2.BackgroundColor = Colors.White;
            amber.BackgroundColor = Colors.Gray;

            // делаем текст видимым на чёрном фоне
            nightModeLabel.TextColor = Colors.White;
            speedLabel.TextColor = Colors.White;
            opacityLabel.TextColor = Colors.White;
        }
        else // дневной режим
        {
            this.BackgroundColor = Colors.White;
            pea.BackgroundColor = Colors.White;
            keha1.BackgroundColor = Colors.White;
            keha2.BackgroundColor = Colors.White;
            amber.BackgroundColor = Colors.Black;

            // возвращаем чёрный цвет текста
            nightModeLabel.TextColor = Colors.Black;
            speedLabel.TextColor = Colors.Black;
            opacityLabel.TextColor = Colors.Black;
        }
    }
}