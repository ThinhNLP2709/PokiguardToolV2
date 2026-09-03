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
	internal class ActiveAxis // TypeDefIndex: 7002
	{
		// Fields
		private int _currentDepth; // 0x10
		private bool _isActive; // 0x14
		private Asttree _axisTree; // 0x18
		private ArrayList _axisStack; // 0x20
	
		// Properties
		public int CurrentDepth { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		internal ActiveAxis(Asttree axisTree); // 0x0000000181AC2FD0-0x0000000181AC3220
	
		// Methods
		internal void Reactivate(); // 0x0000000181AC2FC0-0x0000000181AC2FD0
		public bool MoveToStartElement(string localname, string URN); // 0x0000000181AC2E30-0x0000000181AC2FC0
		public virtual bool EndElement(string localname, string URN); // 0x0000000181AC2B90-0x0000000181AC2CD0
		public bool MoveToAttribute(string localname, string URN); // 0x0000000181AC2CD0-0x0000000181AC2E30
	}
}
