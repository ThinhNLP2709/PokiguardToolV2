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
	internal class RunningAverage // TypeDefIndex: 14140
	{
		// Fields
		private float[] m_Values; // 0x10
		private int m_NumValues; // 0x18
		private int m_LastIndex; // 0x1C
		private float m_AverageValue; // 0x20
	
		// Constructors
		public RunningAverage(int sampleWindowSize = 100 /* Metadata: 0x006A95AB */); // 0x0000000182144BE0-0x0000000182144C50
	
		// Methods
		public int GetNumValues(); // 0x0000000180B23260-0x0000000180B23270
		public int GetSampleWindowSize(); // 0x0000000180B5F570-0x0000000180B5F590
		public float GetAverageOr(float defaultValue); // 0x0000000182144B50-0x0000000182144B60
		public float GetMostRecentValueOr(float defaultValue); // 0x0000000182144B60-0x0000000182144BA0
		public void AddValue(float NewValue); // 0x0000000182144AB0-0x0000000182144B50
		public void Reset(); // 0x0000000182144BA0-0x0000000182144BE0
	}
}
