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
	internal class AdaptivePerformanceManagerSpawner : ScriptableObject // TypeDefIndex: 14133
	{
		// Fields
		public const string AdaptivePerformanceManagerObjectName = "AdaptivePerformanceManager"; // Metadata: 0x006A9590
		private GameObject m_ManagerGameObject; // 0x18
	
		// Properties
		public GameObject ManagerGameObject { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public AdaptivePerformanceManagerSpawner(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		private void OnEnable(); // 0x00000001821350F0-0x0000000182135180
		public void Initialize(bool isCheckingProvider); // 0x0000000182134BC0-0x0000000182134F20
		public void Deinitialize(); // 0x0000000182134B40-0x0000000182134BC0
		private void InstallScalers(AdaptivePerformanceScalerProfile profile, IAdaptivePerformanceSettings settings); // 0x0000000182134F20-0x00000001821350F0
	}
}
