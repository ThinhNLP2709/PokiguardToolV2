/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class DynamicAtlasPage : IDisposable // TypeDefIndex: 4313
	{
		// Fields
		[CompilerGenerated]
		private TextureId _textureId_k__BackingField; // 0x10
		[CompilerGenerated]
		private RenderTexture _atlas_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly RenderTextureFormat _format_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly FilterMode _filterMode_k__BackingField; // 0x24
		[CompilerGenerated]
		private readonly Vector2Int _minSize_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly Vector2Int _maxSize_k__BackingField; // 0x30
		private readonly int m_1Padding; // 0x38
		private readonly int m_2Padding; // 0x3C
		private Allocator2D m_Allocator; // 0x40
		private TextureBlitter m_Blitter; // 0x48
		private Vector2Int m_CurrentSize; // 0x50
		[NoAutoStaticsCleanup]
		private static int s_TextureCounter; // 0x00
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x58
	
		// Properties
		public TextureId textureId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public RenderTexture atlas { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public RenderTextureFormat format { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public FilterMode filterMode { [CompilerGenerated] get; } // 0x0000000180D17D10-0x0000000180D17D20 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
	
		// Constructors
		public DynamicAtlasPage(RenderTextureFormat format, FilterMode filterMode, Vector2Int minSize, Vector2Int maxSize); // 0x00000001824D5940-0x00000001824D5AE0
	
		// Methods
		public void Dispose(); // 0x00000001824D4DE0-0x00000001824D4E50
		protected virtual void Dispose(bool disposing); // 0x00000001824D4C20-0x00000001824D4DE0
		public bool TryAdd(Texture2D image, out Allocator2D.Alloc2D alloc, out RectInt rect); // 0x00000001824D4F40-0x00000001824D5310
		public void Update(Texture2D image, RectInt rect); // 0x00000001824D5770-0x00000001824D5940
		public void Remove(Allocator2D.Alloc2D alloc); // 0x00000001824D4E50-0x00000001824D4F40
		public void Commit(); // 0x00000001824D4AA0-0x00000001824D4AE0
		private void UpdateAtlasTexture(); // 0x00000001824D5310-0x00000001824D5770
		private RenderTexture CreateAtlasTexture(); // 0x00000001824D4AE0-0x00000001824D4C20
	}
}
