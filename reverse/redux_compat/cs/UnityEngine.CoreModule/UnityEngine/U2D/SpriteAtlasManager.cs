/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.U2D
{
	[NativeHeader("Runtime/2D/SpriteAtlas/SpriteAtlasManager.h")]
	[NativeHeader("Runtime/2D/SpriteAtlas/SpriteAtlas.h")]
	[StaticAccessor("GetSpriteAtlasManager()", StaticAccessorType.Dot)]
	public class SpriteAtlasManager // TypeDefIndex: 8468
	{
		// Fields
		[CompilerGenerated]
		private static Action<string, Action<SpriteAtlas>> atlasRequested; // 0x00
		[CompilerGenerated]
		private static Action<SpriteAtlas> atlasRegistered; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<string, Action<SpriteAtlas>> atlasRequested {
			add; // 0x000000018226BE00-0x000000018226BEF0
			remove; // 0x000000018226BFE0-0x000000018226C0D0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<SpriteAtlas> atlasRegistered {
			add; // 0x000000018226BD10-0x000000018226BE00
			remove; // 0x000000018226BEF0-0x000000018226BFE0
		}
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 8469
		{
			// Fields
			public static Action<SpriteAtlas> _0___Register; // 0x00
		}
	
		// Constructors
		static SpriteAtlasManager(); // 0x000000018226BB90-0x000000018226BD10
	
		// Methods
		[RequiredByNativeCode]
		private static bool RequestAtlas(string tag); // 0x000000018226B710-0x000000018226B820
		[RequiredByNativeCode]
		private static void PostRegisteredAtlas(SpriteAtlas spriteAtlas); // 0x000000018226B5E0-0x000000018226B660
		internal static void Register(SpriteAtlas spriteAtlas); // 0x000000018226B6A0-0x000000018226B710
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018226B820-0x000000018226BB90
		private static void Register_Injected(IntPtr spriteAtlas); // 0x000000018226B660-0x000000018226B6A0
	}
}
