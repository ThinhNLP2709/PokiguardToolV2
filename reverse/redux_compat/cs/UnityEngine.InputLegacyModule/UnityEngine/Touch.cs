/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 60: UnityEngine.InputLegacyModule.dll - Assembly: UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15737-15751

namespace UnityEngine
{
	[NativeHeader("Runtime/Input/InputBindings.h")]
	public struct Touch // TypeDefIndex: 15743
	{
		// Fields
		private int m_FingerId; // 0x00
		private Vector2 m_Position; // 0x04
		private Vector2 m_RawPosition; // 0x0C
		private Vector2 m_PositionDelta; // 0x14
		private float m_TimeDelta; // 0x1C
		private int m_TapCount; // 0x20
		private TouchPhase m_Phase; // 0x24
		private TouchType m_Type; // 0x28
		private float m_Pressure; // 0x2C
		private float m_maximumPossiblePressure; // 0x30
		private float m_Radius; // 0x34
		private float m_RadiusVariance; // 0x38
		private float m_AltitudeAngle; // 0x3C
		private float m_AzimuthAngle; // 0x40
	
		// Properties
		public int fingerId { get; } // 0x0000000180732D10-0x0000000180732D20 
		public Vector2 position { get; } // 0x0000000180C5D180-0x0000000180C5D1A0 
		public Vector2 deltaPosition { get; } // 0x000000018112F6D0-0x000000018112F6F0 
		public TouchPhase phase { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public float pressure { get; } // 0x000000018206CB50-0x000000018206CB60 
		public float maximumPossiblePressure { get; } // 0x00000001806CCB40-0x00000001806CCB50 
		public TouchType type { get; } // 0x0000000180377930-0x0000000180377940 
		public float altitudeAngle { get; } // 0x0000000181C58AB0-0x0000000181C58AC0 
		public float azimuthAngle { get; } // 0x0000000181D8CC60-0x0000000181D8CC70 
		public float radius { get; } // 0x0000000181230A40-0x0000000181230A50 
		public float radiusVariance { get; } // 0x0000000181C62E80-0x0000000181C62E90 
	}
}
