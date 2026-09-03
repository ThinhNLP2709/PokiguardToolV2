/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
	[NullableContext(2)]
	public class JsonSerializerSettings // TypeDefIndex: 9995
	{
		// Fields
		internal const ReferenceLoopHandling DefaultReferenceLoopHandling = ReferenceLoopHandling.Error; // Metadata: 0x006A05EF
		internal const MissingMemberHandling DefaultMissingMemberHandling = MissingMemberHandling.Ignore; // Metadata: 0x006A05F0
		internal const NullValueHandling DefaultNullValueHandling = NullValueHandling.Include; // Metadata: 0x006A05F1
		internal const DefaultValueHandling DefaultDefaultValueHandling = DefaultValueHandling.Include; // Metadata: 0x006A05F2
		internal const ObjectCreationHandling DefaultObjectCreationHandling = ObjectCreationHandling.Auto; // Metadata: 0x006A05F3
		internal const PreserveReferencesHandling DefaultPreserveReferencesHandling = PreserveReferencesHandling.None; // Metadata: 0x006A05F4
		internal const ConstructorHandling DefaultConstructorHandling = ConstructorHandling.Default; // Metadata: 0x006A05F5
		internal const TypeNameHandling DefaultTypeNameHandling = TypeNameHandling.None; // Metadata: 0x006A05F6
		internal const MetadataPropertyHandling DefaultMetadataPropertyHandling = MetadataPropertyHandling.Default; // Metadata: 0x006A05F7
		internal static readonly StreamingContext DefaultContext; // 0x00
		internal const Formatting DefaultFormatting = Formatting.None; // Metadata: 0x006A05F8
		internal const DateFormatHandling DefaultDateFormatHandling = DateFormatHandling.IsoDateFormat; // Metadata: 0x006A05F9
		internal const DateTimeZoneHandling DefaultDateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind; // Metadata: 0x006A05FA
		internal const DateParseHandling DefaultDateParseHandling = DateParseHandling.DateTime; // Metadata: 0x006A05FB
		internal const FloatParseHandling DefaultFloatParseHandling = FloatParseHandling.Double; // Metadata: 0x006A05FC
		internal const FloatFormatHandling DefaultFloatFormatHandling = FloatFormatHandling.String; // Metadata: 0x006A05FD
		internal const StringEscapeHandling DefaultStringEscapeHandling = StringEscapeHandling.Default; // Metadata: 0x006A05FE
		internal const TypeNameAssemblyFormatHandling DefaultTypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple; // Metadata: 0x006A05FF
		[Nullable(1)]
		internal static readonly CultureInfo DefaultCulture; // 0x10
		internal const bool DefaultCheckAdditionalContent = false; // Metadata: 0x006A0600
		[Nullable(1)]
		internal const string DefaultDateFormatString = "yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss.FFFFFFFK"; // Metadata: 0x006A0601
		internal const int DefaultMaxDepth = 64; // Metadata: 0x006A0628
		internal Formatting? _formatting; // 0x10
		internal DateFormatHandling? _dateFormatHandling; // 0x18
		internal DateTimeZoneHandling? _dateTimeZoneHandling; // 0x20
		internal DateParseHandling? _dateParseHandling; // 0x28
		internal FloatFormatHandling? _floatFormatHandling; // 0x30
		internal FloatParseHandling? _floatParseHandling; // 0x38
		internal StringEscapeHandling? _stringEscapeHandling; // 0x40
		internal CultureInfo _culture; // 0x48
		internal bool? _checkAdditionalContent; // 0x50
		internal int? _maxDepth; // 0x54
		internal bool _maxDepthSet; // 0x5C
		internal string _dateFormatString; // 0x60
		internal bool _dateFormatStringSet; // 0x68
		internal TypeNameAssemblyFormatHandling? _typeNameAssemblyFormatHandling; // 0x6C
		internal DefaultValueHandling? _defaultValueHandling; // 0x74
		internal PreserveReferencesHandling? _preserveReferencesHandling; // 0x7C
		internal NullValueHandling? _nullValueHandling; // 0x84
		internal ObjectCreationHandling? _objectCreationHandling; // 0x8C
		internal MissingMemberHandling? _missingMemberHandling; // 0x94
		internal ReferenceLoopHandling? _referenceLoopHandling; // 0x9C
		internal StreamingContext? _context; // 0xA8
		internal ConstructorHandling? _constructorHandling; // 0xC0
		internal TypeNameHandling? _typeNameHandling; // 0xC8
		internal MetadataPropertyHandling? _metadataPropertyHandling; // 0xD0
		[CompilerGenerated]
		[Nullable(1)]
		private IList<JsonConverter> _Converters_k__BackingField; // 0xD8
		[CompilerGenerated]
		private IContractResolver _ContractResolver_k__BackingField; // 0xE0
		[CompilerGenerated]
		private IEqualityComparer _EqualityComparer_k__BackingField; // 0xE8
		[CompilerGenerated]
		private Func<IReferenceResolver> _ReferenceResolverProvider_k__BackingField; // 0xF0
		[CompilerGenerated]
		private ITraceWriter _TraceWriter_k__BackingField; // 0xF8
		[CompilerGenerated]
		private ISerializationBinder _SerializationBinder_k__BackingField; // 0x100
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private EventHandler<ErrorEventArgs> _Error_k__BackingField; // 0x108
	
		// Properties
		public ReferenceLoopHandling ReferenceLoopHandling { get; set; } // 0x000000018033D1F0-0x000000018033D200 0x00000001816A2C30-0x00000001816A2C70
		public MissingMemberHandling MissingMemberHandling { get; set; } // 0x000000018033D1D0-0x000000018033D1E0 0x00000001816A2B70-0x00000001816A2BB0
		public ObjectCreationHandling ObjectCreationHandling { get; set; } // 0x000000018169CBC0-0x000000018169CBD0 0x00000001816A2BF0-0x00000001816A2C30
		public NullValueHandling NullValueHandling { get; set; } // 0x000000018033D620-0x000000018033D630 0x00000001816A2BB0-0x00000001816A2BF0
		public DefaultValueHandling DefaultValueHandling { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x000000018169BB90-0x000000018169BBC0
		[Nullable(1)]
		public IList<JsonConverter> Converters { [NullableContext(1)] [CompilerGenerated] get; [NullableContext(1)] [CompilerGenerated] set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x00000001806CCE00-0x00000001806CCE20
		public PreserveReferencesHandling PreserveReferencesHandling { get; set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x000000018169BB60-0x000000018169BB90
		public TypeNameHandling TypeNameHandling { get; set; } // 0x00000001816A28D0-0x00000001816A28E0 0x00000001816A2DC0-0x00000001816A2E00
		public MetadataPropertyHandling MetadataPropertyHandling { get; set; } // 0x0000000180CC3A00-0x0000000180CC3A10 0x00000001816A2B30-0x00000001816A2B70
		[Obsolete("TypeNameAssemblyFormat is obsolete. Use TypeNameAssemblyFormatHandling instead.")]
		public FormatterAssemblyStyle TypeNameAssemblyFormat { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x000000018169BBC0-0x000000018169BBF0
		public TypeNameAssemblyFormatHandling TypeNameAssemblyFormatHandling { get; set; } // 0x0000000180CC2260-0x0000000180CC2270 0x000000018169BBC0-0x000000018169BBF0
		public ConstructorHandling ConstructorHandling { get; set; } // 0x0000000180CC3970-0x0000000180CC3980 0x00000001816A29A0-0x00000001816A29E0
		public IContractResolver ContractResolver { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001806CCDC0-0x00000001806CCDE0
		public IEqualityComparer EqualityComparer { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		[Obsolete("ReferenceResolver property is obsolete. Use the ReferenceResolverProvider property to set the IReferenceResolver: settings.ReferenceResolverProvider = () => resolver")]
		public IReferenceResolver ReferenceResolver { get; set; } // 0x00000001816A28A0-0x00000001816A28C0 0x00000001816A2C70-0x00000001816A2D50
		public Func<IReferenceResolver> ReferenceResolverProvider { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CC3740-0x0000000180CC3750 0x0000000180CC3C60-0x0000000180CC3C80
		public ITraceWriter TraceWriter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001816A2DA0-0x00000001816A2DC0
		[Obsolete("Binder is obsolete. Use SerializationBinder instead.")]
		public SerializationBinder Binder { get; set; } // 0x00000001816A2620-0x00000001816A26E0 0x00000001816A28E0-0x00000001816A2970
		public ISerializationBinder SerializationBinder { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001816A2D50-0x00000001816A2D70
		[Nullable(new byte[2] {2, 1 })]
		public EventHandler<ErrorEventArgs> Error { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		public StreamingContext Context { get; set; } // 0x00000001816A26E0-0x00000001816A2780 0x00000001816A29E0-0x00000001816A2A40
		[Nullable(1)]
		public string DateFormatString { [NullableContext(1)] get; [NullableContext(1)] set; } // 0x00000001816A27E0-0x00000001816A2820 0x00000001816A2A40-0x00000001816A2A60
		public int? MaxDepth { get; set; } // 0x00000001816A2860-0x00000001816A28A0 0x00000001816A2A90-0x00000001816A2B30
		public Formatting Formatting { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x000000018169C750-0x000000018169C780
		public DateFormatHandling DateFormatHandling { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x000000018169C660-0x000000018169C690
		public DateTimeZoneHandling DateTimeZoneHandling { get; set; } // 0x00000001816A2840-0x00000001816A2860 0x000000018169C7E0-0x000000018169C810
		public DateParseHandling DateParseHandling { get; set; } // 0x00000001816A2820-0x00000001816A2840 0x000000018169C780-0x000000018169C7B0
		public FloatFormatHandling FloatFormatHandling { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018169C810-0x000000018169C840
		public FloatParseHandling FloatParseHandling { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001816A2A60-0x00000001816A2A90
		public StringEscapeHandling StringEscapeHandling { get; set; } // 0x000000018033D780-0x000000018033D790 0x00000001816A2D70-0x00000001816A2DA0
		[Nullable(1)]
		public CultureInfo Culture { [NullableContext(1)] get; [NullableContext(1)] set; } // 0x00000001816A2780-0x00000001816A27E0 0x00000001803780C0-0x00000001803780D0
		public bool CheckAdditionalContent { get; set; } // 0x00000001802F4040-0x00000001802F4050 0x00000001816A2970-0x00000001816A29A0
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass93_0 // TypeDefIndex: 9996
		{
			// Fields
			[Nullable(0)]
			public IReferenceResolver value; // 0x10
	
			// Constructors
			public __c__DisplayClass93_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IReferenceResolver _set_ReferenceResolver_b__0(); // 0x0000000180377550-0x0000000180377560
		}
	
		// Constructors
		static JsonSerializerSettings(); // 0x00000001816A22E0-0x00000001816A2360
		[DebuggerStepThrough]
		public JsonSerializerSettings(); // 0x00000001816A25A0-0x00000001816A2620
		[NullableContext(1)]
		public JsonSerializerSettings(JsonSerializerSettings original); // 0x00000001816A2360-0x00000001816A25A0
	}
}
