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
	[NativeHeader("Modules/Audio/Public/SampleProvider/ScriptBindings/SampleProvider.bindings.h")]
	internal static class SampleProviderBindings // TypeDefIndex: 14924
	{
		// Methods
		[NativeMethod(Name = "audio::CreateSampleProviderGeneratorHeader", IsFreeFunction = true, ThrowsException = true)]
		internal static unsafe void* CreateGeneratorHeader(AudioClip audioClip, void* resourceHeader, AudioConfiguration* nestedConfiguration); // 0x000000018216D090-0x000000018216D0F0
		private static unsafe void* CreateGeneratorHeader_Injected(IntPtr audioClip, void* resourceHeader, AudioConfiguration* nestedConfiguration); // 0x000000018216D030-0x000000018216D090
	}
}
