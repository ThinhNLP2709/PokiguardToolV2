/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class TextureGradient : IDisposable // TypeDefIndex: 5793
	{
		// Fields
		[CompilerGenerated]
		[HideInInspector]
		[SerializeField]
		private int _textureSize_k__BackingField; // 0x10
		[SerializeField]
		private Gradient m_Gradient; // 0x18
		private Texture2D m_Texture; // 0x20
		private int m_RequestedTextureSize; // 0x28
		private bool m_IsTextureDirty; // 0x2C
		private bool m_Precise; // 0x2D
		[HideInInspector]
		[SerializeField]
		public GradientMode mode; // 0x30
		[HideInInspector]
		[SerializeField]
		public ColorSpace colorSpace; // 0x34
	
		// Properties
		public int textureSize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		[HideInInspector]
		public GradientColorKey[] colorKeys { get; } // 0x0000000181ECDDB0-0x0000000181ECDDD0 
		[HideInInspector]
		public GradientAlphaKey[] alphaKeys { get; } // 0x0000000181ECDD90-0x0000000181ECDDB0 
	
		// Constructors
		public TextureGradient(Gradient baseCurve); // 0x0000000181ECDC80-0x0000000181ECDD90
		public TextureGradient(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode = GradientMode.PerceptualBlend /* Metadata: 0x00661B1A */, ColorSpace colorSpace = ColorSpace.Uninitialized /* Metadata: 0x00661B1B */, int requestedTextureSize = -1 /* Metadata: 0x00661B1C */, bool precise = false /* Metadata: 0x00661B1D */); // 0x0000000181ECDC00-0x0000000181ECDC80
	
		// Methods
		private void Rebuild(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode, ColorSpace colorSpace, int requestedTextureSize, bool precise); // 0x0000000181ECD6B0-0x0000000181ECDAA0
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Release(); // 0x0000000181ECDAA0-0x0000000181ECDB40
		public void SetDirty(); // 0x0000000181ECDB40-0x0000000181ECDB50
		private static GraphicsFormat GetTextureFormat(); // 0x0000000180740830-0x0000000180740840
		public Texture2D GetTexture(); // 0x0000000181ECD400-0x0000000181ECD6B0
		public Color Evaluate(float time); // 0x0000000181ECD3B0-0x0000000181ECD400
		public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode, ColorSpace colorSpace); // 0x0000000181ECDB50-0x0000000181ECDC00
	}
}
