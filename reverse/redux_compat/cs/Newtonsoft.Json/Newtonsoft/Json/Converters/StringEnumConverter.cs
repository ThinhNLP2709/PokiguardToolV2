/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class StringEnumConverter : JsonConverter // TypeDefIndex: 10388
	{
		// Fields
		[CompilerGenerated]
		[Nullable(2)]
		private NamingStrategy _NamingStrategy_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _AllowIntegerValues_k__BackingField; // 0x18
	
		// Properties
		[Obsolete("StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.")]
		public bool CamelCaseText { get; set; } // 0x0000000181776310-0x0000000181776380 0x0000000181776380-0x0000000181776460
		[Nullable(2)]
		public NamingStrategy NamingStrategy { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool AllowIntegerValues { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
	
		// Constructors
		public StringEnumConverter(); // 0x00000001817760F0-0x0000000181776100
		[Obsolete("StringEnumConverter(bool) is obsolete. Create a converter with StringEnumConverter(NamingStrategy, bool) instead.")]
		public StringEnumConverter(bool camelCaseText); // 0x0000000181776070-0x00000001817760F0
		public StringEnumConverter(NamingStrategy namingStrategy, bool allowIntegerValues = true /* Metadata: 0x006A1000 */); // 0x0000000181776020-0x0000000181776070
		public StringEnumConverter(Type namingStrategyType); // 0x0000000181776100-0x00000001817761A0
		public StringEnumConverter(Type namingStrategyType, object[] namingStrategyParameters); // 0x00000001817761A0-0x0000000181776250
		public StringEnumConverter(Type namingStrategyType, object[] namingStrategyParameters, bool allowIntegerValues); // 0x0000000181776250-0x0000000181776310
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181775E20-0x0000000181776020
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x00000001817759A0-0x0000000181775E20
		public override bool CanConvert(Type objectType); // 0x0000000181775930-0x00000001817759A0
	}
}
