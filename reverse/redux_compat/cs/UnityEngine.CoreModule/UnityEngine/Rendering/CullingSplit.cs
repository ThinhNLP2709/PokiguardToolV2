/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[UsedByNativeCode]
	public struct CullingSplit // TypeDefIndex: 8357
	{
		// Fields
		public Vector3 sphereCenter; // 0x00
		public float sphereRadius; // 0x0C
		public int cullingPlaneOffset; // 0x10
		public int cullingPlaneCount; // 0x14
		public float cascadeBlendCullingFactor; // 0x18
		public float nearPlane; // 0x1C
		public Matrix4x4 cullingMatrix; // 0x20
	}
}
