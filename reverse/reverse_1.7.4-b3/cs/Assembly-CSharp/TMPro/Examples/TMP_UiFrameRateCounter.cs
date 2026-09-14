/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class TMP_UiFrameRateCounter : MonoBehaviour // TypeDefIndex: 2488
	{
		// Fields
		public float UpdateInterval; // 0x20
		private float m_LastInterval; // 0x24
		private int m_Frames; // 0x28
		public FpsCounterAnchorPositions AnchorPosition; // 0x2C
		private string htmlColorTag; // 0x30
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS"; // Metadata: 0x005F0F2B
		private TextMeshProUGUI m_TextMeshPro; // 0x38
		private RectTransform m_frameCounter_transform; // 0x40
		private FpsCounterAnchorPositions last_AnchorPosition; // 0x48
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 2489
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMP_UiFrameRateCounter(); // 0x0000000180B88910-0x0000000180B88970
	
		// Methods
		private void Awake(); // 0x0000000180B8D670-0x0000000180B8DAE0
		private void Start(); // 0x0000000180B87E50-0x0000000180B87EB0
		private void Update(); // 0x0000000180B8DAE0-0x0000000180B8DD30
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x0000000180B8DD30-0x0000000180B8E0F0
	}
}
