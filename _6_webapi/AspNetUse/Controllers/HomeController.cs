using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AspNetUse.Models;

namespace AspNetUse.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = new List<ProductDTO>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5034/api/products"))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("API Response: " + apiResponse);

                if (string.IsNullOrWhiteSpace(apiResponse))
                {
                    return BadRequest("API response is empty.");
                }

                try
                {
                    products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
                }
                catch (JsonException ex)
                {
                    Debug.WriteLine("JSON Deserialization Error: " + ex.Message);
                    return BadRequest("Failed to deserialize the response.");
                }
            }
        }
    
        return View(products);
    }
}