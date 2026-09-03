/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DebugShapes // TypeDefIndex: 5448
	{
		// Fields
		private static DebugShapes s_Instance; // 0x00
		private Mesh m_sphereMesh; // 0x10
		private Mesh m_boxMesh; // 0x18
		private Mesh m_coneMesh; // 0x20
		private Mesh m_pyramidMesh; // 0x28
	
		// Properties
		public static DebugShapes instance { get; } // 0x0000000181E46B30-0x0000000181E46BC0 
	
		// Constructors
		public DebugShapes(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private void BuildSphere(ref Mesh outputMesh, float radius, uint longSubdiv, uint latSubdiv); // 0x0000000181E46030-0x0000000181E468B0
		private void BuildBox(ref Mesh outputMesh, float length, float width, float height); // 0x0000000181E442E0-0x0000000181E44F00
		private void BuildCone(ref Mesh outputMesh, float height, float topRadius, float bottomRadius, int nbSides); // 0x0000000181E44F00-0x0000000181E45990
		private void BuildPyramid(ref Mesh outputMesh, float width, float height, float depth); // 0x0000000181E45A30-0x0000000181E45EB0
		private void BuildShapes(); // 0x0000000181E45EB0-0x0000000181E46030
		private void RebuildResources(); // 0x0000000181E468B0-0x0000000181E46AB0
		public Mesh RequestSphereMesh(); // 0x0000000181E46B10-0x0000000181E46B30
		public Mesh BuildCustomSphereMesh(float radius, uint longSubdiv, uint latSubdiv); // 0x0000000181E45990-0x0000000181E45A30
		public Mesh RequestBoxMesh(); // 0x0000000181E46AB0-0x0000000181E46AD0
		public Mesh RequestConeMesh(); // 0x0000000181E46AD0-0x0000000181E46AF0
		public Mesh RequestPyramidMesh(); // 0x0000000181E46AF0-0x0000000181E46B10
	}
}
