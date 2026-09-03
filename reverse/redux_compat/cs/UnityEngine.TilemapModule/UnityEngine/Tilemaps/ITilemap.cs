/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 52: UnityEngine.TilemapModule.dll - Assembly: UnityEngine.TilemapModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15554-15571

namespace UnityEngine.Tilemaps
{
	[RequiredByNativeCode]
	public class ITilemap // TypeDefIndex: 15557
	{
		// Fields
		internal Tilemap m_Tilemap; // 0x10
		internal bool m_AddToList; // 0x18
		internal bool m_NeedSort; // 0x19
		internal int m_RefreshCount; // 0x1C
		internal NativeArray<Vector3Int> m_RefreshPos; // 0x20
		[NoAutoStaticsCleanup]
		private static Func<Tilemap, ITilemap> createITilemap; // 0x00
		[NoAutoStaticsCleanup]
		private static int createITilemapPriority; // 0x08
	
		// Constructors
		public ITilemap(Tilemap tilemap); // 0x0000000182354510-0x00000001823545D0
	
		// Methods
		internal virtual void RefreshTileList(Vector3Int position); // 0x00000001823542D0-0x00000001823543E0
		public void RefreshTile(Vector3Int position); // 0x00000001823543E0-0x0000000182354490
		[RequiredByNativeCode]
		internal static void RegisterCreateITilemapFunc(Func<Tilemap, ITilemap> func, int priority); // 0x0000000182354490-0x0000000182354510
		[RequiredByNativeCode]
		internal static ITilemap CreateInstanceFromTilemap(Tilemap tilemap); // 0x0000000182353020-0x0000000182353160
		[RequiredByNativeCode]
		private static ITilemap GetInstanceFromTilemap(Tilemap tilemap); // 0x0000000182353780-0x00000001823537A0
		internal virtual void HandleRefreshPositions(int count, NativeArray<EntityId> usedTileIds, NativeArray<EntityId> oldTilesIds, NativeArray<EntityId> newTilesIds, NativeArray<Vector3Int> positions); // 0x0000000182354050-0x00000001823542D0
		[RequiredByNativeCode]
		private static void FindAllRefreshPositions(ITilemap tilemap, int usedTileCount, IntPtr usedTilesIntPtr, int count, IntPtr oldTilesIntPtr, IntPtr newTilesIntPtr, IntPtr positionsIntPtr); // 0x00000001823532D0-0x00000001823534A0
		[RequiredByNativeCode]
		private static void HandleAllTilesOnEnable(ITilemap tilemap, int usedTileCount, IntPtr usedTilesIntPtr); // 0x0000000182353A10-0x0000000182353B90
		internal virtual JobHandle HandleGetAllTileData(int usedTileCount, NativeArray<EntityId> usedTilesIds, int count, NativeArray<EntityId> tileIds, NativeArray<Vector3Int> positions, NativeArray<TileData> tileDataArray); // 0x0000000182353DF0-0x0000000182354050
		[RequiredByNativeCode]
		private static void GetAllTileData(ITilemap tilemap, int usedTileCount, IntPtr usedTilesIntPtr, int count, IntPtr tilesIntPtr, IntPtr positionsIntPtr, IntPtr outTileDataIntPtr, out JobHandle jobHandle); // 0x0000000182353630-0x0000000182353780
		internal virtual JobHandle HandleGetAllTileAnimation(int usedTileCount, NativeArray<EntityId> usedTilesIds, NativeArray<bool> usedTileHasAnimation, int count, NativeArray<EntityId> tileIds, NativeArray<Vector3Int> positions, NativeArray<TileAnimationEntityIdData> tileAnimationDataArray); // 0x0000000182353B90-0x0000000182353DF0
		[RequiredByNativeCode]
		private static void GetAllTileAnimationData(ITilemap tilemap, int usedTileCount, IntPtr usedTilesIntPtr, IntPtr usedTileHasAnimationIntPtr, int count, IntPtr tilesIntPtr, IntPtr positionsIntPtr, IntPtr outTileAnimationDataIntPtr, out JobHandle jobHandle); // 0x00000001823534A0-0x0000000182353630
		internal virtual JobHandle HandleAllTileStartUp(int usedTileCount, NativeArray<EntityId> usedTilesIds, NativeArray<bool> usedTileHasStartUp, int count, NativeArray<EntityId> tileIds, NativeArray<EntityId> tileGameObjectIds, NativeArray<Vector3Int> positions); // 0x00000001823537A0-0x0000000182353A10
		[RequiredByNativeCode]
		private static void DoAllTileStartUp(ITilemap tilemap, int usedTileCount, IntPtr usedTilesIntPtr, IntPtr usedTileHasStartUpIntPtr, int count, IntPtr tilesIntPtr, IntPtr gameObjectsIntPtr, IntPtr positionsIntPtr); // 0x0000000182353160-0x00000001823532D0
	}
}
