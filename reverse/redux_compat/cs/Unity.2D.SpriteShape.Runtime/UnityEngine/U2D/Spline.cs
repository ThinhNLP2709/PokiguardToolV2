/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[Serializable]
	public class Spline // TypeDefIndex: 13987
	{
		// Fields
		private static readonly string KErrorMessage; // 0x00
		private static readonly float KEpsilon; // 0x08
		[SerializeField]
		private bool m_IsOpenEnded; // 0x10
		[SerializeField]
		private List<SplineControlPoint> m_ControlPoints; // 0x18
		private int m_DirtyIndex; // 0x20
	
		// Properties
		public bool isOpenEnded { get; set; } // 0x0000000181C47AA0-0x0000000181C47AD0 0x0000000181C47AD0-0x0000000181C47AE0
	
		// Constructors
		public Spline(); // 0x0000000181C47A20-0x0000000181C47AA0
		static Spline(); // 0x0000000181C479A0-0x0000000181C47A20
	
		// Methods
		private bool IsPositionValid(int index, int next, Vector3 point); // 0x0000000181C472C0-0x0000000181C47560
		public void Clear(); // 0x0000000181C46D50-0x0000000181C46DA0
		public int GetPointCount(); // 0x00000001814EA450-0x00000001814EA470
		public void InsertPointAt(int index, Vector3 point); // 0x0000000181C47150-0x0000000181C472C0
		public void RemovePointAt(int index); // 0x0000000181C47560-0x0000000181C475A0
		public Vector3 GetPosition(int index); // 0x0000000181C47000-0x0000000181C47050
		public void SetPosition(int index, Vector3 point); // 0x0000000181C47750-0x0000000181C47870
		public Vector3 GetLeftTangent(int index); // 0x0000000181C46F60-0x0000000181C47000
		public void SetLeftTangent(int index, Vector3 tangent); // 0x0000000181C476C0-0x0000000181C47750
		public Vector3 GetRightTangent(int index); // 0x0000000181C47050-0x0000000181C470F0
		public void SetRightTangent(int index, Vector3 tangent); // 0x0000000181C47870-0x0000000181C47900
		public ShapeTangentMode GetTangentMode(int index); // 0x0000000181C47120-0x0000000181C47150
		public void SetTangentMode(int index, ShapeTangentMode mode); // 0x0000000181C47940-0x0000000181C479A0
		public float GetHeight(int index); // 0x0000000181C46F30-0x0000000181C46F60
		public void SetHeight(int index, float value); // 0x0000000181C47680-0x0000000181C476C0
		public int GetSpriteIndex(int index); // 0x0000000181C470F0-0x0000000181C47120
		public void SetSpriteIndex(int index, int value); // 0x0000000181C47900-0x0000000181C47940
		public bool GetCorner(int index); // 0x0000000181C46E50-0x0000000181C46E70
		public void SetCorner(int index, bool value); // 0x0000000181C47610-0x0000000181C47680
		internal void SetCornerMode(int index, Corner value); // 0x0000000181C475A0-0x0000000181C47610
		internal Corner GetCornerMode(int index); // 0x0000000181C46DA0-0x0000000181C46E50
		internal int GetChangeIndex(); // 0x0000000180C4F680-0x0000000180C4F690
		public override int GetHashCode(); // 0x0000000181C46E70-0x0000000181C46F30
	}
}
