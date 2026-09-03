/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	internal class CodePageDataItem // TypeDefIndex: 3444
	{
		// Fields
		internal int m_dataIndex; // 0x10
		internal int m_uiFamilyCodePage; // 0x14
		internal string m_webName; // 0x18
		internal uint m_flags; // 0x20
		private static readonly char[] sep; // 0x00
	
		// Properties
		public string WebName { get; } // 0x00000001815778A0-0x00000001815779F0 
	
		// Constructors
		internal CodePageDataItem(int dataIndex); // 0x00000001815777E0-0x00000001815778A0
		static CodePageDataItem(); // 0x0000000181577750-0x00000001815777E0
	
		// Methods
		internal static string CreateString(string pStrings, uint index); // 0x0000000181577690-0x0000000181577750
	}
}
