using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeesApiClient;

class Program
{
    static async Task Main(string[] args)
    {
        // Log application start
        Logger.LogInfo("GitHub Repositories API Integration started.");

        // Initialize HttpClient with a custom User-Agent (GitHub API requires this)
        var httpClient = new HttpClient
        {
            DefaultRequestHeaders = { { "User-Agent", "ConsoleApp" } }
        };

        // Instantiate the GitHub API service
        var apiService = new GitHubApiService(httpClient);

        // Get GitHub username input from the user
        Console.WriteLine("Enter GitHub username:");
        string username = Console.ReadLine();

        // Fetch and display repositories
        var repositories = await apiService.FetchUserRepositoriesAsync(username);

        if (repositories != null && repositories.Count > 0)
        {
            Console.WriteLine($"\nRepositories for user '{username}':");
            foreach (var repo in repositories)
            {
                Console.WriteLine($"- {repo.Name}: {repo.Description}");
                Console.WriteLine($"  URL: {repo.HtmlUrl}\n");
            }
        }
        else
        {
            Logger.LogError("No repositories found or an error occurred.");
        }

        // Log application end
        Logger.LogInfo("GitHub Repositories API Integration finished.");
    }
}
