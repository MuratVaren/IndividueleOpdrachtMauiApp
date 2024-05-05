using ClassLibAutheur.Business.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiAppAuthor
{
    class RestService
    {
        private const string REST_URL = "https://5s7727dz-7205.euw.devtunnels.ms/GetAllAuthors";

        public static async Task<List<Author>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = REST_URL;

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if(apiResponse != "")
                    {
                        try
                        {
                            // Parse the JSON array into a JArray
                            JArray jsonArray = JArray.Parse(apiResponse);

                            // Deserialize the JSON array into a List<Author>
                            List<Author> authors = jsonArray.Select(json => json.ToObject<Author>()).ToList();

                            return authors;
                        }
                        catch (HttpRequestException ex)
                        {
                            // Handle exception due to API being inactive
                            throw new Exception("Error communicating with the API. Please try again later.", ex);
                        }
                        catch (JsonSerializationException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else
                    {
                        throw new Exception("Response was empty!");
                    }

                }
                else
                {
                    throw new Exception($"ERROR: {response.StatusCode}");
                }
            }
        }
        public static async Task<string> Post(Author author)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5s7727dz-7205.euw.devtunnels.ms/");

                // Prepare data to be sent in the request body
                var postData = new
                {
                    name = author.Name,
                    country = author.Country,
                    birthdate = author.Birthdate.ToString("yyyy-MM-dd"), // Format the date as required by the API
                    mostPopularWork = author.MostPopularWork,
                    imageAuthor = "",
                    audioTrack = "",
                };

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("RegisterAuthor", content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and return the response from the API
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return "Response from API: " + responseContent;
                    }
                    else
                    {
                        // Return the error status code
                        return "Error: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    // Throw the exception
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

    }
}
