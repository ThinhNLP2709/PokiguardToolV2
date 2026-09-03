/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
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
	public class IsoDateTimeConverter : DateTimeConverterBase // TypeDefIndex: 10384
	{
		// Fields
		private const string DefaultDateTimeFormat = "yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss.FFFFFFFK"; // Metadata: 0x006A0FBF
		private DateTimeStyles _dateTimeStyles; // 0x10
		[Nullable(2)]
		private string _dateTimeFormat; // 0x18
		[Nullable(2)]
		private CultureInfo _culture; // 0x20
	
		// Properties
		public DateTimeStyles DateTimeStyles { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		[Nullable(2)]
		public string DateTimeFormat { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x0000000181571840-0x0000000181571860 0x000000018175D080-0x000000018175D0D0
		public CultureInfo Culture { get; set; } // 0x000000018175D040-0x000000018175D080 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public IsoDateTimeConverter(); // 0x000000018175D030-0x000000018175D040
	
		// Methods
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x000000018175CD20-0x000000018175D030
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x000000018175C720-0x000000018175CD20
	}
}
