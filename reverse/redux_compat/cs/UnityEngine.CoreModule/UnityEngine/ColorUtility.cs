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

namespace UnityEngine
{
	[NativeHeader("Runtime/Math/ColorUtility.h")]
	public class ColorUtility // TypeDefIndex: 7657
	{
		// Methods
		[FreeFunction("TryParseHtmlColor", true)]
		internal static bool DoTryParseHtmlColor(string htmlString, out Color32 color); // 0x00000001821C7B20-0x00000001821C7C80
		public static bool TryParseHtmlString(string htmlString, out Color color); // 0x00000001821C7D90-0x00000001821C7E30
		public static string ToHtmlStringRGB(Color color); // 0x00000001821C7C80-0x00000001821C7D90
		public static string ToHtmlStringRGB([IsReadOnly] in Color color); // 0x00000001821C7C80-0x00000001821C7D90
		private static bool DoTryParseHtmlColor_Injected(ref ManagedSpanWrapper htmlString, out Color32 color); // 0x00000001821C7AD0-0x00000001821C7B20
	}
}
