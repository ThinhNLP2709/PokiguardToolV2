/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class ObjectSpin : MonoBehaviour // TypeDefIndex: 1796
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
		public enum MotionType // TypeDefIndex: 1797
		{
			Rotation = 0,
			SearchLight = 1,
			Translation = 2
		}
	
		// Constructors
		public ObjectSpin(); // 0x00000001805F5BD0-0x00000001805F5C10
	
		// Methods
		private void Awake(); // 0x00000001805F5710-0x00000001805F59B0
		private void Update(); // 0x00000001805F59B0-0x00000001805F5BD0
	}
}
