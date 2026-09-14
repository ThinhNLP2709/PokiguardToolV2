/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class TMP_TextEventCheck : MonoBehaviour // TypeDefIndex: 2484
	{
		// Fields
		public TMP_TextEventHandler TextEventHandler; // 0x20
		private TMP_Text m_TextComponent; // 0x28
	
		// Constructors
		public TMP_TextEventCheck(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180B88970-0x0000000180B88E60
		private void OnDisable(); // 0x0000000180B88E60-0x0000000180B89260
		private void OnCharacterSelection(char c, int index); // 0x0000000180B89260-0x0000000180B89430
		private void OnSpriteSelection(char c, int index); // 0x0000000180B89430-0x0000000180B89600
		private void OnWordSelection(string word, int firstCharacterIndex, int length); // 0x0000000180B89600-0x0000000180B89830
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length); // 0x0000000180B89830-0x0000000180B89A60
		private void OnLinkSelection(string linkID, string linkText, int linkIndex); // 0x0000000180B89A60-0x0000000180B89D30
	}
}
