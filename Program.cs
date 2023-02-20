namespace ReadContent
{
    class Program
    {
        private static async Task Main()
        {
            // Read URL from console
            Console.Write("Enter URL: ");
            var url = Console.ReadLine();

            // Check if URL is not null and call ReadContent method with URL as parameter.
            if (url != null)
            {
                await ReadContent(url);
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }

        private static async Task ReadContent(string url)
        {
            // Try to read content from URL and write it to file A.txt.
            try
            {
                // Create HTTP client and get response from URL
                var httpClient = new HttpClient();
                // Get response from URL
                var response = await httpClient.GetAsync(url);
                // Read content from response as string and store it in result variable.
                var result = await response.Content.ReadAsStringAsync();
                // Write content to file A.txt
                await File.WriteAllTextAsync("A.txt", result);
            }
            catch (Exception e)
            {
                // If something went wrong, write error message to console
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
    }
}