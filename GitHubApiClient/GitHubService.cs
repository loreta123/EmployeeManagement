using EmployeesApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApiClient
{
    public class GitHubApiService
    {
        private readonly HttpClient _httpClient;

        public GitHubApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Repository>> FetchUserRepositoriesAsync(string username)
        {
            int maxRetries = 3; // Maximum number of retry attempts
            int delay = 2000;   // Initial delay before retrying (2 seconds)

            for (int retryCount = 0; retryCount < maxRetries; retryCount++)
            {
                try
                {
                    Logger.LogInfo($"Fetching repositories for user '{username}'... Attempt {retryCount + 1}");

                    var response = await _httpClient.GetAsync($"https://api.github.com/users/{username}/repos");

                    if (response.IsSuccessStatusCode)
                    {
                        var repositories = await response.Content.ReadFromJsonAsync<List<Repository>>();
                        Logger.LogInfo($"Successfully fetched {repositories?.Count} repositories for user '{username}'.");
                        return repositories;
                    }
                    else
                    {
                        Logger.LogWarning($"Request failed with status code {response.StatusCode}. Retrying...");
                    }
                }
                catch (HttpRequestException e)
                {
                    Logger.LogError($"Request failed: {e.Message}. Retrying...");
                }
                // Wait before retrying
                await Task.Delay(delay);
                delay *= 2; // Exponential backoff (double the delay)
            }

            // If all retries fail, log the error and return null or handle it appropriately
            Logger.LogError($"Failed to fetch repositories for user '{username}' after {maxRetries} attempts.");
            return null;
        }
    }
}
