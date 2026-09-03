/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // TypeDefIndex: 1809
	{
		// Fields
		private TextMeshPro m_TextMeshPro; // 0x20
		private Camera m_Camera; // 0x28
		private bool m_isHoveringObject; // 0x30
		private int m_selectedLink; // 0x34
		private int m_lastCharIndex; // 0x38
		private int m_lastWordIndex; // 0x3C
	
		// Constructors
		public TMP_TextSelector_A(); // 0x00000001805F9940-0x00000001805F9960
	
		// Methods
		private void Awake(); // 0x00000001805F8FF0-0x00000001805F90B0
		private void LateUpdate(); // 0x00000001805F90B0-0x00000001805F9880
		public void OnPointerEnter(PointerEventData eventData); // 0x00000001805F9880-0x00000001805F98E0
		public void OnPointerExit(PointerEventData eventData); // 0x00000001805F98E0-0x00000001805F9940
	}
}
