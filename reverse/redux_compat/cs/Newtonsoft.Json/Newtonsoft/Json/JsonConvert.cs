/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Xml;
using System.Xml.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public static class JsonConvert // TypeDefIndex: 9970
	{
		// Fields
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private static Func<JsonSerializerSettings> _DefaultSettings_k__BackingField; // 0x00
		public static readonly string True; // 0x08
		public static readonly string False; // 0x10
		public static readonly string Null; // 0x18
		public static readonly string Undefined; // 0x20
		public static readonly string PositiveInfinity; // 0x28
		public static readonly string NegativeInfinity; // 0x30
		public static readonly string NaN; // 0x38
	
		// Properties
		[Nullable(new byte[2] {2, 1 })]
		public static Func<JsonSerializerSettings> DefaultSettings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018169B7F0-0x000000018169B840 0x000000018169B840-0x000000018169B8B0
	
		// Constructors
		static JsonConvert(); // 0x000000018169B5F0-0x000000018169B7F0
	
		// Methods
		public static string ToString(DateTime value); // 0x000000018169B2B0-0x000000018169B310
		public static string ToString(DateTime value, DateFormatHandling format, DateTimeZoneHandling timeZoneHandling); // 0x000000018169AB30-0x000000018169AD00
		public static string ToString(DateTimeOffset value); // 0x000000018169B310-0x000000018169B370
		public static string ToString(DateTimeOffset value, DateFormatHandling format); // 0x000000018169A740-0x000000018169A920
		public static string ToString(bool value); // 0x000000018169AAA0-0x000000018169AB30
		public static string ToString(char value); // 0x0000000181699470-0x00000001816994E0
		public static string ToString(Enum value); // 0x000000018169B5A0-0x000000018169B5F0
		public static string ToString(int value); // 0x00000001816994E0-0x0000000181699520
		public static string ToString(short value); // 0x000000018169AD00-0x000000018169AD40
		[CLSCompliant(false)]
		public static string ToString(ushort value); // 0x000000018169AD40-0x000000018169AD80
		[CLSCompliant(false)]
		public static string ToString(uint value); // 0x000000018169AD80-0x000000018169ADC0
		public static string ToString(long value); // 0x000000018169B1C0-0x000000018169B200
		private static string ToStringInternal(BigInteger value); // 0x00000001816991D0-0x0000000181699250
		[CLSCompliant(false)]
		public static string ToString(ulong value); // 0x0000000181699430-0x0000000181699470
		public static string ToString(float value); // 0x000000018169A9F0-0x000000018169AAA0
		internal static string ToString(float value, FloatFormatHandling floatFormatHandling, char quoteChar, bool nullable); // 0x000000018169B070-0x000000018169B180
		private static string EnsureFloatFormat(double value, string text, FloatFormatHandling floatFormatHandling, char quoteChar, bool nullable); // 0x0000000181697DF0-0x0000000181697F40
		public static string ToString(double value); // 0x000000018169B200-0x000000018169B2B0
		internal static string ToString(double value, FloatFormatHandling floatFormatHandling, char quoteChar, bool nullable); // 0x000000018169B420-0x000000018169B510
		private static string EnsureDecimalPlace(double value, string text); // 0x0000000181697CC0-0x0000000181697D90
		private static string EnsureDecimalPlace(string text); // 0x0000000181697D90-0x0000000181697DF0
		public static string ToString(byte value); // 0x000000018169A700-0x000000018169A740
		[CLSCompliant(false)]
		public static string ToString(sbyte value); // 0x000000018169B180-0x000000018169B1C0
		public static string ToString(decimal value); // 0x0000000181699250-0x0000000181699340
		public static string ToString(Guid value); // 0x0000000181699340-0x0000000181699430
		internal static string ToString(Guid value, char quoteChar); // 0x000000018169B370-0x000000018169B420
		public static string ToString(TimeSpan value); // 0x000000018169AF40-0x000000018169B070
		internal static string ToString(TimeSpan value, char quoteChar); // 0x000000018169B510-0x000000018169B5A0
		public static string ToString([Nullable(2)] Uri value); // 0x000000018169ADC0-0x000000018169AF40
		internal static string ToString(Uri value, char quoteChar); // 0x000000018169A680-0x000000018169A700
		public static string ToString([Nullable(2)] string value); // 0x000000018169A920-0x000000018169A9F0
		public static string ToString([Nullable(2)] string value, char delimiter); // 0x000000018169A580-0x000000018169A680
		public static string ToString([Nullable(2)] string value, char delimiter, StringEscapeHandling stringEscapeHandling); // 0x000000018169A4A0-0x000000018169A580
		public static string ToString([Nullable(2)] object value); // 0x0000000181699520-0x000000018169A4A0
		[DebuggerStepThrough]
		public static string SerializeObject([Nullable(2)] object value); // 0x0000000181698630-0x00000001816986D0
		[DebuggerStepThrough]
		public static string SerializeObject([Nullable(2)] object value, Formatting formatting); // 0x00000001816986D0-0x00000001816987D0
		[DebuggerStepThrough]
		public static string SerializeObject([Nullable(2)] object value, params JsonConverter[] converters); // 0x0000000181698520-0x0000000181698630
		[DebuggerStepThrough]
		public static string SerializeObject([Nullable(2)] object value, Formatting formatting, params JsonConverter[] converters); // 0x0000000181698850-0x0000000181698930
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static string SerializeObject(object value, JsonSerializerSettings settings); // 0x0000000181698A00-0x0000000181698AC0
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static string SerializeObject(object value, Type type, JsonSerializerSettings settings); // 0x0000000181698490-0x0000000181698520
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static string SerializeObject(object value, Formatting formatting, JsonSerializerSettings settings); // 0x00000001816987D0-0x0000000181698850
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static string SerializeObject(object value, Type type, Formatting formatting, JsonSerializerSettings settings); // 0x0000000181698930-0x0000000181698A00
		private static string SerializeObjectInternal([Nullable(2)] object value, [Nullable(2)] Type type, JsonSerializer jsonSerializer); // 0x0000000181698280-0x0000000181698490
		[DebuggerStepThrough]
		public static object DeserializeObject(string value); // 0x00000001816972F0-0x0000000181697340
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, JsonSerializerSettings settings); // 0x0000000181696FF0-0x0000000181697050
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type); // 0x0000000181697340-0x00000001816973A0
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static T DeserializeObject<T>([Nullable(1)] string value);
		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject);
		[DebuggerStepThrough]
		public static T DeserializeAnonymousType<T>(string value, T anonymousTypeObject, JsonSerializerSettings settings);
		[DebuggerStepThrough]
		public static T DeserializeObject<T>(string value, params JsonConverter[] converters);
		[DebuggerStepThrough]
		[NullableContext(2)]
		public static T DeserializeObject<T>([Nullable(1)] string value, JsonSerializerSettings settings);
		[DebuggerStepThrough]
		public static object DeserializeObject(string value, Type type, params JsonConverter[] converters); // 0x0000000181696F20-0x0000000181696FF0
		[NullableContext(2)]
		public static object DeserializeObject([Nullable(1)] string value, Type type, JsonSerializerSettings settings); // 0x0000000181697050-0x00000001816972F0
		[DebuggerStepThrough]
		public static void PopulateObject(string value, object target); // 0x0000000181698220-0x0000000181698280
		public static void PopulateObject(string value, object target, [Nullable(2)] JsonSerializerSettings settings); // 0x0000000181697F40-0x0000000181698220
		public static string SerializeXmlNode([Nullable(2)] XmlNode node); // 0x0000000181698E80-0x0000000181698FB0
		public static string SerializeXmlNode([Nullable(2)] XmlNode node, Formatting formatting); // 0x00000001816990C0-0x00000001816991D0
		public static string SerializeXmlNode([Nullable(2)] XmlNode node, Formatting formatting, bool omitRootObject); // 0x0000000181698FB0-0x00000001816990C0
		public static XmlDocument DeserializeXmlNode(string value); // 0x0000000181697BD0-0x0000000181697C60
		[NullableContext(2)]
		public static XmlDocument DeserializeXmlNode([Nullable(1)] string value, string deserializeRootElementName); // 0x0000000181697C60-0x0000000181697CC0
		[NullableContext(2)]
		public static XmlDocument DeserializeXmlNode([Nullable(1)] string value, string deserializeRootElementName, bool writeArrayAttribute); // 0x0000000181697830-0x0000000181697A10
		[NullableContext(2)]
		public static XmlDocument DeserializeXmlNode([Nullable(1)] string value, string deserializeRootElementName, bool writeArrayAttribute, bool encodeSpecialCharacters); // 0x0000000181697A10-0x0000000181697BD0
		public static string SerializeXNode([Nullable(2)] XObject node); // 0x0000000181698AC0-0x0000000181698C30
		public static string SerializeXNode([Nullable(2)] XObject node, Formatting formatting); // 0x0000000181698D40-0x0000000181698E80
		public static string SerializeXNode([Nullable(2)] XObject node, Formatting formatting, bool omitRootObject); // 0x0000000181698C30-0x0000000181698D40
		public static XDocument DeserializeXNode(string value); // 0x00000001816977A0-0x0000000181697830
		[NullableContext(2)]
		public static XDocument DeserializeXNode([Nullable(1)] string value, string deserializeRootElementName); // 0x0000000181697580-0x00000001816975E0
		[NullableContext(2)]
		public static XDocument DeserializeXNode([Nullable(1)] string value, string deserializeRootElementName, bool writeArrayAttribute); // 0x00000001816973A0-0x0000000181697580
		[NullableContext(2)]
		public static XDocument DeserializeXNode([Nullable(1)] string value, string deserializeRootElementName, bool writeArrayAttribute, bool encodeSpecialCharacters); // 0x00000001816975E0-0x00000001816977A0
	}
}
