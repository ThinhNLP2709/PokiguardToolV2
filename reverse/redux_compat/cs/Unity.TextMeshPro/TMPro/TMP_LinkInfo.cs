/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public struct TMP_LinkInfo // TypeDefIndex: 11932
	{
		// Fields
		public TMP_Text textComponent; // 0x00
		public int hashCode; // 0x08
		public int linkIdFirstCharacterIndex; // 0x0C
		public int linkIdLength; // 0x10
		public int linkTextfirstCharacterIndex; // 0x14
		public int linkTextLength; // 0x18
		internal char[] linkID; // 0x20
	
		// Methods
		internal void SetLinkID(char[] text, int startIndex, int length); // 0x00000001820EC250-0x00000001820EC330
		public string GetLinkText(); // 0x00000001820EC0C0-0x00000001820EC1B0
		public string GetLink(); // 0x00000001820EC1B0-0x00000001820EC250
		public string GetLinkID(); // 0x00000001820EC020-0x00000001820EC0C0
	}
}
