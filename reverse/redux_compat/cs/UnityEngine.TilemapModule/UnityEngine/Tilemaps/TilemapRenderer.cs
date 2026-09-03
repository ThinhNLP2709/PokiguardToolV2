/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.U2D;

// Image 52: UnityEngine.TilemapModule.dll - Assembly: UnityEngine.TilemapModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15554-15571

namespace UnityEngine.Tilemaps
{
	[NativeClass("TilemapRenderer", PersistentTypeId = 483693784)]
	[NativeHeader("Modules/Tilemap/Public/TilemapRenderer.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
	[NativeHeader("Modules/Tilemap/TilemapRendererJobs.h")]
	[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
	[RequireComponent(typeof(Tilemap))]
	public sealed class TilemapRenderer : Renderer // TypeDefIndex: 15567
	{
		// Methods
		[RequiredByNativeCode]
		internal void RegisterSpriteAtlasRegistered(); // 0x0000000182355250-0x00000001823552E0
		[RequiredByNativeCode]
		internal void UnregisterSpriteAtlasRegistered(); // 0x00000001823552E0-0x0000000182355370
		internal void OnSpriteAtlasRegistered(SpriteAtlas atlas); // 0x00000001823551D0-0x0000000182355250
		private static void OnSpriteAtlasRegistered_Injected(IntPtr _unity_self, IntPtr atlas); // 0x0000000182355180-0x00000001823551D0
	}
}
