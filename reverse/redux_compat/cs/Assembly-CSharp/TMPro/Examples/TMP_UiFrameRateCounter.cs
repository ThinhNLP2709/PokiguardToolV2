/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class TMP_UiFrameRateCounter : MonoBehaviour // TypeDefIndex: 1811
	{
		// Fields
		public float UpdateInterval; // 0x20
		private float m_LastInterval; // 0x24
		private int m_Frames; // 0x28
		public FpsCounterAnchorPositions AnchorPosition; // 0x2C
		private string htmlColorTag; // 0x30
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS"; // Metadata: 0x0064DBC9
		private TextMeshProUGUI m_TextMeshPro; // 0x38
		private RectTransform m_frameCounter_transform; // 0x40
		private FpsCounterAnchorPositions last_AnchorPosition; // 0x48
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 1812
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMP_UiFrameRateCounter(); // 0x00000001805F7090-0x00000001805F70B0
	
		// Methods
		private void Awake(); // 0x0000000180609490-0x00000001806096B0
		private void Start(); // 0x00000001805F6ED0-0x00000001805F6F00
		private void Update(); // 0x0000000180609990-0x0000000180609B20
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x00000001806096B0-0x0000000180609990
	}
}
