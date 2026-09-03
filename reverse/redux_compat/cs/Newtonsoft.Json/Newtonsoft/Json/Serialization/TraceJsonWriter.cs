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
	internal class TraceJsonWriter : JsonWriter // TypeDefIndex: 10260
	{
		// Fields
		private readonly JsonWriter _innerWriter; // 0x60
		private readonly JsonTextWriter _textWriter; // 0x68
		private readonly StringWriter _sw; // 0x70
	
		// Constructors
		public TraceJsonWriter(JsonWriter innerWriter); // 0x00000001817378C0-0x0000000181737AC0
	
		// Methods
		public string GetSerializedJsonMessage(); // 0x0000000181735DB0-0x0000000181735DE0
		public override void WriteValue(decimal value); // 0x00000001817366D0-0x0000000181736760
		public override void WriteValue(decimal? value); // 0x0000000181736970-0x0000000181736A30
		public override void WriteValue(bool value); // 0x0000000181736900-0x0000000181736970
		public override void WriteValue(bool? value); // 0x0000000181736B60-0x0000000181736BF0
		public override void WriteValue(byte value); // 0x0000000181736430-0x00000001817364A0
		public override void WriteValue(byte? value); // 0x0000000181736E70-0x0000000181736F00
		public override void WriteValue(char value); // 0x0000000181736AF0-0x0000000181736B60
		public override void WriteValue(char? value); // 0x0000000181736F00-0x0000000181736F90
		[NullableContext(2)]
		public override void WriteValue(byte[] value); // 0x00000001817376D0-0x0000000181737750
		public override void WriteValue(DateTime value); // 0x00000001817374C0-0x0000000181737530
		public override void WriteValue(DateTime? value); // 0x00000001817364A0-0x0000000181736540
		public override void WriteValue(DateTimeOffset value); // 0x0000000181736760-0x00000001817367F0
		public override void WriteValue(DateTimeOffset? value); // 0x0000000181736A30-0x0000000181736AF0
		public override void WriteValue(double value); // 0x00000001817367F0-0x0000000181736860
		public override void WriteValue(double? value); // 0x0000000181736CF0-0x0000000181736D90
		public override void WriteUndefined(); // 0x00000001817362D0-0x0000000181736330
		public override void WriteNull(); // 0x0000000181735F70-0x0000000181735FD0
		public override void WriteValue(float value); // 0x0000000181737190-0x0000000181737200
		public override void WriteValue(float? value); // 0x00000001817375D0-0x0000000181737660
		public override void WriteValue(Guid value); // 0x0000000181737030-0x00000001817370C0
		public override void WriteValue(Guid? value); // 0x0000000181737200-0x00000001817372C0
		public override void WriteValue(int value); // 0x0000000181736660-0x00000001817366D0
		public override void WriteValue(int? value); // 0x0000000181736330-0x00000001817363C0
		public override void WriteValue(long value); // 0x0000000181737330-0x00000001817373A0
		public override void WriteValue(long? value); // 0x0000000181736860-0x0000000181736900
		[NullableContext(2)]
		public override void WriteValue(object value); // 0x00000001817373A0-0x00000001817374C0
		public override void WriteValue(sbyte value); // 0x00000001817363C0-0x0000000181736430
		public override void WriteValue(sbyte? value); // 0x0000000181736540-0x00000001817365D0
		public override void WriteValue(short value); // 0x0000000181737750-0x00000001817377C0
		public override void WriteValue(short? value); // 0x00000001817365D0-0x0000000181736660
		[NullableContext(2)]
		public override void WriteValue(string value); // 0x0000000181736C80-0x0000000181736CF0
		public override void WriteValue(TimeSpan value); // 0x0000000181736D90-0x0000000181736E00
		public override void WriteValue(TimeSpan? value); // 0x0000000181736F90-0x0000000181737030
		public override void WriteValue(uint value); // 0x00000001817372C0-0x0000000181737330
		public override void WriteValue(uint? value); // 0x00000001817377C0-0x0000000181737850
		public override void WriteValue(ulong value); // 0x0000000181737660-0x00000001817376D0
		public override void WriteValue(ulong? value); // 0x0000000181737530-0x00000001817375D0
		[NullableContext(2)]
		public override void WriteValue(Uri value); // 0x00000001817370C0-0x0000000181737190
		public override void WriteValue(ushort value); // 0x0000000181736E00-0x0000000181736E70
		public override void WriteValue(ushort? value); // 0x0000000181736BF0-0x0000000181736C80
		public override void WriteWhitespace(string ws); // 0x0000000181737850-0x00000001817378C0
		[NullableContext(2)]
		public override void WriteComment(string text); // 0x0000000181735DE0-0x0000000181735E50
		public override void WriteStartArray(); // 0x00000001817361A0-0x0000000181736200
		public override void WriteEndArray(); // 0x0000000181735E50-0x0000000181735EB0
		public override void WriteStartConstructor(string name); // 0x0000000181736200-0x0000000181736270
		public override void WriteEndConstructor(); // 0x0000000181735EB0-0x0000000181735F10
		public override void WritePropertyName(string name); // 0x0000000181735FD0-0x0000000181736040
		public override void WritePropertyName(string name, bool escape); // 0x0000000181736040-0x00000001817360C0
		public override void WriteStartObject(); // 0x0000000181736270-0x00000001817362D0
		public override void WriteEndObject(); // 0x0000000181735F10-0x0000000181735F70
		[NullableContext(2)]
		public override void WriteRawValue(string json); // 0x00000001817360C0-0x0000000181736130
		[NullableContext(2)]
		public override void WriteRaw(string json); // 0x0000000181736130-0x00000001817361A0
		public override void Close(); // 0x0000000181735D00-0x0000000181735D60
		public override void Flush(); // 0x0000000181735D60-0x0000000181735DB0
	}
}
