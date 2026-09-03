/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.U2D
{
	[NativeClass("SpriteAtlas", PersistentTypeId = 687078895)]
	[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
	[NativeHeader("Runtime/2D/SpriteAtlas/SpriteAtlas.h")]
	public class SpriteAtlas : UnityEngine.Object // TypeDefIndex: 8470
	{
		// Properties
		public bool isVariant { [NativeMethod("IsVariant")] get; } // 0x000000018226C740-0x000000018226C7A0 
		public string tag { get; } // 0x000000018226C890-0x000000018226C980 
		public int spriteCount { get; } // 0x000000018226C7E0-0x000000018226C840 
	
		// Constructors
		public SpriteAtlas(); // 0x000000018226C6B0-0x000000018226C700
	
		// Methods
		public bool CanBindTo([NotNull] Sprite sprite); // 0x000000018226C120-0x000000018226C1E0
		public Sprite GetSprite(string name); // 0x000000018226C230-0x000000018226C400
		public int GetSprites(Sprite[] sprites); // 0x000000018226C450-0x000000018226C4B0
		public int GetSprites(Sprite[] sprites, string name); // 0x000000018226C6A0-0x000000018226C6B0
		private int GetSpritesScripting([UnityMarshalAs(NativeType.ScriptingObjectPtr)] Sprite[] sprites); // 0x000000018226C450-0x000000018226C4B0
		private int GetSpritesWithNameScripting([UnityMarshalAs(NativeType.ScriptingObjectPtr)] Sprite[] sprites, string name); // 0x000000018226C510-0x000000018226C6A0
		private static bool get_isVariant_Injected(IntPtr _unity_self); // 0x000000018226C700-0x000000018226C740
		private static void get_tag_Injected(IntPtr _unity_self, ); // 0x000000018226C840-0x000000018226C890
		private static int get_spriteCount_Injected(IntPtr _unity_self); // 0x000000018226C7A0-0x000000018226C7E0
		private static bool CanBindTo_Injected(IntPtr _unity_self, IntPtr sprite); // 0x000000018226C0D0-0x000000018226C120
		private static IntPtr GetSprite_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x000000018226C1E0-0x000000018226C230
		private static int GetSpritesScripting_Injected(IntPtr _unity_self, Sprite[] sprites); // 0x000000018226C400-0x000000018226C450
		private static int GetSpritesWithNameScripting_Injected(IntPtr _unity_self, Sprite[] sprites, ref ManagedSpanWrapper name); // 0x000000018226C4B0-0x000000018226C510
	}
}
