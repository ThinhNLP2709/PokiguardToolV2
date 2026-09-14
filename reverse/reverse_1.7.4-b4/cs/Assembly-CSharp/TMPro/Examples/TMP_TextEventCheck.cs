/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro.Examples
{
	public class TMP_TextEventCheck : MonoBehaviour // TypeDefIndex: 2491
	{
		// Fields
		public TMP_TextEventHandler TextEventHandler; // 0x20
		private TMP_Text m_TextComponent; // 0x28
	
		// Constructors
		public TMP_TextEventCheck(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void OnEnable(); // 0x0000000180B95D90-0x0000000180B96280
		private void OnDisable(); // 0x0000000180B96280-0x0000000180B96680
		private void OnCharacterSelection(char c, int index); // 0x0000000180B96680-0x0000000180B96850
		private void OnSpriteSelection(char c, int index); // 0x0000000180B96850-0x0000000180B96A20
		private void OnWordSelection(string word, int firstCharacterIndex, int length); // 0x0000000180B96A20-0x0000000180B96C50
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length); // 0x0000000180B96C50-0x0000000180B96E80
		private void OnLinkSelection(string linkID, string linkText, int linkIndex); // 0x0000000180B96E80-0x0000000180B97150
	}
}
