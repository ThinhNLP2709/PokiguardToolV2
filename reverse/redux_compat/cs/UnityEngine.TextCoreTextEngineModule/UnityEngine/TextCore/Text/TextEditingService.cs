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

namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextEditingService.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	internal class TextEditingService // TypeDefIndex: 12686
	{
		// Methods
		[NativeMethod(Name = "TextEditingService::GetText")]
		internal static string GetText(IntPtr textGenerationInfo); // 0x00000001823366D0-0x0000000182336790
		[NativeMethod(Name = "TextEditingService::SetText")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool SetText(IntPtr textGenerationInfo, string text); // 0x0000000182336A10-0x0000000182336B80
		[NativeMethod(Name = "TextEditingService::DeleteSelection")]
		internal static int DeleteSelection(IntPtr textGenerationInfo); // 0x0000000182336540-0x0000000182336580
		[NativeMethod(Name = "TextEditingService::Delete")]
		internal static int Delete(IntPtr textGenerationInfo); // 0x0000000182336600-0x0000000182336640
		[NativeMethod(Name = "TextEditingService::Backspace")]
		internal static int Backspace(IntPtr textGenerationInfo); // 0x0000000182336480-0x00000001823364C0
		[NativeMethod(Name = "TextEditingService::DeleteWordBack")]
		internal static int DeleteWordBack(IntPtr textGenerationInfo); // 0x0000000182336580-0x00000001823365C0
		[NativeMethod(Name = "TextEditingService::DeleteWordForward")]
		internal static int DeleteWordForward(IntPtr textGenerationInfo); // 0x00000001823365C0-0x0000000182336600
		[NativeMethod(Name = "TextEditingService::DeleteLineBack")]
		internal static int DeleteLineBack(IntPtr textGenerationInfo); // 0x0000000182336500-0x0000000182336540
		[NativeMethod(Name = "TextEditingService::ReplaceSelection")]
		internal static int ReplaceSelection(IntPtr textGenerationInfo, string replace); // 0x0000000182336820-0x0000000182336980
		[NativeMethod(Name = "TextEditingService::RestoreCursorState")]
		internal static void RestoreCursorState(IntPtr textGenerationInfo); // 0x0000000182336980-0x00000001823369C0
		[NativeMethod(Name = "TextEditingService::EnableCursorPreviewState")]
		internal static void EnableCursorPreviewState(IntPtr textGenerationInfo, int compositionStringLength); // 0x0000000182336640-0x0000000182336680
		[NativeMethod(Name = "TextEditingService::Cut")]
		internal static int Cut(IntPtr textGenerationInfo); // 0x00000001823364C0-0x0000000182336500
		[NativeMethod(Name = "TextEditingService::OnBlur")]
		internal static int OnBlur(IntPtr textGenerationInfo); // 0x0000000182336790-0x00000001823367D0
		private static void GetText_Injected(IntPtr textGenerationInfo, ); // 0x0000000182336680-0x00000001823366D0
		private static bool SetText_Injected(IntPtr textGenerationInfo, ref ManagedSpanWrapper text); // 0x00000001823369C0-0x0000000182336A10
		private static int ReplaceSelection_Injected(IntPtr textGenerationInfo, ref ManagedSpanWrapper replace); // 0x00000001823367D0-0x0000000182336820
	}
}
