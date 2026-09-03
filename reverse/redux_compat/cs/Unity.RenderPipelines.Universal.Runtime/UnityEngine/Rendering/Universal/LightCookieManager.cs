/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class LightCookieManager : IDisposable // TypeDefIndex: 9494
	{
		// Fields
		private static readonly Matrix4x4 s_DirLightProj; // 0x00
		private Texture2DAtlas m_AdditionalLightsCookieAtlas; // 0x10
		private LightCookieShaderData m_AdditionalLightsCookieShaderData; // 0x18
		private readonly Settings m_Settings; // 0x20
		private WorkMemory m_WorkMem; // 0x38
		private int[] m_VisibleLightIndexToShaderDataIndex; // 0x40
		private const int k_MaxCookieSizeDivisor = 16; // Metadata: 0x0069EBD6
		private int m_CookieSizeDivisor; // 0x48
		private uint m_PrevCookieRequestPixelCount; // 0x4C
		private int m_PrevWarnFrame; // 0x50
		[CompilerGenerated]
		private bool _IsKeywordLightCookieEnabled_k__BackingField; // 0x54
	
		// Properties
		internal bool IsKeywordLightCookieEnabled { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D250-0x000000018033D260 0x000000018033E860-0x000000018033E870
		internal RTHandle AdditionalLightsCookieAtlasTexture { get; } // 0x0000000181F953F0-0x0000000181F95400 
	
		// Nested types
		private static class ShaderProperty // TypeDefIndex: 9495
		{
			// Fields
			public static readonly int mainLightTexture; // 0x00
			public static readonly int mainLightWorldToLight; // 0x04
			public static readonly int mainLightCookieTextureFormat; // 0x08
			public static readonly int additionalLightsCookieAtlasTexture; // 0x0C
			public static readonly int additionalLightsCookieAtlasTextureFormat; // 0x10
			public static readonly int lightCookiesBuffer; // 0x14
			public static readonly int additionalLightsWorldToLights; // 0x18
			public static readonly int additionalLightsCookieAtlasUVRects; // 0x1C
			public static readonly int additionalLightsLightTypes; // 0x20
			public static readonly int additionalLightsCookieEnableBits; // 0x24
	
			// Constructors
			static ShaderProperty(); // 0x0000000181F98000-0x0000000181F981E0
		}
	
		internal enum LightCookieShaderFormat // TypeDefIndex: 9496
		{
			None = -1,
			RGB = 0,
			Alpha = 1,
			Red = 2
		}
	
		public struct Settings // TypeDefIndex: 9497
		{
			// Fields
			public AtlasSettings atlas; // 0x00
			public int maxAdditionalLights; // 0x0C
			public float cubeOctahedralSizeScale; // 0x10
			public bool useConstantBuffer; // 0x14
	
			// Nested types
			public struct AtlasSettings // TypeDefIndex: 9498
			{
				// Fields
				public Vector2Int resolution; // 0x00
				public GraphicsFormat format; // 0x08
	
				// Properties
				public bool isPow2 { get; } // 0x0000000181F88B90-0x0000000181F88BB0 
				public bool isSquare { get; } // 0x0000000181F88BB0-0x0000000181F88BC0 
			}
	
			// Methods
			public static Settings Create(); // 0x0000000181F97F50-0x0000000181F98000
		}
	
		private struct LightCookieMapping // TypeDefIndex: 9499
		{
			// Fields
			public ushort visibleLightIndex; // 0x00
			public ushort lightBufferIndex; // 0x02
			public Light light; // 0x08
			public static readonly Func<LightCookieMapping, LightCookieMapping, int> s_CompareByCookieSize; // 0x00
			public static readonly Func<LightCookieMapping, LightCookieMapping, int> s_CompareByBufferIndex; // 0x08
	
			// Constructors
			static LightCookieMapping(); // 0x0000000181F95530-0x0000000181F95620
	
			// Methods
			private static int CompareByCookieSize(LightCookieMapping a, LightCookieMapping b); // 0x0000000181F95430-0x0000000181F95530
			private static int CompareByBufferIndex(LightCookieMapping a, LightCookieMapping b); // 0x0000000181F95420-0x0000000181F95430
		}
	
		[IsReadOnly]
		private struct WorkSlice<T> // TypeDefIndex: 9500
		{
			// Fields
			private readonly T[] m_Data;
			private readonly int m_Start;
			private readonly int m_Length;
	
			// Properties
			public T this[int index] { get => default; set {} }
			public int length { get; }
			public int capacity { get; }
	
			// Constructors
			public WorkSlice(T[] src, int srcLen = -1 /* Metadata: 0x0069EBDB */);
			public WorkSlice(T[] src, int srcStart, int srcLen = -1 /* Metadata: 0x0069EBDC */);
	
			// Methods
			public void Sort(Func<T, T, int> compare);
		}
	
		private class WorkMemory // TypeDefIndex: 9501
		{
			// Fields
			public LightCookieMapping[] lightMappings; // 0x10
			public Vector4[] uvRects; // 0x18
	
			// Constructors
			public WorkMemory(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Resize(int size); // 0x0000000181FA0040-0x0000000181FA06F0
		}
	
		private class LightCookieShaderData : IDisposable // TypeDefIndex: 9502
		{
			// Fields
			private int m_Size; // 0x10
			private bool m_UseConstantBuffer; // 0x14
			private Matrix4x4[] m_WorldToLightCpuData; // 0x18
			private Vector4[] m_AtlasUVRectCpuData; // 0x20
			private float[] m_LightTypeCpuData; // 0x28
			private ShaderBitArray m_CookieEnableBitsCpuData; // 0x30
			private const string k_LightCookieCBName = "Light Cookies Buffer"; // Metadata: 0x0069EBDD
			private NativeArray<Vector4> m_LightCookieData; // 0x38
			private GraphicsBuffer m_LightCookieBuffer; // 0x48
			[CompilerGenerated]
			private bool _isUploaded_k__BackingField; // 0x50
	
			// Properties
			public Matrix4x4[] worldToLights { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public ShaderBitArray cookieEnableBits { get; } // 0x000000018031E110-0x000000018031E120 
			public Vector4[] atlasUVRects { get; } // 0x00000001802F8630-0x00000001802F8640 
			public float[] lightTypes { get; } // 0x000000018033D240-0x000000018033D250 
			public bool isUploaded { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
	
			// Constructors
			public LightCookieShaderData(int size, bool useConstantBuffer); // 0x0000000181F95D60-0x0000000181F95DA0
	
			// Methods
			public void Dispose(); // 0x0000000181F957A0-0x0000000181F95870
			public void Resize(int size); // 0x0000000181F95870-0x0000000181F95A20
			public void Upload(CommandBuffer cmd); // 0x0000000181F95A20-0x0000000181F95D60
			public void Clear(CommandBuffer cmd); // 0x0000000181F95620-0x0000000181F957A0
		}
	
		// Constructors
		public LightCookieManager(ref Settings settings); // 0x0000000181F95360-0x0000000181F953F0
		static LightCookieManager(); // 0x0000000181F952D0-0x0000000181F95360
	
		// Methods
		private void InitAdditionalLights(int size); // 0x0000000181F93580-0x0000000181F936D0
		public bool isInitialized(); // 0x0000000181F95400-0x0000000181F95420
		public void Dispose(); // 0x0000000181F92650-0x0000000181F92690
		public int GetLightCookieShaderDataIndex(int visibleLightIndex); // 0x0000000181F93250-0x0000000181F932A0
		public void Setup(CommandBuffer cmd, UniversalLightData lightData); // 0x0000000181F94140-0x0000000181F94590
		private bool SetupMainLight(CommandBuffer cmd, ref VisibleLight visibleMainLight); // 0x0000000181F93A70-0x0000000181F94140
		internal LightCookieShaderFormat GetLightCookieShaderFormat(GraphicsFormat cookieFormat); // 0x0000000181F932A0-0x0000000181F93320
		private void GetLightUVScaleOffset(ref UniversalAdditionalLightData additionalLightData, ref Matrix4x4 uvTransform); // 0x0000000181F93320-0x0000000181F93580
		private bool SetupAdditionalLights(CommandBuffer cmd, UniversalLightData lightData); // 0x0000000181F936D0-0x0000000181F93A70
		private int FilterAndValidateAdditionalLights(UniversalLightData lightData, LightCookieMapping[] validLightMappings); // 0x0000000181F92D60-0x0000000181F93250
		private int UpdateAdditionalLightsAtlas(CommandBuffer cmd, ref WorkSlice<LightCookieMapping> validLightMappings, Vector4[] textureAtlasUVRects); // 0x0000000181F94650-0x0000000181F948A0
		private int FetchUVRects(CommandBuffer cmd, ref WorkSlice<LightCookieMapping> validLightMappings, Vector4[] textureAtlasUVRects, int cookieSizeDivisor); // 0x0000000181F92A70-0x0000000181F92D60
		private uint ComputeCookieRequestPixelCount(ref WorkSlice<LightCookieMapping> validLightMappings); // 0x0000000181F92420-0x0000000181F92520
		private int ApproximateCookieSizeDivisor(float requestAtlasRatio); // 0x0000000181F923E0-0x0000000181F92420
		private Vector4 Fetch2D(CommandBuffer cmd, Texture cookie, int cookieSizeDivisor = 1 /* Metadata: 0x0069EBD4 */); // 0x0000000181F92690-0x0000000181F92820
		private Vector4 FetchCube(CommandBuffer cmd, Texture cookie, int cookieSizeDivisor = 1 /* Metadata: 0x0069EBD5 */); // 0x0000000181F92820-0x0000000181F92A70
		private int ComputeOctahedralCookieSize(Texture cookie); // 0x0000000181F92520-0x0000000181F92650
		private void AdjustUVRect(ref Vector4 uvScaleOffset, Texture cookie, ref Vector2 cookieSize); // 0x0000000181F922D0-0x0000000181F923E0
		private void ShrinkUVRect(ref Vector4 uvScaleOffset, float amountPixels, ref Vector2 cookieSize); // 0x0000000181F94590-0x0000000181F94650
		private void UploadAdditionalLights(CommandBuffer cmd, UniversalLightData lightData, ref WorkSlice<LightCookieMapping> validLightMappings, ref WorkSlice<Vector4> validUvRects); // 0x0000000181F948A0-0x0000000181F952D0
	}
}
