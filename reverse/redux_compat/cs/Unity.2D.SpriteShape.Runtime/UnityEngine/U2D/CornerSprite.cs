/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[Serializable]
	public class CornerSprite : ICloneable // TypeDefIndex: 13996
	{
		// Fields
		[SerializeField]
		private CornerType m_CornerType; // 0x10
		[SerializeField]
		private List<Sprite> m_Sprites; // 0x18
	
		// Properties
		public CornerType cornerType { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public List<Sprite> sprites { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		public CornerSprite(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public object Clone(); // 0x0000000181C42E10-0x0000000181C42EF0
		public override bool Equals(object obj); // 0x0000000181C42EF0-0x0000000181C430A0
		public override int GetHashCode(); // 0x0000000181C430A0-0x0000000181C431A0
	}
}
