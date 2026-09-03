/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class SpriteSkinContainer : ScriptableObject // TypeDefIndex: 14414
	{
		// Fields
		[CompilerGenerated]
		private static Action<SpriteSkin> onAddedSpriteSkin; // 0x00
		[CompilerGenerated]
		private static Action<SpriteSkin> onRemovedSpriteSkin; // 0x08
		[CompilerGenerated]
		private static Action<SpriteSkin> onBoneTransformChanged; // 0x10
		private static SpriteSkinContainer s_Instance; // 0x18
		private List<SpriteSkin> m_SpriteSkin; // 0x18
	
		// Properties
		public static SpriteSkinContainer instance { get; } // 0x0000000181C25980-0x0000000181C25AB0 
		public IReadOnlyList<SpriteSkin> spriteSkins { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Events
		public static event Action<SpriteSkin> onAddedSpriteSkin {
			add; // 0x0000000181C256F0-0x0000000181C257C0
			remove; // 0x0000000181C25AB0-0x0000000181C25B80
		}
		public static event Action<SpriteSkin> onRemovedSpriteSkin {
			add; // 0x0000000181C258A0-0x0000000181C25980
			remove; // 0x0000000181C25C60-0x0000000181C25D40
		}
		public static event Action<SpriteSkin> onBoneTransformChanged {
			add; // 0x0000000181C257C0-0x0000000181C258A0
			remove; // 0x0000000181C25B80-0x0000000181C25C60
		}
	
		// Constructors
		public SpriteSkinContainer(); // 0x0000000181C25670-0x0000000181C256F0
	
		// Methods
		public void AddSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C254A0-0x0000000181C25580
		public void RemoveSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C255E0-0x0000000181C25670
		public void BoneTransformsChanged(SpriteSkin spriteSkin); // 0x0000000181C25580-0x0000000181C255E0
	}
}
