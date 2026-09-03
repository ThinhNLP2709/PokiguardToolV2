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

namespace UnityEngine
{
	[NativeClass("AudioListener", PersistentTypeId = 81)]
	[RequireComponent(typeof(Transform))]
	[StaticAccessor("AudioListenerBindings", StaticAccessorType.DoubleColon)]
	public sealed class AudioListener : AudioBehaviour // TypeDefIndex: 14918
	{
		// Fields
		private const string k_GetOutputDataMsg = "GetOutputData() returning a float[] has been deprecated. Use GetOutputData() that accepts a preallocated array instead."; // Metadata: 0x006A9A07
		private const string k_GetSpectrumDataMsg = "GetSpectrumData() returning a float[] has been deprecated. Use GetSpectrumData() that accepts a preallocated array instead."; // Metadata: 0x006A9A80
	
		// Properties
		public static float volume { get; set; } // 0x0000000182167220-0x0000000182167250 0x0000000182167330-0x0000000182167370
		[NativeProperty("ListenerPause")]
		public static bool pause { get; set; } // 0x0000000182167150-0x0000000182167180 0x0000000182167250-0x0000000182167290
		public AudioVelocityUpdateMode velocityUpdateMode { get; set; } // 0x00000001821671C0-0x0000000182167220 0x00000001821672D0-0x0000000182167330
	
		// Constructors
		public AudioListener(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[NativeMethod(ThrowsException = true)]
		private static void GetOutputDataHelper(out float[] samples, int channel); // 0x0000000182166E40-0x0000000182166ED0
		[NativeMethod(ThrowsException = true)]
		private static void GetSpectrumDataHelper(out float[] samples, int channel, FFTWindow window); // 0x0000000182166FE0-0x0000000182167080
		public static void GetOutputData(float[] samples, int channel); // 0x0000000182166E40-0x0000000182166ED0
		public static void GetSpectrumData(float[] samples, int channel, FFTWindow window); // 0x0000000182166FE0-0x0000000182167080
		[Obsolete("GetOutputData() returning a float[] has been deprecated. Use GetOutputData() that accepts a preallocated array instead.", true)]
		public static float[] GetOutputData(int numSamples, int channel); // 0x0000000182166ED0-0x0000000182166F90
		[Obsolete("GetSpectrumData() returning a float[] has been deprecated. Use GetSpectrumData() that accepts a preallocated array instead.", true)]
		public static float[] GetSpectrumData(int numSamples, int channel, FFTWindow window); // 0x0000000182167080-0x0000000182167150
		private static void GetOutputDataHelper_Injected(out BlittableArrayWrapper samples, int channel); // 0x0000000182166E00-0x0000000182166E40
		private static void GetSpectrumDataHelper_Injected(out BlittableArrayWrapper samples, int channel, FFTWindow window); // 0x0000000182166F90-0x0000000182166FE0
		private static AudioVelocityUpdateMode get_velocityUpdateMode_Injected(IntPtr _unity_self); // 0x0000000182167180-0x00000001821671C0
		private static void set_velocityUpdateMode_Injected(IntPtr _unity_self, AudioVelocityUpdateMode value); // 0x0000000182167290-0x00000001821672D0
	}
}
