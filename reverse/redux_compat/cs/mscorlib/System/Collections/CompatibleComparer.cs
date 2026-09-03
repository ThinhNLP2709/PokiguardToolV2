/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	[Serializable]
	internal sealed class CompatibleComparer : IEqualityComparer // TypeDefIndex: 3505
	{
		// Fields
		private readonly IHashCodeProvider _hcp; // 0x10
		private readonly IComparer _comparer; // 0x18
	
		// Properties
		internal IHashCodeProvider HashCodeProvider { get; } // 0x0000000180377550-0x0000000180377560 
		internal IComparer Comparer { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal CompatibleComparer(IHashCodeProvider hashCodeProvider, IComparer comparer); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public new bool Equals(object a, object b); // 0x0000000181593790-0x0000000181593920
		public int Compare(object a, object b); // 0x00000001815935D0-0x0000000181593790
		public int GetHashCode(object obj); // 0x0000000181593920-0x00000001815939F0
	}
}
