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
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	[NativeClass("AudioMixer", PersistentTypeId = 240)]
	[NativeHeader("Modules/Audio/Public/AudioMixer.h")]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioMixer.bindings.h")]
	public class AudioMixer : UnityEngine.Object // TypeDefIndex: 14947
	{
		// Methods
		[NativeMethod]
		public bool SetFloat(string name, float value); // 0x00000001821675C0-0x0000000182167750
		[NativeMethod]
		public bool GetFloat(string name, out float value); // 0x00000001821673D0-0x0000000182167560
		private static bool SetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value); // 0x0000000182167560-0x00000001821675C0
		private static bool GetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out float value); // 0x0000000182167370-0x00000001821673D0
	}
}
