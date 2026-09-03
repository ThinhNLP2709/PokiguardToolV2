/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Xsl.Runtime
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct StringConcat // TypeDefIndex: 6999
	{
		// Fields
		private string s1; // 0x00
		private string s2; // 0x08
		private string s3; // 0x10
		private string s4; // 0x18
		private string delimiter; // 0x20
		private List<string> strList; // 0x28
		private int idxStr; // 0x30
	
		// Properties
		internal int Count { get; } // 0x000000018033D100-0x000000018033D110 
	
		// Methods
		public void Clear(); // 0x0000000181AD3090-0x0000000181AD30B0
		public string GetResult(); // 0x0000000181AD3240-0x0000000181AD3330
		internal void ConcatNoDelimiter(string s); // 0x0000000181AD30B0-0x0000000181AD3240
	}
}
