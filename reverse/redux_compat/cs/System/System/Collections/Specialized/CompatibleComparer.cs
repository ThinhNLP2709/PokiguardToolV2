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

namespace System.Collections.Specialized
{
	[Serializable]
	internal class CompatibleComparer : IEqualityComparer // TypeDefIndex: 8964
	{
		// Fields
		private IComparer _comparer; // 0x10
		private static IComparer defaultComparer; // 0x00
		private IHashCodeProvider _hcp; // 0x18
		private static IHashCodeProvider defaultHashProvider; // 0x08
	
		// Properties
		public IComparer Comparer { get; } // 0x0000000180377550-0x0000000180377560 
		public IHashCodeProvider HashCodeProvider { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public static IComparer DefaultComparer { get; } // 0x0000000181BC1190-0x0000000181BC1270 
		public static IHashCodeProvider DefaultHashCodeProvider { get; } // 0x0000000181BC1270-0x0000000181BC1350 
	
		// Constructors
		internal CompatibleComparer(IComparer comparer, IHashCodeProvider hashCodeProvider); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public new bool Equals(object a, object b); // 0x0000000181BC0F40-0x0000000181BC10C0
		public int GetHashCode(object obj); // 0x0000000181BC10C0-0x0000000181BC1190
	}
}
