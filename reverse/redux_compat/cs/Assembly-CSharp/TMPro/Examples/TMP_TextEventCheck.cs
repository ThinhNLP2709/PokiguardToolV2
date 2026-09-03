/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class TMP_TextEventCheck : MonoBehaviour // TypeDefIndex: 1807
	{
		// Fields
		public TMP_TextEventHandler TextEventHandler; // 0x20
		private TMP_Text m_TextComponent; // 0x28
	
		// Constructors
		public TMP_TextEventCheck(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x00000001805F7A40-0x00000001805F7D00
		private void OnDisable(); // 0x00000001805F77F0-0x00000001805F7A40
		private void OnCharacterSelection(char c, int index); // 0x00000001805F7680-0x00000001805F77F0
		private void OnSpriteSelection(char c, int index); // 0x00000001805F80C0-0x00000001805F8230
		private void OnWordSelection(string word, int firstCharacterIndex, int length); // 0x00000001805F8230-0x00000001805F83E0
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length); // 0x00000001805F7D00-0x00000001805F7EB0
		private void OnLinkSelection(string linkID, string linkText, int linkIndex); // 0x00000001805F7EB0-0x00000001805F80C0
	}
}
