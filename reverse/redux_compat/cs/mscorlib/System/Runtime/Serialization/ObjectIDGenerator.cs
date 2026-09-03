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

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	public class ObjectIDGenerator // TypeDefIndex: 3033
	{
		// Fields
		internal int m_currentCount; // 0x10
		internal int m_currentSize; // 0x14
		internal long[] m_ids; // 0x18
		internal object[] m_objs; // 0x20
		private static readonly int[] sizes; // 0x00
	
		// Constructors
		public ObjectIDGenerator(); // 0x00000001814E55F0-0x00000001814E56D0
		static ObjectIDGenerator(); // 0x00000001814E5540-0x00000001814E55F0
	
		// Methods
		private int FindElement(object obj, out bool found); // 0x00000001814E4EC0-0x00000001814E4F90
		public virtual long GetId(object obj, out bool firstTime); // 0x00000001814E4F90-0x00000001814E5130
		public virtual long HasId(object obj, out bool firstTime); // 0x00000001814E5130-0x00000001814E5210
		private void Rehash(); // 0x00000001814E5210-0x00000001814E5540
	}
}
