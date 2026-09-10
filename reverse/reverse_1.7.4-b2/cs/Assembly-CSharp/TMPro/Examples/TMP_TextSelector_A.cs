/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 2088
	{
		// Fields
		private TextMeshPro m_TextMeshPro; // 0x20
		private Camera m_Camera; // 0x28
		private bool m_isHoveringObject; // 0x30
		private int m_selectedLink; // 0x34
		private int m_lastCharIndex; // 0x38
		private int m_lastWordIndex; // 0x3C
	
		// Constructors
		public TMP_TextSelector_A(); // 0x000000018072D830-0x000000018072D850
	
		// Methods
		private void Awake(); // 0x000000018072CEE0-0x000000018072CFA0
		private void LateUpdate(); // 0x000000018072CFA0-0x000000018072D770
		public void OnPointerEnter(PointerEventData eventData); // 0x000000018072D770-0x000000018072D7D0
		public void OnPointerExit(PointerEventData eventData); // 0x000000018072D7D0-0x000000018072D830
	}
}
