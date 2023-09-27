using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Fast.Components.FluentUI.Infrastructure;

namespace Microsoft.Fast.Components.FluentUI;

public class FileBasedStaticAssetService : IStaticAssetService
{
    public async Task<string?> GetAsync(string assetUrl, bool useCache = false)
    {
        string? result = null;
        HttpRequestMessage message = CreateMessage(assetUrl);
        if (string.IsNullOrEmpty(result))
        {
            result = await ReadData(assetUrl);
        }
        return result;
    }
    private static HttpRequestMessage CreateMessage(string url) => new(HttpMethod.Get, url);

    private static async Task<string> ReadData(string file)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync($"wwwroot/{file}");
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}
