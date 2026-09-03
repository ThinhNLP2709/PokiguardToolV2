/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	internal static class SerializationEventsCache // TypeDefIndex: 3026
	{
		// Fields
		private static readonly ConcurrentDictionary<Type, SerializationEvents> s_cache; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3027
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Type, SerializationEvents> __9__1_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001814ED0E0-0x00000001814ED150
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal SerializationEvents _GetSerializationEventsForType_b__1_0(Type type); // 0x00000001814ECF10-0x00000001814ED040
		}
	
		// Constructors
		static SerializationEventsCache(); // 0x00000001814EA9D0-0x00000001814EAA60
	
		// Methods
		internal static SerializationEvents GetSerializationEventsForType(Type t); // 0x00000001814EA890-0x00000001814EA9D0
	}
}
