/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	internal class XROcclusionMesh // TypeDefIndex: 5313
	{
		// Fields
		private XRPass m_Pass; // 0x10
		private Mesh m_CombinedMesh; // 0x18
		private Material m_Material; // 0x20
		private int m_CombinedMeshHashCode; // 0x28
		private static readonly ProfilingSampler k_OcclusionMeshProfilingSampler; // 0x00
	
		// Properties
		internal bool hasValidOcclusionMesh { get; } // 0x0000000181E2D950-0x0000000181E2D9F0 
	
		// Constructors
		internal XROcclusionMesh(XRPass xrPass); // 0x00000001803855F0-0x0000000180385630
		static XROcclusionMesh(); // 0x0000000181E2D8C0-0x0000000181E2D950
	
		// Methods
		internal void SetMaterial(Material mat); // 0x000000018033E830-0x000000018033E840
		internal void RenderOcclusionMesh(CommandBuffer cmd, float occlusionMeshScale, bool yFlip = false /* Metadata: 0x0066147F */); // 0x0000000181E2D0C0-0x0000000181E2D5E0
		internal void UpdateCombinedMesh(); // 0x0000000181E2D700-0x0000000181E2D8C0
		private bool IsOcclusionMeshSupported(); // 0x0000000181E2D040-0x0000000181E2D0C0
		private bool TryGetOcclusionMeshCombinedHashCode(out int hashCode); // 0x0000000181E2D5E0-0x0000000181E2D700
		private void CreateOcclusionMeshCombined(); // 0x0000000181E2CD00-0x0000000181E2D040
	}
}
