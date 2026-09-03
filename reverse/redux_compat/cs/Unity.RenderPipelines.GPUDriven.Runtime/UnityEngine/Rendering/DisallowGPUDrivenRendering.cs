/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[ExecuteInEditMode]
	internal class DisallowGPUDrivenRendering : MonoBehaviour // TypeDefIndex: 12756
	{
		// Fields
		private bool m_AppliedRecursively; // 0x20
		[FormerlySerializedAs("applyToChildrenRecursively")]
		public bool m_applyToChildrenRecursively; // 0x21
	
		// Properties
		public bool applyToChildrenRecursively { get; set; } // 0x000000018147B6C0-0x000000018147B6D0 0x0000000181F068A0-0x0000000181F068D0
	
		// Constructors
		public DisallowGPUDrivenRendering(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x0000000181F067A0-0x0000000181F06860
		private void OnDisable(); // 0x0000000181F066E0-0x0000000181F067A0
		private static void AllowGPUDrivenRendering(Transform transform, bool allow); // 0x0000000181F06640-0x0000000181F066E0
		private static void AllowGPUDrivenRenderingRecursively(Transform transform, bool allow); // 0x0000000181F06330-0x0000000181F06640
		private void OnValidate(); // 0x0000000181F06860-0x0000000181F068A0
	}
}
