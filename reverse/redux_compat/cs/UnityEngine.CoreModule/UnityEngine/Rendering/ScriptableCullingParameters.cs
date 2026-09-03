/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	public struct ScriptableCullingParameters : IEquatable<ScriptableCullingParameters> // TypeDefIndex: 8399
	{
		// Fields
		private LODParameters m_LODParameters; // 0x00
		public static readonly int maximumCullingPlaneCount; // 0x00
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte m_CullingPlanes[0]; // 0x1C
		private int m_CullingPlaneCount; // 0xBC
		private int m_SplitPlaneCount; // 0xC0
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte m_SplitPlanes[0]; // 0xC4
		private uint m_CullingMask; // 0x164
		private ulong m_SceneMask; // 0x168
		private ulong m_ViewID; // 0x170
		public static readonly int layerCount; // 0x04
		internal unsafe fixed /* 0x00000000-0x00000000 */ float m_LayerFarCullDistances[0]; // 0x178
		private int m_LayerCull; // 0x1F8
		private Matrix4x4 m_CullingMatrix; // 0x1FC
		private Vector3 m_Origin; // 0x23C
		private float m_ShadowDistance; // 0x248
		private float m_ShadowNearPlaneOffset; // 0x24C
		private CullingOptions m_CullingOptions; // 0x250
		private ReflectionProbeSortingCriteria m_ReflectionProbeSortingCriteria; // 0x254
		private CameraProperties m_CameraProperties; // 0x258
		private float m_AccurateOcclusionThreshold; // 0x640
		private int m_MaximumPortalCullingJobs; // 0x644
		private Matrix4x4 m_StereoViewMatrix; // 0x648
		private Matrix4x4 m_StereoProjectionMatrix; // 0x688
		private float m_StereoSeparationDistance; // 0x6C8
		private int m_maximumVisibleLights; // 0x6CC
		private bool m_ConservativeEnclosingSphere; // 0x6D0
		private int m_NumIterationsEnclosingSphere; // 0x6D4
	
		// Properties
		public int maximumVisibleLights { set; } // 0x0000000182266520-0x0000000182266530
		public bool conservativeEnclosingSphere { set; } // 0x00000001822664E0-0x00000001822664F0
		public int numIterationsEnclosingSphere { set; } // 0x0000000182266530-0x0000000182266540
		public int cullingPlaneCount { get; } // 0x000000018158B010-0x000000018158B020 
		public int splitPlaneCount { get; set; } // 0x0000000181239340-0x0000000181239350 0x0000000182266560-0x0000000182266640
		public LODParameters lodParameters { get; set; } // 0x0000000182266490-0x00000001822664B0 0x0000000182266500-0x0000000182266520
		public float shadowDistance { set; } // 0x0000000182266550-0x0000000182266560
		public CullingOptions cullingOptions { get; set; } // 0x0000000182266480-0x0000000182266490 0x00000001822664F0-0x0000000182266500
		public ReflectionProbeSortingCriteria reflectionProbeSortingCriteria { set; } // 0x0000000182266540-0x0000000182266550
		public Matrix4x4 stereoViewMatrix { set; } // 0x0000000182266680-0x00000001822666B0
		public Matrix4x4 stereoProjectionMatrix { get; set; } // 0x00000001822664B0-0x00000001822664E0 0x0000000182266640-0x0000000182266670
		public float stereoSeparationDistance { set; } // 0x0000000182266670-0x0000000182266680
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_CullingPlanes_e__FixedBuffer // TypeDefIndex: 8400
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_LayerFarCullDistances_e__FixedBuffer // TypeDefIndex: 8401
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_SplitPlanes_e__FixedBuffer // TypeDefIndex: 8402
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Constructors
		static ScriptableCullingParameters(); // 0x0000000182266430-0x0000000182266480
	
		// Methods
		public float GetLayerCullingDistance(int layerIndex); // 0x00000001822660A0-0x0000000182266180
		public Plane GetSplitCullingPlane(int index); // 0x0000000182266180-0x00000001822662D0
		public void SetSplitCullingPlane(int index, Plane plane); // 0x00000001822662D0-0x0000000182266430
		public Plane GetCullingPlane(int index); // 0x0000000182265CC0-0x0000000182265E10
		public bool Equals(ScriptableCullingParameters other); // 0x0000000182265460-0x0000000182265C00
		public override bool Equals(object obj); // 0x0000000182265C00-0x0000000182265CC0
		public override int GetHashCode(); // 0x0000000182265E10-0x00000001822660A0
	}
}
