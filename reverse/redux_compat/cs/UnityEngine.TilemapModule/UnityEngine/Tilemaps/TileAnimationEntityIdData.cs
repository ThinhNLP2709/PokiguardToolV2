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
	[NativeHeader("Modules/Tilemap/TilemapScripting.h")]
	[RequiredByNativeCode]
	public struct TileAnimationEntityIdData // TypeDefIndex: 15571
	{
		// Fields
		private IntPtr m_AnimatedSpritesEntityIdPtr; // 0x00
		private int m_Count; // 0x08
		private float m_AnimationSpeed; // 0x0C
		private float m_AnimationStartTime; // 0x10
		private TileAnimationFlags m_Flags; // 0x14
	
		// Properties
		public NativeArray<EntityId> animatedSpritesEntityIds { set; } // 0x0000000182354820-0x0000000182354860
	
		// Methods
		internal void CopyFrom(TileAnimationData other); // 0x0000000182354680-0x0000000182354820
	}
}
