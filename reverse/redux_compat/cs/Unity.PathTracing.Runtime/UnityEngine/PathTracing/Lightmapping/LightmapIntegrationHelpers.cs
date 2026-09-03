/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal static class LightmapIntegrationHelpers // TypeDefIndex: 13637
	{
		// Fields
		private static readonly ProfilerMarker k_BoxFiltering; // 0x00
	
		// Nested types
		internal class ComputeHelpers // TypeDefIndex: 13638
		{
			// Fields
			internal ComputeShader ComputeHelperShader; // 0x10
			internal static int MultiplyKernel; // 0x00
			internal static int BroadcastChannelKernel; // 0x04
			internal static int SetChannelKernel; // 0x08
			internal static int ReferenceBoxFilterKernel; // 0x0C
			internal static int ReferenceBoxFilterBlueChannelKernel; // 0x10
			internal static int StandardErrorKernel; // 0x14
			internal static int StandardErrorThresholdKernel; // 0x18
			internal static int GetValueKernel; // 0x1C
			internal static int NormalizeByAlphaKernel; // 0x20
			internal static int CopyTextureAdditiveKernel; // 0x24
			internal static int MaskAlphaChannelKernel; // 0x28
			private static readonly ProfilerMarker k_CopyTextureAdditive; // 0x30
			private static readonly ProfilerMarker k_MaskAlphaChannel; // 0x38
	
			// Nested types
			internal static class ShaderIDs // TypeDefIndex: 13639
			{
				// Fields
				public static readonly int TextureInOut; // 0x00
				public static readonly int SampleCountInW; // 0x04
				public static readonly int VarianceInR; // 0x08
				public static readonly int StandardErrorInR; // 0x0C
				public static readonly int MeanInR; // 0x10
				public static readonly int SourceTexture; // 0x14
				public static readonly int OutputBuffer; // 0x18
				public static readonly int X; // 0x1C
				public static readonly int Y; // 0x20
				public static readonly int TextureOut; // 0x24
				public static readonly int TextureWidth; // 0x28
				public static readonly int TextureHeight; // 0x2C
				public static readonly int MultiplicationFactor; // 0x30
				public static readonly int BoxFilterRadius; // 0x34
				public static readonly int StandardErrorThreshold; // 0x38
				public static readonly int ChannelIndex; // 0x3C
				public static readonly int ChannelValue; // 0x40
				public static readonly int TemporaryRenderTarget; // 0x44
				public static readonly int SecondTemporaryRenderTarget; // 0x48
				public static readonly int MultiplyTemporaryRenderTarget; // 0x4C
				public static readonly int DestinationTexture; // 0x50
				public static readonly int SourceX; // 0x54
				public static readonly int SourceY; // 0x58
				public static readonly int SourceWidth; // 0x5C
				public static readonly int SourceHeight; // 0x60
				public static readonly int DestinationX; // 0x64
				public static readonly int DestinationY; // 0x68
	
				// Constructors
				static ShaderIDs(); // 0x0000000181E128F0-0x0000000181E12DB0
			}
	
			// Constructors
			public ComputeHelpers(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static ComputeHelpers(); // 0x0000000181E07310-0x0000000181E073D0
	
			// Methods
			public void Load(); // 0x0000000181E06E00-0x0000000181E07100
			public void CopyTextureAdditive(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, int width, int height, int sourceX = 0 /* Metadata: 0x006A7DCE */, int sourceY = 0 /* Metadata: 0x006A7DCF */, int destinationX = 0 /* Metadata: 0x006A7DD0 */, int destinationY = 0 /* Metadata: 0x006A7DD1 */); // 0x0000000181E06AF0-0x0000000181E06E00
			public void MaskAlphaChannel(CommandBuffer cmd, RenderTargetIdentifier texture, int width, int height); // 0x0000000181E07100-0x0000000181E07310
		}
	
		public class GPUSync : IDisposable // TypeDefIndex: 13640
		{
			// Fields
			private RenderTexture _syncTexture; // 0x10
			private Texture2D _readableTex; // 0x18
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 13641
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Action<AsyncGPUReadbackRequest> __9__3_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181E144A0-0x0000000181E14510
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _Sync_b__3_0(AsyncGPUReadbackRequest _p0_); // 0x00000001802E76C0-0x00000001802E76D0
			}
	
			// Constructors
			public GPUSync(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Create(); // 0x0000000181E09250-0x0000000181E09410
			public void Sync(CommandBuffer cmd); // 0x0000000181E09560-0x0000000181E09770
			public void RequestAsyncReadback(CommandBuffer cmd, Action<AsyncGPUReadbackRequest> callback); // 0x0000000181E09530-0x0000000181E09560
			public void Dispose(); // 0x0000000181E09410-0x0000000181E09530
		}
	
		public struct HitEntry // TypeDefIndex: 13642
		{
			// Fields
			public uint instanceID; // 0x00
			public uint primitiveIndex; // 0x04
			public float2 barycentrics; // 0x08
		}
	
		public enum LogBufferType // TypeDefIndex: 13643
		{
			UInt = 0,
			Float2 = 1,
			Float4 = 2,
			HitEntry = 3
		}
	
		public class AdaptiveSample // TypeDefIndex: 13644
		{
			// Fields
			public uint sampleCount; // 0x10
			public float accumulatedLuminance; // 0x14
			public float mean; // 0x18
			public float meanSqr; // 0x1C
			public float variance; // 0x20
			public float varianceFiltered; // 0x24
			public float standardError; // 0x28
			public bool active; // 0x2C
	
			// Constructors
			public AdaptiveSample(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public override string ToString(); // 0x0000000181E02BC0-0x0000000181E02E60
			public static string HeaderString(); // 0x0000000181E02920-0x0000000181E029B0
			public static string SamplesToString(AdaptiveSample[] samples, int x, int y, float adaptiveThreshold); // 0x0000000181E029B0-0x0000000181E02BC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 13645
		{
			// Fields
			public string prefix; // 0x10
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LogGraphicsBuffer_b__0(AsyncGPUReadbackRequest request); // 0x0000000181E14150-0x0000000181E14350
			internal void _LogGraphicsBuffer_b__1(AsyncGPUReadbackRequest request); // 0x0000000181E14350-0x0000000181E143C0
			internal void _LogGraphicsBuffer_b__2(AsyncGPUReadbackRequest request); // 0x0000000181E143C0-0x0000000181E14430
			internal void _LogGraphicsBuffer_b__3(AsyncGPUReadbackRequest request); // 0x0000000181E14430-0x0000000181E144A0
		}
	
		// Constructors
		static LightmapIntegrationHelpers(); // 0x0000000181E0E080-0x0000000181E0E0F0
	
		// Methods
		private static string IntegratedOutputTypeToComponentName(IntegratedOutputType integratedOutputType); // 0x0000000181E0B8A0-0x0000000181E0BA00
		private static string BuildLightmapComponentPath(string outputType, int lightmapIndex, string path); // 0x0000000181E0AB20-0x0000000181E0ABA0
		public static bool WriteLightmap(CommandBuffer cmd, RenderTexture renderTex, string outputType, int lightmapIndex, string path); // 0x0000000181E0DF10-0x0000000181E0DFF0
		public static bool WriteLightmap(CommandBuffer cmd, RenderTexture renderTex, IntegratedOutputType integratedOutputType, int lightmapIndex, string path); // 0x0000000181E0DFF0-0x0000000181E0E080
		public static Texture2D ReadLightmap(IntegratedOutputType integratedOutputType, int lightmapIndex, string path); // 0x0000000181E0D160-0x0000000181E0D270
		private static void OutputUIntRequestData(string prefix, AsyncGPUReadbackRequest request); // 0x0000000181E0CFA0-0x0000000181E0D160
		private static void OutputFloat2RequestData(string prefix, AsyncGPUReadbackRequest request); // 0x0000000181E0C5B0-0x0000000181E0C820
		private static void OutputFloat4RequestData(string prefix, AsyncGPUReadbackRequest request); // 0x0000000181E0C820-0x0000000181E0CC00
		private static void OutputHitEntryRequestData(string prefix, AsyncGPUReadbackRequest request); // 0x0000000181E0CC00-0x0000000181E0CFA0
		public static void LogGraphicsBuffer(CommandBuffer cmd, GraphicsBuffer graphicsBuffer, string prefix, LogBufferType type); // 0x0000000181E0BA10-0x0000000181E0BDB0
		public static bool IsPow2(int value); // 0x0000000181E0BA00-0x0000000181E0BA10
		internal static GraphicsBuffer CreateDispatchDimensionBuffer(); // 0x0000000181E0B220-0x0000000181E0B280
		public static double4 GetSum(int width, int height, RenderTexture renderTex); // 0x0000000181E0B280-0x0000000181E0B480
		public static float Luminance(Color color); // 0x0000000181E0BDB0-0x0000000181E0BDE0
		public static Color GetValue(CommandBuffer cmd, ComputeShader computeShader, int getValueKernel, int sampleX, int sampleY, int width, int height, RenderTargetIdentifier renderTargetIdentifier); // 0x0000000181E0B480-0x0000000181E0B8A0
		public static void NormalizeByAlpha(CommandBuffer cmd, ComputeShader computeShader, int normalizeByAlphaKernel, int width, int height, RenderTargetIdentifier inOut); // 0x0000000181E0C400-0x0000000181E0C5B0
		public static void MultiplyRenderTexture(CommandBuffer cmd, ComputeShader multiplyShader, int multiplyKernel, RenderTargetIdentifier inOut, int width, int height, Vector4 multiplicationFactor); // 0x0000000181E0BDE0-0x0000000181E0BFC0
		public static void MultiplyTexture(CommandBuffer cmd, ComputeShader multiplyShader, int multiplyKernel, Texture2D texture, Vector4 multiplicationFactor); // 0x0000000181E0BFC0-0x0000000181E0C400
		public static void StandardErrorRenderTexture(CommandBuffer cmd, ComputeShader standardError, int standardErrorKernel, RenderTargetIdentifier varianceInR, RenderTargetIdentifier sampleCountInW, RenderTargetIdentifier output, int width, int height); // 0x0000000181E0DA40-0x0000000181E0DC90
		public static void StandardErrorThresholdRenderTexture(CommandBuffer cmd, ComputeShader standardErrorThreshold, int StandardErrorThresholdKernel, RenderTargetIdentifier standardErrorInR, RenderTargetIdentifier meanInR, float standardErrorThresholdValue, RenderTargetIdentifier output, int width, int height); // 0x0000000181E0DC90-0x0000000181E0DF10
		public static void BroadcastChannelRenderTexture(CommandBuffer cmd, ComputeShader broadcastChannelShader, int broadcastChannelKernel, RenderTargetIdentifier inOut, int width, int height, int channelIndex); // 0x0000000181E0A950-0x0000000181E0AB20
		public static void SetChannelRenderTexture(CommandBuffer cmd, ComputeShader setChannelShader, int setChannelKernel, RenderTargetIdentifier inOut, int width, int height, int channelIndex, float channelValue); // 0x0000000181E0D840-0x0000000181E0DA40
		public static void ReferenceBoxFilterRenderTexture(CommandBuffer cmd, ComputeShader referenceBoxFilterShader, int referenceBoxFilterKernel, RenderTargetIdentifier inOut, int width, int height, int radius); // 0x0000000181E0D550-0x0000000181E0D840
		public static void ReferenceBoxFilterBlueChannelRenderTexture(CommandBuffer cmd, ComputeShader referenceBoxFilterBlueChannelShader, int referenceBoxFilterBlueChannelKernel, RenderTargetIdentifier inOut, int width, int height, int radius, GraphicsBuffer indirectDispatchBuffer); // 0x0000000181E0D270-0x0000000181E0D550
		internal static void ComputeOccupiedTexelRegionForInstance(uint lightmapWidth, uint lightmapHeight, Vector4 instanceLightmapST, Vector2 uvBoundsSize, Vector2 uvBoundsOffset, out Vector4 normalizedOccupiedST, out Vector2Int occupiedTexelSize, out Vector2Int occupiedTexelOffset); // 0x0000000181E0ABA0-0x0000000181E0AE80
		internal static void ComputeUVBounds(IEnumerable<Vector2> uvs, out Vector2 size, out Vector2 offset); // 0x0000000181E0AE80-0x0000000181E0B220
	}
}
