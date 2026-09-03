/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore.LowLevel;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/OSFontFallback.h")]
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal static class OSFontFallbackBindings // TypeDefIndex: 12705
	{
		// Methods
		[FreeFunction("OSFontFallback::GetPendingFallbackCount")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int GetPendingFallbackCount(); // 0x0000000182332B20-0x0000000182332B50
		[FreeFunction("OSFontFallback::GetPendingFallbackNativePtr")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static IntPtr GetPendingFallbackNativePtr(int index); // 0x0000000182332BE0-0x0000000182332C20
		[FreeFunction("OSFontFallback::GetPendingFallbackFontReference")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static FontReference GetPendingFallbackFontReference(int index); // 0x0000000182332B90-0x0000000182332BE0
		[FreeFunction("OSFontFallback::ClearPendingFallbacks")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void ClearPendingFallbacks(); // 0x0000000182332AF0-0x0000000182332B20
		[FreeFunction("OSFontFallback::ReleaseNativeFallback")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void ReleaseNativeFallback(IntPtr nativePtr); // 0x0000000182332C20-0x0000000182332C60
		private static void GetPendingFallbackFontReference_Injected(int index, ); // 0x0000000182332B50-0x0000000182332B90
	}
}
