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

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Nullable(0)]
	[NullableContext(1)]
	[VisibleToOtherModules(new string[2] {"UnityEditor.CoreModule", "UnityEngine.UIElementsModule" })]
	internal class FontAssetFactory // TypeDefIndex: 12661
	{
		// Fields
		private static readonly HashSet<FontAsset> visitedFontAssets; // 0x00
	
		// Constructors
		static FontAssetFactory(); // 0x0000000182331380-0x0000000182331410
	
		// Methods
		internal static FontAsset ConvertFontToFontAsset(Font font, bool persistent = true /* Metadata: 0x006A48F3 */); // 0x0000000182330C30-0x0000000182330D50
		internal static void SetupFontAssetSettings(FontAsset fontAsset, bool persistent = true /* Metadata: 0x006A48F4 */); // 0x0000000182331250-0x0000000182331380
		public static void SetHideFlags(FontAsset fontAsset, bool persistent = true /* Metadata: 0x006A48F5 */); // 0x0000000182331190-0x0000000182331250
		internal static List<FontAsset> CreateFontAssetOSFallbackList(string[] fallbacksFamilyNames, int pointSize = 90 /* Metadata: 0x006A48F6 */, bool persistent = true /* Metadata: 0x006A48F8 */); // 0x0000000182330EE0-0x0000000182331190
		internal static FontAsset CreateFontAssetFromFamilyName(string familyName, int pointSize = 90 /* Metadata: 0x006A48F9 */, bool persistent = true /* Metadata: 0x006A48FB */); // 0x0000000182330D50-0x0000000182330EE0
	}
}
