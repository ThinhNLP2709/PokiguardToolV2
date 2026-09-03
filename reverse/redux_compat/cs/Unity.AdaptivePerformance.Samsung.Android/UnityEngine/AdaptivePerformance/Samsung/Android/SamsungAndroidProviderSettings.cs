/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

// Image 79: Unity.AdaptivePerformance.Samsung.Android.dll - Assembly: Unity.AdaptivePerformance.Samsung.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15913-15920

namespace UnityEngine.AdaptivePerformance.Samsung.Android
{
	[Serializable]
	[AdaptivePerformanceConfigurationData("Samsung (Android)", "com.unity.adaptiveperformance.samsung.android.provider_settings")]
	public class SamsungAndroidProviderSettings : IAdaptivePerformanceSettings // TypeDefIndex: 15917
	{
		// Fields
		[SerializeField]
		[Tooltip("Enable Logging in Devmode")]
		private bool m_SamsungProviderLogging; // 0x50
		[SerializeField]
		[Tooltip("Allow High-Speed Variable Refresh Rate. It is required if you want to use variable refresh rates higher than 60hz. Can increase device temperature when activated.")]
		private bool m_HighSpeedVRR; // 0x51
		[SerializeField]
		[Tooltip("Enable Automatic Variable Refresh Rate. Only enabled if VRR is supported on the target device.")]
		private bool m_AutomaticVRR; // 0x52
		public static SamsungAndroidProviderSettings s_RuntimeInstance; // 0x00
	
		// Properties
		public bool samsungProviderLogging { get; set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
		public bool highSpeedVRR { get; set; } // 0x00000001802F4040-0x00000001802F4050 0x00000001802F4060-0x00000001802F4070
		public bool automaticVRR { get; set; } // 0x00000001818986C0-0x00000001818986D0 0x0000000181C64010-0x0000000181C64020
	
		// Constructors
		public SamsungAndroidProviderSettings(); // 0x0000000181C64000-0x0000000181C64010
	
		// Methods
		private void Awake(); // 0x0000000181C63F60-0x0000000181C63FC0
		public static SamsungAndroidProviderSettings GetSettings(); // 0x0000000181C63FC0-0x0000000181C64000
	}
}
