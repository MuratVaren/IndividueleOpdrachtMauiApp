using ClassLibAutheur.Business.Entities;

namespace Individuele_opdracht___Maui_app
{
    public partial class MainPage : ContentPage
    {
        List<Author> authorList = new List<Author>();
        Dictionary<string, string> dictionaryAudio = new Dictionary<string, string>();
        string audioPath = "";
        private IAudioPlayer audioPlayer; // Remove the colon here
        public MainPage()
        {
            InitializeComponent();
            FillDictionary();
        }
        public void FillDictionary()
        {
            dictionaryAudio["Lord of the Rings"] = "LordOfTheRings.mp3";
            dictionaryAudio["Harry Potter"] = "HarryPotter.mp3";
            dictionaryAudio["A Song of Ice and Fire"] = "GameOfThrones.mp3";
            dictionaryAudio["The Shining"] = "Shining.mp3";
            dictionaryAudio["The Adventures of Tintin"] = "Tintin.mp3";

        }
        async Task FillAuthorList()
        {
            authorList = await RestService.GetAll();
        }

        private async void LoadAuthorsBtn_Clicked(object sender, EventArgs e)
        {
            await FillAuthorList();
            ListViewAuthors.ItemsSource = authorList;
        }

        private void ListViewAuthors_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedAuthor = e.Item as Author;
            if (dictionaryAudio.ContainsKey(selectedAuthor.MostPopularWork))
            {
                audioPath = dictionaryAudio[selectedAuthor.MostPopularWork];

                // Check if audioPlayer is already instantiated and playing
                if (audioPlayer != null && audioPlayer.IsPlaying)
                {
                    audioPlayer.Stop();
                }

                // Play the sound
                PlaySound(audioPath);
            }
            else
            {
                if (audioPlayer != null && audioPlayer.IsPlaying)
                {
                    audioPlayer.Stop();
                }
                PlaySound("Boo Hoo.mp3");
            }
            audioPath = "";
        }

        private async void PlaySound(string path)
        {
            audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(path));
            audioPlayer.Volume = 0.3;
            audioPlayer.Play();
        }
    } 
}
