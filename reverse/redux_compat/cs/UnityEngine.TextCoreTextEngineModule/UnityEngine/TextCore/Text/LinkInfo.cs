/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct LinkInfo // TypeDefIndex: 12647
	{
		// Fields
		public int hashCode; // 0x00
		public int linkIdFirstCharacterIndex; // 0x04
		public int linkIdLength; // 0x08
		public int linkTextfirstCharacterIndex; // 0x0C
		public int linkTextLength; // 0x10
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal char[] linkId; // 0x18
		private string m_LinkIdString; // 0x20
		private string m_LinkTextString; // 0x28
	
		// Methods
		internal void SetLinkId(char[] text, int startIndex, int length); // 0x0000000182303D80-0x0000000182303E80
		public string GetLinkText(TextInfo textInfo); // 0x0000000182303C70-0x0000000182303D80
		public string GetLinkId(); // 0x0000000182303C20-0x0000000182303C70
	}
}
