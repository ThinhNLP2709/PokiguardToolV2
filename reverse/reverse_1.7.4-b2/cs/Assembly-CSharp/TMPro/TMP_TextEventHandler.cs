/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro
{
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 2059
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
		public CharacterSelectionEvent onCharacterSelection { get; set; } // 0x00000001802FF660-0x00000001802FF670 0x0000000180308AD0-0x0000000180308AE0
		public SpriteSelectionEvent onSpriteSelection { get; set; } // 0x00000001802FF640-0x00000001802FF650 0x0000000180308AC0-0x0000000180308AD0
		public WordSelectionEvent onWordSelection { get; set; } // 0x0000000180308AA0-0x0000000180308AB0 0x0000000180308B00-0x0000000180308B10
		public LineSelectionEvent onLineSelection { get; set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20
		public LinkSelectionEvent onLinkSelection { get; set; } // 0x0000000180308A90-0x0000000180308AA0 0x0000000180308AF0-0x0000000180308B00
	
		// Nested types
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2060
		{
			// Constructors
			public CharacterSelectionEvent(); // 0x0000000180713240-0x0000000180713250
		}
	
		[Serializable]
		public class SpriteSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2061
		{
			// Constructors
			public SpriteSelectionEvent(); // 0x0000000180713240-0x0000000180713250
		}
	
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2062
		{
			// Constructors
			public WordSelectionEvent(); // 0x0000000180713240-0x0000000180713250
		}
	
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2063
		{
			// Constructors
			public LineSelectionEvent(); // 0x0000000180713240-0x0000000180713250
		}
	
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int> // TypeDefIndex: 2064
		{
			// Constructors
			public LinkSelectionEvent(); // 0x0000000180713240-0x0000000180713250
		}
	
		// Constructors
		public TMP_TextEventHandler(); // 0x00000001807233D0-0x0000000180723520
	
		// Methods
		private void Awake(); // 0x0000000180722910-0x0000000180722AA0
		private void LateUpdate(); // 0x0000000180722AA0-0x0000000180723170
		public void OnPointerEnter(PointerEventData eventData); // 0x00000001802EB6C0-0x00000001802EB6D0
		public void OnPointerExit(PointerEventData eventData); // 0x00000001802EB6C0-0x00000001802EB6D0
		private void SendOnCharacterSelection(char character, int characterIndex); // 0x0000000180723170-0x00000001807231E0
		private void SendOnSpriteSelection(char character, int characterIndex); // 0x00000001807232E0-0x0000000180723350
		private void SendOnWordSelection(string word, int charIndex, int length); // 0x0000000180723350-0x00000001807233D0
		private void SendOnLineSelection(string line, int charIndex, int length); // 0x00000001807231E0-0x0000000180723260
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex); // 0x0000000180723260-0x00000001807232E0
	}
}
