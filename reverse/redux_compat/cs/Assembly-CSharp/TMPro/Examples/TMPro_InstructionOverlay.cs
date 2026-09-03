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
	public class TMPro_InstructionOverlay : MonoBehaviour // TypeDefIndex: 1813
	{
		// Fields
		public FpsCounterAnchorPositions AnchorPosition; // 0x20
		private const string instructions = "Camera Control - <#ffff00>Shift + RMB\n</color>Zoom - <#ffff00>Mouse wheel."; // Metadata: 0x0064DC04
		private TextMeshPro m_TextMeshPro; // 0x28
		private TextContainer m_textContainer; // 0x30
		private Transform m_frameCounter_transform; // 0x38
		private Camera m_camera; // 0x40
	
		// Nested types
		public enum FpsCounterAnchorPositions // TypeDefIndex: 1814
		{
			TopLeft = 0,
			BottomLeft = 1,
			TopRight = 2,
			BottomRight = 3
		}
	
		// Constructors
		public TMPro_InstructionOverlay(); // 0x0000000180609F30-0x0000000180609F40
	
		// Methods
		private void Awake(); // 0x0000000180609B20-0x0000000180609DC0
		private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position); // 0x0000000180609DC0-0x0000000180609F30
	}
}
