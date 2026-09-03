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

namespace System.Runtime.Serialization.Formatters.Binary
{
	[Serializable]
	internal sealed class IntSizedArray : ICloneable // TypeDefIndex: 3108
	{
		// Fields
		internal int[] objects; // 0x10
		internal int[] negObjects; // 0x18
	
		// Properties
		internal int this[int index] { get => default; set {} } // 0x000000018150D7C0-0x000000018150D830 0x000000018150D830-0x000000018150D8E0
	
		// Constructors
		public IntSizedArray(); // 0x000000018150D740-0x000000018150D7C0
		private IntSizedArray(IntSizedArray sizedArray); // 0x000000018150D620-0x000000018150D740
	
		// Methods
		public object Clone(); // 0x000000018150D2F0-0x000000018150D440
		internal void IncreaseCapacity(int index); // 0x000000018150D440-0x000000018150D620
	}
}
