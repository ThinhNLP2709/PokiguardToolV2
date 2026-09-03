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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class SelectorActiveAxis : ActiveAxis // TypeDefIndex: 7015
	{
		// Fields
		private ConstraintStruct cs; // 0x28
		private ArrayList KSs; // 0x30
		private int KSpointer; // 0x38
	
		// Properties
		public int lastDepth { get; } // 0x0000000181AD24E0-0x0000000181AD2590 
	
		// Constructors
		public SelectorActiveAxis(Asttree axisTree, ConstraintStruct cs); // 0x0000000181AD2450-0x0000000181AD24E0
	
		// Methods
		public override bool EndElement(string localname, string URN); // 0x0000000181AD1DB0-0x0000000181AD1FA0
		public int PushKS(int errline, int errcol); // 0x0000000181AD2040-0x0000000181AD2450
		public KeySequence PopKS(); // 0x0000000181AD1FA0-0x0000000181AD2040
	}
}
