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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	internal sealed class WeakHashtable : Hashtable // TypeDefIndex: 8928
	{
		// Fields
		private static IEqualityComparer _comparer; // 0x00
	
		// Nested types
		private class WeakKeyComparer : IEqualityComparer // TypeDefIndex: 8929
		{
			// Constructors
			public WeakKeyComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			bool IEqualityComparer.Equals(object x, object y); // 0x0000000181BDCE00-0x0000000181BDCFA0
			int IEqualityComparer.GetHashCode(object obj); // 0x0000000181BDCFA0-0x0000000181BDCFD0
		}
	
		// Constructors
		internal WeakHashtable(); // 0x0000000181BDCDA0-0x0000000181BDCE00
		static WeakHashtable(); // 0x0000000181BDCD20-0x0000000181BDCDA0
	
		// Methods
		public override void Clear(); // 0x0000000181BDCD00-0x0000000181BDCD10
		public override void Remove(object key); // 0x0000000181BDCD10-0x0000000181BDCD20
	}
}
