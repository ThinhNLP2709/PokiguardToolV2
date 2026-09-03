/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class CharEnumerator : IEnumerator<char>, ICloneable // TypeDefIndex: 2226
	{
		// Fields
		private string _str; // 0x10
		private int _index; // 0x18
		private char _currentElement; // 0x1C
	
		// Properties
		object IEnumerator.Current { get; } // 0x00000001815604B0-0x0000000181560590 
		public char Current { get; } // 0x0000000181560600-0x00000001815606D0 
	
		// Constructors
		internal CharEnumerator(string str); // 0x0000000181560590-0x00000001815605D0
		internal CharEnumerator(); // 0x00000001815605D0-0x0000000181560600
	
		// Methods
		public object Clone(); // 0x0000000181560410-0x0000000181560420
		public bool MoveNext(); // 0x0000000181560450-0x00000001815604A0
		public void Dispose(); // 0x0000000181560420-0x0000000181560450
		public void Reset(); // 0x00000001815604A0-0x00000001815604B0
	}
}
