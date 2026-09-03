/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[ExecuteAlways]
	[ExecuteInEditMode]
	public class SpriteShapeObjectPlacement : MonoBehaviour // TypeDefIndex: 14019
	{
		// Fields
		[SerializeField]
		private SpriteShapeController m_SpriteShapeController; // 0x20
		[SerializeField]
		private bool m_SetNormal; // 0x28
		[SerializeField]
		private SpriteShapeObjectPlacementMode m_Mode; // 0x2C
		[Min(0f)]
		[SerializeField]
		private int m_StartPoint; // 0x30
		[Min(0f)]
		[SerializeField]
		private int m_EndPoint; // 0x34
		[SerializeField]
		private float m_Ratio; // 0x38
		private int m_ActiveHashCode; // 0x3C
		private static readonly float kMaxDistance; // 0x00
		private static readonly int kMaxIteration; // 0x04
	
		// Properties
		public bool setNormal { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public SpriteShapeObjectPlacementMode mode { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public float ratio { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public SpriteShapeController spriteShapeController { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public int startPoint { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public int endPoint { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
	
		// Constructors
		public SpriteShapeObjectPlacement(); // 0x0000000181C62E60-0x0000000181C62E80
		static SpriteShapeObjectPlacement(); // 0x0000000181C62E10-0x0000000181C62E60
	
		// Methods
		private bool PlaceObjectOnHashChange(); // 0x0000000181C61B20-0x0000000181C624D0
		private static float Angle(Vector3 a, Vector3 b); // 0x0000000181C60C80-0x0000000181C60CE0
		private float GetDistance(float dist, int spoint, int epoint, ref int start, ref int end, ref float r, NativeArray<ShapeControlPoint> shapePoints); // 0x0000000181C60CE0-0x0000000181C610C0
		private Vector3 PlaceObjectInternal(int sp, int ep, float t, NativeArray<ShapeControlPoint> shapePoints); // 0x0000000181C61110-0x0000000181C61B20
		private Vector3 PlaceObject(Spline spline, int sp, int ep, ref bool run); // 0x0000000181C624D0-0x0000000181C626F0
		private int GetSplinePointCount(); // 0x0000000181C610C0-0x0000000181C61110
		private bool Place(); // 0x0000000181C626F0-0x0000000181C62E00
		private void Start(); // 0x0000000181C62E00-0x0000000181C62E10
		private void Update(); // 0x0000000181C62E00-0x0000000181C62E10
	}
}
