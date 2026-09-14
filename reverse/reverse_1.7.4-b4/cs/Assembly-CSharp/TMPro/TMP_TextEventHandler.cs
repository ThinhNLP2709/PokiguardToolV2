/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro
{
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 2464
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
		public CharacterSelectionEvent onCharacterSelection { get; set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
		public SpriteSelectionEvent onSpriteSelection { get; set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA510-0x00000001802BA570
		public WordSelectionEvent onWordSelection { get; set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA570-0x00000001802BA5D0
		public LineSelectionEvent onLineSelection { get; set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x00000001802BA5E0-0x00000001802BA640
		public LinkSelectionEvent onLinkSelection { get; set; } // 0x00000001802BA640-0x00000001802BA650 0x00000001802BA650-0x00000001802BA6B0
	
		// Nested types
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2465
		{
			// Constructors
			public CharacterSelectionEvent(); // 0x0000000180B8D340-0x0000000180B8D350
		}
	
		[Serializable]
		public class SpriteSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2466
		{
			// Constructors
			public SpriteSelectionEvent(); // 0x0000000180B8D340-0x0000000180B8D350
		}
	
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2467
		{
			// Constructors
			public WordSelectionEvent(); // 0x0000000180B8D340-0x0000000180B8D350
		}
	
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2468
		{
			// Constructors
			public LineSelectionEvent(); // 0x0000000180B8D340-0x0000000180B8D350
		}
	
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int> // TypeDefIndex: 2469
		{
			// Constructors
			public LinkSelectionEvent(); // 0x0000000180B8D340-0x0000000180B8D350
		}
	
		// Constructors
		public TMP_TextEventHandler(); // 0x0000000180B8D020-0x0000000180B8D340
	
		// Methods
		private void Awake(); // 0x0000000180B8BED0-0x0000000180B8C210
		private void LateUpdate(); // 0x0000000180B8C210-0x0000000180B8CDC0
		public void OnPointerEnter(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		public void OnPointerExit(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		private void SendOnCharacterSelection(char character, int characterIndex); // 0x0000000180B8CDC0-0x0000000180B8CE30
		private void SendOnSpriteSelection(char character, int characterIndex); // 0x0000000180B8CE30-0x0000000180B8CEA0
		private void SendOnWordSelection(string word, int charIndex, int length); // 0x0000000180B8CEA0-0x0000000180B8CF20
		private void SendOnLineSelection(string line, int charIndex, int length); // 0x0000000180B8CF20-0x0000000180B8CFA0
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex); // 0x0000000180B8CFA0-0x0000000180B8D020
	}
}
