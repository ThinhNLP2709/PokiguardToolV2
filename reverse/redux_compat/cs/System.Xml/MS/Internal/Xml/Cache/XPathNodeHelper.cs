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

namespace MS.Internal.Xml.Cache
{
	internal abstract class XPathNodeHelper // TypeDefIndex: 7317
	{
		// Methods
		public static int GetLocalNamespaces(XPathNode[] pageElem, int idxElem, out XPathNode[] pageNmsp); // 0x0000000181A237F0-0x0000000181A23880
		public static int GetInScopeNamespaces(XPathNode[] pageElem, int idxElem, out XPathNode[] pageNmsp); // 0x0000000181A236B0-0x0000000181A237F0
		public static bool GetParent(ref XPathNode[] pageNode, ref int idxNode); // 0x0000000181A239C0-0x0000000181A23A60
		public static int GetLocation(XPathNode[] pageNode, int idxNode); // 0x0000000181A23880-0x0000000181A238C0
		public static bool GetTextFollowing(ref XPathNode[] pageCurrent, ref int idxCurrent, XPathNode[] pageEnd, int idxEnd); // 0x0000000181A23A60-0x0000000181A23C60
		public static bool GetNonDescendant(ref XPathNode[] pageNode, ref int idxNode); // 0x0000000181A238C0-0x0000000181A239C0
	}
}
