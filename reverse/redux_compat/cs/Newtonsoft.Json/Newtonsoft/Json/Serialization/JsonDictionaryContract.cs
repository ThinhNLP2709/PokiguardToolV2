/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(2)]
	public class JsonDictionaryContract : JsonContainerContract // TypeDefIndex: 10228
	{
		// Fields
		[CompilerGenerated]
		[Nullable(new byte[3] {2, 1, 1 })]
		private Func<string, string> _DictionaryKeyResolver_k__BackingField; // 0xC0
		[CompilerGenerated]
		private readonly Type _DictionaryKeyType_k__BackingField; // 0xC8
		[CompilerGenerated]
		private readonly Type _DictionaryValueType_k__BackingField; // 0xD0
		[CompilerGenerated]
		private JsonContract _KeyContract_k__BackingField; // 0xD8
		private readonly Type _genericCollectionDefinitionType; // 0xE0
		private Type _genericWrapperType; // 0xE8
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _genericWrapperCreator; // 0xF0
		[Nullable(new byte[2] {2, 1 })]
		private Func<object> _genericTemporaryDictionaryCreator; // 0xF8
		[CompilerGenerated]
		private readonly bool _ShouldCreateWrapper_k__BackingField; // 0x100
		private readonly ConstructorInfo _parameterizedConstructor; // 0x108
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _overrideCreator; // 0x110
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _parameterizedCreator; // 0x118
		[CompilerGenerated]
		private bool _HasParameterizedCreator_k__BackingField; // 0x120
	
		// Properties
		[Nullable(new byte[3] {2, 1, 1 })]
		public Func<string, string> DictionaryKeyResolver { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
		public Type DictionaryKeyType { [CompilerGenerated] get; } // 0x00000001806CCB50-0x00000001806CCB60 
		public Type DictionaryValueType { [CompilerGenerated] get; } // 0x00000001806CCB60-0x00000001806CCB70 
		internal JsonContract KeyContract { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x00000001806CCE00-0x00000001806CCE20
		internal bool ShouldCreateWrapper { [CompilerGenerated] get; } // 0x000000018170B140-0x000000018170B150 
		[Nullable(new byte[2] {2, 1 })]
		internal ObjectConstructor<object> ParameterizedCreator { get; } // 0x000000018170B060-0x000000018170B140 
		[Nullable(new byte[2] {2, 1 })]
		public ObjectConstructor<object> OverrideCreator { get; set; } // 0x000000018170B050-0x000000018170B060 0x000000018170B160-0x000000018170B180
		public bool HasParameterizedCreator { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170B040-0x000000018170B050 0x000000018170B150-0x000000018170B160
		internal bool HasParameterizedCreatorInternal { get; } // 0x000000018170AFD0-0x000000018170B040 
	
		// Constructors
		[NullableContext(1)]
		public JsonDictionaryContract(Type underlyingType); // 0x000000018170A4C0-0x000000018170AFD0
	
		// Methods
		[NullableContext(1)]
		internal IWrappedDictionary CreateWrapper(object dictionary); // 0x000000018170A180-0x000000018170A4C0
		[NullableContext(1)]
		internal IDictionary CreateTemporaryDictionary(); // 0x0000000181709F10-0x000000018170A180
	}
}
