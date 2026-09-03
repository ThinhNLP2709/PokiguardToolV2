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
	internal class AxisElement // TypeDefIndex: 7000
	{
		// Fields
		internal DoubleLinkAxis curNode; // 0x10
		internal int rootDepth; // 0x18
		internal int curDepth; // 0x1C
		internal bool isMatch; // 0x20
	
		// Properties
		internal DoubleLinkAxis CurNode { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		internal AxisElement(DoubleLinkAxis node, int depth); // 0x0000000181AC45E0-0x0000000181AC4630
	
		// Methods
		internal void SetDepth(int depth); // 0x0000000181AC45D0-0x0000000181AC45E0
		internal void MoveToParent(int depth, ForwardAxis parent); // 0x0000000181AC4480-0x0000000181AC45D0
		internal bool MoveToChild(string name, string URN, int depth, ForwardAxis parent); // 0x0000000181AC42F0-0x0000000181AC4480
	}
}
