/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	internal struct ColorTween : ITweenValue // TypeDefIndex: 11794
	{
		// Fields
		private ColorTweenCallback m_Target; // 0x00
		private Color m_StartColor; // 0x08
		private Color m_TargetColor; // 0x18
		private ColorTweenMode m_TweenMode; // 0x28
		private float m_Duration; // 0x2C
		private bool m_IgnoreTimeScale; // 0x30
	
		// Properties
		public Color startColor { get; set; } // 0x0000000180C57230-0x0000000180C57240 0x0000000181259E20-0x0000000181259E30
		public Color targetColor { get; set; } // 0x0000000180A5E120-0x0000000180A5E130 0x0000000180F9EBA0-0x0000000180F9EBB0
		public ColorTweenMode tweenMode { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public float duration { get; set; } // 0x000000018206CB50-0x000000018206CB60 0x000000018206CC90-0x000000018206CCA0
		public bool ignoreTimeScale { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
	
		// Nested types
		public enum ColorTweenMode // TypeDefIndex: 11795
		{
			All = 0,
			RGB = 1,
			Alpha = 2
		}
	
		public class ColorTweenCallback : UnityEvent<Color> // TypeDefIndex: 11796
		{
			// Constructors
			public ColorTweenCallback(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Methods
		public void TweenValue(float floatPercentage); // 0x000000018206CB60-0x000000018206CC90
		public void AddOnChangedCallback(UnityAction<Color> callback); // 0x000000018206CAB0-0x000000018206CB50
		public bool GetIgnoreTimescale(); // 0x00000001802E8950-0x00000001802E8960
		public float GetDuration(); // 0x000000018206CB50-0x000000018206CB60
		public bool ValidTarget(); // 0x0000000180A3EC30-0x0000000180A3EC40
	}
}
