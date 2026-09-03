/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct LODParameters : IEquatable<LODParameters> // TypeDefIndex: 8415
	{
		// Fields
		private int m_IsOrthographic; // 0x00
		private Vector3 m_CameraPosition; // 0x04
		private float m_FieldOfView; // 0x10
		private float m_OrthoSize; // 0x14
		private int m_CameraPixelHeight; // 0x18
	
		// Properties
		public bool isOrthographic { get; } // 0x000000018225CF40-0x000000018225CF90 
		public Vector3 cameraPosition { get; } // 0x0000000180C5D750-0x0000000180C5D770 
		public float fieldOfView { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
		public float orthoSize { get; } // 0x0000000181120AA0-0x0000000181120AB0 
		public int cameraPixelHeight { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Methods
		public bool Equals(LODParameters other); // 0x000000018225CCD0-0x000000018225CD70
		public override bool Equals(object obj); // 0x000000018225CD70-0x000000018225CE90
		public override int GetHashCode(); // 0x000000018225CE90-0x000000018225CF40
	}
}
