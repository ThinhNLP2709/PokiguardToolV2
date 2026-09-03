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
	public class TMP_FrameRateCounter : MonoBehaviour // TypeDefIndex: 1805
	{
		// Fields
		public float UpdateInterval; // 0x20
		private float m_LastInterval; // 0x24
		private int m_Frames; // 0x28
		public FpsCounterAnchorPositions AnchorPosition; // 0x2C
		private string htmlColorTag; // 0x30
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS"; // Metadata: 0x0064DB57
		private TextMeshPro m_TextMeshPro; // 0x38
		private Transform m_frameCounter_transform; // 0x40
		private Camera m_camera; // 0x48
		private FpsCounterAnchorPositions last_AnchorPosition; // 0x50
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 1806
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMP_FrameRateCounter(); // 0x00000001805F7090-0x00000001805F70B0
	
		// Methods
		private void Awake(); // 0x00000001805F69F0-0x00000001805F6C60
		private void Start(); // 0x00000001805F6ED0-0x00000001805F6F00
		private void Update(); // 0x00000001805F6F00-0x00000001805F7090
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x00000001805F6C60-0x00000001805F6ED0
	}
}
