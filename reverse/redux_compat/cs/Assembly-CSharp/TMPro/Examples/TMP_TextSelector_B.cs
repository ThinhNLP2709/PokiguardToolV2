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
	public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler // TypeDefIndex: 1810
	{
		// Fields
		public RectTransform TextPopup_Prefab_01; // 0x20
		private RectTransform m_TextPopup_RectTransform; // 0x28
		private TextMeshProUGUI m_TextPopup_TMPComponent; // 0x30
		private const string k_LinkText = "You have selected link <#ffff00>"; // Metadata: 0x0064DB92
		private const string k_WordText = "Word Index: <#ffff00>"; // Metadata: 0x0064DBB3
		private TextMeshProUGUI m_TextMeshPro; // 0x38
		private Canvas m_Canvas; // 0x40
		private Camera m_Camera; // 0x48
		private bool isHoveringObject; // 0x50
		private int m_selectedWord; // 0x54
		private int m_selectedLink; // 0x58
		private int m_lastIndex; // 0x5C
		private Matrix4x4 m_matrix; // 0x60
		private TMP_MeshInfo[] m_cachedMeshInfoVertexData; // 0xA0
	
		// Constructors
		public TMP_TextSelector_B(); // 0x00000001805FBAE0-0x00000001805FBB00
	
		// Methods
		private void Awake(); // 0x00000001805F9960-0x00000001805F9B20
		private void OnEnable(); // 0x00000001805FAF40-0x00000001805FB010
		private void OnDisable(); // 0x00000001805FAE70-0x00000001805FAF40
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x00000001805FADC0-0x00000001805FAE70
		private void LateUpdate(); // 0x00000001805F9B20-0x00000001805FADC0
		public void OnPointerEnter(PointerEventData eventData); // 0x00000001805FB010-0x00000001805FB020
		public void OnPointerExit(PointerEventData eventData); // 0x00000001805FB020-0x00000001805FB030
		public void OnPointerClick(PointerEventData eventData); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnPointerUp(PointerEventData eventData); // 0x00000001802E76C0-0x00000001802E76D0
		private void RestoreCachedVertexAttributes(int index); // 0x00000001805FB030-0x00000001805FBAE0
	}
}
