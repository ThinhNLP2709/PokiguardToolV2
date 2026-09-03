/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI.CoroutineTween
{
	internal struct ColorTween : ITweenValue // TypeDefIndex: 13146
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
		public enum ColorTweenMode // TypeDefIndex: 13147
		{
			All = 0,
			RGB = 1,
			Alpha = 2
		}
	
		public class ColorTweenCallback : UnityEvent<Color> // TypeDefIndex: 13148
		{
			// Constructors
			public ColorTweenCallback(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Methods
		public void TweenValue(float floatPercentage); // 0x00000001825AE720-0x00000001825AE850
		public void AddOnChangedCallback(UnityAction<Color> callback); // 0x00000001825AE680-0x00000001825AE720
		public bool GetIgnoreTimescale(); // 0x00000001802E8950-0x00000001802E8960
		public float GetDuration(); // 0x000000018206CB50-0x000000018206CB60
		public bool ValidTarget(); // 0x0000000180A3EC30-0x0000000180A3EC40
	}
}
