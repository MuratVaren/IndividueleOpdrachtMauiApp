﻿using ClassLibAutheur.Business.Entities;
using Plugin.Maui.Audio;
using System.Globalization;
using System.IO;

namespace MauiAppAuthor
{
    public partial class MainPage : ContentPage
    {
        List<Author> authorList = new List<Author>();
        private IAudioPlayer audioPlayer; // Remove the colon here
        List<string> listAvailableImages = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            FillListAvailableImages();
        }
        public void FillListAvailableImages()
        {
            listAvailableImages.Clear();
            listAvailableImages.Add("king.jpg");
            listAvailableImages.Add("martin.jpg");
            listAvailableImages.Add("remi.jpg");
            listAvailableImages.Add("rowling.jpg");
            listAvailableImages.Add("tolkien.jpg");
        }
        async Task FillAuthorList()
        {
            authorList = await RestService.GetAll();
        }

        private async void LoadAuthorsBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await FillAuthorList();
                AssignPlaceholderImagesIfNeeded();
                ListViewAuthors.ItemsSource = authorList;
            }
            catch(Exception ex)
            {
                await DisplayAlert(ex.Message, "Error!", "Ok!");
            }
        }

        private void AssignPlaceholderImagesIfNeeded()
        {
            foreach(var author in authorList)
            {
                if (!listAvailableImages.Contains(author.ImageAuthor))
                {
                    author.ImageAuthor = "placeholder.png";
                }
            }
        }
        private void ListViewAuthors_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedAuthor = e.Item as Author;

            // Check if audioPlayer is already instantiated and playing
            if (audioPlayer != null && audioPlayer.IsPlaying)
            {
                audioPlayer.Stop();
            }

            // Play the sound
            PlaySound(selectedAuthor.AudioTrack);
        }
        private async void PlaySound(string path)
        {
            try
            {
                audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(path));
                audioPlayer.Volume = 0.3;
                audioPlayer.Play();
            }
            catch
            {
                audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Audio/Boo Hoo.mp3"));
                audioPlayer.Volume = 0.3;
                audioPlayer.Play();
            }

        }

        private async void InsertPageBtn_Clicked(object sender, EventArgs e)
        {
            ListViewAuthors.ItemsSource = null;
            InsertPage insertPage = new InsertPage();
            await Shell.Current.GoToAsync("//InsertPage");
        }
    }

}
