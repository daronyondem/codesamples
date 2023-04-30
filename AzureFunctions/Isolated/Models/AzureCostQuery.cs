using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Company.Function.Models
{
    public class QueryPayload
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timeframe")]
        public string Timeframe { get; set; }

        [JsonProperty("dataset")]
        public QueryDataset Dataset { get; set; }
    }

    public class QueryDataset
    {
        [JsonProperty("granularity")]
        public string Granularity { get; set; }

        [JsonProperty("grouping")]
        public List<QueryGrouping> Grouping { get; set; }

        [JsonProperty("aggregation")]
        public Dictionary<string, QueryAggregation> Aggregation { get; set; }
    }

    public class QueryGrouping
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class QueryAggregation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }
    }

}