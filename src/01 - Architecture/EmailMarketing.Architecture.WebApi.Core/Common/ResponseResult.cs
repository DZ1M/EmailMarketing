using System.Text.Json.Serialization;

namespace EmailMarketing.Architecture.WebApi.Core.Common
{
    public class ResponseResult
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("errors")]
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
