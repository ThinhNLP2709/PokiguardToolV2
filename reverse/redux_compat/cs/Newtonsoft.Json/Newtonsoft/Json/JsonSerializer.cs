/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Versioning;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public class JsonSerializer // TypeDefIndex: 9994
	{
		// Fields
		internal TypeNameHandling _typeNameHandling; // 0x10
		internal TypeNameAssemblyFormatHandling _typeNameAssemblyFormatHandling; // 0x14
		internal PreserveReferencesHandling _preserveReferencesHandling; // 0x18
		internal ReferenceLoopHandling _referenceLoopHandling; // 0x1C
		internal MissingMemberHandling _missingMemberHandling; // 0x20
		internal ObjectCreationHandling _objectCreationHandling; // 0x24
		internal NullValueHandling _nullValueHandling; // 0x28
		internal DefaultValueHandling _defaultValueHandling; // 0x2C
		internal ConstructorHandling _constructorHandling; // 0x30
		internal MetadataPropertyHandling _metadataPropertyHandling; // 0x34
		[Nullable(2)]
		internal JsonConverterCollection _converters; // 0x38
		internal IContractResolver _contractResolver; // 0x40
		[Nullable(2)]
		internal ITraceWriter _traceWriter; // 0x48
		[Nullable(2)]
		internal IEqualityComparer _equalityComparer; // 0x50
		internal ISerializationBinder _serializationBinder; // 0x58
		internal StreamingContext _context; // 0x60
		[Nullable(2)]
		private IReferenceResolver _referenceResolver; // 0x70
		private Formatting? _formatting; // 0x78
		private DateFormatHandling? _dateFormatHandling; // 0x80
		private DateTimeZoneHandling? _dateTimeZoneHandling; // 0x88
		private DateParseHandling? _dateParseHandling; // 0x90
		private FloatFormatHandling? _floatFormatHandling; // 0x98
		private FloatParseHandling? _floatParseHandling; // 0xA0
		private StringEscapeHandling? _stringEscapeHandling; // 0xA8
		private CultureInfo _culture; // 0xB0
		private int? _maxDepth; // 0xB8
		private bool _maxDepthSet; // 0xC0
		private bool? _checkAdditionalContent; // 0xC1
		[Nullable(2)]
		private string _dateFormatString; // 0xC8
		private bool _dateFormatStringSet; // 0xD0
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private EventHandler<ErrorEventArgs> Error; // 0xD8
	
		// Properties
		[Nullable(2)]
		public virtual IReferenceResolver ReferenceResolver { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001816A41A0-0x00000001816A4210 0x00000001816A60E0-0x00000001816A6170
		[Obsolete("Binder is obsolete. Use SerializationBinder instead.")]
		public virtual SerializationBinder Binder { get; set; } // 0x00000001816A55A0-0x00000001816A5690 0x00000001816A5910-0x00000001816A5A10
		public virtual ISerializationBinder SerializationBinder { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001816A6170-0x00000001816A6200
		[Nullable(2)]
		public virtual ITraceWriter TraceWriter { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		[Nullable(2)]
		public virtual IEqualityComparer EqualityComparer { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public virtual TypeNameHandling TypeNameHandling { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001816A6320-0x00000001816A6390
		[Obsolete("TypeNameAssemblyFormat is obsolete. Use TypeNameAssemblyFormatHandling instead.")]
		public virtual FormatterAssemblyStyle TypeNameAssemblyFormat { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x00000001816A62B0-0x00000001816A6320
		public virtual TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x00000001816A6240-0x00000001816A62B0
		public virtual PreserveReferencesHandling PreserveReferencesHandling { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x00000001816A6000-0x00000001816A6070
		public virtual ReferenceLoopHandling ReferenceLoopHandling { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x00000001816A6070-0x00000001816A60E0
		public virtual MissingMemberHandling MissingMemberHandling { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x00000001816A5EB0-0x00000001816A5F20
		public virtual NullValueHandling NullValueHandling { get; set; } // 0x0000000180377930-0x0000000180377940 0x00000001816A5F20-0x00000001816A5F90
		public virtual DefaultValueHandling DefaultValueHandling { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001816A5C80-0x00000001816A5CF0
		public virtual ObjectCreationHandling ObjectCreationHandling { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x00000001816A5F90-0x00000001816A6000
		public virtual ConstructorHandling ConstructorHandling { get; set; } // 0x000000018033D100-0x000000018033D110 0x00000001816A5A40-0x00000001816A5AB0
		public virtual MetadataPropertyHandling MetadataPropertyHandling { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x00000001816A5E40-0x00000001816A5EB0
		public virtual JsonConverterCollection Converters { get; } // 0x00000001816A56B0-0x00000001816A5740 
		public virtual IContractResolver ContractResolver { get; set; } // 0x0000000180377940-0x0000000180377950 0x00000001816A5AD0-0x00000001816A5B90
		public virtual StreamingContext Context { get; set; } // 0x00000001816A56A0-0x00000001816A56B0 0x00000001816A5AB0-0x00000001816A5AD0
		public virtual Formatting Formatting { get; set; } // 0x00000001816A5830-0x00000001816A5840 0x00000001816A5D70-0x00000001816A5DA0
		public virtual DateFormatHandling DateFormatHandling { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x00000001816A5B90-0x00000001816A5BD0
		public virtual DateTimeZoneHandling DateTimeZoneHandling { get; set; } // 0x00000001816A5810-0x00000001816A5830 0x00000001816A5C40-0x00000001816A5C80
		public virtual DateParseHandling DateParseHandling { get; set; } // 0x00000001816A57F0-0x00000001816A5810 0x00000001816A5C00-0x00000001816A5C40
		public virtual FloatParseHandling FloatParseHandling { get; set; } // 0x000000018033D210-0x000000018033D220 0x00000001816A5D30-0x00000001816A5D70
		public virtual FloatFormatHandling FloatFormatHandling { get; set; } // 0x000000018033D200-0x000000018033D210 0x00000001816A5CF0-0x00000001816A5D30
		public virtual StringEscapeHandling StringEscapeHandling { get; set; } // 0x000000018158AF80-0x000000018158AF90 0x00000001816A6200-0x00000001816A6240
		public virtual string DateFormatString { get; set; } // 0x00000001816A57B0-0x00000001816A57F0 0x00000001816A5BD0-0x00000001816A5C00
		public virtual CultureInfo Culture { get; set; } // 0x00000001816A5740-0x00000001816A57B0 0x00000001806C0C00-0x00000001806C0C20
		public virtual int? MaxDepth { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001816A5DA0-0x00000001816A5E40
		public virtual bool CheckAdditionalContent { get; set; } // 0x00000001816A5690-0x00000001816A56A0 0x00000001816A5A10-0x00000001816A5A40
	
		// Events
		[Nullable(new byte[2] {2, 1 })]
		public virtual event EventHandler<ErrorEventArgs> Error {
			add; // 0x00000001816A54D0-0x00000001816A55A0
			remove; // 0x00000001816A5840-0x00000001816A5910
		}
	
		// Constructors
		public JsonSerializer(); // 0x00000001816A5360-0x00000001816A54D0
	
		// Methods
		internal bool IsCheckAdditionalContentSet(); // 0x00000001816A4210-0x00000001816A4220
		public static JsonSerializer Create(); // 0x00000001816A39C0-0x00000001816A3B60
		public static JsonSerializer Create([Nullable(2)] JsonSerializerSettings settings); // 0x00000001816A3800-0x00000001816A39C0
		public static JsonSerializer CreateDefault(); // 0x00000001816A34E0-0x00000001816A3730
		public static JsonSerializer CreateDefault([Nullable(2)] JsonSerializerSettings settings); // 0x00000001816A3730-0x00000001816A3770
		private static void ApplySerializerSettings(JsonSerializer serializer, JsonSerializerSettings settings); // 0x00000001816A2E00-0x00000001816A34E0
		[DebuggerStepThrough]
		public void Populate(TextReader reader, object target); // 0x00000001816A4520-0x00000001816A4690
		[DebuggerStepThrough]
		public void Populate(JsonReader reader, object target); // 0x00000001816A4500-0x00000001816A4520
		internal virtual void PopulateInternal(JsonReader reader, object target); // 0x00000001816A4220-0x00000001816A4500
		[DebuggerStepThrough]
		public object Deserialize(JsonReader reader); // 0x00000001816A3E50-0x00000001816A3E70
		[DebuggerStepThrough]
		public object Deserialize(TextReader reader, Type objectType); // 0x00000001816A3E90-0x00000001816A4000
		[DebuggerStepThrough]
		[NullableContext(2)]
		public T Deserialize<T>([Nullable(1)] JsonReader reader);
		[DebuggerStepThrough]
		[NullableContext(2)]
		public object Deserialize([Nullable(1)] JsonReader reader, Type objectType); // 0x00000001816A3E70-0x00000001816A3E90
		[NullableContext(2)]
		internal virtual object DeserializeInternal([Nullable(1)] JsonReader reader, Type objectType); // 0x00000001816A3B60-0x00000001816A3E50
		[NullableContext(2)]
		internal void SetupReader([Nullable(1)] JsonReader reader, out CultureInfo previousCulture, out DateTimeZoneHandling? previousDateTimeZoneHandling, out DateParseHandling? previousDateParseHandling, out FloatParseHandling? previousFloatParseHandling, out int? previousMaxDepth, out string previousDateFormatString); // 0x00000001816A4FB0-0x00000001816A5360
		[NullableContext(2)]
		private void ResetReader([Nullable(1)] JsonReader reader, CultureInfo previousCulture, DateTimeZoneHandling? previousDateTimeZoneHandling, DateParseHandling? previousDateParseHandling, FloatParseHandling? previousFloatParseHandling, int? previousMaxDepth, string previousDateFormatString); // 0x00000001816A4690-0x00000001816A4950
		public void Serialize(TextWriter textWriter, [Nullable(2)] object value); // 0x00000001816A4EF0-0x00000001816A4F80
		[NullableContext(2)]
		public void Serialize([Nullable(1)] JsonWriter jsonWriter, object value, Type objectType); // 0x00000001816A4ED0-0x00000001816A4EF0
		public void Serialize(TextWriter textWriter, [Nullable(2)] object value, Type objectType); // 0x00000001816A4E30-0x00000001816A4ED0
		public void Serialize(JsonWriter jsonWriter, [Nullable(2)] object value); // 0x00000001816A4F80-0x00000001816A4FB0
		private TraceJsonReader CreateTraceJsonReader(JsonReader reader); // 0x00000001816A3770-0x00000001816A3800
		[NullableContext(2)]
		internal virtual void SerializeInternal([Nullable(1)] JsonWriter jsonWriter, object value, Type objectType); // 0x00000001816A4950-0x00000001816A4E30
		internal IReferenceResolver GetReferenceResolver(); // 0x00000001816A41A0-0x00000001816A4210
		internal JsonConverter GetMatchingConverter(Type type); // 0x00000001816A4000-0x00000001816A40D0
		internal static JsonConverter GetMatchingConverter([Nullable(new byte[2] {2, 1 })] IList<JsonConverter> converters, Type objectType); // 0x00000001816A40D0-0x00000001816A41A0
		internal void OnError(ErrorEventArgs e); // 0x000000018136F320-0x000000018136F350
	}
}
