/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class ShaderInfoStorage<T> : BaseShaderInfoStorage // TypeDefIndex: 5146
		where T : struct
	{
		// Fields
		private readonly int m_InitialSize;
		private readonly int m_MaxSize;
		private readonly TextureFormat m_Format;
		private readonly Func<Color, T> m_Convert;
		private UIRAtlasAllocator m_Allocator;
		private Texture2D m_Texture;
		private NativeArray<T> m_Texels;
	
		// Properties
		public override Texture2D texture { get; }
	
		// Constructors
		public ShaderInfoStorage(TextureFormat format, Func<Color, T> convert, int initialSize = 64 /* Metadata: 0x00660ADA */, int maxSize = 4096 /* Metadata: 0x00660ADC */);
	
		// Methods
		protected override void Dispose(bool disposing);
		public override bool AllocateRect(int width, int height, out RectInt uvs);
		public override void SetTexel(int x, int y, Color color);
		public override void UpdateTexture();
		private void CreateOrExpandTexture();
		private static void CpuBlit(NativeArray<T> src, int srcWidth, int srcHeight, NativeArray<T> dst, int dstWidth, int dstHeight);
	}
}
