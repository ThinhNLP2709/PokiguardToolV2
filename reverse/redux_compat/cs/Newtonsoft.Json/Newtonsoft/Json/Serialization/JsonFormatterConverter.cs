/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class JsonFormatterConverter : IFormatterConverter // TypeDefIndex: 10230
	{
		// Fields
		private readonly JsonSerializerInternalReader _reader; // 0x10
		private readonly JsonISerializableContract _contract; // 0x18
		[Nullable(2)]
		private readonly JsonProperty _member; // 0x20
	
		// Constructors
		public JsonFormatterConverter(JsonSerializerInternalReader reader, JsonISerializableContract contract, [Nullable(2)] JsonProperty member); // 0x000000018170BF20-0x000000018170C060
	
		// Methods
		private T GetTokenValue<T>(object value);
		public object Convert(object value, Type type); // 0x000000018170B8E0-0x000000018170BA50
		public object Convert(object value, TypeCode typeCode); // 0x000000018170B7C0-0x000000018170B8E0
		public bool ToBoolean(object value); // 0x000000018170BA50-0x000000018170BAA0
		public byte ToByte(object value); // 0x000000018170BAA0-0x000000018170BAF0
		public char ToChar(object value); // 0x000000018170BAF0-0x000000018170BB40
		public DateTime ToDateTime(object value); // 0x000000018170BB40-0x000000018170BB90
		public decimal ToDecimal(object value); // 0x000000018170BB90-0x000000018170BC00
		public double ToDouble(object value); // 0x000000018170BC00-0x000000018170BC50
		public short ToInt16(object value); // 0x000000018170BC50-0x000000018170BCA0
		public int ToInt32(object value); // 0x000000018170BCA0-0x000000018170BCF0
		public long ToInt64(object value); // 0x000000018170BCF0-0x000000018170BD40
		public sbyte ToSByte(object value); // 0x000000018170BD40-0x000000018170BD90
		public float ToSingle(object value); // 0x000000018170BD90-0x000000018170BDE0
		public string ToString(object value); // 0x000000018170BDE0-0x000000018170BE30
		public ushort ToUInt16(object value); // 0x000000018170BE30-0x000000018170BE80
		public uint ToUInt32(object value); // 0x000000018170BE80-0x000000018170BED0
		public ulong ToUInt64(object value); // 0x000000018170BED0-0x000000018170BF20
	}
}
