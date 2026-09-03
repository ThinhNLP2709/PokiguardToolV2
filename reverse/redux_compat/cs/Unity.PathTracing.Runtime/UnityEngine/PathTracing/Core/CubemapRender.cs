/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class CubemapRender : IDisposable // TypeDefIndex: 13572
	{
		// Fields
		private Material _material; // 0x10
		private Shader _lastUsedShader; // 0x18
		private LocalKeyword? _noSunKeyword; // 0x20
		private Color[] _faceColors; // 0x40
		private readonly Mesh _skyboxMesh; // 0x48
		private readonly Mesh _sixFaceSkyboxMesh; // 0x50
		private readonly Shader _solidColorShader; // 0x58
		private Material _colorMaterial; // 0x60
		private MaterialPropertyBlock _colorProperties; // 0x68
		private RenderTexture _cubemap; // 0x70
		private int _hash; // 0x78
		private Mode _mode; // 0x7C
		private static readonly int[] _cubeFaceToSkyboxPass; // 0x00
		private static readonly Matrix4x4[] _cubemapFaceBases; // 0x08
		private static readonly int s_ColorID; // 0x10
	
		// Properties
		public int Hash { get; } // 0x000000018169BB50-0x000000018169BB60 
	
		// Nested types
		internal enum Mode // TypeDefIndex: 13573
		{
			Material = 0,
			Color = 1
		}
	
		// Constructors
		public CubemapRender(Mesh skyboxMesh, Mesh sixFaceSkyboxMesh, Shader solidColorShader); // 0x0000000181DED8F0-0x0000000181DEDA20
		static CubemapRender(); // 0x0000000181DED3C0-0x0000000181DED8F0
	
		// Methods
		public void Dispose(); // 0x0000000181DEBED0-0x0000000181DEBF80
		public void SetMaterial(Material mat); // 0x00000001803780D0-0x00000001803780E0
		public void SetColor(Color color); // 0x0000000181DED080-0x0000000181DED0D0
		public void SetFaceColor(CubemapFace face, Color color); // 0x0000000181DED0D0-0x0000000181DED110
		public void SetMode(Mode mode); // 0x00000001819E0710-0x00000001819E0720
		public Material GetMaterial(); // 0x0000000180377550-0x0000000180377560
		private Color LightColorInRenderingSpace(Light light); // 0x0000000181DEC250-0x0000000181DEC3C0
		public void Update(CommandBuffer cmd, Light sun, int resolution, out bool viewAndProjectionMatricesChanged); // 0x0000000181DED110-0x0000000181DED3C0
		private void ReleaseCubemapIfExists(); // 0x0000000181DEC3C0-0x0000000181DEC480
		public Texture GetCubemap(); // 0x0000000181DEC180-0x0000000181DEC220
		private void RenderWithColor(CommandBuffer cmd); // 0x0000000181DEC480-0x0000000181DEC740
		private void RenderWithMaterial(CommandBuffer cmd, Light sun, int cubemapResolution, out bool viewAndProjectionMatricesChanged); // 0x0000000181DEC740-0x0000000181DED080
		private void EnsureCubemapExistsWithParticularResolution(int resolution); // 0x0000000181DEBF80-0x0000000181DEC180
		private void CreateCubemap(int width); // 0x0000000181DEBD60-0x0000000181DEBED0
		private static bool IsOpenGLGfxDevice(); // 0x0000000181DEC220-0x0000000181DEC250
	}
}
