/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class TMP_UiFrameRateCounter : MonoBehaviour // TypeDefIndex: 2090
	{
		// Fields
		public float UpdateInterval; // 0x20
		private float m_LastInterval; // 0x24
		private int m_Frames; // 0x28
		public FpsCounterAnchorPositions AnchorPosition; // 0x2C
		private string htmlColorTag; // 0x30
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS"; // Metadata: 0x0068E02D
		private TextMeshProUGUI m_TextMeshPro; // 0x38
		private RectTransform m_frameCounter_transform; // 0x40
		private FpsCounterAnchorPositions last_AnchorPosition; // 0x48
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 2091
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMP_UiFrameRateCounter(); // 0x000000018072C160-0x000000018072C180
	
		// Methods
		private void Awake(); // 0x000000018072F9F0-0x000000018072FC10
		private void Start(); // 0x000000018072BFA0-0x000000018072BFD0
		private void Update(); // 0x000000018072FEF0-0x0000000180730080
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x000000018072FC10-0x000000018072FEF0
	}
}
