/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Audio
{
	[NativeHeader("Modules/Audio/Public/ScriptableProcessors/ScriptBindings/ScriptableProcessor.bindings.h")]
	internal static class ScriptableProcessorBindings // TypeDefIndex: 14944
	{
		// Methods
		public static unsafe bool CheckProcessorExists(DualThreadHandle handle, ControlHeader* control); // 0x000000018216D730-0x000000018216D770
		[NativeMethod(Name = "audio::CheckProcessorExists", IsFreeFunction = true)]
		private static unsafe bool CheckProcessorExistsInternal(DualThreadHandle handle, void* control); // 0x000000018216D6F0-0x000000018216D730
		private static unsafe bool CheckProcessorExistsInternal_Injected(in DualThreadHandle handle, void* control); // 0x000000018216D6A0-0x000000018216D6F0
	}
}
