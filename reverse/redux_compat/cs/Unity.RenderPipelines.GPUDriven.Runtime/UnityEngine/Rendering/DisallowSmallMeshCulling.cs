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

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[ExecuteInEditMode]
	internal class DisallowSmallMeshCulling : MonoBehaviour // TypeDefIndex: 12757
	{
		// Fields
		private bool m_AppliedRecursively; // 0x20
		public bool m_applyToChildrenRecursively; // 0x21
	
		// Properties
		public bool applyToChildrenRecursively { get; set; } // 0x000000018147B6C0-0x000000018147B6D0 0x0000000181F06E20-0x0000000181F06E50
	
		// Constructors
		public DisallowSmallMeshCulling(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void OnEnable(); // 0x0000000181F06D40-0x0000000181F06E00
		private void OnDisable(); // 0x0000000181F06C80-0x0000000181F06D40
		private static void AllowSmallMeshCulling(Transform transform, bool allow); // 0x0000000181F06BE0-0x0000000181F06C80
		private static void AllowSmallMeshCullingRecursively(Transform transform, bool allow); // 0x0000000181F068D0-0x0000000181F06BE0
		private void OnValidate(); // 0x0000000181F06E00-0x0000000181F06E20
	}
}
