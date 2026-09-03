/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class FreeCamera : MonoBehaviour // TypeDefIndex: 5328
	{
		// Fields
		private const float k_MouseSensitivityMultiplier = 0.01f; // Metadata: 0x00661494
		public float m_LookSpeedController; // 0x20
		public float m_LookSpeedMouse; // 0x24
		public float m_MoveSpeed; // 0x28
		public float m_MoveSpeedIncrement; // 0x2C
		public float m_Turbo; // 0x30
		private InputAction lookAction; // 0x38
		private InputAction moveAction; // 0x40
		private InputAction speedAction; // 0x48
		private InputAction yMoveAction; // 0x50
		private float inputRotateAxisX; // 0x58
		private float inputRotateAxisY; // 0x5C
		private float inputChangeSpeed; // 0x60
		private float inputVertical; // 0x64
		private float inputHorizontal; // 0x68
		private float inputYAxis; // 0x6C
		private bool leftShiftBoost; // 0x70
		private bool leftShift; // 0x71
		private bool fire1; // 0x72
	
		// Constructors
		public FreeCamera(); // 0x0000000181E23B90-0x0000000181E23BC0
	
		// Methods
		private void OnEnable(); // 0x0000000181E22D70-0x0000000181E22D80
		private void RegisterInputs(); // 0x0000000181E22D80-0x0000000181E23540
		private void UpdateInputs(); // 0x0000000181E23540-0x0000000181E237B0
		private void Update(); // 0x0000000181E237B0-0x0000000181E23B90
	}
}
