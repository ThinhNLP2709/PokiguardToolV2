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
	internal class KeySequence // TypeDefIndex: 7019
	{
		// Fields
		private TypedObject[] ks; // 0x10
		private int dim; // 0x18
		private int hashcode; // 0x1C
		private int posline; // 0x20
		private int poscol; // 0x24
	
		// Properties
		public int PosLine { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public int PosCol { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public object this[int index] { get => default; set {} } // 0x0000000181ACD1B0-0x0000000181ACD1E0 0x0000000181ACD1E0-0x0000000181ACD2F0
	
		// Constructors
		internal KeySequence(int dim, int line, int col); // 0x0000000181ACD120-0x0000000181ACD1B0
	
		// Methods
		internal bool IsQualified(); // 0x0000000181ACCF60-0x0000000181ACCFD0
		public override int GetHashCode(); // 0x0000000181ACCBA0-0x0000000181ACCF60
		public override bool Equals(object other); // 0x0000000181ACCA90-0x0000000181ACCBA0
		public override string ToString(); // 0x0000000181ACCFD0-0x0000000181ACD120
	}
}
