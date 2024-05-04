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
    }
}
