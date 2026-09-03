/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct TypeTable // TypeDefIndex: 6644
	{
		// Fields
		public Dictionary<InternedString, Type> table; // 0x00
		private InputManager m_Manager; // 0x08
	
		// Properties
		public IEnumerable<string> names { get; } // 0x0000000181D01290-0x0000000181D013C0 
		public IEnumerable<InternedString> internedNames { get; } // 0x0000000181D01240-0x0000000181D01290 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6645
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<InternedString, string> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181D01B00-0x0000000181D01B70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _get_names_b__2_0(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
		}
	
		// Methods
		public void Initialize(InputManager manager); // 0x0000000181D00FA0-0x0000000181D01030
		public InternedString FindNameForType(Type type); // 0x0000000181D00DD0-0x0000000181D00FA0
		public void AddTypeRegistration(string name, Type type); // 0x0000000181D00C60-0x0000000181D00DD0
		public Type LookupTypeRegistration(string name); // 0x0000000181D01030-0x0000000181D01180
		private Type TryLookupTypeRegistration(InternedString internedName); // 0x0000000181D01180-0x0000000181D01240
	}
}
