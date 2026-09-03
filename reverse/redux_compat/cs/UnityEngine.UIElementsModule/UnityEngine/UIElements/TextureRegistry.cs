/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class TextureRegistry // TypeDefIndex: 4340
	{
		// Fields
		private List<TextureInfo> m_Textures; // 0x10
		private Dictionary<Texture, TextureId> m_TextureToId; // 0x18
		private Stack<TextureId> m_FreeIds; // 0x20
		[CompilerGenerated]
		private static readonly TextureRegistry _instance_k__BackingField; // 0x00
	
		// Properties
		[NoAutoStaticsCleanup]
		public static TextureRegistry instance { [CompilerGenerated] get; } // 0x00000001824DDEE0-0x00000001824DDF30 
	
		// Nested types
		private struct TextureInfo // TypeDefIndex: 4341
		{
			// Fields
			public Texture texture; // 0x00
			public bool dynamic; // 0x08
			public int refCount; // 0x0C
		}
	
		// Constructors
		public TextureRegistry(); // 0x00000001824DDDD0-0x00000001824DDEE0
		static TextureRegistry(); // 0x00000001824DDC70-0x00000001824DDDD0
	
		// Methods
		public Texture GetTexture(TextureId id); // 0x00000001824DD760-0x00000001824DD8A0
		public TextureId AllocAndAcquireDynamic(); // 0x00000001824DD3F0-0x00000001824DD400
		public void UpdateDynamic(TextureId id, Texture texture); // 0x00000001824DDAA0-0x00000001824DDC70
		private TextureId AllocAndAcquire(Texture texture, bool dynamic); // 0x00000001824DD400-0x00000001824DD760
		public TextureId Acquire(Texture tex); // 0x00000001824DD2A0-0x00000001824DD3F0
		public void Release(TextureId id); // 0x00000001824DD8A0-0x00000001824DDAA0
	}
}
