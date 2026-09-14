/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace TMPro.Examples
{
	public class TMP_FrameRateCounter : MonoBehaviour // TypeDefIndex: 2489
	{
		// Fields
		public float UpdateInterval; // 0x20
		private float m_LastInterval; // 0x24
		private int m_Frames; // 0x28
		public FpsCounterAnchorPositions AnchorPosition; // 0x2C
		private string htmlColorTag; // 0x30
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS"; // Metadata: 0x005F22D0
		private TextMeshPro m_TextMeshPro; // 0x38
		private Transform m_frameCounter_transform; // 0x40
		private Camera m_camera; // 0x48
		private FpsCounterAnchorPositions last_AnchorPosition; // 0x50
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 2490
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMP_FrameRateCounter(); // 0x0000000180B95D30-0x0000000180B95D90
	
		// Methods
		private void Awake(); // 0x0000000180B94D50-0x0000000180B95270
		private void Start(); // 0x0000000180B95270-0x0000000180B952D0
		private void Update(); // 0x0000000180B952D0-0x0000000180B95520
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x0000000180B95520-0x0000000180B95D30
	}
}
