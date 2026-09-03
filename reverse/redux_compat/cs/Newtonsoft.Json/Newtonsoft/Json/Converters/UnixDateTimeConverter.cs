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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class UnixDateTimeConverter : DateTimeConverterBase // TypeDefIndex: 10389
	{
		// Fields
		internal static readonly DateTime UnixEpoch; // 0x00
		[CompilerGenerated]
		private bool _AllowPreEpoch_k__BackingField; // 0x10
	
		// Properties
		public bool AllowPreEpoch { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Constructors
		public UnixDateTimeConverter(); // 0x0000000181776CA0-0x0000000181776CC0
		public UnixDateTimeConverter(bool allowPreEpoch); // 0x0000000181776CC0-0x0000000181776CF0
		static UnixDateTimeConverter(); // 0x0000000181776C20-0x0000000181776CA0
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x0000000181776940-0x0000000181776C20
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x0000000181776460-0x0000000181776940
	}
}
