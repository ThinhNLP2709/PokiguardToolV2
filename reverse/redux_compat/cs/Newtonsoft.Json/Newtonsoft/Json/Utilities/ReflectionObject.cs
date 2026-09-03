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
	internal class ReflectionObject // TypeDefIndex: 10171
	{
		// Fields
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private readonly ObjectConstructor<object> _Creator_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly IDictionary<string, ReflectionMember> _Members_k__BackingField; // 0x18
	
		// Properties
		[Nullable(new byte[2] {2, 1 })]
		public ObjectConstructor<object> Creator { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public IDictionary<string, ReflectionMember> Members { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 10172
		{
			// Fields
			[Nullable(new byte[2] {0, 1 })]
			public Func<object> ctor; // 0x10
	
			// Constructors
			public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _Create_b__0([Nullable(new byte[2] {1, 2 })] object[] args); // 0x00000001804EAA20-0x00000001804EAA50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_1 // TypeDefIndex: 10173
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 2 })]
			public MethodCall<object, object> call; // 0x10
	
			// Constructors
			public __c__DisplayClass11_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal object _Create_b__1(object target); // 0x00000001816FB360-0x00000001816FB400
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_2 // TypeDefIndex: 10174
		{
			// Fields
			[Nullable(new byte[3] {0, 1, 2 })]
			public MethodCall<object, object> call; // 0x10
	
			// Constructors
			public __c__DisplayClass11_2(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Create_b__2(object target, [Nullable(2)] object arg); // 0x00000001816FB400-0x00000001816FB4D0
		}
	
		// Constructors
		private ReflectionObject([Nullable(new byte[2] {2, 1 })] ObjectConstructor<object> creator); // 0x00000001816F6280-0x00000001816F6320
	
		// Methods
		public object GetValue(object target, string member); // 0x00000001816F6150-0x00000001816F61E0
		public void SetValue(object target, string member, [Nullable(2)] object value); // 0x00000001816F61E0-0x00000001816F6280
		public Type GetType(string member); // 0x00000001816F60F0-0x00000001816F6150
		public static ReflectionObject Create(Type t, params string[] memberNames); // 0x00000001816F5790-0x00000001816F57A0
		public static ReflectionObject Create(Type t, [Nullable(2)] MethodBase creator, params string[] memberNames); // 0x00000001816F57A0-0x00000001816F60F0
	}
}
