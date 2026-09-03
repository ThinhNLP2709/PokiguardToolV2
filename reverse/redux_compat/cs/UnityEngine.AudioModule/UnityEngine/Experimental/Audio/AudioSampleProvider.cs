/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Experimental.Audio
{
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioSampleProvider.bindings.h")]
	[StaticAccessor("AudioSampleProviderBindings", StaticAccessorType.DoubleColon)]
	public class AudioSampleProvider // TypeDefIndex: 14922
	{
		// Fields
		[CompilerGenerated]
		private SampleFramesHandler sampleFramesAvailable; // 0x10
		[CompilerGenerated]
		private SampleFramesHandler sampleFramesOverflow; // 0x18
	
		// Nested types
		public delegate void SampleFramesHandler(AudioSampleProvider provider, uint sampleFrameCount); // TypeDefIndex: 14923; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Methods
		[RequiredByNativeCode]
		private void InvokeSampleFramesAvailable(int sampleFrameCount); // 0x0000000182167750-0x0000000182167780
		[RequiredByNativeCode]
		private void InvokeSampleFramesOverflow(int droppedSampleFrameCount); // 0x0000000182167780-0x00000001821677B0
	}
}
