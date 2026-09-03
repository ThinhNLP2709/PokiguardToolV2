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
	public struct CameraProperties : IEquatable<CameraProperties> // TypeDefIndex: 8394
	{
		// Fields
		private Rect screenRect; // 0x00
		private Vector3 viewDir; // 0x10
		private float projectionNear; // 0x1C
		private float projectionFar; // 0x20
		private float cameraNear; // 0x24
		private float cameraFar; // 0x28
		private float cameraAspect; // 0x2C
		private Matrix4x4 cameraToWorld; // 0x30
		private Matrix4x4 actualWorldToClip; // 0x70
		private Matrix4x4 cameraClipToWorld; // 0xB0
		private Matrix4x4 cameraWorldToClip; // 0xF0
		private Matrix4x4 implicitProjection; // 0x130
		private Matrix4x4 stereoWorldToClipLeft; // 0x170
		private Matrix4x4 stereoWorldToClipRight; // 0x1B0
		private Matrix4x4 worldToCamera; // 0x1F0
		private Vector3 up; // 0x230
		private Vector3 right; // 0x23C
		private Vector3 transformDirection; // 0x248
		private Vector3 cameraEuler; // 0x254
		private Vector3 velocity; // 0x260
		private float farPlaneWorldSpaceLength; // 0x26C
		private uint rendererCount; // 0x270
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte m_ShadowCullPlanes[0]; // 0x274
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte m_CameraCullPlanes[0]; // 0x2D4
		private float baseFarDistance; // 0x334
		private Vector3 shadowCullCenter; // 0x338
		internal unsafe fixed /* 0x00000000-0x00000000 */ float layerCullDistances[0]; // 0x344
		private int layerCullSpherical; // 0x3C4
		private CoreCameraValues coreCameraValues; // 0x3C8
		private uint cameraType; // 0x3D8
		private int projectionIsOblique; // 0x3DC
		private int isImplicitProjectionMatrix; // 0x3E0
		internal bool useInteractiveLightBakingData; // 0x3E4
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _layerCullDistances_e__FixedBuffer // TypeDefIndex: 8395
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_CameraCullPlanes_e__FixedBuffer // TypeDefIndex: 8396
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_ShadowCullPlanes_e__FixedBuffer // TypeDefIndex: 8397
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public Plane GetShadowCullingPlane(int index); // 0x0000000182258940-0x0000000182258A30
		public Plane GetCameraCullingPlane(int index); // 0x00000001822582B0-0x00000001822583A0
		public bool Equals(CameraProperties other); // 0x0000000182256800-0x0000000182258170
		public override bool Equals(object obj); // 0x0000000182258170-0x00000001822582B0
		public override int GetHashCode(); // 0x00000001822583A0-0x0000000182258940
	}
}
