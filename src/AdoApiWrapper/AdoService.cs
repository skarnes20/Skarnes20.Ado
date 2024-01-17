using System.Net.Http.Headers;
using System.Net.Http.Json;
using AdoApiWrapper.Models;

namespace AdoApiWrapper;

public class AdoService : IAdoService
{
    public Task<IAsyncEnumerable<TestPlanResponse>> GetAllTestPlans()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://dev.azure.com/")
        };

        var auth = "kjetil_pat:rn7tde5okgjsfaq4spbrpefrbkshujbdd4lfsfzsckfvknsifr2q";
        var base64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(auth));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);

        var organization = "kjetilkvaerne";
        var project = "Kata";

        var response = httpClient.GetFromJsonAsAsyncEnumerable<TestPlanResponse>($"{organization}/{project}/_apis/test/plans?api-version=5.0");
        return null;
    }
}