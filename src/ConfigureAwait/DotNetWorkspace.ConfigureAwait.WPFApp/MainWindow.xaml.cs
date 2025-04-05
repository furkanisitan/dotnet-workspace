using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using DotNetWorkspace.ConfigureAwait.Library;

namespace DotNetWorkspace.ConfigureAwait.WPFApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BtnUi_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Main thread
            Debug.WriteLine("Before WaitAsync");

            // Worker thread
            await WaitAsync().ConfigureAwait(true); // default
            //await WaitAsync().ConfigureAwait(false);

            // Continuation task (Which thread?)
            Debug.WriteLine("After WaitAsync");
            Window.Background = GetRandomColor();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
        }
    }

    private async void BtnLibrary_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Main thread
            Debug.WriteLine("Before SleepAsync");

            // Worker thread
            await Sleeper.SleepAsync(); // recommended
            //Sleeper.SleepAsync().Wait(); // not recommended

            Debug.WriteLine("After SleepAsync");
            Window.Background = GetRandomColor();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
        }
    }

    private static async Task WaitAsync()
    {
        Debug.WriteLine("Before Delay");

        await Task.Delay(1000);

        Debug.WriteLine("After Delay");
    }

    private static Brush GetRandomColor()
    {
        var r = new Random();
        Brush brush = new SolidColorBrush(Color.FromRgb(
            (byte)r.Next(1, 255),
            (byte)r.Next(1, 255),
            (byte)r.Next(1, 233))
        );

        return brush;
    }
}