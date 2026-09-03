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
	internal class XRVisibleMesh // TypeDefIndex: 5321
	{
		// Fields
		private XRPass m_Pass; // 0x10
		private Mesh m_CombinedMesh; // 0x18
		private int m_CombinedMeshHashCode; // 0x20
		private static readonly ProfilingSampler k_VisibleMeshProfilingSampler; // 0x00
	
		// Properties
		internal bool hasValidVisibleMesh { get; } // 0x0000000181E368A0-0x0000000181E36940 
	
		// Constructors
		internal XRVisibleMesh(XRPass xrPass); // 0x00000001803855F0-0x0000000180385630
		static XRVisibleMesh(); // 0x0000000181E36810-0x0000000181E368A0
	
		// Methods
		internal void Dispose(); // 0x0000000181E361A0-0x0000000181E36240
		internal void RenderVisibleMeshCustomMaterial(CommandBuffer cmd, float occlusionMeshScale, Material material, MaterialPropertyBlock materialBlock, int shaderPass, bool yFlip = false /* Metadata: 0x00661491 */); // 0x0000000181E36290-0x0000000181E36520
		internal void UpdateCombinedMesh(); // 0x0000000181E36640-0x0000000181E36810
		private bool IsVisibleMeshSupported(); // 0x0000000181E36240-0x0000000181E36290
		private bool TryGetVisibleMeshCombinedHashCode(out int hashCode); // 0x0000000181E36520-0x0000000181E36640
		private void CreateVisibleMeshCombined(); // 0x0000000181E35E60-0x0000000181E361A0
	}
}
