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

namespace System.Xml
{
	internal class ReadContentAsBinaryHelper // TypeDefIndex: 6725
	{
		// Fields
		private XmlReader reader; // 0x10
		private State state; // 0x18
		private int valueOffset; // 0x1C
		private bool isEnd; // 0x20
	
		// Nested types
		private enum State // TypeDefIndex: 6726
		{
			None = 0,
			InReadContent = 1,
			InReadElementContent = 2
		}
	
		// Methods
		internal void Finish(); // 0x0000000181A35E60-0x0000000181A360B0
		internal void Reset(); // 0x0000000181A36200-0x0000000181A36210
		private bool MoveToNextContentNode(bool moveIfOnContentNode); // 0x0000000181A360B0-0x0000000181A36200
	}
}
