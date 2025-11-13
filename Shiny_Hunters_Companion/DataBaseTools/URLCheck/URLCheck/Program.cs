using System;
using System.IO;                  // For reading/writing files
using System.Net.Http;          // For checking URLs
using System.Threading.Tasks;   // For running async tasks
using System.Collections.Generic; // For List
using System.Text;              // For StringBuilder

/// <summary>
/// This program will read a CSV file, check every URL in it for errors,
/// and output a new CSV file named "bad_urls_report.csv" with any failures.
/// </summary>
public class Program
{
    // This is the main entry point
    public static async Task Main(string[] args)
    {
        Console.WriteLine("--- Starting URL Check ---");

        // We call the async method and wait for it to finish
        await UrlChecker.RunCheckAsync();

        Console.WriteLine("\n--- URL Check finished! ---");
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}

// -----------------------------------------------------------------
// THE URL CHECKER TOOL
// -----------------------------------------------------------------
public class UrlChecker
{
    // !!! UPDATE THIS PATH !!!
    // This should be the full path to your main pokemon_import.csv file
    private static readonly string _csvFilePath = @"H:\3309\PokemonDataStuff\CompletePokemonCSV4.csv";

    // This is the output file. It will be saved in the same folder
    // as the .exe file (e.g., YourProject/bin/Debug/net6.0/)
    private static readonly string _reportFilePath = "bad_urls_report.csv";


    // A single, reusable client is most efficient
    private static readonly HttpClient _httpClient = new HttpClient();

    /// <summary>
    /// Runs the entire check and saves the report.
    /// </summary>
    public static async Task RunCheckAsync()
    {
        if (!File.Exists(_csvFilePath))
        {
            Console.WriteLine($"ERROR: Cannot find CSV file at: {_csvFilePath}");
            return;
        }

        // A list to hold any error rows for the report
        // Each string[] is a row: [DisplayName, URL, Error]
        List<string[]> badUrls = new List<string[]>();

        // Read all lines from your import file
        string[] allLines = File.ReadAllLines(_csvFilePath);

        // Start at 1 to skip the header row
        for (int i = 1; i < allLines.Length; i++)
        {
            string line = allLines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] columns = line.Split(',');

            // Extract data from the columns
            string displayName = columns[3];
            string url = columns[4];
            string errorInfo = ""; // This will hold the error message

            Console.Write($"Checking: {displayName}...");

            try
            {
                // We use HttpMethod.Head for a fast check without downloading the file
                using (var request = new HttpRequestMessage(HttpMethod.Head, url))
                {
                    var response = await _httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        // IsSuccessStatusCode means 200-299 (e.g., 200 OK)
                        Console.WriteLine(" OK!");
                    }
                    else
                    {
                        // Any other code (like 404 Not Found, 403 Forbidden, 500 Error)
                        errorInfo = $"HTTP Error: {response.StatusCode}";
                        Console.WriteLine($" FAILED! (Status: {response.StatusCode})");
                        badUrls.Add(new string[] { displayName, url, errorInfo });
                    }
                }
            }
            catch (Exception ex)
            {
                // This catches network errors, bad hostnames, etc.
                errorInfo = $"Exception: {ex.Message}";
                Console.WriteLine($" ERROR! (Exception: {ex.Message})");
                badUrls.Add(new string[] { displayName, url, errorInfo });
            }
        }

        Console.WriteLine("\n--- Check Complete ---");

        // Write the results to the report file
        if (badUrls.Count == 0)
        {
            Console.WriteLine("All URLs are valid!");
        }
        else
        {
            Console.WriteLine($"Found {badUrls.Count} bad URLs. Saving report...");
            try
            {
                // Using StringBuilder is more efficient than writing line-by-line
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("DisplayName,URL,Error"); // Add header

                foreach (var badUrl in badUrls)
                {
                    // Format as a CSV line. Quotes handle any commas in the data.
                    sb.AppendLine($"\"{badUrl[0]}\",\"{badUrl[1]}\",\"{badUrl[2]}\"");
                }

                // Write the entire report to the file at once
                File.WriteAllText(_reportFilePath, sb.ToString());

                // Path.GetFullPath() shows the user exactly where the file was saved
                Console.WriteLine($"Successfully saved report to: {Path.GetFullPath(_reportFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Could not save report file. {ex.Message}");
            }
        }
    }
}