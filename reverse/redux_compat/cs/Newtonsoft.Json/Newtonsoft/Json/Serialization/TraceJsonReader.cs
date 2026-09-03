/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class TraceJsonReader : JsonReader, IJsonLineInfo // TypeDefIndex: 10259
	{
		// Fields
		private readonly JsonReader _innerReader; // 0x78
		private readonly JsonTextWriter _textWriter; // 0x80
		private readonly StringWriter _sw; // 0x88
	
		// Properties
		public override int Depth { get; } // 0x00000001816CFDF0-0x00000001816CFE20 
		public override string Path { get; } // 0x00000001816CFE20-0x00000001816CFE50 
		public override char QuoteChar { get; protected internal set; } // 0x00000001816CFE50-0x00000001816CFE80 0x0000000181735CD0-0x0000000181735D00
		public override JsonToken TokenType { get; } // 0x00000001816CFE80-0x00000001816CFEB0 
		[Nullable(2)]
		public override object Value { [NullableContext(2)] get; } // 0x00000001816CFEE0-0x00000001816CFF10 
		[Nullable(2)]
		public override Type ValueType { [NullableContext(2)] get; } // 0x00000001816CFEB0-0x00000001816CFEE0 
		int IJsonLineInfo.LineNumber { get; } // 0x00000001817355C0-0x0000000181735620 
		int IJsonLineInfo.LinePosition { get; } // 0x0000000181735620-0x0000000181735680 
	
		// Constructors
		public TraceJsonReader(JsonReader innerReader); // 0x0000000181735B70-0x0000000181735CD0
	
		// Methods
		public string GetDeserializedJsonMessage(); // 0x0000000181735530-0x0000000181735560
		public override bool Read(); // 0x0000000181735AA0-0x0000000181735B20
		public override int? ReadAsInt32(); // 0x00000001817359A0-0x0000000181735A20
		[NullableContext(2)]
		public override string ReadAsString(); // 0x0000000181735A20-0x0000000181735AA0
		[NullableContext(2)]
		public override byte[] ReadAsBytes(); // 0x0000000181735700-0x0000000181735780
		public override decimal? ReadAsDecimal(); // 0x0000000181735890-0x0000000181735920
		public override double? ReadAsDouble(); // 0x0000000181735920-0x00000001817359A0
		public override bool? ReadAsBoolean(); // 0x0000000181735680-0x0000000181735700
		public override DateTime? ReadAsDateTime(); // 0x0000000181735810-0x0000000181735890
		public override DateTimeOffset? ReadAsDateTimeOffset(); // 0x0000000181735780-0x0000000181735810
		public void WriteCurrentToken(); // 0x0000000181735B20-0x0000000181735B70
		public override void Close(); // 0x0000000181735500-0x0000000181735530
		bool IJsonLineInfo.HasLineInfo(); // 0x0000000181735560-0x00000001817355C0
	}
}
