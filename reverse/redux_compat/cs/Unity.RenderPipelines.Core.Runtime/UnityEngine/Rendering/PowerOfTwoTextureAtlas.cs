/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class PowerOfTwoTextureAtlas : Texture2DAtlas // TypeDefIndex: 5707
	{
		// Fields
		private readonly int m_MipPadding; // 0x48
		private const float k_MipmapFactorApprox = 1.33f; // Metadata: 0x006617DB
		private Dictionary<TextureIdentifier, Vector2Int> m_RequestedTextures; // 0x50
	
		// Properties
		public int mipPadding { get; } // 0x000000018033D1C0-0x000000018033D1D0 
	
		// Nested types
		private enum BlitType // TypeDefIndex: 5708
		{
			Padding = 0,
			PaddingMultiply = 1,
			OctahedralPadding = 2,
			OctahedralPaddingMultiply = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5709
		{
			// Fields
			public static readonly __c __9; // 0x00
			[TupleElementNames(new string[2] {"identifier", "size" })]
			public static Comparison<ValueTuple<Texture2DAtlas.TextureIdentifier, Vector2Int>> __9__33_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181EA2000-0x0000000181EA2070
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _RelayoutEntries_b__33_0([TupleElementNames(new string[2] {"identifier", "size" })] ValueTuple<Texture2DAtlas.TextureIdentifier, Vector2Int> c1, [TupleElementNames(new string[2] {"identifier", "size" })] ValueTuple<Texture2DAtlas.TextureIdentifier, Vector2Int> c2); // 0x0000000181EA1D60-0x0000000181EA1DB0
		}
	
		// Constructors
		public PowerOfTwoTextureAtlas(int size, int mipPadding, GraphicsFormat format, FilterMode filterMode = FilterMode.Point /* Metadata: 0x006617D4 */, string name = "" /* Metadata: 0x006617D5 */, bool useMipMap = true /* Metadata: 0x006617D6 */); // 0x0000000181E921C0-0x0000000181E922C0
	
		// Methods
		private int GetTexturePadding(); // 0x0000000181E91940-0x0000000181E91970
		public Vector4 GetPayloadScaleOffset(Texture texture, [IsReadOnly] in Vector4 scaleOffset); // 0x0000000181E91720-0x0000000181E91880
		public static Vector4 GetPayloadScaleOffset([IsReadOnly] in Vector2 textureSize, [IsReadOnly] in Vector2 paddingSize, [IsReadOnly] in Vector4 scaleOffset); // 0x0000000181E91640-0x0000000181E91720
		private void Blit2DTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, BlitType blitType); // 0x0000000181E90470-0x0000000181E908C0
		[Obsolete("BlitTexture(CommandBuffer, Vector4, Texture, Vector4, bool, int) is obsolete, use BlitTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public override void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E91250-0x0000000181E91320
		[Obsolete("BlitTexture(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public override void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E91430-0x0000000181E91490
		public override void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x006617D7 */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E91320-0x0000000181E91430
		[Obsolete("BlitTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool, int) is obsolete, use BlitTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public void BlitTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E91110-0x0000000181E91250
		[Obsolete("BlitTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public void BlitTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E90FD0-0x0000000181E91110
		public void BlitTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x006617D8 */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E90EB0-0x0000000181E90FD0
		[Obsolete("BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool, int) is obsolete, use BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool ,TextureIdentifier ) instead.", true)]
		public override void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E90C60-0x0000000181E90D30
		[Obsolete("BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool ,TextureIdentifier ) instead.", true)]
		public override void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E90D30-0x0000000181E90D90
		public override void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x006617D9 */, TextureIdentifier textureIdentifier = default); // 0x0000000181E90D90-0x0000000181E90EB0
		[Obsolete("BlitOctahedralTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool, int) is obsolete, use BlitOctahedralTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool,TextureIdentifier  ) instead.", true)]
		public void BlitOctahedralTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E90B20-0x0000000181E90C60
		[Obsolete("BlitOctahedralTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitOctahedralTextureMultiply(CommandBuffer, Vector4, Texture, Vector4, bool,TextureIdentifier  ) instead.", true)]
		public void BlitOctahedralTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E908C0-0x0000000181E90A00
		public void BlitOctahedralTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x006617DA */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E90A00-0x0000000181E90B20
		private void TextureSizeToPowerOfTwo(Texture texture, ref int width, ref int height); // 0x0000000181E92160-0x0000000181E921C0
		private Vector2 GetPowerOfTwoTextureSize(Texture texture); // 0x0000000181E91880-0x0000000181E91940
		[Obsolete("AllocateTexture(CommandBuffer, ref Vector4, Texture, int, int, int) is obsolete, use AllocateTexture(CommandBuffer, ref Vector4, Texture, int, int, TextureIdentifier) instead.", true)]
		public override bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, int overrideInstanceID); // 0x0000000181E90440-0x0000000181E90470
		public override bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, TextureIdentifier overrideIdentifier = default); // 0x0000000181E90220-0x0000000181E90440
		public void ResetRequestedTexture(); // 0x0000000181E92140-0x0000000181E92160
		public bool ReserveSpace(Texture texture); // 0x0000000181E91E10-0x0000000181E91EA0
		public bool ReserveSpace(Texture texture, int width, int height); // 0x0000000181E91F40-0x0000000181E91FA0
		public bool ReserveSpace(Texture textureA, Texture textureB, int width, int height); // 0x0000000181E91EC0-0x0000000181E91F40
		[Obsolete("ReserveSpace with int id is obsolete, use the TextureIdentifier version instead.", true)]
		public bool ReserveSpace(int id, int width, int height); // 0x0000000181E91EA0-0x0000000181E91EC0
		public bool ReserveSpace(TextureIdentifier identifier, int width, int height); // 0x0000000181E91FA0-0x0000000181E92140
		public bool RelayoutEntries(); // 0x0000000181E91970-0x0000000181E91E10
		public static long GetApproxCacheSizeInByte(int nbElement, int resolution, bool hasMipmap, GraphicsFormat format); // 0x0000000181E91490-0x0000000181E91560
		public static int GetMaxCacheSizeForWeightInByte(int weight, bool hasMipmap, GraphicsFormat format); // 0x0000000181E91560-0x0000000181E91640
	}
}
