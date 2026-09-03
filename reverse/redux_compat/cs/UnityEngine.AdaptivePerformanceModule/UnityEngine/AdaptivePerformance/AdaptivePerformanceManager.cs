/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	internal class AdaptivePerformanceManager : MonoBehaviour, IAdaptivePerformance, IThermalStatus, IPerformanceStatus, IDevicePerformanceControl, IDevelopmentSettings, IPerformanceModeStatus // TypeDefIndex: 14132
	{
		// Fields
		[CompilerGenerated]
		private ThermalEventHandler ThermalEvent; // 0x20
		[CompilerGenerated]
		private PerformanceBottleneckChangeHandler PerformanceBottleneckChangeEvent; // 0x28
		[CompilerGenerated]
		private PerformanceLevelChangeHandler PerformanceLevelChangeEvent; // 0x30
		[CompilerGenerated]
		private PerformanceBoostChangeHandler PerformanceBoostChangeEvent; // 0x38
		[CompilerGenerated]
		private PerformanceModeEventHandler PerformanceModeEvent; // 0x40
		private bool m_JustResumed; // 0x48
		private int m_RequestedCpuLevel; // 0x4C
		private int m_RequestedGpuLevel; // 0x50
		private bool m_NewUserPerformanceLevelRequest; // 0x54
		private bool m_RequestedCpuBoost; // 0x55
		private bool m_RequestedGpuBoost; // 0x56
		private bool m_NewUserCpuPerformanceBoostRequest; // 0x57
		private bool m_NewUserGpuPerformanceBoostRequest; // 0x58
		private ThermalMetrics m_ThermalMetrics; // 0x5C
		private PerformanceMetrics m_PerformanceMetrics; // 0x68
		private FrameTiming m_FrameTiming; // 0x8C
		private PerformanceMode m_PerformanceMode; // 0xA4
		[CompilerGenerated]
		private int _LoggingFrequencyInFrames_k__BackingField; // 0xA8
		private bool m_AutomaticPerformanceControl; // 0xAC
		private bool m_AutomaticPerformanceControlChanged; // 0xAD
		[CompilerGenerated]
		private AdaptivePerformanceIndexer _Indexer_k__BackingField; // 0xB0
		private IAdaptivePerformanceSettings m_Settings; // 0xB8
		private AdaptivePerformanceSubsystem m_Subsystem; // 0xC0
		private DevicePerformanceControlImpl m_DevicePerfControl; // 0xC8
		private AutoPerformanceLevelController m_AutoPerformanceLevelController; // 0xD0
		private AutoPerformanceModeController m_AutoPerformanceModeController; // 0xD8
		private CpuTimeProvider m_CpuFrameTimeProvider; // 0xE0
		private GpuTimeProvider m_GpuFrameTimeProvider; // 0xE8
		private IApplicationLifecycle m_AppLifecycle; // 0xF0
		private TemperatureTrend m_TemperatureTrend; // 0xF8
		private bool m_UseProviderOverallFrameTime; // 0x100
		private WaitForEndOfFrame m_WaitForEndOfFrame; // 0x108
		private int m_FrameCount; // 0x110
		private RunningAverage m_OverallFrameTime; // 0x118
		private float m_OverallFrameTimeAccu; // 0x120
		private RunningAverage m_GpuFrameTime; // 0x128
		private RunningAverage m_CpuFrameTime; // 0x130
	
		// Properties
		public ThermalMetrics ThermalMetrics { get; } // 0x0000000182139E90-0x0000000182139EB0 
		public PerformanceMetrics PerformanceMetrics { get; } // 0x0000000182139E70-0x0000000182139E90 
		public FrameTiming FrameTiming { get; } // 0x0000000182139BD0-0x0000000182139BF0 
		public PerformanceMode PerformanceMode { get; } // 0x000000018033D210-0x000000018033D220 
		public bool Logging { get; set; } // 0x0000000182139D00-0x0000000182139D50 0x000000018213A220-0x000000018213A280
		public int LoggingFrequencyInFrames { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806671D0-0x00000001806671E0 0x0000000181EE3C80-0x0000000181EE3C90
		public bool Initialized { get; } // 0x0000000182139BF0-0x0000000182139D00 
		public bool Active { get; } // 0x0000000182139AB0-0x0000000182139BD0 
		public int MaxCpuPerformanceLevel { get; } // 0x0000000182139D50-0x0000000182139DD0 
		public int MaxGpuPerformanceLevel { get; } // 0x0000000182139DD0-0x0000000182139E50 
		public bool AutomaticPerformanceControl { get; set; } // 0x0000000181EE3C20-0x0000000181EE3C30 0x000000018213A1D0-0x000000018213A1E0
		public PerformanceControlMode PerformanceControlMode { get; } // 0x0000000182139E50-0x0000000182139E70 
		public int CpuLevel { get; set; } // 0x000000018033D1B0-0x000000018033D1C0 0x000000018213A1E0-0x000000018213A1F0
		public int GpuLevel { get; set; } // 0x000000018033D660-0x000000018033D670 0x000000018213A200-0x000000018213A210
		public bool CpuPerformanceBoost { get; set; } // 0x0000000181A856A0-0x0000000181A856B0 0x000000018213A1F0-0x000000018213A200
		public bool GpuPerformanceBoost { get; set; } // 0x00000001815C4760-0x00000001815C4770 0x000000018213A210-0x000000018213A220
		public IDevelopmentSettings DevelopmentSettings { get; } // 0x0000000180370C60-0x0000000180370C70 
		public IThermalStatus ThermalStatus { get; } // 0x0000000180370C60-0x0000000180370C70 
		public IPerformanceStatus PerformanceStatus { get; } // 0x0000000180370C60-0x0000000180370C70 
		public IDevicePerformanceControl DevicePerformanceControl { get; } // 0x0000000180370C60-0x0000000180370C70 
		public IPerformanceModeStatus PerformanceModeStatus { get; } // 0x0000000180370C60-0x0000000180370C70 
		public AdaptivePerformanceIndexer Indexer { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
		public IAdaptivePerformanceSettings Settings { get; private set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		public AdaptivePerformanceSubsystem Subsystem { get; } // 0x00000001806CCB70-0x00000001806CCB80 
	
		// Events
		public event ThermalEventHandler ThermalEvent {
			add; // 0x0000000182139A10-0x0000000182139AB0
			remove; // 0x000000018213A130-0x000000018213A1D0
		}
		public event PerformanceBottleneckChangeHandler PerformanceBottleneckChangeEvent {
			add; // 0x0000000182139830-0x00000001821398D0
			remove; // 0x0000000182139F50-0x0000000182139FF0
		}
		public event PerformanceLevelChangeHandler PerformanceLevelChangeEvent {
			add; // 0x00000001821398D0-0x0000000182139970
			remove; // 0x0000000182139FF0-0x000000018213A090
		}
		public event PerformanceBoostChangeHandler PerformanceBoostChangeEvent {
			add; // 0x0000000182139790-0x0000000182139830
			remove; // 0x0000000182139EB0-0x0000000182139F50
		}
		public event PerformanceModeEventHandler PerformanceModeEvent {
			add; // 0x0000000182139970-0x0000000182139A10
			remove; // 0x000000018213A090-0x000000018213A130
		}
	
		// Constructors
		public AdaptivePerformanceManager(); // 0x0000000182139530-0x0000000182139790
	
		// Methods
		private static bool HasFeature(Feature flags, Feature feature); // 0x0000000181A228E0-0x0000000181A228F0
		public bool SupportedFeature(Feature feature); // 0x0000000182138540-0x0000000182138580
		public void Awake(); // 0x0000000182135400-0x00000001821355D0
		private void LogThermalEvent(ThermalMetrics ev); // 0x0000000182138080-0x0000000182138260
		private void LogBottleneckEvent(PerformanceBottleneckChangeEventArgs ev); // 0x0000000182137AB0-0x0000000182137BB0
		private void LogBoostEvent(PerformanceBoostChangeEventArgs ev); // 0x0000000182137950-0x0000000182137AB0
		private void LogPerformanceModeEvent(PerformanceMode performanceMode); // 0x0000000182137EF0-0x0000000182138080
		private void LogAdaptivePerformanceStatus(); // 0x0000000182136F30-0x0000000182137950
		private static string ToStringWithSign(int x); // 0x0000000182138580-0x00000001821385C0
		private void LogPerformanceLevelEvent(PerformanceLevelChangeEventArgs ev); // 0x0000000182137BB0-0x0000000182137EF0
		private void AddNonNegativeValue(RunningAverage runningAverage, float value); // 0x00000001821351A0-0x0000000182135250
		public void LateUpdate(); // 0x0000000182136E90-0x0000000182136F30
		public void Update(); // 0x0000000182139440-0x00000001821394F0
		private void CollectProfilerStats(); // 0x00000001821355D0-0x0000000182135830
		private void AppendFrameTiming(string label, float averageSeconds, float currentSeconds); // 0x0000000182135250-0x0000000182135400
		private void AccumulateTimingValue(ref float accu, float newValue); // 0x0000000182135180-0x00000001821351A0
		private void UpdateSubsystem(); // 0x00000001821385C0-0x0000000182139440
		private static bool WillCurrentFrameRender(); // 0x00000001821394F0-0x0000000182139530
		public static float EffectiveTargetFrameRate(); // 0x0000000182135DC0-0x0000000182135E10
		public void OnDestroy(); // 0x00000001821383B0-0x00000001821383C0
		public void InitializeAdaptivePerformance(); // 0x0000000182135E10-0x0000000182136E90
		public void StartAdaptivePerformance(); // 0x00000001821383C0-0x0000000182138480
		public void StopAdaptivePerformance(); // 0x0000000182138480-0x0000000182138540
		public void DeinitializeAdaptivePerformance(); // 0x0000000182135830-0x0000000182135DC0
		public void OnApplicationPause(bool pause); // 0x0000000182138260-0x00000001821383B0
	}
}
