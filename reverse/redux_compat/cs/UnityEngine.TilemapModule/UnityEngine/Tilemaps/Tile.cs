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
	[Serializable]
	[HelpURL("https://docs.unity3d.com/Manual/Tilemap-TileAsset.html")]
	[RequiredByNativeCode]
	public class Tile : TileBase // TypeDefIndex: 15558
	{
		// Fields
		[SerializeField]
		private Sprite m_Sprite; // 0x20
		[SerializeField]
		private Color m_Color; // 0x28
		[SerializeField]
		private Matrix4x4 m_Transform; // 0x38
		[SerializeField]
		private GameObject m_InstancedGameObject; // 0x78
		[SerializeField]
		private TileFlags m_Flags; // 0x80
		[SerializeField]
		private ColliderType m_ColliderType; // 0x84
		private EntityId m_SpriteEntityId; // 0x88
		private EntityId m_InstancedGameObjectEntityId; // 0x90
	
		// Properties
		public Sprite sprite { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000182355070-0x0000000182355120
		public Color color { get; set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public Matrix4x4 transform { get; set; } // 0x0000000182354F90-0x0000000182354FC0 0x0000000182355120-0x0000000182355140
		public GameObject gameObject { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000182354FC0-0x0000000182355070
		public TileFlags flags { get; set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x0000000180CC3E80-0x0000000180CC3E90
		public ColliderType colliderType { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
	
		// Nested types
		public enum ColliderType // TypeDefIndex: 15559
		{
			None = 0,
			Sprite = 1,
			Grid = 2
		}
	
		// Constructors
		public Tile(); // 0x0000000182354F30-0x0000000182354F90
	
		// Methods
		public override void OnEnable(); // 0x0000000182354D80-0x0000000182354E60
		public virtual void OnValidate(); // 0x0000000182354E60-0x0000000182354F30
		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData); // 0x0000000182354CD0-0x0000000182354D80
	}
}
