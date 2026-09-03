/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Events;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI.CoroutineTween
{
	internal struct FloatTween : ITweenValue // TypeDefIndex: 13149
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
		public class FloatTweenCallback : UnityEvent<float> // TypeDefIndex: 13150
		{
			// Constructors
			public FloatTweenCallback(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Methods
		public void TweenValue(float floatPercentage); // 0x00000001825B2760-0x00000001825B27E0
		public void AddOnChangedCallback(UnityAction<float> callback); // 0x00000001825B26C0-0x00000001825B2760
		public bool GetIgnoreTimescale(); // 0x0000000181102980-0x0000000181102990
		public float GetDuration(); // 0x00000001807187E0-0x00000001807187F0
		public bool ValidTarget(); // 0x0000000180A3EC30-0x0000000180A3EC40
	}
}
