/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Editor
{
	internal struct SampleFrequencyCalculator // TypeDefIndex: 6391
	{
		// Fields
		private double m_LastUpdateTime; // 0x00
		private int m_SampleCount; // 0x08
		[CompilerGenerated]
		private float _targetFrequency_k__BackingField; // 0x0C
		[CompilerGenerated]
		private float _frequency_k__BackingField; // 0x10
	
		// Properties
		public float targetFrequency { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
		public float frequency { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
	
		// Constructors
		public SampleFrequencyCalculator(float targetFrequency, double realtimeSinceStartup); // 0x0000000181DD07E0-0x0000000181DD0800
	
		// Methods
		public void ProcessSample(InputEventPtr eventPtr); // 0x0000000181DD0730-0x0000000181DD0740
		public bool Update(); // 0x0000000181DD0780-0x0000000181DD07E0
		public bool Update(double realtimeSinceStartup); // 0x0000000181DD0740-0x0000000181DD0780
	}
}
