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
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal static class TextGenerationInfo // TypeDefIndex: 12704
	{
		// Fields
		[CompilerGenerated]
		private static int _CurrentGenerationIteration_k__BackingField; // 0x00
	
		// Properties
		public static int CurrentGenerationIteration { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000182339250-0x0000000182339290 0x0000000182339290-0x00000001823392D0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr Create(bool isPermanent); // 0x00000001823390D0-0x0000000182339110
		[NativeMethod(IsThreadSafe = true)]
		public static void Destroy(IntPtr ptr); // 0x0000000182339140-0x0000000182339180
		public static void OnRepaintEnd(); // 0x00000001823391C0-0x0000000182339250
		private static void DestroyAllTempAllocations(); // 0x0000000182339110-0x0000000182339140
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		public static float GetLineHeight(IntPtr ptr, int lineNumber); // 0x0000000182339180-0x00000001823391C0
	}
}
