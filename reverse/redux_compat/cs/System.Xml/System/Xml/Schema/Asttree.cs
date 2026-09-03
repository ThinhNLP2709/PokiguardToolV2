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
using System.Xml;
using MS.Internal.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class Asttree // TypeDefIndex: 7005
	{
		// Fields
		private ArrayList _fAxisArray; // 0x10
		private string _xpathexpr; // 0x18
		private bool _isField; // 0x20
		private XmlNamespaceManager _nsmgr; // 0x28
	
		// Properties
		internal ArrayList SubtreeArray { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public Asttree(string xPath, bool isField, XmlNamespaceManager nsmgr); // 0x0000000181AC3CD0-0x0000000181AC3D50
	
		// Methods
		private static bool IsNameTest(Axis ast); // 0x0000000181AC3B40-0x0000000181AC3B70
		internal static bool IsAttribute(Axis ast); // 0x0000000181AC3AE0-0x0000000181AC3B10
		private static bool IsDescendantOrSelf(Axis ast); // 0x0000000181AC3B10-0x0000000181AC3B40
		internal static bool IsSelf(Axis ast); // 0x0000000181AC3B70-0x0000000181AC3BA0
		public void CompileXPath(string xPath, bool isField, XmlNamespaceManager nsmgr); // 0x0000000181AC3220-0x0000000181AC3AE0
		private void SetURN(Axis axis, XmlNamespaceManager nsmgr); // 0x0000000181AC3BA0-0x0000000181AC3CD0
	}
}
