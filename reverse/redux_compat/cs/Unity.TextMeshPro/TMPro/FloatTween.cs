/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	internal struct FloatTween : ITweenValue // TypeDefIndex: 11797
	{
		// Fields
		private FloatTweenCallback m_Target; // 0x00
		private float m_StartValue; // 0x08
		private float m_TargetValue; // 0x0C
		private float m_Duration; // 0x10
		private bool m_IgnoreTimeScale; // 0x14
	
		// Properties
		public float startValue { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float targetValue { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
		public float duration { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
		public bool ignoreTimeScale { get; set; } // 0x0000000181102980-0x0000000181102990 0x0000000181541B70-0x0000000181541B80
	
		// Nested types
		public class FloatTweenCallback : UnityEvent<float> // TypeDefIndex: 11798
		{
			// Constructors
			public FloatTweenCallback(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Methods
		public void TweenValue(float floatPercentage); // 0x000000018206D0E0-0x000000018206D160
		public void AddOnChangedCallback(UnityAction<float> callback); // 0x000000018206D040-0x000000018206D0E0
		public bool GetIgnoreTimescale(); // 0x0000000181102980-0x0000000181102990
		public float GetDuration(); // 0x00000001807187E0-0x00000001807187F0
		public bool ValidTarget(); // 0x0000000180A3EC30-0x0000000180A3EC40
	}
}
