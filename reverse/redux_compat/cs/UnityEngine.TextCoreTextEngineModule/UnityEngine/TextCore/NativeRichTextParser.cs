/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/RichTextParser.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal static class NativeRichTextParser // TypeDefIndex: 12624
	{
		// Methods
		[NativeMethod(Name = "RichTextParser::GetAllLinks", IsThreadSafe = true)]
		public static RichTextLinkInfo[] GetAllLinks(IntPtr textGenerationInfo); // 0x00000001823070C0-0x0000000182307100
		[NativeMethod(Name = "RichTextParser::GetLinkCount", IsThreadSafe = true)]
		public static int GetLinkCount(IntPtr textGenerationInfo); // 0x0000000182307100-0x0000000182307140
	}
}
