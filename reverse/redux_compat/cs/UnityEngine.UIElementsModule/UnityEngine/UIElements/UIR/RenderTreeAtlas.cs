/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal static class RenderTreeAtlas // TypeDefIndex: 5129
	{
		// Nested types
		public struct AtlasBlock // TypeDefIndex: 5130
		{
			// Fields
			public int width; // 0x00
			public int height; // 0x04
			public RectInt rect; // 0x08
			public Rect uvRect; // 0x18
			public RenderTexture texture; // 0x28
	
			// Constructors
			public AtlasBlock(int w, int h, RectInt r, Rect uv); // 0x000000018241F750-0x000000018241F780
		}
	
		// Methods
		public static bool ReserveSize(int width, int height, out AtlasBlock block); // 0x000000018242DE60-0x000000018242DFD0
		public static bool CreateTextureForAtlasBlock(ref AtlasBlock block, bool forceGammaRendering, out bool allocatedNewTexture); // 0x000000018242DBF0-0x000000018242DE60
	}
}
