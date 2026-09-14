/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro.Examples
{
	public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler // TypeDefIndex: 2494
	{
		// Fields
		public RectTransform TextPopup_Prefab_01; // 0x20
		private RectTransform m_TextPopup_RectTransform; // 0x28
		private TextMeshProUGUI m_TextPopup_TMPComponent; // 0x30
		private const string k_LinkText = "You have selected link <#ffff00>"; // Metadata: 0x005F230B
		private const string k_WordText = "Word Index: <#ffff00>"; // Metadata: 0x005F232C
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
		public TMP_TextSelector_B(); // 0x0000000180B9A860-0x0000000180B9A8C0
	
		// Methods
		private void Awake(); // 0x0000000180B97F00-0x0000000180B98360
		private void OnEnable(); // 0x0000000180B98360-0x0000000180B98450
		private void OnDisable(); // 0x0000000180B98450-0x0000000180B98540
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180B98540-0x0000000180B986F0
		private void LateUpdate(); // 0x0000000180B986F0-0x0000000180B99D90
		public void OnPointerEnter(PointerEventData eventData); // 0x0000000180B99D90-0x0000000180B99DA0
		public void OnPointerExit(PointerEventData eventData); // 0x0000000180B99DA0-0x0000000180B99DB0
		public void OnPointerClick(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		public void OnPointerUp(PointerEventData eventData); // 0x000000018028A320-0x000000018028A330
		private void RestoreCachedVertexAttributes(int index); // 0x0000000180B99DB0-0x0000000180B9A860
	}
}
