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
	public class JsonObjectContract : JsonContainerContract // TypeDefIndex: 10233
	{
		// Fields
		[CompilerGenerated]
		private MemberSerialization _MemberSerialization_k__BackingField; // 0xC0
		[CompilerGenerated]
		private MissingMemberHandling? _MissingMemberHandling_k__BackingField; // 0xC4
		[CompilerGenerated]
		private Required? _ItemRequired_k__BackingField; // 0xCC
		[CompilerGenerated]
		private NullValueHandling? _ItemNullValueHandling_k__BackingField; // 0xD4
		[CompilerGenerated]
		[Nullable(1)]
		private readonly JsonPropertyCollection _Properties_k__BackingField; // 0xE0
		[CompilerGenerated]
		private ExtensionDataSetter _ExtensionDataSetter_k__BackingField; // 0xE8
		[CompilerGenerated]
		private ExtensionDataGetter _ExtensionDataGetter_k__BackingField; // 0xF0
		[CompilerGenerated]
		[Nullable(new byte[3] {2, 1, 1 })]
		private Func<string, string> _ExtensionDataNameResolver_k__BackingField; // 0xF8
		internal bool ExtensionDataIsJToken; // 0x100
		private bool? _hasRequiredOrDefaultValueProperties; // 0x101
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _overrideCreator; // 0x108
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _parameterizedCreator; // 0x110
		private JsonPropertyCollection _creatorParameters; // 0x118
		private Type _extensionDataValueType; // 0x120
	
		// Properties
		public MemberSerialization MemberSerialization { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181239340-0x0000000181239350 0x000000018170C650-0x000000018170C660
		public MissingMemberHandling? MissingMemberHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C580-0x000000018170C590 0x000000018170C660-0x000000018170C670
		public Required? ItemRequired { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C570-0x000000018170C580 0x000000018170C640-0x000000018170C650
		public NullValueHandling? ItemNullValueHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C560-0x000000018170C570 0x000000018170C630-0x000000018170C640
		[Nullable(1)]
		public JsonPropertyCollection Properties { [NullableContext(1)] [CompilerGenerated] get; } // 0x00000001806CCB80-0x00000001806CCB90 
		[Nullable(1)]
		public JsonPropertyCollection CreatorParameters { [NullableContext(1)] get; } // 0x000000018170C240-0x000000018170C2D0 
		[Nullable(new byte[2] {2, 1 })]
		public ObjectConstructor<object> OverrideCreator { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		[Nullable(new byte[2] {2, 1 })]
		internal ObjectConstructor<object> ParameterizedCreator { get; set; } // 0x000000018170B050-0x000000018170B060 0x000000018170B160-0x000000018170B180
		public ExtensionDataSetter ExtensionDataSetter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		public ExtensionDataGetter ExtensionDataGetter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CC3740-0x0000000180CC3750 0x0000000180CC3C60-0x0000000180CC3C80
		public Type ExtensionDataValueType { get; set; } // 0x000000018170C2D0-0x000000018170C2E0 0x000000018170C590-0x000000018170C630
		[Nullable(new byte[3] {2, 1, 1 })]
		public Func<string, string> ExtensionDataNameResolver { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001816A2DA0-0x00000001816A2DC0
		internal bool HasRequiredOrDefaultValueProperties { get; } // 0x000000018170C2E0-0x000000018170C560 
	
		// Constructors
		[NullableContext(1)]
		public JsonObjectContract(Type underlyingType); // 0x000000018170C1B0-0x000000018170C240
	
		// Methods
		[NullableContext(1)]
		internal object GetUninitializedObject(); // 0x000000018170C0A0-0x000000018170C1B0
	}
}
