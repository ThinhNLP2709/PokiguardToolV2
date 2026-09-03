/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class TextureSlotAllocator : IDisposable // TypeDefIndex: 13570
	{
		// Fields
		private readonly int _size; // 0x10
		private readonly GraphicsFormat _format; // 0x14
		private readonly FilterMode _filterMode; // 0x18
		private readonly CommandBuffer _cmd; // 0x20
		private RenderTexture _atlases; // 0x28
		private readonly HashSet<int> _freeAtlases; // 0x30
		private TextureQuadTree[] _textureQuadTrees; // 0x38
		private readonly Dictionary<TextureLocation, Vector2Int> _textureSizes; // 0x40
		private readonly int _tempTextureID; // 0x48
	
		// Properties
		public RenderTexture Texture { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		[IsReadOnly]
		public struct TextureLocation // TypeDefIndex: 13571
		{
			// Fields
			public readonly int AtlasIndex; // 0x00
			public readonly TextureQuadTree.TextureNode TextureNode; // 0x08
			public static readonly TextureLocation Invalid; // 0x00
	
			// Properties
			public bool IsValid { get; } // 0x0000000181DFCE30-0x0000000181DFCE50 
	
			// Constructors
			public TextureLocation(int atlasIndex, TextureQuadTree.TextureNode textureNode); // 0x0000000180F37790-0x0000000180F377B0
			static TextureLocation(); // 0x0000000181DFCDB0-0x0000000181DFCE30
		}
	
		// Constructors
		public TextureSlotAllocator(int size, GraphicsFormat format, FilterMode filterMode); // 0x0000000181DFEC60-0x0000000181DFEE70
	
		// Methods
		public TextureLocation AddTexture(Texture texture, Vector2 scale, Vector2 offset); // 0x0000000181DFD930-0x0000000181DFE2B0
		public void UpdateTexture([IsReadOnly] in TextureLocation location, Texture texture, Vector2 scale, Vector2 offset); // 0x0000000181DFE8E0-0x0000000181DFEC60
		public void RemoveTexture([IsReadOnly] in TextureLocation location); // 0x0000000181DFE4F0-0x0000000181DFE5A0
		public Vector2Int GetTextureSize([IsReadOnly] in TextureLocation location); // 0x0000000181DFE420-0x0000000181DFE4F0
		public void GetScaleAndOffset([IsReadOnly] in TextureLocation location, out Vector2 scale, out Vector2 offset); // 0x0000000181DFE370-0x0000000181DFE420
		private void ResizeAtlas(int sliceCount); // 0x0000000181DFE5A0-0x0000000181DFE8E0
		public void Dispose(); // 0x0000000181DFE2B0-0x0000000181DFE370
	}
}
