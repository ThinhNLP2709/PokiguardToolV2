/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class ObjectSpin : MonoBehaviour // TypeDefIndex: 2075
	{
		// Fields
		public MotionType Motion; // 0x20
		public Vector3 TranslationDistance; // 0x24
		public float TranslationSpeed; // 0x30
		public float SpinSpeed; // 0x34
		public int RotationRange; // 0x38
		private Transform m_transform; // 0x40
		private float m_time; // 0x48
		private Vector3 m_prevPOS; // 0x4C
		private Vector3 m_initial_Rotation; // 0x58
		private Vector3 m_initial_Position; // 0x64
		private Color32 m_lightColor; // 0x70
	
		// Nested types
		public enum MotionType // TypeDefIndex: 2076
		{
			Rotation = 0,
			SearchLight = 1,
			Translation = 2
		}
	
		// Constructors
		public ObjectSpin(); // 0x00000001807298B0-0x00000001807298F0
	
		// Methods
		private void Awake(); // 0x00000001807294F0-0x0000000180729690
		private void Update(); // 0x0000000180729690-0x00000001807298B0
	}
}
