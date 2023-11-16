using System.Text.Json.Serialization;

namespace OptiScaffold.Models;

internal class ScaffConfigurationModel
{
    [JsonPropertyName("n")]
    public string Namespace { get; set; }

    [JsonPropertyName("abc")]
    public string AbstractBlockClass { get; set; }

    [JsonPropertyName("abn")]
    public string AbstractBlockNamespace { get; set; }

    [JsonPropertyName("apc")]
    public string AbstractPageClass { get; set; }

    [JsonPropertyName("apn")]
    public string AbstractPageNamespace { get; set; }

    [JsonPropertyName("pvc")]
    public string PageViewModelClass { get; set; }

    [JsonPropertyName("pvn")]
    public string PageViewModelNamespace { get; set; }

    [JsonPropertyName("bvc")]
    public string BlockViewModelClass { get; set; }

    [JsonPropertyName("bvn")]
    public string BlockViewModelNamespace { get; set; }
}