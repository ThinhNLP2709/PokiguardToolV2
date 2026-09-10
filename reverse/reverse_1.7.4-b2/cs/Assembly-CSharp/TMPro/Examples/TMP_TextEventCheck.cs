/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class TMP_TextEventCheck : MonoBehaviour // TypeDefIndex: 2086
	{
		// Fields
		public TMP_TextEventHandler TextEventHandler; // 0x20
		private TMP_Text m_TextComponent; // 0x28
	
		// Constructors
		public TMP_TextEventCheck(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void OnEnable(); // 0x000000018072C540-0x000000018072C800
		private void OnDisable(); // 0x000000018072C2F0-0x000000018072C540
		private void OnCharacterSelection(char c, int index); // 0x000000018072C180-0x000000018072C2F0
		private void OnSpriteSelection(char c, int index); // 0x000000018072CBC0-0x000000018072CD30
		private void OnWordSelection(string word, int firstCharacterIndex, int length); // 0x000000018072CD30-0x000000018072CEE0
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length); // 0x000000018072C800-0x000000018072C9B0
		private void OnLinkSelection(string linkID, string linkText, int linkIndex); // 0x000000018072C9B0-0x000000018072CBC0
	}
}
