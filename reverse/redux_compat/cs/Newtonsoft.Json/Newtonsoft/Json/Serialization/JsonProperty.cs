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

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(2)]
	public class JsonProperty // TypeDefIndex: 10235
	{
		// Fields
		internal Required? _required; // 0x10
		internal bool _hasExplicitDefaultValue; // 0x18
		private object _defaultValue; // 0x20
		private bool _hasGeneratedDefaultValue; // 0x28
		private string _propertyName; // 0x30
		internal bool _skipPropertyNameEscape; // 0x38
		private Type _propertyType; // 0x40
		[CompilerGenerated]
		private JsonContract _PropertyContract_k__BackingField; // 0x48
		[CompilerGenerated]
		private Type _DeclaringType_k__BackingField; // 0x50
		[CompilerGenerated]
		private int? _Order_k__BackingField; // 0x58
		[CompilerGenerated]
		private string _UnderlyingName_k__BackingField; // 0x60
		[CompilerGenerated]
		private IValueProvider _ValueProvider_k__BackingField; // 0x68
		[CompilerGenerated]
		private IAttributeProvider _AttributeProvider_k__BackingField; // 0x70
		[CompilerGenerated]
		private JsonConverter _Converter_k__BackingField; // 0x78
		[CompilerGenerated]
		private bool _Ignored_k__BackingField; // 0x80
		[CompilerGenerated]
		private bool _Readable_k__BackingField; // 0x81
		[CompilerGenerated]
		private bool _Writable_k__BackingField; // 0x82
		[CompilerGenerated]
		private bool _HasMemberAttribute_k__BackingField; // 0x83
		[CompilerGenerated]
		private bool? _IsReference_k__BackingField; // 0x84
		[CompilerGenerated]
		private NullValueHandling? _NullValueHandling_k__BackingField; // 0x88
		[CompilerGenerated]
		private DefaultValueHandling? _DefaultValueHandling_k__BackingField; // 0x90
		[CompilerGenerated]
		private ReferenceLoopHandling? _ReferenceLoopHandling_k__BackingField; // 0x98
		[CompilerGenerated]
		private ObjectCreationHandling? _ObjectCreationHandling_k__BackingField; // 0xA0
		[CompilerGenerated]
		private TypeNameHandling? _TypeNameHandling_k__BackingField; // 0xA8
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private Predicate<object> _ShouldSerialize_k__BackingField; // 0xB0
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private Predicate<object> _ShouldDeserialize_k__BackingField; // 0xB8
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private Predicate<object> _GetIsSpecified_k__BackingField; // 0xC0
		[CompilerGenerated]
		[Nullable(new byte[3] {2, 1, 2 })]
		private Action<object, object> _SetIsSpecified_k__BackingField; // 0xC8
		[CompilerGenerated]
		private JsonConverter _ItemConverter_k__BackingField; // 0xD0
		[CompilerGenerated]
		private bool? _ItemIsReference_k__BackingField; // 0xD8
		[CompilerGenerated]
		private TypeNameHandling? _ItemTypeNameHandling_k__BackingField; // 0xDC
		[CompilerGenerated]
		private ReferenceLoopHandling? _ItemReferenceLoopHandling_k__BackingField; // 0xE4
	
		// Properties
		internal JsonContract PropertyContract { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public string PropertyName { get; set; } // 0x000000018031E110-0x000000018031E120 0x000000018170D440-0x000000018170D4D0
		public Type DeclaringType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public int? Order { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F4000-0x00000001802F4010 0x000000018044C5A0-0x000000018044C5B0
		public string UnderlyingName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public IValueProvider ValueProvider { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public IAttributeProvider AttributeProvider { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public Type PropertyType { get; set; } // 0x0000000180377940-0x0000000180377950 0x000000018170D4D0-0x000000018170D540
		public JsonConverter Converter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		[Obsolete("MemberConverter is obsolete. Use Converter instead.")]
		public JsonConverter MemberConverter { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public bool Ignored { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D340-0x000000018170D350 0x00000001812500E0-0x00000001812500F0
		public bool Readable { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D390-0x000000018170D3A0 0x000000018170D540-0x000000018170D550
		public bool Writable { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816BD430-0x00000001816BD440 0x00000001816BD5E0-0x00000001816BD5F0
		public bool HasMemberAttribute { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D330-0x000000018170D340 0x000000018170D3D0-0x000000018170D3E0
		public object DefaultValue { get; set; } // 0x000000018170D320-0x000000018170D330 0x000000018170D3B0-0x000000018170D3D0
		public Required Required { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x000000018169C750-0x000000018169C780
		public bool IsRequiredSpecified { get; } // 0x00000001805625D0-0x00000001805625E0 
		public bool? IsReference { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D350-0x000000018170D360 0x000000018170D3E0-0x000000018170D3F0
		public NullValueHandling? NullValueHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018038B8A0-0x000000018038B8B0 0x000000018170D420-0x000000018170D430
		public DefaultValueHandling? DefaultValueHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x000000018170D3A0-0x000000018170D3B0
		public ReferenceLoopHandling? ReferenceLoopHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x000000018170D550-0x000000018170D560
		public ObjectCreationHandling? ObjectCreationHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805B5990-0x00000001805B59A0 0x000000018170D430-0x000000018170D440
		public TypeNameHandling? TypeNameHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018170D560-0x000000018170D570
		[Nullable(new byte[2] {2, 1 })]
		public Predicate<object> ShouldSerialize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
		[Nullable(new byte[2] {2, 1 })]
		public Predicate<object> ShouldDeserialize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		[Nullable(new byte[2] {2, 1 })]
		public Predicate<object> GetIsSpecified { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
		[Nullable(new byte[3] {2, 1, 2 })]
		public Action<object, object> SetIsSpecified { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
		public JsonConverter ItemConverter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001806CCD80-0x00000001806CCDA0
		public bool? ItemIsReference { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D360-0x000000018170D370 0x000000018170D3F0-0x000000018170D400
		public TypeNameHandling? ItemTypeNameHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D380-0x000000018170D390 0x000000018170D410-0x000000018170D420
		public ReferenceLoopHandling? ItemReferenceLoopHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170D370-0x000000018170D380 0x000000018170D400-0x000000018170D410
	
		// Constructors
		public JsonProperty(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal object GetResolvedDefaultValue(); // 0x000000018170D1F0-0x000000018170D2A0
		[NullableContext(1)]
		public override string ToString(); // 0x000000018170D2A0-0x000000018170D2C0
		[NullableContext(1)]
		internal void WritePropertyName(JsonWriter writer); // 0x000000018170D2C0-0x000000018170D320
	}
}
