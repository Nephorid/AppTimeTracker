using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            string oyunAdi = Microsoft.VisualBasic.Interaction.InputBox("Oyunun adını girin:", "Oyun Adı");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
            openFileDialog.Title = "Oyunun yürütülebilir dosyasını seçin";

            string oyunExecutablePath = string.Empty;
            if (openFileDialog.ShowDialog() == true)
            {
                oyunExecutablePath = openFileDialog.FileName;
            }

            if (!string.IsNullOrEmpty(oyunAdi) && !string.IsNullOrEmpty(oyunExecutablePath))
            {
                Oyun oyun = new Oyun(oyunAdi, oyunExecutablePath);
                gameListBox.Items.Add(oyun);
            }
            else
            {
                MessageBox.Show("Oyun adı veya yolu eksik.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
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
