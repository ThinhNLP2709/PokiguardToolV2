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
	internal class FSharpUtils // TypeDefIndex: 10142
	{
		// Fields
		private static readonly object Lock; // 0x00
		[Nullable(2)]
		private static FSharpUtils _instance; // 0x08
		private MethodInfo _ofSeq; // 0x10
		private Type _mapType; // 0x18
		[CompilerGenerated]
		private Assembly _FSharpCoreAssembly_k__BackingField; // 0x20
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 2, 1 })]
		private MethodCall<object, object> _IsUnion_k__BackingField; // 0x28
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 2, 1 })]
		private MethodCall<object, object> _GetUnionCases_k__BackingField; // 0x30
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 2, 1 })]
		private MethodCall<object, object> _PreComputeUnionTagReader_k__BackingField; // 0x38
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 2, 1 })]
		private MethodCall<object, object> _PreComputeUnionReader_k__BackingField; // 0x40
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 2, 1 })]
		private MethodCall<object, object> _PreComputeUnionConstructor_k__BackingField; // 0x48
		[CompilerGenerated]
		private Func<object, object> _GetUnionCaseInfoDeclaringType_k__BackingField; // 0x50
		[CompilerGenerated]
		private Func<object, object> _GetUnionCaseInfoName_k__BackingField; // 0x58
		[CompilerGenerated]
		private Func<object, object> _GetUnionCaseInfoTag_k__BackingField; // 0x60
		[CompilerGenerated]
		[Nullable(new byte[3] {1, 1, 2 })]
		private MethodCall<object, object> _GetUnionCaseInfoFields_k__BackingField; // 0x68
		public const string FSharpSetTypeName = "FSharpSet`1"; // Metadata: 0x006A0961
		public const string FSharpListTypeName = "FSharpList`1"; // Metadata: 0x006A096D
		public const string FSharpMapTypeName = "FSharpMap`2"; // Metadata: 0x006A097A
	
		// Properties
		public static FSharpUtils Instance { get; } // 0x00000001816F0300-0x00000001816F0350 
		public Assembly FSharpCoreAssembly { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		[Nullable(new byte[3] {1, 2, 1 })]
		public MethodCall<object, object> IsUnion { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		[Nullable(new byte[3] {1, 2, 1 })]
		public MethodCall<object, object> GetUnionCases { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		[Nullable(new byte[3] {1, 2, 1 })]
		public MethodCall<object, object> PreComputeUnionTagReader { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[Nullable(new byte[3] {1, 2, 1 })]
		public MethodCall<object, object> PreComputeUnionReader { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		[Nullable(new byte[3] {1, 2, 1 })]
		public MethodCall<object, object> PreComputeUnionConstructor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public Func<object, object> GetUnionCaseInfoDeclaringType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public Func<object, object> GetUnionCaseInfoName { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		public Func<object, object> GetUnionCaseInfoTag { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[Nullable(new byte[3] {1, 1, 2 })]
		public MethodCall<object, object> GetUnionCaseInfoFields { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__55<TKey, TValue> // TypeDefIndex: 10143
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__55<TKey, TValue> __9;
			[Nullable(0)]
			public static Func<KeyValuePair<TKey, TValue>, Tuple<TKey, TValue>> __9__55_1;
	
			// Constructors
			static __c__55();
			public __c__55();
	
			// Methods
			[NullableContext(0)]
			internal Tuple<TKey, TValue> _BuildMapCreator_b__55_1(KeyValuePair<TKey, TValue> kv);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass52_0 // TypeDefIndex: 10144
		{
			// Fields
			[Nullable(new byte[3] {0, 2, 2 })]
			public MethodCall<object, object> call; // 0x10
			[Nullable(new byte[3] {0, 2, 1 })]
			public MethodCall<object, object> invoke; // 0x18
	
			// Constructors
			public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _CreateFSharpFuncCall_b__0([Nullable(2)] object target, [Nullable(new byte[2] {1, 2 })] object[] args); // 0x00000001816FB550-0x00000001816FB600
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass55_0<TKey, TValue> // TypeDefIndex: 10145
		{
			// Fields
			[Nullable(new byte[2] {0, 1 })]
			public ObjectConstructor<object> ctorDelegate;
	
			// Constructors
			public __c__DisplayClass55_0();
	
			// Methods
			internal object _BuildMapCreator_b__0([Nullable(new byte[2] {1, 2 })] object[] args);
		}
	
		// Constructors
		private FSharpUtils(Assembly fsharpCoreAssembly); // 0x00000001816EFD60-0x00000001816F0300
		static FSharpUtils(); // 0x00000001816EFCF0-0x00000001816EFD60
	
		// Methods
		public static void EnsureInitialized(Assembly fsharpCoreAssembly); // 0x00000001816EFB20-0x00000001816EFC70
		private static MethodInfo GetMethodWithNonPublicFallback(Type type, string methodName, BindingFlags bindingFlags); // 0x00000001816EFC70-0x00000001816EFCF0
		private static MethodCall<object, object> CreateFSharpFuncCall(Type type, string methodName); // 0x00000001816EF5F0-0x00000001816EF830
		public ObjectConstructor<object> CreateSeq(Type t); // 0x00000001816EFA00-0x00000001816EFB20
		public ObjectConstructor<object> CreateMap(Type keyType, Type valueType); // 0x00000001816EF830-0x00000001816EFA00
		[NullableContext(2)]
		public ObjectConstructor<object> BuildMapCreator<TKey, TValue>();
	}
}
