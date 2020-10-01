using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordBot.Services
{
    public class DiscordService
    {
        private readonly HttpClient _http;

        public DiscordService(HttpClient http)
            => _http = http;

        public async Task AddDiscordEntryAsync(string channel, string user, string text, string link)
        {
            string json = JsonConvert.SerializeObject(new
            {
                channelName = channel,
                username = user,
                message = text,
                messageLink = link
            });

            var discordweb = Environment.GetEnvironmentVariable("discordweb");
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            await _http.PostAsync(discordweb, content);
        }
    }
}