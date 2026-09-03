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
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class LateBoundReflectionDelegateFactory : ReflectionDelegateFactory // TypeDefIndex: 10157
	{
		// Fields
		private static readonly LateBoundReflectionDelegateFactory _instance; // 0x00
	
		// Properties
		internal static ReflectionDelegateFactory Instance { get; } // 0x00000001816F4610-0x00000001816F4660 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 10158
		{
			// Fields
			[Nullable(0)]
			public ConstructorInfo c; // 0x10
			[Nullable(0)]
			public MethodBase method; // 0x18
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _CreateParameterizedConstructor_b__0([Nullable(new byte[2] {1, 2 })] object[] a); // 0x00000001816FB500-0x00000001816FB520
			internal object _CreateParameterizedConstructor_b__1([Nullable(new byte[2] {1, 2 })] object[] a); // 0x00000001816FB520-0x00000001816FB550
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0<T> // TypeDefIndex: 10159
		{
			// Fields
			[Nullable(0)]
			public ConstructorInfo c;
			[Nullable(0)]
			public MethodBase method;
	
			// Constructors
			public __c__DisplayClass4_0();
	
			// Methods
			[NullableContext(0)]
			internal object _CreateMethodCall_b__0(T o, [Nullable(new byte[2] {1, 2 })] object[] a);
			[NullableContext(0)]
			internal object _CreateMethodCall_b__1(T o, [Nullable(new byte[2] {1, 2 })] object[] a);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0<T> // TypeDefIndex: 10160
		{
			// Fields
			[Nullable(0)]
			public Type type;
			[Nullable(0)]
			public ConstructorInfo constructorInfo;
	
			// Constructors
			public __c__DisplayClass5_0();
	
			// Methods
			[NullableContext(0)]
			internal T _CreateDefaultConstructor_b__0();
			[NullableContext(0)]
			internal T _CreateDefaultConstructor_b__1();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0<T> // TypeDefIndex: 10161
		{
			// Fields
			[Nullable(0)]
			public PropertyInfo propertyInfo;
	
			// Constructors
			public __c__DisplayClass6_0();
	
			// Methods
			[NullableContext(0)]
			internal object _CreateGet_b__0(T o);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0<T> // TypeDefIndex: 10162
		{
			// Fields
			[Nullable(0)]
			public FieldInfo fieldInfo;
	
			// Constructors
			public __c__DisplayClass7_0();
	
			// Methods
			[NullableContext(0)]
			internal object _CreateGet_b__0(T o);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0<T> // TypeDefIndex: 10163
		{
			// Fields
			[Nullable(0)]
			public FieldInfo fieldInfo;
	
			// Constructors
			public __c__DisplayClass8_0();
	
			// Methods
			[NullableContext(0)]
			internal void _CreateSet_b__0(T o, [Nullable(2)] object v);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0<T> // TypeDefIndex: 10164
		{
			// Fields
			[Nullable(0)]
			public PropertyInfo propertyInfo;
	
			// Constructors
			public __c__DisplayClass9_0();
	
			// Methods
			[NullableContext(0)]
			internal void _CreateSet_b__0(T o, [Nullable(2)] object v);
		}
	
		// Constructors
		public LateBoundReflectionDelegateFactory(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static LateBoundReflectionDelegateFactory(); // 0x00000001816F45A0-0x00000001816F4610
	
		// Methods
		public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method); // 0x00000001816F4400-0x00000001816F45A0
		public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method);
		public override Func<T> CreateDefaultConstructor<T>(Type type);
		public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo);
		public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo);
		public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo);
		public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo);
	}
}
