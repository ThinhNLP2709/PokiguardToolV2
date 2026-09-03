/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal sealed class MotionVectorsPersistentData // TypeDefIndex: 9508
	{
		// Fields
		private const int k_MaxViewPerPass = 2; // Metadata: 0x0069EBF3
		private Matrix4x4[] m_stagingMatrixArray; // 0x10
		private const int k_EyeCount = 4; // Metadata: 0x0069EBF4
		private int m_numPreviousViews; // 0x18
		private readonly Matrix4x4[] m_Projection; // 0x20
		private readonly Matrix4x4[] m_View; // 0x28
		private readonly Matrix4x4[] m_ViewProjection; // 0x30
		private readonly Matrix4x4[] m_PreviousProjection; // 0x38
		private readonly Matrix4x4[] m_PreviousView; // 0x40
		private readonly Matrix4x4[] m_PreviousViewProjection; // 0x48
		private readonly Matrix4x4[] m_PreviousPreviousProjection; // 0x50
		private readonly Matrix4x4[] m_PreviousPreviousView; // 0x58
		private readonly int[] m_LastFrameIndex; // 0x60
		private readonly float[] m_PrevAspectRatio; // 0x68
		private float m_deltaTime; // 0x70
		private float m_lastDeltaTime; // 0x74
		private Vector3 m_worldSpaceCameraPos; // 0x78
		private Vector3 m_previousWorldSpaceCameraPos; // 0x84
		private Vector3 m_previousPreviousWorldSpaceCameraPos; // 0x90
		private Vector2Int m_previousPreUpscaleResolution; // 0x9C
	
		// Properties
		internal int lastFrameIndex { get; } // 0x0000000181F96F90-0x0000000181F96FC0 
		internal Matrix4x4 viewProjection { get; } // 0x0000000181F97060-0x0000000181F970B0 
		internal Matrix4x4 previousViewProjection { get; } // 0x0000000181F96FF0-0x0000000181F97040 
		internal Matrix4x4[] viewProjectionStereo { get; } // 0x000000018031E110-0x000000018031E120 
		internal Matrix4x4[] previousViewProjectionStereo { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal Matrix4x4[] stagingMatrixStereo { get; } // 0x0000000180377550-0x0000000180377560 
		internal Matrix4x4[] projectionStereo { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal Matrix4x4[] previousProjectionStereo { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal Matrix4x4[] previousPreviousProjectionStereo { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal Matrix4x4[] viewStereo { get; } // 0x000000018033D240-0x000000018033D250 
		internal Matrix4x4[] previousViewStereo { get; } // 0x0000000180377940-0x0000000180377950 
		internal Matrix4x4[] previousPreviousViewStereo { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal float deltaTime { get; } // 0x0000000181F7C310-0x0000000181F7C320 
		internal float lastDeltaTime { get; } // 0x0000000181F63F10-0x0000000181F63F20 
		internal Vector3 worldSpaceCameraPos { get; } // 0x0000000181F970B0-0x0000000181F970D0 
		internal Vector3 previousWorldSpaceCameraPos { get; } // 0x0000000181F97040-0x0000000181F97060 
		internal Vector3 previousPreviousWorldSpaceCameraPos { get; } // 0x0000000181F96FD0-0x0000000181F96FF0 
		internal Vector2Int previousPreUpscaleResolution { get; set; } // 0x0000000181F96FC0-0x0000000181F96FD0 0x0000000181F970D0-0x0000000181F970E0
	
		// Constructors
		internal MotionVectorsPersistentData(); // 0x0000000181F96DC0-0x0000000181F96F90
	
		// Methods
		public void Reset(); // 0x0000000181F95F10-0x0000000181F962D0
		private static int GetXRMultiPassId(XRPass xr); // 0x0000000181F95EE0-0x0000000181F95F10
		public void Update(UniversalCameraData cameraData); // 0x0000000181F96550-0x0000000181F96DC0
		public void SetGlobalMotionMatrices(RasterCommandBuffer cmd, XRPass xr); // 0x0000000181F962D0-0x0000000181F96550
	}
}
