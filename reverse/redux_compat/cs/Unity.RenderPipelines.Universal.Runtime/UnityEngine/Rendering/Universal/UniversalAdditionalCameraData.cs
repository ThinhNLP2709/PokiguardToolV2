/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class UniversalAdditionalCameraData : MonoBehaviour, ISerializationCallbackReceiver, IAdditionalData // TypeDefIndex: 9814
	{
		// Fields
		private const string k_GizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/"; // Metadata: 0x0069F0F1
		private const string k_BaseCameraGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_Base.png"; // Metadata: 0x0069F12E
		private const string k_OverlayCameraGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_Base.png"; // Metadata: 0x0069F17B
		private const string k_PostProcessingGizmoPath = "Packages/com.unity.render-pipelines.universal/Editor/Gizmos/Camera_PostProcessing.png"; // Metadata: 0x0069F1C8
		[FormerlySerializedAs("renderShadows")]
		[SerializeField]
		private bool m_RenderShadows; // 0x20
		[SerializeField]
		private CameraOverrideOption m_RequiresDepthTextureOption; // 0x24
		[SerializeField]
		private CameraOverrideOption m_RequiresOpaqueTextureOption; // 0x28
		[SerializeField]
		private CameraRenderType m_CameraType; // 0x2C
		[SerializeField]
		private List<Camera> m_Cameras; // 0x30
		[SerializeField]
		private int m_RendererIndex; // 0x38
		[SerializeField]
		private LayerMask m_VolumeLayerMask; // 0x3C
		[SerializeField]
		private Transform m_VolumeTrigger; // 0x40
		[SerializeField]
		private VolumeFrameworkUpdateMode m_VolumeFrameworkUpdateModeOption; // 0x48
		[SerializeField]
		private bool m_RenderPostProcessing; // 0x4C
		[SerializeField]
		private AntialiasingMode m_Antialiasing; // 0x50
		[SerializeField]
		private AntialiasingQuality m_AntialiasingQuality; // 0x54
		[SerializeField]
		private bool m_StopNaN; // 0x58
		[SerializeField]
		private bool m_Dithering; // 0x59
		[SerializeField]
		private bool m_ClearDepth; // 0x5A
		[SerializeField]
		private bool m_AllowXRRendering; // 0x5B
		[SerializeField]
		private bool m_AllowHDROutput; // 0x5C
		[SerializeField]
		private bool m_UseScreenCoordOverride; // 0x5D
		[SerializeField]
		private Vector4 m_ScreenSizeOverride; // 0x60
		[SerializeField]
		private Vector4 m_ScreenCoordScaleBias; // 0x70
		[NonSerialized]
		private Camera m_Camera; // 0x80
		[FormerlySerializedAs("requiresDepthTexture")]
		[SerializeField]
		private bool m_RequiresDepthTexture; // 0x88
		[FormerlySerializedAs("requiresColorTexture")]
		[SerializeField]
		private bool m_RequiresColorTexture; // 0x89
		[NonSerialized]
		private MotionVectorsPersistentData m_MotionVectorsPersistentData; // 0x90
		[NonSerialized]
		internal UniversalCameraHistory m_History; // 0x98
		[NonSerialized]
		internal Camera[] m_AllCamerasTemp; // 0xA0
		[SerializeField]
		internal TemporalAA.Settings m_TaaSettings; // 0xA8
		private static List<VolumeStack> s_CachedVolumeStacks; // 0x00
		private VolumeStack m_VolumeStack; // 0xC8
		[SerializeField]
		private Version m_Version; // 0xD0
	
		// Properties
		internal Camera camera { get; } // 0x0000000181FFD690-0x0000000181FFD730 
		public bool renderShadows { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public CameraOverrideOption requiresDepthOption { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public CameraOverrideOption requiresColorOption { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public CameraRenderType renderType { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public List<Camera> cameraStack { get; } // 0x0000000181FFD520-0x0000000181FFD690 
		public bool clearDepth { get; } // 0x00000001802E7850-0x00000001802E7860 
		public bool requiresDepthTexture { get; set; } // 0x0000000181FFD7A0-0x0000000181FFD810 0x0000000181FFDB80-0x0000000181FFDBA0
		public bool requiresColorTexture { get; set; } // 0x0000000181FFD730-0x0000000181FFD7A0 0x0000000181FFDB60-0x0000000181FFDB80
		public ScriptableRenderer scriptableRenderer { get; } // 0x0000000181FFD890-0x0000000181FFDB40 
		public LayerMask volumeLayerMask { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		public Transform volumeTrigger { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		internal VolumeFrameworkUpdateMode volumeFrameworkUpdateMode { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public bool requiresVolumeFrameworkUpdate { get; } // 0x0000000181FFD810-0x0000000181FFD880 
		public VolumeStack volumeStack { get; set; } // 0x00000001806CCB50-0x00000001806CCB60 0x0000000181FFDBE0-0x0000000181FFDD60
		public bool renderPostProcessing { get; set; } // 0x00000001803B6550-0x00000001803B6560 0x0000000181DB90D0-0x0000000181DB90E0
		public AntialiasingMode antialiasing { get; set; } // 0x000000018033D660-0x000000018033D670 0x000000018033EC40-0x000000018033EC50
		public AntialiasingQuality antialiasingQuality { get; set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181ADB600-0x0000000181ADB610
		public ref TemporalAA.Settings taaSettings { get; } // 0x0000000181FFDB40-0x0000000181FFDB50 
		public ICameraHistoryReadAccess history { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		internal UniversalCameraHistory historyManager { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		internal MotionVectorsPersistentData motionVectorsPersistentData { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public bool resetHistory { get; set; } // 0x0000000181FFD880-0x0000000181FFD890 0x0000000181FFDBA0-0x0000000181FFDBE0
		public bool stopNaN { get; set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
		public bool dithering { get; set; } // 0x00000001802E7880-0x00000001802E7890 0x0000000181727420-0x0000000181727430
		public bool allowXRRendering { get; set; } // 0x00000001802E7870-0x00000001802E7880 0x00000001802E7A10-0x00000001802E7A20
		public bool useScreenCoordOverride { get; set; } // 0x0000000181F645F0-0x0000000181F64600 0x0000000181F65030-0x0000000181F65040
		public Vector4 screenSizeOverride { get; set; } // 0x00000001816A56A0-0x00000001816A56B0 0x000000018172A480-0x000000018172A490
		public Vector4 screenCoordScaleBias { get; set; } // 0x000000018172A380-0x000000018172A390 0x000000018172A450-0x000000018172A460
		public bool allowHDROutput { get; set; } // 0x00000001815D7D00-0x00000001815D7D10 0x0000000181EE3C70-0x0000000181EE3C80
		internal int rendererIndex { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		[Obsolete("This field has been deprecated. #from(6000.2)")]
		public float version { get; } // 0x0000000181FFDB50-0x0000000181FFDB60 
	
		// Nested types
		private enum Version // TypeDefIndex: 9815
		{
			Initial = 0,
			DepthAndOpaqueTextureOptions = 2,
			Count = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9816
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<Camera> __9__48_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FFB550-0x0000000181FFB5C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _UpdateCameraStack_b__48_0(Camera cam); // 0x0000000181FFAEC0-0x0000000181FFAF10
		}
	
		// Constructors
		public UniversalAdditionalCameraData(); // 0x0000000181FFD2A0-0x0000000181FFD520
	
		// Methods
		private void Start(); // 0x0000000181FFCD60-0x0000000181FFCDA0
		internal void UpdateCameraStack(); // 0x0000000181FFD000-0x0000000181FFD2A0
		internal bool TryAddCameraToStack(Camera overlayCamera); // 0x0000000181FFCDA0-0x0000000181FFCFA0
		public void SetRenderer(int index); // 0x00000001805D5570-0x00000001805D5580
		internal void GetOrCreateVolumeStack(); // 0x0000000181FFC600-0x0000000181FFC8A0
		public void OnValidate(); // 0x0000000181FFCCD0-0x0000000181FFCD60
		public void OnDrawGizmos(); // 0x0000000181FFCB80-0x0000000181FFCCD0
		public void OnDestroy(); // 0x0000000181FFC9B0-0x0000000181FFCB80
		private ScriptableRenderer GetRawRenderer(); // 0x0000000181FFC8A0-0x0000000181FFC9B0
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181FFCFE0-0x0000000181FFD000
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181FFCFA0-0x0000000181FFCFE0
	}
}
