/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.Sampling
{
	internal sealed class SamplingResources : IDisposable // TypeDefIndex: 5867
	{
		// Fields
		private Texture2D m_SobolScramblingTile; // 0x10
		private Texture2D m_SobolRankingTile; // 0x18
		private Texture2D m_SobolOwenScrambled256Samples; // 0x20
		private GraphicsBuffer m_SobolBuffer; // 0x28
		internal static readonly uint[] sobolMatrices; // 0x00
	
		// Nested types
		internal enum ResourceType // TypeDefIndex: 5868
		{
			BlueNoiseTextures = 1,
			SobolMatrices = 2,
			All = 3
		}
	
		// Constructors
		public SamplingResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static SamplingResources(); // 0x0000000181ECB910-0x0000000181ECB990
	
		// Methods
		public static void Bind(CommandBuffer cmd, SamplingResources resources); // 0x0000000181ECB710-0x0000000181ECB8F0
		public void Dispose(); // 0x0000000181ECB8F0-0x0000000181ECB910
	}
}
