using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AndroidBinderator;

public class LicenseConfig
{
	[JsonProperty ("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty ("file")]
	public string File { get; set; } = string.Empty;

	[DefaultValue ("")]
	[JsonProperty ("spdx")]
	public string Spdx { get; set; } = string.Empty;

	[JsonProperty ("proprietary")]
	public bool Proprietary { get; set; }

	[DefaultValue ("")]
	[JsonProperty ("comments")]
	public string Comments { get; set; } = string.Empty;
}
