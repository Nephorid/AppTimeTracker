using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class OyunDetaylari : UserControl
    {
        private Oyun _game;
        private MainWindow _mainWindow;



        public async Task InitializeAsync(Oyun oyun, MainWindow mainWindow)
        {
            InitializeComponent();
            _game = oyun;
            _mainWindow = mainWindow;
            GameNameTextBlock.Text = _game.Ad;

            UpdateTimePlayedTextBlock();
        }

        private void UpdateTimePlayedTextBlock()
        {

            TimeSpan playedTime = TimeSpan.FromMilliseconds(_game.OynamaSuresi.TotalMilliseconds);
            string formattedTime = playedTime.ToString(@"hh\:mm\:ss");

            TimePlayedTextBlock.Text = $"Oynanan Süre: {formattedTime}";
        }


        private async void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(_game.ExecutablePath))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Process gameProcess = new Process();
                gameProcess.StartInfo.FileName = _game.ExecutablePath;
                gameProcess.Start();

                await Task.Run(() => gameProcess.WaitForExit());

                stopwatch.Stop();
                _game.OynamaSuresi += stopwatch.Elapsed;
                UpdateTimePlayedTextBlock();

                int selectedIndex = _mainWindow.gameListBox.SelectedIndex;
                if (selectedIndex != -1)
                {
                    _mainWindow.gameListBox.Items[selectedIndex] = _game;
                    _mainWindow.SaveGameLibrary();
                }
            }
            else
            {
                MessageBox.Show("Oyun dosyası bulunamadı. Lütfen yolu kontrol edin.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
