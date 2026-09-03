/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class JsonSerializerProxy : JsonSerializer // TypeDefIndex: 10245
	{
		// Fields
		[Nullable(2)]
		private readonly JsonSerializerInternalReader _serializerReader; // 0xE0
		[Nullable(2)]
		private readonly JsonSerializerInternalWriter _serializerWriter; // 0xE8
		internal readonly JsonSerializer _serializer; // 0xF0
	
		// Properties
		[Nullable(2)]
		public override IReferenceResolver ReferenceResolver { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x0000000181732B20-0x0000000181732B50 0x00000001817330D0-0x0000000181733100
		[Nullable(2)]
		public override ITraceWriter TraceWriter { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x0000000181732BB0-0x0000000181732BE0 0x0000000181733160-0x0000000181733190
		[Nullable(2)]
		public override IEqualityComparer EqualityComparer { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x0000000181732910-0x0000000181732940 0x0000000181732EC0-0x0000000181732EF0
		public override JsonConverterCollection Converters { get; } // 0x00000001817327C0-0x00000001817327F0 
		public override DefaultValueHandling DefaultValueHandling { get; set; } // 0x00000001817328E0-0x0000000181732910 0x0000000181732E90-0x0000000181732EC0
		public override IContractResolver ContractResolver { get; set; } // 0x0000000181732790-0x00000001817327C0 0x0000000181732D70-0x0000000181732DA0
		public override MissingMemberHandling MissingMemberHandling { get; set; } // 0x0000000181732A30-0x0000000181732A60 0x0000000181732FE0-0x0000000181733010
		public override NullValueHandling NullValueHandling { get; set; } // 0x0000000181732A60-0x0000000181732A90 0x0000000181733010-0x0000000181733040
		public override ObjectCreationHandling ObjectCreationHandling { get; set; } // 0x0000000181732A90-0x0000000181732AC0 0x0000000181733040-0x0000000181733070
		public override ReferenceLoopHandling ReferenceLoopHandling { get; set; } // 0x0000000181732AF0-0x0000000181732B20 0x00000001817330A0-0x00000001817330D0
		public override PreserveReferencesHandling PreserveReferencesHandling { get; set; } // 0x0000000181732AC0-0x0000000181732AF0 0x0000000181733070-0x00000001817330A0
		public override TypeNameHandling TypeNameHandling { get; set; } // 0x0000000181732C40-0x0000000181732C70 0x00000001817331F0-0x0000000181733220
		public override MetadataPropertyHandling MetadataPropertyHandling { get; set; } // 0x0000000181732A00-0x0000000181732A30 0x0000000181732FB0-0x0000000181732FE0
		[Obsolete("TypeNameAssemblyFormat is obsolete. Use TypeNameAssemblyFormatHandling instead.")]
		public override FormatterAssemblyStyle TypeNameAssemblyFormat { get; set; } // 0x0000000181732C10-0x0000000181732C40 0x00000001817331C0-0x00000001817331F0
		public override TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling { get; set; } // 0x0000000181732BE0-0x0000000181732C10 0x0000000181733190-0x00000001817331C0
		public override ConstructorHandling ConstructorHandling { get; set; } // 0x0000000181732710-0x0000000181732740 0x0000000181732D00-0x0000000181732D30
		[Obsolete("Binder is obsolete. Use SerializationBinder instead.")]
		public override SerializationBinder Binder { get; set; } // 0x00000001817326B0-0x00000001817326E0 0x0000000181732CA0-0x0000000181732CD0
		public override ISerializationBinder SerializationBinder { get; set; } // 0x0000000181732B50-0x0000000181732B80 0x0000000181733100-0x0000000181733130
		public override StreamingContext Context { get; set; } // 0x0000000181732740-0x0000000181732790 0x0000000181732D30-0x0000000181732D70
		public override Formatting Formatting { get; set; } // 0x00000001817329A0-0x00000001817329D0 0x0000000181732F50-0x0000000181732F80
		public override DateFormatHandling DateFormatHandling { get; set; } // 0x0000000181732820-0x0000000181732850 0x0000000181732DD0-0x0000000181732E00
		public override DateTimeZoneHandling DateTimeZoneHandling { get; set; } // 0x00000001817328B0-0x00000001817328E0 0x0000000181732E60-0x0000000181732E90
		public override DateParseHandling DateParseHandling { get; set; } // 0x0000000181732880-0x00000001817328B0 0x0000000181732E30-0x0000000181732E60
		public override FloatFormatHandling FloatFormatHandling { get; set; } // 0x0000000181732940-0x0000000181732970 0x0000000181732EF0-0x0000000181732F20
		public override FloatParseHandling FloatParseHandling { get; set; } // 0x0000000181732970-0x00000001817329A0 0x0000000181732F20-0x0000000181732F50
		public override StringEscapeHandling StringEscapeHandling { get; set; } // 0x0000000181732B80-0x0000000181732BB0 0x0000000181733130-0x0000000181733160
		public override string DateFormatString { get; set; } // 0x0000000181732850-0x0000000181732880 0x0000000181732E00-0x0000000181732E30
		public override CultureInfo Culture { get; set; } // 0x00000001817327F0-0x0000000181732820 0x0000000181732DA0-0x0000000181732DD0
		public override int? MaxDepth { get; set; } // 0x00000001817329D0-0x0000000181732A00 0x0000000181732F80-0x0000000181732FB0
		public override bool CheckAdditionalContent { get; set; } // 0x00000001817326E0-0x0000000181732710 0x0000000181732CD0-0x0000000181732D00
	
		// Events
		[Nullable(new byte[2] {2, 1 })]
		public override event EventHandler<ErrorEventArgs> Error {
			add; // 0x0000000181732680-0x00000001817326B0
			remove; // 0x0000000181732C70-0x0000000181732CA0
		}
	
		// Constructors
		public JsonSerializerProxy(JsonSerializerInternalReader serializerReader); // 0x00000001817325F0-0x0000000181732680
		public JsonSerializerProxy(JsonSerializerInternalWriter serializerWriter); // 0x0000000181732560-0x00000001817325F0
	
		// Methods
		internal JsonSerializerInternalBase GetInternalSerializer(); // 0x00000001817324A0-0x00000001817324C0
		[NullableContext(2)]
		internal override object DeserializeInternal([Nullable(1)] JsonReader reader, Type objectType); // 0x0000000181732450-0x00000001817324A0
		internal override void PopulateInternal(JsonReader reader, object target); // 0x00000001817324C0-0x0000000181732510
		[NullableContext(2)]
		internal override void SerializeInternal([Nullable(1)] JsonWriter jsonWriter, object value, Type rootType); // 0x0000000181732510-0x0000000181732560
	}
}
