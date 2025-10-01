using System.Net.Http.Json;
using CRMApp.BlazorUI.Models;

namespace CRMApp.BlazorUI.Services;

public class CustomerService
{
    private readonly HttpClient _http;

    public CustomerService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CustomerDto>> GetCustomersAsync()
        => await _http.GetFromJsonAsync<List<CustomerDto>>("api/customers") ?? new();

    public async Task<bool> AddCustomerAsync(CustomerDto customer)
    {
        var response = await _http.PostAsJsonAsync("api/customers", customer);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerDto customer)
    {
        var response = await _http.PutAsJsonAsync($"api/customers/{customer.AccountId}", customer);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/customers/{id}");
        return response.IsSuccessStatusCode;
    }
}
