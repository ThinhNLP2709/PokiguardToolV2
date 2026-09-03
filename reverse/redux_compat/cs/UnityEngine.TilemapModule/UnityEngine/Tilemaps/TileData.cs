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

// Image 52: UnityEngine.TilemapModule.dll - Assembly: UnityEngine.TilemapModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15554-15571

namespace UnityEngine.Tilemaps
{
	[NativeHeader("Modules/Tilemap/TilemapScripting.h")]
	[RequiredByNativeCode]
	public struct TileData // TypeDefIndex: 15568
	{
		// Fields
		private EntityId m_Sprite; // 0x00
		private Color m_Color; // 0x08
		private Matrix4x4 m_Transform; // 0x18
		private EntityId m_GameObject; // 0x58
		private TileFlags m_Flags; // 0x60
		private Tile.ColliderType m_ColliderType; // 0x64
		internal static readonly TileData Default; // 0x00
	
		// Properties
		public EntityId spriteEntityId { set; } // 0x0000000180CBE820-0x0000000180CBE830
		public Color color { set; } // 0x0000000181259E20-0x0000000181259E30
		public Matrix4x4 transform { set; } // 0x0000000182354CB0-0x0000000182354CD0
		public EntityId gameObjectEntityId { set; } // 0x000000018044C5A0-0x000000018044C5B0
		public TileFlags flags { set; } // 0x000000018041DC00-0x000000018041DC10
		public Tile.ColliderType colliderType { set; } // 0x000000018033EA40-0x000000018033EA50
	
		// Constructors
		static TileData(); // 0x0000000182354BD0-0x0000000182354CB0
	
		// Methods
		private static TileData CreateDefault(); // 0x0000000182354B40-0x0000000182354BD0
	}
}
