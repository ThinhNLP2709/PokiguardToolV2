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

namespace System.Xml
{
	internal sealed class XmlChildEnumerator : IEnumerator // TypeDefIndex: 6816
	{
		// Fields
		internal XmlNode container; // 0x10
		internal XmlNode child; // 0x18
		internal bool isFirst; // 0x20
	
		// Properties
		object IEnumerator.Current { get; } // 0x0000000181A5D540-0x0000000181A5D5D0 
		internal XmlNode Current { get; } // 0x0000000181A5D540-0x0000000181A5D5D0 
	
		// Constructors
		internal XmlChildEnumerator(XmlNode container); // 0x0000000181A5D5D0-0x0000000181A5D640
	
		// Methods
		bool IEnumerator.MoveNext(); // 0x0000000181A5D460-0x0000000181A5D4F0
		internal bool MoveNext(); // 0x0000000181A5D460-0x0000000181A5D4F0
		void IEnumerator.Reset(); // 0x0000000181A5D4F0-0x0000000181A5D540
	}
}
