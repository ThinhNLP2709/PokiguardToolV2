/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.TextCore.Text;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/RichTextAssetPreload.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal static class NativeRichTextAssetRegistry // TypeDefIndex: 12634
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static readonly Dictionary<uint, FontAsset> s_FontAssetCache; // 0x00
		internal static readonly Dictionary<uint, SpriteAsset> s_SpriteAssetCache; // 0x08
		internal static readonly Dictionary<uint, TextColorGradient> s_GradientAssetCache; // 0x10
	
		// Constructors
		static NativeRichTextAssetRegistry(); // 0x0000000182306F70-0x00000001823070C0
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void PreloadAssetsFromTags(NativeTextBuffer textBuffer, TextSettings textSettings); // 0x0000000182306980-0x0000000182306AD0
		[RequiredByNativeCode]
		internal static IntPtr GetFontAssetForNative(uint nameHash); // 0x0000000182305F20-0x0000000182305FD0
		[RequiredByNativeCode]
		internal static IntPtr GetGradientAssetForNative(uint nameHash); // 0x0000000182305FD0-0x0000000182306080
		[RequiredByNativeCode]
		internal static int ResolveSpriteForNative(EntityId textSettingsId, uint assetNameHash, uint spriteNameHash, int spriteIndexHint, out EntityId spriteAssetId, out GlyphMetrics metrics, out float scale); // 0x0000000182306B20-0x0000000182306E80
		[RequiredByNativeCode]
		internal static string GetStyleOpeningForNative(EntityId textSettingsId, int styleHash); // 0x00000001823060F0-0x0000000182306180
		[RequiredByNativeCode]
		internal static string GetStyleClosingForNative(EntityId textSettingsId, int styleHash); // 0x0000000182306080-0x00000001823060F0
		private static TextStyle ResolveStyle(EntityId textSettingsId, int styleHash); // 0x0000000182306E80-0x0000000182306F70
		public static uint HashName(ReadOnlySpan<char> name); // 0x0000000182306180-0x0000000182306210
		[FreeFunction("RichTextAssetPreload::PreloadAssetsFromText", IsThreadSafe = true)]
		internal static void PreloadAssetsFromText(IntPtr text, int textLength, IntPtr nativeTextSettings); // 0x0000000182306AD0-0x0000000182306B20
		[RequiredByNativeCode]
		internal static void LoadFontAssetForPreload(EntityId textSettingsId, IntPtr namePtr, int nameLength); // 0x0000000182306210-0x0000000182306480
		[RequiredByNativeCode]
		internal static void LoadSpriteAssetForPreload(EntityId textSettingsId, IntPtr namePtr, int nameLength); // 0x0000000182306700-0x0000000182306980
		[RequiredByNativeCode]
		internal static void LoadGradientAssetForPreload(EntityId textSettingsId, IntPtr namePtr, int nameLength); // 0x0000000182306480-0x0000000182306700
	}
}
