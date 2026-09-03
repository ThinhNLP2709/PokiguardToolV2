/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class LocatedActiveAxis : ActiveAxis // TypeDefIndex: 7014
	{
		// Fields
		private int column; // 0x28
		internal bool isMatched; // 0x2C
		internal KeySequence Ks; // 0x30
	
		// Properties
		internal int Column { get; } // 0x0000000180377930-0x0000000180377940 
	
		// Constructors
		internal LocatedActiveAxis(Asttree astfield, KeySequence ks, int column); // 0x0000000181ACE2B0-0x0000000181ACE300
	
		// Methods
		internal void Reactivate(KeySequence ks); // 0x0000000181ACE290-0x0000000181ACE2B0
	}
}
