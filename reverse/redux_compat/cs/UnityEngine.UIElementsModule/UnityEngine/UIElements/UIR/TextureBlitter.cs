/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class TextureBlitter : IDisposable // TypeDefIndex: 5155
	{
		// Fields
		private static readonly int[] k_TextureIds; // 0x00
		private static readonly ProfilerMarker s_CommitSampler; // 0x08
		private BlitInfo[] m_SingleBlit; // 0x10
		private Material m_BlitMaterial; // 0x18
		private MaterialPropertyBlock m_Properties; // 0x20
		private RectInt m_Viewport; // 0x28
		private RenderTexture m_PrevRT; // 0x38
		private List<BlitInfo> m_PendingBlits; // 0x40
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x48
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
	
		// Nested types
		private struct BlitInfo // TypeDefIndex: 5156
		{
			// Fields
			public Texture src; // 0x00
			public RectInt srcRect; // 0x08
			public Vector2Int dstPos; // 0x18
			public int border; // 0x20
			public Color tint; // 0x24
		}
	
		// Constructors
		public TextureBlitter(int capacity = 512 /* Metadata: 0x00660AE2 */); // 0x0000000182449670-0x0000000182449730
		static TextureBlitter(); // 0x0000000182449520-0x0000000182449670
	
		// Methods
		public void Dispose(); // 0x0000000182448B60-0x0000000182448BD0
		protected virtual void Dispose(bool disposing); // 0x0000000182448BD0-0x0000000182448C50
		private static int[] BuildTextureIds(); // 0x00000001824488F0-0x00000001824489B0
		public void QueueBlit(Texture src, RectInt srcRect, Vector2Int dstPos, bool addBorder, Color tint); // 0x00000001824493A0-0x0000000182449520
		public void BlitOneNow(RenderTexture dst, Texture src, RectInt srcRect, Vector2Int dstPos, bool addBorder, Color tint); // 0x00000001824487C0-0x00000001824488F0
		public void Commit(RenderTexture dst); // 0x00000001824489B0-0x0000000182448B60
		private void BeginBlit(RenderTexture dst); // 0x0000000182448570-0x00000001824487C0
		private void DoBlit(IList<BlitInfo> blitInfos, int startIndex); // 0x0000000182448C50-0x00000001824492E0
		private void EndBlit(); // 0x00000001824492E0-0x00000001824493A0
	}
}
