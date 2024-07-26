using System.Text.Json.Serialization;
 
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Dob
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("seed")]
        public string Seed { get; set; }

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("dob")]
        public Dob Dob { get; set; }
    }

    public class NombresGenerados
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }

