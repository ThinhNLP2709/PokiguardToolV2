/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class TileLayoutUtils // TypeDefIndex: 5795
	{
		// Methods
		public static bool TryLayoutByTiles(RectInt src, uint tileSize, out RectInt main, out RectInt topRow, out RectInt rightCol, out RectInt topRight); // 0x0000000181ECE0A0-0x0000000181ECE1E0
		public static bool TryLayoutByRow(RectInt src, uint tileSize, out RectInt main, out RectInt other); // 0x0000000181ECDFE0-0x0000000181ECE0A0
		public static bool TryLayoutByCol(RectInt src, uint tileSize, out RectInt main, out RectInt other); // 0x0000000181ECDF20-0x0000000181ECDFE0
	}
}
