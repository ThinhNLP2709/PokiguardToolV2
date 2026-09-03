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
	internal class AxisStack // TypeDefIndex: 7001
	{
		// Fields
		private ArrayList _stack; // 0x10
		private ForwardAxis _subtree; // 0x18
		private ActiveAxis _parent; // 0x20
	
		// Properties
		internal ForwardAxis Subtree { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal int Length { get; } // 0x0000000181592F20-0x0000000181592F50 
	
		// Constructors
		public AxisStack(ForwardAxis faxis, ActiveAxis parent); // 0x0000000181AC4E80-0x0000000181AC4F50
	
		// Methods
		internal void Push(int depth); // 0x0000000181AC4DD0-0x0000000181AC4E80
		internal void Pop(); // 0x0000000181AC4D80-0x0000000181AC4DD0
		internal static bool Equal(string thisname, string thisURN, string name, string URN); // 0x0000000181AC4630-0x0000000181AC46B0
		internal void MoveToParent(string name, string URN, int depth); // 0x0000000181AC4A70-0x0000000181AC4D80
		internal bool MoveToChild(string name, string URN, int depth); // 0x0000000181AC48B0-0x0000000181AC4A70
		internal bool MoveToAttribute(string name, string URN, int depth); // 0x0000000181AC46B0-0x0000000181AC48B0
	}
}
