using ClassLibAutheur.Business.Entities;

namespace MauiAppAuthor;

public partial class InsertPage : ContentPage
{
	public InsertPage()
	{
		InitializeComponent();
	}

    private async void HomePageBtn_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//MainPage");
    }

    private async void InsertBtn_Clicked(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Author author = new Author();
            author.Name = NameEntry.Text;
            author.Country = CountryEntry.Text;
            author.MostPopularWork = PopularWorkEntry.Text;
            author.Birthdate = AuthorDatePicker.Date;

            try
            {
                // Call the Post method to send data to the API
                string response = await RestService.Post(author);

                // Display a success message
                await DisplayAlert("Success", response, "Ok");

                // Clear the input fields
                NameEntry.Text = string.Empty;
                CountryEntry.Text = string.Empty;
                PopularWorkEntry.Text = string.Empty;
                AuthorDatePicker.Date = DateTime.Now; // Reset the date picker to today's date or another default date
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }

    public bool ValidateInput()
    {
        if (string.IsNullOrEmpty(NameEntry.Text))
        {
            DisplayAlert("Empty value!", "Name can't be empty!", "Ok");
            return false;
        }
        if (string.IsNullOrEmpty(CountryEntry.Text))
        {
            DisplayAlert("Empty value!", "Country can't be empty!", "Ok");
            return false;
        }
        if (string.IsNullOrEmpty(PopularWorkEntry.Text))
        {
            DisplayAlert("Empty value!", "Popular work can't be empty!", "Ok");
            return false;
        }
        if (AuthorDatePicker.Date == null || AuthorDatePicker.Date == DateTime.MinValue)
        {
            DisplayAlert("Empty value!", "Please select a date!", "Ok");
            return false;
        }
        return true;
    }


}