/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[Serializable]
	public class SplineControlPoint // TypeDefIndex: 13994
	{
		// Fields
		public Vector3 position; // 0x10
		public Vector3 leftTangent; // 0x1C
		public Vector3 rightTangent; // 0x28
		public ShapeTangentMode mode; // 0x34
		public float height; // 0x38
		public int spriteIndex; // 0x3C
		public bool corner; // 0x40
		[SerializeField]
		private Corner m_CornerMode; // 0x44
	
		// Properties
		public Corner cornerMode { get; set; } // 0x000000018033D780-0x000000018033D790 0x000000018033ED00-0x000000018033ED10
	
		// Constructors
		public SplineControlPoint(); // 0x0000000181C46750-0x0000000181C46760
	
		// Methods
		public override int GetHashCode(); // 0x0000000181C465C0-0x0000000181C46750
	}
}
