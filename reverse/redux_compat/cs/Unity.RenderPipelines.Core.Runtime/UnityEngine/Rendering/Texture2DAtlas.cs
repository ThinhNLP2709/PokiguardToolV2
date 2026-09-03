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
	public class Texture2DAtlas // TypeDefIndex: 5724
	{
		// Fields
		private protected const int kGPUTexInvalid = 0; // Metadata: 0x0066195D
		private protected const int kGPUTexValidMip0 = 1; // Metadata: 0x0066195E
		private protected const int kGPUTexValidMipAll = 2; // Metadata: 0x0066195F
		private protected RTHandle m_AtlasTexture; // 0x10
		private protected int m_Width; // 0x18
		private protected int m_Height; // 0x1C
		private protected GraphicsFormat m_Format; // 0x20
		private protected bool m_UseMipMaps; // 0x24
		private bool m_IsAtlasTextureOwner; // 0x25
		private AtlasAllocator m_AtlasAllocator; // 0x28
		[TupleElementNames(new string[2] {"scaleOffset", "size" })]
		private Dictionary<TextureIdentifier, ValueTuple<Vector4, Vector2Int>> m_AllocationCache; // 0x30
		private Dictionary<TextureIdentifier, int> m_IsGPUTextureUpToDate; // 0x38
		private Dictionary<TextureIdentifier, int> m_TextureHashes; // 0x40
		private static readonly Vector4 fullScaleOffset; // 0x00
		private static readonly int s_MaxMipLevelPadding; // 0x10
	
		// Properties
		public static int maxMipLevelPadding { get; } // 0x0000000181EA1160-0x0000000181EA11B0 
		public RTHandle AtlasTexture { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		[IsReadOnly]
		public struct TextureIdentifier : IEquatable<TextureIdentifier> // TypeDefIndex: 5725
		{
			// Fields
			internal readonly ulong value; // 0x00
	
			// Properties
			public static TextureIdentifier None { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Constructors
			internal TextureIdentifier(ulong value); // 0x0000000180CBE820-0x0000000180CBE830
	
			// Methods
			public bool Equals(TextureIdentifier other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
			public override int GetHashCode(); // 0x000000018126B220-0x000000018126B230
			public static bool operator ==(TextureIdentifier left, TextureIdentifier right); // 0x0000000180A29AB0-0x0000000180A29AC0
			public static bool operator !=(TextureIdentifier left, TextureIdentifier right); // 0x000000018126B560-0x000000018126B570
		}
	
		private enum BlitType // TypeDefIndex: 5726
		{
			Default = 0,
			CubeTo2DOctahedral = 1,
			SingleChannel = 2,
			CubeTo2DOctahedralSingleChannel = 3
		}
	
		// Constructors
		public Texture2DAtlas(int width, int height, GraphicsFormat format, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0066194E */, bool powerOfTwoPadding = false /* Metadata: 0x0066194F */, string name = "" /* Metadata: 0x00661950 */, bool useMipMap = true /* Metadata: 0x00661951 */); // 0x0000000181EA0E80-0x0000000181EA1160
		static Texture2DAtlas(); // 0x0000000181EA0E20-0x0000000181EA0E80
	
		// Methods
		public void Release(); // 0x0000000181EA0A10-0x0000000181EA0AD0
		public void ResetAllocator(); // 0x0000000181EA0AD0-0x0000000181EA0B60
		public void ClearTarget(CommandBuffer cmd); // 0x0000000181E9F5C0-0x0000000181E9F7B0
		private protected int GetTextureMipmapCount(int width, int height); // 0x0000000181E9FC30-0x0000000181E9FCC0
		private protected bool Is2D(Texture texture); // 0x0000000181E9FCC0-0x0000000181E9FD80
		private protected bool IsSingleChannelBlit(Texture source, Texture destination); // 0x0000000181E9FF30-0x0000000181EA01A0
		private void Blit2DTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, BlitType blitType); // 0x0000000181E9EE40-0x0000000181E9F110
		private protected void MarkGPUTextureValid(TextureIdentifier identifier, bool mipAreValid = false /* Metadata: 0x00661952 */); // 0x0000000181EA0200-0x0000000181EA0270
		private protected void MarkGPUTextureInvalid(TextureIdentifier identifier); // 0x0000000181EA01A0-0x0000000181EA0200
		[Obsolete("BlitTexture(CommandBuffer, Vector4, Texture, Vector4 , bool , int) is obsolete, use BlitTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E91250-0x0000000181E91320
		[Obsolete("BlitTexture(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E91430-0x0000000181E91490
		public virtual void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x00661953 */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E9F420-0x0000000181E9F5C0
		[Obsolete("BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool, int) is obsolete, use BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, int overrideInstanceID); // 0x0000000181E90C60-0x0000000181E90D30
		[Obsolete("BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, int) is obsolete, use BlitOctahedralTexture(CommandBuffer, Vector4, Texture, Vector4, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, int overrideInstanceID); // 0x0000000181E90D30-0x0000000181E90D90
		public virtual void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true /* Metadata: 0x00661954 */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E9F3B0-0x0000000181E9F420
		[Obsolete("BlitCubeTexture2D(CommandBuffer, Vector4, Texture, bool blitMips, int ) is obsolete, use BlitCubeTexture2D(CommandBuffer, Vector4, Texture, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitCubeTexture2D(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, bool blitMips, int overrideInstanceID); // 0x0000000181E9F150-0x0000000181E9F200
		[Obsolete("BlitCubeTexture2D(CommandBuffer, Vector4, Texture, int) is obsolete, use BlitCubeTexture2D(CommandBuffer, Vector4, Texture, bool, TextureIdentifier) instead.", true)]
		public virtual void BlitCubeTexture2D(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, int overrideInstanceID); // 0x0000000181E9F110-0x0000000181E9F150
		public virtual void BlitCubeTexture2D(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, bool blitMips = true /* Metadata: 0x00661955 */, TextureIdentifier overrideIdentifier = default); // 0x0000000181E9F200-0x0000000181E9F3B0
		[Obsolete("AllocateTexture(CommandBuffer, ref Vector4, Texture, int, int, int) is obsolete, use AllocateTexture(CommandBuffer, ref Vector4, Texture, int, int, TextureIdentifier) instead.", true)]
		public virtual bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, int overrideInstanceID); // 0x0000000181E9EDA0-0x0000000181E9EE40
		public virtual bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, TextureIdentifier overrideIdentifier = default); // 0x0000000181E9EB60-0x0000000181E9EDA0
		public bool AllocateTextureWithoutBlit(Texture texture, int width, int height, ref Vector4 scaleOffset); // 0x0000000181E9E8C0-0x0000000181E9E930
		[Obsolete("AllocateTextureWithoutBlit(int, int, int, ref Vector4) is obsolete, use AllocateTextureWithoutBlit(TextureIdentifier, int, int, ref Vector4) instead.", true)]
		public virtual bool AllocateTextureWithoutBlit(int instanceId, int width, int height, ref Vector4 scaleOffset); // 0x0000000181E9E8A0-0x0000000181E9E8C0
		public virtual bool AllocateTextureWithoutBlit(TextureIdentifier identifier, int width, int height, ref Vector4 scaleOffset); // 0x0000000181E9E930-0x0000000181E9EB60
		private protected int GetTextureHash(Texture textureA, Texture textureB); // 0x0000000181E9FAC0-0x0000000181E9FB30
		[Obsolete("int GetTextureID(Texture texture) is obsolete, use GetTextureIdentifier(Texture texture) instead.", true)]
		public int GetTextureID(Texture texture); // 0x0000000181E9FB90-0x0000000181E9FBC0
		public TextureIdentifier GetTextureIdentifier(Texture texture); // 0x0000000181E9FBC0-0x0000000181E9FBE0
		[Obsolete("GetTextureID(Texture textureA, Texture textureB) is obsolete , use GetTextureIdentifier(Texture textureA, Texture textureB) instead.", true)]
		public int GetTextureID(Texture textureA, Texture textureB); // 0x0000000181E9FB30-0x0000000181E9FB90
		public TextureIdentifier GetTextureIdentifier(Texture textureA, Texture textureB); // 0x0000000181E9FBE0-0x0000000181E9FC30
		public bool IsCached(out Vector4 scaleOffset, Texture textureA, Texture textureB); // 0x0000000181E9FD80-0x0000000181E9FDF0
		public bool IsCached(out Vector4 scaleOffset, Texture texture); // 0x0000000181E9FE70-0x0000000181E9FEB0
		[Obsolete("IsCached(out Vector4, int) is obsolete, use IsCached(out Vector4, TextureIdentifier) instead.", true)]
		public bool IsCached(out Vector4 scaleOffset, int id); // 0x0000000181E9FDF0-0x0000000181E9FE70
		public bool IsCached(out Vector4 scaleOffset, TextureIdentifier identifier); // 0x0000000181E9FEB0-0x0000000181E9FF30
		[Obsolete("GetCachedTextureSize(int) is obsolete, use GetCachedTextureSize(TextureIdentifier) instead.", true)]
		internal Vector2Int GetCachedTextureSize(int id); // 0x0000000181E9F9E0-0x0000000181E9FA50
		internal Vector2Int GetCachedTextureSize(TextureIdentifier identifier); // 0x0000000181E9FA50-0x0000000181E9FAC0
		public virtual bool NeedsUpdate(Texture texture, bool needMips = false /* Metadata: 0x00661956 */); // 0x0000000181EA07B0-0x0000000181EA0A10
		[Obsolete("NeedsUpdate(int, int, bool) is obsolete, use NeedsUpdate(TextureIdentifier, int, bool) instead.", true)]
		public virtual bool NeedsUpdate(int id, int updateCount, bool needMips); // 0x0000000181EA0270-0x0000000181EA0290
		public virtual bool NeedsUpdate(TextureIdentifier identifier, int updateCount, bool needMips = false /* Metadata: 0x00661957 */); // 0x0000000181EA06C0-0x0000000181EA07B0
		public virtual bool NeedsUpdate(Texture textureA, Texture textureB, bool needMips = false /* Metadata: 0x00661958 */); // 0x0000000181EA0290-0x0000000181EA06C0
		public virtual bool AddTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture); // 0x0000000181E9E7C0-0x0000000181E9E8A0
		public virtual bool UpdateTexture(CommandBuffer cmd, Texture oldTexture, Texture newTexture, ref Vector4 scaleOffset, Vector4 sourceScaleOffset, bool updateIfNeeded = true /* Metadata: 0x00661959 */, bool blitMips = true /* Metadata: 0x0066195A */); // 0x0000000181EA0B60-0x0000000181EA0D50
		public virtual bool UpdateTexture(CommandBuffer cmd, Texture texture, ref Vector4 scaleOffset, bool updateIfNeeded = true /* Metadata: 0x0066195B */, bool blitMips = true /* Metadata: 0x0066195C */); // 0x0000000181EA0D50-0x0000000181EA0E20
		internal bool EnsureTextureSlot(out bool isUploadNeeded, ref Vector4 scaleBias, TextureIdentifier key, int width, int height); // 0x0000000181E9F7B0-0x0000000181E9F9E0
	}
}
