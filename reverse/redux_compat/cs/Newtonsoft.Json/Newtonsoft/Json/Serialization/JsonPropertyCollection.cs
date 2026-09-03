/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(new byte[3] {0, 1, 1 })]
	[NullableContext(1)]
	public class JsonPropertyCollection : KeyedCollection<string, Newtonsoft.Json.Serialization.JsonProperty> // TypeDefIndex: 10236
	{
		// Fields
		private readonly Type _type; // 0x30
		private readonly List<JsonProperty> _list; // 0x38
	
		// Constructors
		public JsonPropertyCollection(Type type); // 0x000000018170D020-0x000000018170D1F0
	
		// Methods
		protected override string GetKeyForItem(JsonProperty item); // 0x000000018170CD90-0x000000018170CDB0
		public void AddProperty(JsonProperty property); // 0x000000018170CA00-0x000000018170CCE0
		public JsonProperty GetClosestMatchProperty(string propertyName); // 0x000000018170CCE0-0x000000018170CD90
		private bool TryGetProperty(string key, [Nullable(2)] [NotNullWhen(true)] out JsonProperty item); // 0x000000018170CF30-0x000000018170D020
		public JsonProperty GetProperty(string propertyName, StringComparison comparisonType); // 0x000000018170CDB0-0x000000018170CF30
	}
}
