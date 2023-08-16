// Create a service for Weavr API integration
using System.Text.Json;

public interface IWeavrService
{
    Task<ManagedAccountResponse> CreateManagedAccountAsync();
    
    Task<TransactionResponse> CreateTransactionAsync(TransactionRequest request);

    Task<KycResponse> PerformKycAsync(int customerId, KycRequest request);

     Task<IbanAssignmentResponse> AssignIbanToUserAsync(int userId);


}


public class WeavrService : IWeavrService
{
    private readonly HttpClient _httpClient;

    public WeavrService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task<ManagedAccountResponse> IWeavrService.CreateManagedAccountAsync()
    {
        var response = await _httpClient.PostAsync("weavr/api/accounts/create", null);
        response.EnsureSuccessStatusCode();
        
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ManagedAccountResponse>(responseBody);
        return result;
    }


        async Task<IbanAssignmentResponse> IWeavrService.AssignIbanToUserAsync(int userId)
    {
        var response = await _httpClient.PostAsync($"weavr/api/users/{userId}/assign-iban", null);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<IbanAssignmentResponse>(responseBody);
        return result;
    }

       async Task<KycResponse> IWeavrService.PerformKycAsync(int customerId, KycRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"weavr/api/customers/{customerId}/kyc", content);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<KycResponse>(responseBody);
        return result;
    }

      async Task<TransactionResponse> IWeavrService.CreateTransactionAsync(TransactionRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("weavr/api/transactions/create", content);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TransactionResponse>(responseBody);
        return result;
    }

      public async Task<IEnumerable<AccountStatement>> GetAccountStatementsAsync(int accountId)
    {
        var response = await _httpClient.GetAsync($"weavr/api/accounts/{accountId}/statements");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<IEnumerable<AccountStatement>>(responseBody);
        return result;
    }
}

internal class ManagedAccountResponse
{
}

internal class IbanAssignmentResponse
{
}

internal class KycRequest
{
}

internal class KycResponse
{
}

internal class TransactionRequest
{
}

internal class TransactionResponse
{
}

public class AccountStatement
{
}