/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[Serializable]
	public struct SpriteState : IEquatable<SpriteState> // TypeDefIndex: 13122
	{
		// Fields
		[SerializeField]
		private Sprite m_HighlightedSprite; // 0x00
		[SerializeField]
		private Sprite m_PressedSprite; // 0x08
		[SerializeField]
		private Sprite m_SelectedSprite; // 0x10
		[SerializeField]
		private Sprite m_DisabledSprite; // 0x18
	
		// Properties
		public Sprite highlightedSprite { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public Sprite pressedSprite { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		public Sprite selectedSprite { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public Sprite disabledSprite { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Methods
		public bool Equals(SpriteState other); // 0x00000001825A80F0-0x00000001825A81B0
	}
}
