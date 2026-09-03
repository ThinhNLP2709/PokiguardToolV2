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
	public class JsonArrayContract : JsonContainerContract // TypeDefIndex: 10218
	{
		// Fields
		[CompilerGenerated]
		private readonly Type _CollectionItemType_k__BackingField; // 0xC0
		[CompilerGenerated]
		private readonly bool _IsMultidimensionalArray_k__BackingField; // 0xC8
		private readonly Type _genericCollectionDefinitionType; // 0xD0
		private Type _genericWrapperType; // 0xD8
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _genericWrapperCreator; // 0xE0
		[Nullable(new byte[2] {2, 1 })]
		private Func<object> _genericTemporaryCollectionCreator; // 0xE8
		[CompilerGenerated]
		private readonly bool _IsArray_k__BackingField; // 0xF0
		[CompilerGenerated]
		private readonly bool _ShouldCreateWrapper_k__BackingField; // 0xF1
		[CompilerGenerated]
		private bool _CanDeserialize_k__BackingField; // 0xF2
		private readonly ConstructorInfo _parameterizedConstructor; // 0xF8
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _parameterizedCreator; // 0x100
		[Nullable(new byte[2] {2, 1 })]
		private ObjectConstructor<object> _overrideCreator; // 0x108
		[CompilerGenerated]
		private bool _HasParameterizedCreator_k__BackingField; // 0x110
	
		// Properties
		public Type CollectionItemType { [CompilerGenerated] get; } // 0x00000001806CCB70-0x00000001806CCB80 
		public bool IsMultidimensionalArray { [CompilerGenerated] get; } // 0x00000001815989B0-0x00000001815989C0 
		internal bool IsArray { [CompilerGenerated] get; } // 0x0000000181708F30-0x0000000181708F40 
		internal bool ShouldCreateWrapper { [CompilerGenerated] get; } // 0x0000000181709020-0x0000000181709030 
		internal bool CanDeserialize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181708EA0-0x0000000181708EB0 0x0000000181709030-0x0000000181709040
		[Nullable(new byte[2] {2, 1 })]
		internal ObjectConstructor<object> ParameterizedCreator { get; } // 0x0000000181708F40-0x0000000181709020 
		[Nullable(new byte[2] {2, 1 })]
		public ObjectConstructor<object> OverrideCreator { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000181709050-0x0000000181709080
		public bool HasParameterizedCreator { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181708F20-0x0000000181708F30 0x0000000181709040-0x0000000181709050
		internal bool HasParameterizedCreatorInternal { get; } // 0x0000000181708EB0-0x0000000181708F20 
	
		// Constructors
		[NullableContext(1)]
		public JsonArrayContract(Type underlyingType); // 0x0000000181707DB0-0x0000000181708EA0
	
		// Methods
		[NullableContext(1)]
		internal IWrappedCollection CreateWrapper(object list); // 0x00000001817077E0-0x0000000181707C10
		[NullableContext(1)]
		internal IList CreateTemporaryCollection(); // 0x0000000181707590-0x00000001817077E0
		[NullableContext(1)]
		private void StoreFSharpListCreatorIfNecessary(Type underlyingType); // 0x0000000181707C10-0x0000000181707DB0
	}
}
