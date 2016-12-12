using System;
using Newtonsoft.Json;

namespace PatientManager.Common
{
	public abstract class TableData
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("createdAt")]
		public DateTimeOffset? CreatedAt { get; set; }

		[JsonProperty("updatedAt")]
		public DateTimeOffset? UpdatedAt { get; set; }

		[JsonProperty("version")]
		public byte[] Version { get; set; }
	}
}
