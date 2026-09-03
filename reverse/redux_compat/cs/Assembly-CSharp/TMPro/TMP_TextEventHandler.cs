/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro
{
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 1780
	{
		// Fields
		[SerializeField]
		private CharacterSelectionEvent m_OnCharacterSelection; // 0x20
		[SerializeField]
		private SpriteSelectionEvent m_OnSpriteSelection; // 0x28
		[SerializeField]
		private WordSelectionEvent m_OnWordSelection; // 0x30
		[SerializeField]
		private LineSelectionEvent m_OnLineSelection; // 0x38
		[SerializeField]
		private LinkSelectionEvent m_OnLinkSelection; // 0x40
		private TMP_Text m_TextComponent; // 0x48
		private Camera m_Camera; // 0x50
		private Canvas m_Canvas; // 0x58
		private int m_selectedLink; // 0x60
		private int m_lastCharIndex; // 0x64
		private int m_lastWordIndex; // 0x68
		private int m_lastLineIndex; // 0x6C
	
		// Properties
		public CharacterSelectionEvent onCharacterSelection { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public SpriteSelectionEvent onSpriteSelection { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public WordSelectionEvent onWordSelection { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public LineSelectionEvent onLineSelection { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public LinkSelectionEvent onLinkSelection { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Nested types
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 1781
		{
			// Constructors
			public CharacterSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class SpriteSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 1782
		{
			// Constructors
			public SpriteSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 1783
		{
			// Constructors
			public WordSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 1784
		{
			// Constructors
			public LineSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int> // TypeDefIndex: 1785
		{
			// Constructors
			public LinkSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		public TMP_TextEventHandler(); // 0x00000001805F8EA0-0x00000001805F8FF0
	
		// Methods
		private void Awake(); // 0x00000001805F83E0-0x00000001805F8570
		private void LateUpdate(); // 0x00000001805F8570-0x00000001805F8C40
		public void OnPointerEnter(PointerEventData eventData); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnPointerExit(PointerEventData eventData); // 0x00000001802E76C0-0x00000001802E76D0
		private void SendOnCharacterSelection(char character, int characterIndex); // 0x00000001805F8C40-0x00000001805F8CB0
		private void SendOnSpriteSelection(char character, int characterIndex); // 0x00000001805F8DB0-0x00000001805F8E20
		private void SendOnWordSelection(string word, int charIndex, int length); // 0x00000001805F8E20-0x00000001805F8EA0
		private void SendOnLineSelection(string line, int charIndex, int length); // 0x00000001805F8CB0-0x00000001805F8D30
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex); // 0x00000001805F8D30-0x00000001805F8DB0
	}
}
