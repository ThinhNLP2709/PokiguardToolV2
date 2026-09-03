/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 52: UnityEngine.TilemapModule.dll - Assembly: UnityEngine.TilemapModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15554-15571

namespace UnityEngine.Tilemaps
{
	[NativeClass("Tilemap", PersistentTypeId = 1839735485)]
	[NativeHeader("Modules/Grid/Public/Grid.h")]
	[NativeHeader("Modules/Tilemap/Public/Tilemap.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
	[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapTile.h")]
	[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class Tilemap : GridLayout // TypeDefIndex: 15561
	{
		// Fields
		[CompilerGenerated]
		private static Action<Tilemap, SyncTile[]> tilemapTileChanged; // 0x00
		[CompilerGenerated]
		private static Action<Tilemap, NativeArray<Vector3Int>> tilemapPositionsChanged; // 0x08
		[CompilerGenerated]
		private static Action<Tilemap, NativeArray<Vector3Int>> loopEndedForTileAnimation; // 0x10
		private bool m_BufferSyncTile; // 0x18
		private ITilemap m_ITilemap; // 0x20
	
		// Properties
		internal bool bufferSyncTile { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		internal ITilemap iTilemap { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Nested types
		[RequiredByNativeCode]
		public struct SyncTile // TypeDefIndex: 15562
		{
			// Fields
			internal Vector3Int m_Position; // 0x00
			internal TileBase m_Tile; // 0x10
			internal TileData m_TileData; // 0x18
	
			// Methods
			[RequiredByNativeCode]
			internal static void ReconstructArrayElementRaw(SyncTile[] array, int index, TileBase tile, Vector3Int position, TileData tileData); // 0x00000001823545D0-0x0000000182354680
		}
	
		internal struct SyncTileCallbackSettings // TypeDefIndex: 15563
		{
			// Fields
			internal bool hasSyncTileCallback; // 0x00
			internal bool hasPositionsChangedCallback; // 0x01
			internal bool isBufferSyncTile; // 0x02
		}
	
		internal struct TilemapBuffer : IDisposable // TypeDefIndex: 15564
		{
			// Fields
			private IntPtr m_Buffer; // 0x00
			private int m_Length; // 0x08
			private Allocator m_Allocator; // 0x0C
	
			// Methods
			public void Dispose(); // 0x0000000182355140-0x0000000182355180
		}
	
		// Methods
		internal static bool HasLoopEndedForTileAnimationCallback(); // 0x00000001823555D0-0x0000000182355610
		private void HandleLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr); // 0x0000000182355370-0x0000000182355400
		private void SendLoopEndedForTileAnimationCallback(NativeArray<Vector3Int> positions); // 0x0000000182355830-0x00000001823558E0
		internal static bool HasSyncTileCallback(); // 0x0000000182355650-0x0000000182355690
		internal static bool HasPositionsChangedCallback(); // 0x0000000182355610-0x0000000182355650
		private void HandleSyncTileCallback(SyncTile[] syncTiles); // 0x0000000182355490-0x00000001823554F0
		private void HandlePositionsChangedCallback(int count, IntPtr positionsIntPtr); // 0x0000000182355400-0x0000000182355490
		private void SendTilemapTileChangedCallback(SyncTile[] syncTiles); // 0x0000000182355990-0x0000000182355A30
		private void SendTilemapPositionsChangedCallback(NativeArray<Vector3Int> positions); // 0x00000001823558E0-0x0000000182355990
		[NativeMethod(Name = "RefreshTileAsset")]
		public void RefreshTile(Vector3Int position); // 0x00000001823556E0-0x0000000182355740
		[FreeFunction(Name = "TilemapBindings::RefreshTileAssetsNative", HasExplicitThis = true)]
		internal unsafe void RefreshTilesNative(void* positions, int count, bool needSortRemoveDup); // 0x00000001823557B0-0x0000000182355830
		[RequiredByNativeCode]
		private ITilemap GetITilemapProxy(); // 0x0000000182353020-0x0000000182353160
		[RequiredByNativeCode]
		internal void GetLoopEndedForTileAnimationCallbackSettings(ref bool hasEndLoopForTileAnimationCallback); // 0x00000001823554F0-0x0000000182355540
		[RequiredByNativeCode]
		private void DoLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr); // 0x0000000182355370-0x0000000182355400
		[RequiredByNativeCode]
		internal void GetSyncTileCallbackSettings(ref SyncTileCallbackSettings settings); // 0x0000000182355540-0x00000001823555D0
		[RequiredByNativeCode]
		private void DoSyncTileCallback(SyncTile[] syncTiles); // 0x0000000182355490-0x00000001823554F0
		[RequiredByNativeCode]
		private void DoPositionsChangedCallback(int count, IntPtr positionsIntPtr); // 0x0000000182355400-0x0000000182355490
		private static void RefreshTile_Injected(IntPtr _unity_self, in Vector3Int position); // 0x0000000182355690-0x00000001823556E0
		private static unsafe void RefreshTilesNative_Injected(IntPtr _unity_self, void* positions, int count, bool needSortRemoveDup); // 0x0000000182355740-0x00000001823557B0
	}
}
