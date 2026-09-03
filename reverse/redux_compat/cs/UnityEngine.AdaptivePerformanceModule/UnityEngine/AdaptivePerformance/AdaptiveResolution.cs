/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public class AdaptiveResolution : AdaptivePerformanceScaler // TypeDefIndex: 14204
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static int instanceCount; // 0x00
	
		// Constructors
		public AdaptiveResolution(); // 0x000000018212FB20-0x000000018212FB90
	
		// Methods
		protected override void Awake(); // 0x000000018213ECC0-0x000000018213ED60
		protected override void OnDisabled(); // 0x000000018213ED60-0x000000018213EE70
		protected override void OnEnabled(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnValidate(); // 0x000000018213F330-0x000000018213F430
		private bool IsDynamicResolutionSupported(); // 0x00000001802E7990-0x00000001802E79A0
		private void Start(); // 0x000000018213F430-0x000000018213F4D0
		private void OnDestroy(); // 0x000000018213ED60-0x000000018213EE70
		protected override void OnLevel(); // 0x000000018213EE70-0x000000018213F330
	}
}
