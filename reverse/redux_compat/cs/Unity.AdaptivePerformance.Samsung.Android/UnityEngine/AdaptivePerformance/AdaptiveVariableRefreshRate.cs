/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.AdaptivePerformance.Samsung.Android;

// Image 79: Unity.AdaptivePerformance.Samsung.Android.dll - Assembly: Unity.AdaptivePerformance.Samsung.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15913-15920

namespace UnityEngine.AdaptivePerformance
{
	public class AdaptiveVariableRefreshRate : AdaptiveFramerate // TypeDefIndex: 15914
	{
		// Fields
		private bool m_AdaptiveVRREnabled; // 0x48
		private IVariableRefreshRate m_VRR; // 0x50
		private int m_CurrentRefreshRateIndex; // 0x58
		private int m_DefaultRefreshRateIndex; // 0x5C
	
		// Properties
		public override string Name { get; } // 0x0000000181C63E50-0x0000000181C63E80 
		public override bool Enabled { get; set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
	
		// Constructors
		public AdaptiveVariableRefreshRate(); // 0x0000000181C63E40-0x0000000181C63E50
	
		// Methods
		protected override void Awake(); // 0x0000000181C63820-0x0000000181C639C0
		protected override void OnDisabled(); // 0x0000000181C63A60-0x0000000181C63AC0
		protected override void OnEnabled(); // 0x0000000181C63AC0-0x0000000181C63B60
		private void OnDestroy(); // 0x0000000181C639C0-0x0000000181C63A60
		private void RefreshRateChanged(); // 0x0000000181C63DA0-0x0000000181C63E40
		protected override void OnLevelIncrease(); // 0x0000000181C63C90-0x0000000181C63DA0
		protected override void OnLevelDecrease(); // 0x0000000181C63B60-0x0000000181C63C90
	}
}
