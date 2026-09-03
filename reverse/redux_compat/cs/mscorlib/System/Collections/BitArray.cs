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
	public sealed class BitArray : ICollection, ICloneable // TypeDefIndex: 3522
	{
		// Fields
		private int[] m_array; // 0x10
		private int m_length; // 0x18
		private int _version; // 0x1C
		[NonSerialized]
		private object _syncRoot; // 0x20
	
		// Properties
		public bool this[int index] { get => default; set {} } // 0x0000000181590BF0-0x0000000181590CE0 0x00000001815913A0-0x00000001815914C0
		public int Length { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x00000001815914C0-0x0000000181591660
		public int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
		public object SyncRoot { get; } // 0x0000000180B5B970-0x0000000180B5B9E0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[Serializable]
		private class BitArrayEnumeratorSimple : IEnumerator, ICloneable // TypeDefIndex: 3523
		{
			// Fields
			private BitArray bitarray; // 0x10
			private int index; // 0x18
			private int version; // 0x1C
			private bool currentElement; // 0x20
	
			// Properties
			public virtual object Current { get; } // 0x00000001815A7120-0x00000001815A7240 
	
			// Constructors
			internal BitArrayEnumeratorSimple(BitArray bitarray); // 0x00000001815A70D0-0x00000001815A7120
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public virtual bool MoveNext(); // 0x00000001815A6F40-0x00000001815A7050
			public void Reset(); // 0x00000001815A7050-0x00000001815A70D0
		}
	
		// Constructors
		public BitArray(int length); // 0x0000000181591130-0x00000001815912A0
		public BitArray(int length, bool defaultValue); // 0x0000000181590FB0-0x0000000181591130
		public BitArray(BitArray bits); // 0x00000001815912A0-0x00000001815913A0
	
		// Methods
		public bool Get(int index); // 0x0000000181590BF0-0x0000000181590CE0
		public void Set(int index, bool value); // 0x0000000181590E90-0x0000000181590FB0
		public void SetAll(bool value); // 0x0000000181590E10-0x0000000181590E90
		public BitArray Or(BitArray value); // 0x0000000181590CE0-0x0000000181590E10
		public void CopyTo(Array array, int index); // 0x00000001815905A0-0x0000000181590B70
		public object Clone(); // 0x0000000181590470-0x00000001815905A0
		public IEnumerator GetEnumerator(); // 0x0000000181590B90-0x0000000181590BF0
		private static int GetArrayLength(int n, int div); // 0x0000000181590B70-0x0000000181590B90
	}
}
