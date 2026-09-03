/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class TemperatureTrend // TypeDefIndex: 14141
	{
		// Fields
		private bool m_UseProviderTrend; // 0x10
		private double m_SumX; // 0x18
		private double m_SumY; // 0x20
		private double m_SumXY; // 0x28
		private double m_SumXX; // 0x30
		private float[] m_TimeStamps; // 0x38
		private float[] m_Temperature; // 0x40
		private int m_NumValues; // 0x48
		private int m_NextValueIndex; // 0x4C
		private int m_OldestValueIndex; // 0x50
		[CompilerGenerated]
		private float _ThermalTrend_k__BackingField; // 0x54
	
		// Properties
		public float ThermalTrend { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x00000001820CF470-0x00000001820CF480
	
		// Constructors
		public TemperatureTrend(bool useProviderTrend); // 0x0000000182145090-0x0000000182145120
	
		// Methods
		private void PopOldestValue(); // 0x0000000182144C50-0x0000000182144D20
		private void PushNewValue(float tempLevel, float timestamp); // 0x0000000182144D20-0x0000000182144DF0
		public void Reset(); // 0x0000000182144DF0-0x0000000182144E10
		private void UpdateTrend(); // 0x0000000182144E10-0x0000000182144F40
		public void Update(float temperatureTrendFromProvider, float newTemperatureLevel, bool changed, float newTemperatureTimestamp); // 0x0000000182144F40-0x0000000182145090
	}
}
