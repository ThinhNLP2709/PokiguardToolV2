/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DynamicResolutionHandler // TypeDefIndex: 5369
	{
		// Fields
		private bool m_Enabled; // 0x10
		private bool m_UseMipBias; // 0x11
		private float m_MinScreenFraction; // 0x14
		private float m_MaxScreenFraction; // 0x18
		private float m_CurrentFraction; // 0x1C
		private bool m_ForcingRes; // 0x20
		private bool m_CurrentCameraRequest; // 0x21
		private float m_PrevFraction; // 0x24
		private bool m_ForceSoftwareFallback; // 0x28
		private bool m_RunUpscalerFilterOnFullResolution; // 0x29
		private float m_PrevHWScaleWidth; // 0x2C
		private float m_PrevHWScaleHeight; // 0x30
		private Vector2Int m_LastScaledSize; // 0x34
		private static DynamicResScalerSlot s_ActiveScalerSlot; // 0x00
		private static ScalerContainer[] s_ScalerContainers; // 0x08
		private Vector2Int cachedOriginalSize; // 0x3C
		[CompilerGenerated]
		private DynamicResUpscaleFilter _filter_k__BackingField; // 0x44
		private static Dictionary<EntityId, DynamicResUpscaleFilter> s_CameraUpscaleFilters; // 0x10
		[CompilerGenerated]
		private Vector2Int _finalViewport_k__BackingField; // 0x48
		private DynamicResolutionType type; // 0x50
		private GlobalDynamicResolutionSettings m_CachedSettings; // 0x58
		private const int CameraDictionaryMaxcCapacity = 32; // Metadata: 0x006614AB
		private WeakReference m_OwnerCameraWeakRef; // 0xE0
		private static Dictionary<EntityId, DynamicResolutionHandler> s_CameraInstances; // 0x18
		private static DynamicResolutionHandler s_DefaultInstance; // 0x20
		private static EntityId s_ActiveCameraId; // 0x28
		private static DynamicResolutionHandler s_ActiveInstance; // 0x30
		private static bool s_ActiveInstanceDirty; // 0x38
		private static float s_GlobalHwFraction; // 0x3C
		private static bool s_GlobalHwUpresActive; // 0x40
		private UpsamplerScheduleType m_UpsamplerSchedule; // 0xE8
	
		// Properties
		public DynamicResUpscaleFilter filter { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018180F140-0x000000018180F150 0x000000018180F150-0x000000018180F160
		public Vector2Int finalViewport { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x000000018172A440-0x000000018172A450
		public bool runUpscalerFilterOnFullResolution { get; set; } // 0x0000000181E48E00-0x0000000181E48E20 0x000000018052D7C0-0x000000018052D7D0
		public bool forcingResolution { get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
		public UpsamplerScheduleType upsamplerSchedule { get; set; } // 0x0000000180CC39F0-0x0000000180CC3A00 0x0000000180CC3E30-0x0000000180CC3E40
		public static DynamicResolutionHandler instance { get; } // 0x0000000181E48DB0-0x0000000181E48E00 
	
		// Nested types
		private struct ScalerContainer // TypeDefIndex: 5370
		{
			// Fields
			public DynamicResScalePolicyType type; // 0x00
			public PerformDynamicRes method; // 0x08
		}
	
		public enum UpsamplerScheduleType // TypeDefIndex: 5371
		{
			BeforePost = 0,
			AfterDepthOfField = 1,
			AfterPost = 2
		}
	
		// Constructors
		private DynamicResolutionHandler(); // 0x0000000181E48B30-0x0000000181E48DB0
		static DynamicResolutionHandler(); // 0x0000000181E48730-0x0000000181E48B30
	
		// Methods
		private void Reset(); // 0x0000000181E47E50-0x0000000181E47EA0
		private bool FlushScalableBufferManagerState(); // 0x0000000181E47220-0x0000000181E47330
		private static DynamicResolutionHandler GetOrCreateDrsInstanceHandler(Camera camera); // 0x0000000181E474E0-0x0000000181E47970
		private static float DefaultDynamicResMethod(); // 0x0000000181E471E0-0x0000000181E471F0
		private void ProcessSettings(GlobalDynamicResolutionSettings settings); // 0x0000000181E47BE0-0x0000000181E47E30
		public Vector2 GetResolvedScale(); // 0x0000000181E47970-0x0000000181E479E0
		public float CalculateMipBias(Vector2Int inputResolution, Vector2Int outputResolution, bool forceApply = false /* Metadata: 0x006614A8 */); // 0x0000000181E47070-0x0000000181E47140
		public static void SetDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor /* Metadata: 0x006614A9 */); // 0x0000000181E47F00-0x0000000181E47FC0
		public static void SetSystemDynamicResScaler(PerformDynamicRes scaler, DynamicResScalePolicyType scalerType = DynamicResScalePolicyType.ReturnsMinMaxLerpFactor /* Metadata: 0x006614AA */); // 0x0000000181E47FC0-0x0000000181E48080
		public static void SetActiveDynamicScalerSlot(DynamicResScalerSlot slot); // 0x0000000181E47EA0-0x0000000181E47F00
		public static void ClearSelectedCamera(); // 0x0000000181E47140-0x0000000181E471E0
		public static void SetUpscaleFilter(Camera camera, DynamicResUpscaleFilter filter); // 0x0000000181E48080-0x0000000181E48190
		public void SetCurrentCameraRequest(bool cameraRequest); // 0x000000018147BC30-0x000000018147BC40
		public static void UpdateAndUseCamera(Camera camera, GlobalDynamicResolutionSettings? settings = default, Action OnResolutionChange = null); // 0x0000000181E481D0-0x0000000181E48450
		public void Update(GlobalDynamicResolutionSettings settings, Action OnResolutionChange = null); // 0x0000000181E48450-0x0000000181E48730
		public bool SoftwareDynamicResIsEnabled(); // 0x0000000181E48190-0x0000000181E481D0
		public bool HardwareDynamicResIsEnabled(); // 0x0000000181E47BC0-0x0000000181E47BE0
		public bool RequestsHardwareDynamicResolution(); // 0x0000000181E47E30-0x0000000181E47E50
		public bool DynamicResolutionEnabled(); // 0x0000000181E471F0-0x0000000181E47220
		public void ForceSoftwareFallback(); // 0x000000018060A130-0x000000018060A140
		public Vector2Int GetScaledSize(Vector2Int size); // 0x0000000181E479E0-0x0000000181E47BC0
		public Vector2Int ApplyScalesOnSize(Vector2Int size); // 0x0000000181E46D30-0x0000000181E46F00
		internal Vector2Int ApplyScalesOnSize(Vector2Int size, Vector2 scales); // 0x0000000181E46F00-0x0000000181E47070
		public float GetCurrentScale(); // 0x0000000181E47330-0x0000000181E47350
		public Vector2Int GetLastScaledSize(); // 0x0000000181E47350-0x0000000181E47360
		public float GetLowResMultiplier(float targetLowRes); // 0x0000000181E47420-0x0000000181E474E0
		public float GetLowResMultiplier(float targetLowRes, float minimumThreshold); // 0x0000000181E47360-0x0000000181E47420
	}
}
