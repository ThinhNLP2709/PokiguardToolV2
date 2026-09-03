/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	[IsReadOnly]
	internal struct XRView // TypeDefIndex: 5320
	{
		// Fields
		internal readonly Matrix4x4 projMatrix; // 0x00
		internal readonly Matrix4x4 viewMatrix; // 0x40
		internal readonly Matrix4x4 prevViewMatrix; // 0x80
		internal readonly Rect viewport; // 0xC0
		internal readonly Mesh occlusionMesh; // 0xD0
		internal readonly Mesh visibleMesh; // 0xD8
		internal readonly int textureArraySlice; // 0xE0
		internal readonly Vector2 eyeCenterUV; // 0xE4
		internal readonly bool isPrevViewMatrixValid; // 0xEC
	
		// Constructors
		internal XRView(Matrix4x4 projMatrix, Matrix4x4 viewMatrix, Matrix4x4 prevViewMatrix, bool isPrevViewMatrixValid, Rect viewport, Mesh occlusionMesh, Mesh visibleMesh, int textureArraySlice); // 0x0000000181E35CA0-0x0000000181E35E60
	
		// Methods
		private static Vector2 ComputeEyeCenterUV(Matrix4x4 proj); // 0x0000000181E35C00-0x0000000181E35CA0
	}
}
