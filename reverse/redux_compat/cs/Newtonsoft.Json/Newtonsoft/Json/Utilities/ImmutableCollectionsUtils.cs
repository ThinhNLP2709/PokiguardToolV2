/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class ImmutableCollectionsUtils // TypeDefIndex: 10146
	{
		// Fields
		private const string ImmutableListGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableList`1"; // Metadata: 0x006A0986
		private const string ImmutableQueueGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableQueue`1"; // Metadata: 0x006A09B4
		private const string ImmutableStackGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableStack`1"; // Metadata: 0x006A09E3
		private const string ImmutableSetGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableSet`1"; // Metadata: 0x006A0A12
		private const string ImmutableArrayTypeName = "System.Collections.Immutable.ImmutableArray"; // Metadata: 0x006A0A3F
		private const string ImmutableArrayGenericTypeName = "System.Collections.Immutable.ImmutableArray`1"; // Metadata: 0x006A0A6B
		private const string ImmutableListTypeName = "System.Collections.Immutable.ImmutableList"; // Metadata: 0x006A0A99
		private const string ImmutableListGenericTypeName = "System.Collections.Immutable.ImmutableList`1"; // Metadata: 0x006A0AC4
		private const string ImmutableQueueTypeName = "System.Collections.Immutable.ImmutableQueue"; // Metadata: 0x006A0AF1
		private const string ImmutableQueueGenericTypeName = "System.Collections.Immutable.ImmutableQueue`1"; // Metadata: 0x006A0B1D
		private const string ImmutableStackTypeName = "System.Collections.Immutable.ImmutableStack"; // Metadata: 0x006A0B4B
		private const string ImmutableStackGenericTypeName = "System.Collections.Immutable.ImmutableStack`1"; // Metadata: 0x006A0B77
		private const string ImmutableSortedSetTypeName = "System.Collections.Immutable.ImmutableSortedSet"; // Metadata: 0x006A0BA5
		private const string ImmutableSortedSetGenericTypeName = "System.Collections.Immutable.ImmutableSortedSet`1"; // Metadata: 0x006A0BD5
		private const string ImmutableHashSetTypeName = "System.Collections.Immutable.ImmutableHashSet"; // Metadata: 0x006A0C07
		private const string ImmutableHashSetGenericTypeName = "System.Collections.Immutable.ImmutableHashSet`1"; // Metadata: 0x006A0C35
		private static readonly IList<ImmutableCollectionTypeInfo> ArrayContractImmutableCollectionDefinitions; // 0x00
		private const string ImmutableDictionaryGenericInterfaceTypeName = "System.Collections.Immutable.IImmutableDictionary`2"; // Metadata: 0x006A0C65
		private const string ImmutableDictionaryTypeName = "System.Collections.Immutable.ImmutableDictionary"; // Metadata: 0x006A0C99
		private const string ImmutableDictionaryGenericTypeName = "System.Collections.Immutable.ImmutableDictionary`2"; // Metadata: 0x006A0CCA
		private const string ImmutableSortedDictionaryTypeName = "System.Collections.Immutable.ImmutableSortedDictionary"; // Metadata: 0x006A0CFD
		private const string ImmutableSortedDictionaryGenericTypeName = "System.Collections.Immutable.ImmutableSortedDictionary`2"; // Metadata: 0x006A0D34
		private static readonly IList<ImmutableCollectionTypeInfo> DictionaryContractImmutableCollectionDefinitions; // 0x08
	
		// Nested types
		[Nullable(0)]
		internal class ImmutableCollectionTypeInfo // TypeDefIndex: 10147
		{
			// Fields
			[CompilerGenerated]
			private string _ContractTypeName_k__BackingField; // 0x10
			[CompilerGenerated]
			private string _CreatedTypeName_k__BackingField; // 0x18
			[CompilerGenerated]
			private string _BuilderTypeName_k__BackingField; // 0x20
	
			// Properties
			public string ContractTypeName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public string CreatedTypeName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public string BuilderTypeName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
			// Constructors
			public ImmutableCollectionTypeInfo(string contractTypeName, string createdTypeName, string builderTypeName); // 0x00000001803A7D10-0x00000001803A7D80
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10148
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<MethodInfo, bool> __9__24_1; // 0x08
			[Nullable(0)]
			public static Func<MethodInfo, bool> __9__25_1; // 0x10
	
			// Constructors
			static __c(); // 0x00000001816FB740-0x00000001816FB7B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _TryBuildImmutableForArrayContract_b__24_1(MethodInfo m); // 0x00000001816FB170-0x00000001816FB200
			[NullableContext(0)]
			internal bool _TryBuildImmutableForDictionaryContract_b__25_1(MethodInfo m); // 0x00000001816FB200-0x00000001816FB360
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 10149
		{
			// Fields
			[Nullable(0)]
			public string name; // 0x10
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _TryBuildImmutableForArrayContract_b__0(ImmutableCollectionTypeInfo d); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass25_0 // TypeDefIndex: 10150
		{
			// Fields
			[Nullable(0)]
			public string name; // 0x10
	
			// Constructors
			public __c__DisplayClass25_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _TryBuildImmutableForDictionaryContract_b__0(ImmutableCollectionTypeInfo d); // 0x00000001816FB4D0-0x00000001816FB500
		}
	
		// Constructors
		static ImmutableCollectionsUtils(); // 0x00000001816F0D80-0x00000001816F18C0
	
		// Methods
		internal static bool TryBuildImmutableForArrayContract(Type underlyingType, Type collectionItemType, [Nullable(2)] [NotNullWhen(true)] out Type createdType, [Nullable(new byte[2] {2, 1 })] [NotNullWhen(true)] out ObjectConstructor<object> parameterizedCreator); // 0x00000001816F0350-0x00000001816F0820
		internal static bool TryBuildImmutableForDictionaryContract(Type underlyingType, Type keyItemType, Type valueItemType, [Nullable(2)] [NotNullWhen(true)] out Type createdType, [Nullable(new byte[2] {2, 1 })] [NotNullWhen(true)] out ObjectConstructor<object> parameterizedCreator); // 0x00000001816F0820-0x00000001816F0D80
	}
}
