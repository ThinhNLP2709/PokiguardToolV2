/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Graphics/ShadingRateImage.h")]
	public static class ShadingRateImage // TypeDefIndex: 8332
	{
		// Methods
		[FreeFunction("ShadingRateImage::GetAllocSizeInternal")]
		internal static void GetAllocSizeInternal(int pixelWidth, int pixelHeight, out int tileWidth, out int tileHeight); // 0x0000000182269420-0x0000000182269480
		public static Vector2Int GetAllocTileSize(Vector2Int pixelSize); // 0x0000000182269480-0x00000001822694F0
		public static Vector2Int GetAllocTileSize(int pixelWidth, int pixelHeight); // 0x00000001822694F0-0x0000000182269560
	}
}
