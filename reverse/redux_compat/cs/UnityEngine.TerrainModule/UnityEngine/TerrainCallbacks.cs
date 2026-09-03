/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine
{
	[MovedFrom("UnityEngine.Experimental.TerrainAPI")]
	public static class TerrainCallbacks // TypeDefIndex: 15537
	{
		// Fields
		[CompilerGenerated]
		private static HeightmapChangedCallback heightmapChanged; // 0x00
		[CompilerGenerated]
		private static TextureChangedCallback textureChanged; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event HeightmapChangedCallback heightmapChanged {
			add; // 0x00000001822EA660-0x00000001822EA730
			remove; // 0x00000001822EA800-0x00000001822EA8D0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event TextureChangedCallback textureChanged {
			add; // 0x00000001822EA730-0x00000001822EA800
			remove; // 0x00000001822EA8D0-0x00000001822EA9A0
		}
	
		// Nested types
		public delegate void HeightmapChangedCallback(Terrain terrain, RectInt heightRegion, bool synched); // TypeDefIndex: 15538; 0x000000018171ADD0-0x000000018171AE00
	
		public delegate void TextureChangedCallback(Terrain terrain, string textureName, RectInt texelRegion, bool synched); // TypeDefIndex: 15539; 0x00000001822EDDC0-0x00000001822EDE00
	
		// Constructors
		static TerrainCallbacks(); // 0x00000001822EA540-0x00000001822EA660
	
		// Methods
		[RequiredByNativeCode]
		internal static void InvokeHeightmapChangedCallback(TerrainData terrainData, RectInt heightRegion, bool synched); // 0x00000001822E9F30-0x00000001822EA0A0
		[RequiredByNativeCode]
		internal static void InvokeTextureChangedCallback(TerrainData terrainData, string textureName, RectInt texelRegion, bool synched); // 0x00000001822EA0A0-0x00000001822EA220
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822EA220-0x00000001822EA540
	}
}
