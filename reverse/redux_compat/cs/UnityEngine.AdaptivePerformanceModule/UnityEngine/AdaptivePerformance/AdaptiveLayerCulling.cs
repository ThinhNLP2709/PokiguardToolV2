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
	public class AdaptiveLayerCulling : AdaptivePerformanceScaler // TypeDefIndex: 14199
	{
		// Fields
		private float[] m_defaultDistances; // 0x40
		private float[] m_scaledDistances; // 0x48
		private bool init; // 0x50
		private Camera m_cachedCamera; // 0x58
	
		// Constructors
		public AdaptiveLayerCulling(); // 0x0000000182130700-0x00000001821307D0
	
		// Methods
		protected override void Awake(); // 0x0000000182130430-0x00000001821304D0
		protected override void OnDisabled(); // 0x00000001821304D0-0x0000000182130580
		protected override void OnEnabled(); // 0x0000000182130580-0x0000000182130590
		protected override void OnLevel(); // 0x0000000182130590-0x0000000182130700
		private void AsignDefaultValues(); // 0x0000000182130310-0x0000000182130430
	}
}
