/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 2486
	{
		// Fields
		private TextMeshPro m_TextMeshPro; // 0x20
		private Camera m_Camera; // 0x28
		private bool m_isHoveringObject; // 0x30
		private int m_selectedLink; // 0x34
		private int m_lastCharIndex; // 0x38
		private int m_lastWordIndex; // 0x3C
	
		// Constructors
		public TMP_TextSelector_A(); // 0x0000000180B8AA80-0x0000000180B8AAE0
	
		// Methods
		private void Awake(); // 0x0000000180B89D30-0x0000000180B89E90
		private void LateUpdate(); // 0x0000000180B89E90-0x0000000180B8A9A0
		public void OnPointerEnter(PointerEventData eventData); // 0x0000000180B8A9A0-0x0000000180B8AA10
		public void OnPointerExit(PointerEventData eventData); // 0x0000000180B8AA10-0x0000000180B8AA80
	}
}
