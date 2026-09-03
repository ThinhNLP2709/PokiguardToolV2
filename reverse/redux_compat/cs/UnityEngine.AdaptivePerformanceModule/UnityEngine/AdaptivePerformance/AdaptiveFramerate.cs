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
	public class AdaptiveFramerate : AdaptivePerformanceScaler // TypeDefIndex: 14198
	{
		// Fields
		private int m_DefaultFPS; // 0x40
		private int m_FirstTimeStart; // 0x44
	
		// Constructors
		public AdaptiveFramerate(); // 0x000000018212FB20-0x000000018212FB90
	
		// Methods
		protected override void Awake(); // 0x000000018212FE50-0x000000018212FEF0
		protected override void OnDisabled(); // 0x000000018212FEF0-0x000000018212FF50
		protected override void OnEnabled(); // 0x000000018212FF50-0x000000018212FFD0
		protected override void OnLevelIncrease(); // 0x0000000182130080-0x00000001821301F0
		protected override void OnLevelDecrease(); // 0x000000018212FFD0-0x0000000182130080
	}
}
