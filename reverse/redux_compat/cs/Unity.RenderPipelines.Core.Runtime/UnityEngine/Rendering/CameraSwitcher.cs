/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class CameraSwitcher : MonoBehaviour // TypeDefIndex: 5327
	{
		// Fields
		public Camera[] m_Cameras; // 0x20
		private int m_CurrentCameraIndex; // 0x28
		private Camera m_OriginalCamera; // 0x30
		private Vector3 m_OriginalCameraPosition; // 0x38
		private Quaternion m_OriginalCameraRotation; // 0x44
		private Camera m_CurrentCamera; // 0x58
		private GUIContent[] m_CameraNames; // 0x60
		private int[] m_CameraIndices; // 0x68
		private DebugUI.EnumField m_DebugEntry; // 0x70
		private int m_DebugEntryEnumIndex; // 0x78
	
		// Constructors
		public CameraSwitcher(); // 0x0000000181E1EC70-0x0000000181E1EC80
	
		// Methods
		private void OnEnable(); // 0x0000000181E1E3B0-0x0000000181E1E9F0
		private void OnDisable(); // 0x0000000181E1E310-0x0000000181E1E3B0
		private int GetCameraCount(); // 0x0000000181E1E2A0-0x0000000181E1E2C0
		private Camera GetNextCamera(); // 0x0000000181E1E2C0-0x0000000181E1E310
		private void SetCameraIndex(int index); // 0x0000000181E1E9F0-0x0000000181E1EC60
		[CompilerGenerated]
		private int _OnEnable_b__10_0(); // 0x0000000180377930-0x0000000180377940
		[CompilerGenerated]
		private void _OnEnable_b__10_1(int value); // 0x0000000181E1EC60-0x0000000181E1EC70
		[CompilerGenerated]
		private int _OnEnable_b__10_2(); // 0x000000018169BB50-0x000000018169BB60
		[CompilerGenerated]
		private void _OnEnable_b__10_3(int value); // 0x00000001805936B0-0x00000001805936C0
	}
}
