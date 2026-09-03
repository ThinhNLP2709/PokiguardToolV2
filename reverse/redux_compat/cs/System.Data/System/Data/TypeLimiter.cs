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

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class TypeLimiter // TypeDefIndex: 11210
	{
		// Fields
		[Nullable(2)]
		[ThreadStatic]
		private static Scope s_activeScope; // 0x80000000
		private Scope m_instanceScope; // 0x10
	
		// Properties
		private static bool IsTypeLimitingDisabled { get; } // 0x000000018187BE00-0x000000018187BE70 
	
		// Nested types
		private sealed class Scope : IDisposable // TypeDefIndex: 11211
		{
			// Fields
			private static readonly HashSet<Type> s_allowedTypes; // 0x00
			private HashSet<Type> m_allowedTypes; // 0x10
			[Nullable(2)]
			private readonly Scope m_previousScope; // 0x18
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 11212
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<Type, bool> __9__3_0; // 0x08
	
				// Constructors
				static __c(); // 0x000000018187BF10-0x000000018187BFD0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _.ctor_b__3_0(Type type); // 0x000000018164A520-0x000000018164A550
			}
	
			// Constructors
			internal Scope([Nullable(2)] Scope previousScope, IEnumerable<Type> allowedTypes); // 0x000000018187B3D0-0x000000018187B540
			static Scope(); // 0x000000018187AD90-0x000000018187B3D0
	
			// Methods
			public void Dispose(); // 0x000000018187A940-0x000000018187AA10
			public bool IsAllowedType(Type type); // 0x000000018187AA10-0x000000018187ABA0
			private static bool IsTypeUnconditionallyAllowed(Type type); // 0x000000018187ABA0-0x000000018187AD90
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11213
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<DataColumn, Type> __9__10_0; // 0x08
			public static Func<DataTable, IEnumerable<Type>> __9__11_0; // 0x10
	
			// Constructors
			static __c(); // 0x000000018187BEA0-0x000000018187BF10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Type _GetPreviouslyDeclaredDataTypes_b__10_0(DataColumn column); // 0x000000018187BE70-0x000000018187BE90
			internal IEnumerable<Type> _GetPreviouslyDeclaredDataTypes_b__11_0(DataTable table); // 0x000000018187BE90-0x000000018187BEA0
		}
	
		// Constructors
		private TypeLimiter(Scope scope); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[NullableContext(2)]
		public static TypeLimiter Capture(); // 0x000000018187B540-0x000000018187B5C0
		[NullableContext(2)]
		public static void EnsureTypeIsAllowed(Type type, TypeLimiter capturedLimiter = null); // 0x000000018187B5C0-0x000000018187B7C0
		public static IDisposable EnterRestrictedScope(DataSet dataSet); // 0x000000018187B7C0-0x000000018187BA10
		public static IDisposable EnterRestrictedScope(DataTable dataTable); // 0x000000018187BA10-0x000000018187BB20
		private static IEnumerable<Type> GetPreviouslyDeclaredDataTypes(DataTable dataTable); // 0x000000018187BC90-0x000000018187BE00
		private static IEnumerable<Type> GetPreviouslyDeclaredDataTypes(DataSet dataSet); // 0x000000018187BB20-0x000000018187BC90
	}
}
