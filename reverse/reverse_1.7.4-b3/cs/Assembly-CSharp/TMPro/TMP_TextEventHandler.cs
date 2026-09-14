/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro
{
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 2457
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
		public SpriteSelectionEvent onSpriteSelection { get; set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA4E0-0x00000001802BA540
		public WordSelectionEvent onWordSelection { get; set; } // 0x00000001802B4AE0-0x00000001802B4AF0 0x00000001802BA540-0x00000001802BA5A0
		public LineSelectionEvent onLineSelection { get; set; } // 0x00000001802BA5A0-0x00000001802BA5B0 0x00000001802BA5B0-0x00000001802BA610
		public LinkSelectionEvent onLinkSelection { get; set; } // 0x00000001802BA610-0x00000001802BA620 0x00000001802BA620-0x00000001802BA680
	
		// Nested types
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2458
		{
			// Constructors
			public CharacterSelectionEvent(); // 0x0000000180B7FF20-0x0000000180B7FF30
		}
	
		[Serializable]
		public class SpriteSelectionEvent : UnityEvent<char, int> // TypeDefIndex: 2459
		{
			// Constructors
			public SpriteSelectionEvent(); // 0x0000000180B7FF20-0x0000000180B7FF30
		}
	
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2460
		{
			// Constructors
			public WordSelectionEvent(); // 0x0000000180B7FF20-0x0000000180B7FF30
		}
	
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 2461
		{
			// Constructors
			public LineSelectionEvent(); // 0x0000000180B7FF20-0x0000000180B7FF30
		}
	
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int> // TypeDefIndex: 2462
		{
			// Constructors
			public LinkSelectionEvent(); // 0x0000000180B7FF20-0x0000000180B7FF30
		}
	
		// Constructors
		public TMP_TextEventHandler(); // 0x0000000180B7FC00-0x0000000180B7FF20
	
		// Methods
		private void Awake(); // 0x0000000180B7EAB0-0x0000000180B7EDF0
		private void LateUpdate(); // 0x0000000180B7EDF0-0x0000000180B7F9A0
		public void OnPointerEnter(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		public void OnPointerExit(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		private void SendOnCharacterSelection(char character, int characterIndex); // 0x0000000180B7F9A0-0x0000000180B7FA10
		private void SendOnSpriteSelection(char character, int characterIndex); // 0x0000000180B7FA10-0x0000000180B7FA80
		private void SendOnWordSelection(string word, int charIndex, int length); // 0x0000000180B7FA80-0x0000000180B7FB00
		private void SendOnLineSelection(string line, int charIndex, int length); // 0x0000000180B7FB00-0x0000000180B7FB80
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex); // 0x0000000180B7FB80-0x0000000180B7FC00
	}
}
