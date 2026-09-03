/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 52: UnityEngine.TilemapModule.dll - Assembly: UnityEngine.TilemapModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15554-15571

namespace UnityEngine.Tilemaps
{
	[RequiredByNativeCode]
	public abstract class TileBase : ScriptableObject // TypeDefIndex: 15560
	{
		// Fields
		private EntityId m_CachedEntityId; // 0x18
	
		// Properties
		public EntityId cachedEntityId { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		protected TileBase(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public virtual void OnEnable(); // 0x0000000182354A20-0x0000000182354A40
		public virtual void OnDisable(); // 0x00000001802E76C0-0x00000001802E76D0
		[RequiredByNativeCode]
		public virtual void RefreshTile(Vector3Int position, ITilemap tilemap); // 0x0000000182354A40-0x0000000182354B00
		[RequiredByNativeCode]
		public virtual void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData); // 0x00000001802E76C0-0x00000001802E76D0
		private TileData GetTileDataNoRef(Vector3Int position, ITilemap tilemap); // 0x00000001823549A0-0x0000000182354A20
		public virtual bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData); // 0x00000001802E7840-0x00000001802E7850
		[RequiredByNativeCode]
		private void GetTileAnimationDataRef(Vector3Int position, ITilemap tilemap, ref Sprite[] tileAnimationData_AnimatedSprites, ref float tileAnimationData_AnimationSpeed, ref float tileAnimationData_AnimationStartTime, ref int tileAnimationData_Flags, ref bool hasAnimation); // 0x0000000182354860-0x00000001823549A0
		[RequiredByNativeCode]
		public virtual bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go); // 0x00000001802E7840-0x00000001802E7850
		[RequiredByNativeCode]
		private void StartUpRef(Vector3Int position, ITilemap tilemap, GameObject go, ref bool startUpInvokedByUser); // 0x0000000182354B00-0x0000000182354B40
	}
}
