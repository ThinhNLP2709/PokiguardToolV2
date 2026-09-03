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
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal static class OSFontFallbackResolver // TypeDefIndex: 12685
	{
		// Fields
		private static Dictionary<IntPtr, FontAsset> s_PtrToManaged; // 0x00
		private static List<NativeTextInfo> s_SingleTextInfoBuffer; // 0x08
	
		// Constructors
		static OSFontFallbackResolver(); // 0x00000001823333D0-0x00000001823334C0
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal static bool Resolve(List<NativeTextInfo> textInfos, Dictionary<EntityId, HashSet<uint>> allUniqueMissingGlyphs); // 0x0000000182333340-0x00000001823333D0
		private static void ConsumePendingFallbacks(); // 0x0000000182332C60-0x0000000182332F10
		private static bool RemapMeshInfos(List<NativeTextInfo> textInfos, Dictionary<EntityId, HashSet<uint>> allUniqueMissingGlyphs); // 0x0000000182332F10-0x0000000182333340
	}
}
