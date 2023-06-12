using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppTimeTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGameLibrary();
        }


        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private const string SaveFilePath = "gameLibrary.json";

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            SaveGameLibrary();
        }

        public void SaveGameLibrary()
        {
            List<Oyun> gameList = new List<Oyun>();

            foreach (Oyun game in gameListBox.Items)
            {
                gameList.Add(game);
            }

            string json = JsonConvert.SerializeObject(gameList, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    Point mousePos = PointToScreen(Mouse.GetPosition(this));
                    Left = mousePos.X - ActualWidth / 2;
                    Top = 0;
                    DragMove();
                }
                else
                {
                    DragMove();
                }
            }
        }
        private void LoadGameLibrary()
        {
            if (File.Exists(SaveFilePath))
            {
                string json = File.ReadAllText(SaveFilePath);
                List<Oyun> gameList = JsonConvert.DeserializeObject<List<Oyun>>(json);

                gameListBox.Items.Clear();

                foreach (Oyun game in gameList)
                {
                    gameListBox.Items.Add(game);
                }
            }
        }

        private void DosyaKonumuDegistirMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (gameListBox.SelectedIndex != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Uygulama Dosyaları (*.exe)|*.exe";
                openFileDialog.Title = "Oyun Dosyasını Seçin";

                if (openFileDialog.ShowDialog() == true)
                {
                    string yeniDosyaKonumu = openFileDialog.FileName;
                    Oyun seciliOyun = (Oyun)gameListBox.SelectedItem;
                    seciliOyun.UpdateExecutablePath(yeniDosyaKonumu);
                }
            }
        }


        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            CustomInputDialog inputDialog = new CustomInputDialog();
            inputDialog.Title = "Oyun Adı";
            inputDialog.ShowDialog();

            string oyunAdi = inputDialog.GameName;

            if (!string.IsNullOrEmpty(oyunAdi))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Oyunun yürütülebilir dosyasını seçin";

                string oyunExecutablePath = string.Empty;
                if (openFileDialog.ShowDialog() == true)
                {
                    oyunExecutablePath = openFileDialog.FileName;
                }

                if (!string.IsNullOrEmpty(oyunExecutablePath))
                {
                    Oyun oyun = new Oyun(oyunAdi, oyunExecutablePath);
                    gameListBox.Items.Add(oyun);
                }
                else
                {
                    MessageBox.Show("Oyun yolu eksik.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Oyun adı eksik.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (gameListBox.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Seçili oyunu silmek istediğinize emin misiniz?", "Oyun Silme", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    gameListBox.Items.RemoveAt(gameListBox.SelectedIndex);
                    SaveGameLibrary();
                    gameDetailsPanel.Content = null;
                }
            }
        }

        private async void gameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gameListBox.SelectedIndex != -1)
            {
                Oyun selectedGame = gameListBox.SelectedItem as Oyun;
                OyunDetaylari gameDetailsControl = new OyunDetaylari();
                await gameDetailsControl.InitializeAsync(selectedGame, this);
                gameDetailsPanel.Content = gameDetailsControl;
            }
        }
    }
}
