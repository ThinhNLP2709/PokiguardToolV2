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
	[NativeHeader("Runtime/Graphics/ShadingRateInfo.h")]
	public static class ShadingRateInfo // TypeDefIndex: 8333
	{
		// Properties
		public static bool supportsPerImageTile { get; } // 0x0000000182269770-0x00000001822697A0 
		public static bool supportsPerDrawCall { get; } // 0x0000000182269740-0x0000000182269770 
		public static Vector2Int imageTileSize { get; } // 0x00000001822696C0-0x0000000182269700 
		public static ShadingRateFragmentSize[] availableFragmentSizes { get; } // 0x00000001822697A0-0x00000001822697B0 
	
		// Methods
		[FreeFunction("ShadingRateInfo::QueryNativeValue")]
		public static byte QueryNativeValue(ShadingRateFragmentSize fragmentSize); // 0x0000000182269700-0x0000000182269740
		[FreeFunction("ShadingRateInfo::SupportsPerImageTile")]
		private static bool SupportsPerImageTile(); // 0x0000000182269770-0x00000001822697A0
		[FreeFunction("ShadingRateInfo::SupportsPerDrawCall")]
		private static bool SupportsPerDrawCall(); // 0x0000000182269740-0x0000000182269770
		[FreeFunction("ShadingRateInfo::GetImageTileSize")]
		private static Vector2Int GetImageTileSize(); // 0x00000001822696C0-0x0000000182269700
		[FreeFunction("ShadingRateInfo::GetAvailableFragmentSizes")]
		private static ShadingRateFragmentSize[] GetAvailableFragmentSizes(); // 0x00000001822695A0-0x0000000182269680
		private static void GetImageTileSize_Injected(); // 0x0000000182269680-0x00000001822696C0
		private static void GetAvailableFragmentSizes_Injected(); // 0x0000000182269560-0x00000001822695A0
	}
}
