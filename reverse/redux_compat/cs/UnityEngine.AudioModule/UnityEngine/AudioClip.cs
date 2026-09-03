/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine
{
	[NativeClass("AudioClip", PersistentTypeId = 83)]
	[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
	[StaticAccessor("AudioClipBindings", StaticAccessorType.DoubleColon)]
	public sealed class AudioClip : AudioResource, IAudioGenerator // TypeDefIndex: 14914
	{
		// Fields
		[CompilerGenerated]
		private PCMReaderCallback m_PCMReaderCallback; // 0x18
		[CompilerGenerated]
		private PCMSetPositionCallback m_PCMSetPositionCallback; // 0x20
		private const string k_CreateMsg = "Create() with the _3D argument has been deprecated. Use the AudioSource.spatialBlend property to morph between 2D and 3D playback instead."; // Metadata: 0x006A98FB
		private const string k_IsReadyToPlayMsg = "isReadyToPlay has been deprecated. Use AudioClip.loadState to get more detailed information about the loading process instead."; // Metadata: 0x006A9987
	
		// Properties
		[NativeProperty("LengthSec")]
		public float length { get; } // 0x0000000182166940-0x00000001821669A0 
		[NativeProperty("SampleCount")]
		public int samples { get; } // 0x0000000182166C60-0x0000000182166CC0 
		[NativeProperty("ChannelCount")]
		public int channels { get; } // 0x0000000182166800-0x0000000182166860 
		public int frequency { get; } // 0x00000001821668A0-0x0000000182166900 
		public AudioClipLoadType loadType { get; } // 0x0000000182166B20-0x0000000182166B80 
		public bool preloadAudioData { get; } // 0x0000000182166BC0-0x0000000182166C20 
		public bool ambisonic { get; } // 0x0000000182166760-0x00000001821667C0 
		public bool loadInBackground { get; } // 0x00000001821669E0-0x0000000182166A40 
		public AudioDataLoadState loadState { [NativeMethod(Name = "AudioClipBindings::GetLoadState", HasExplicitThis = true)] get; } // 0x0000000182166A80-0x0000000182166AE0 
		bool ICapabilities.isRealtime { get; } // 0x0000000182166310-0x0000000182166330 
		bool ICapabilities.isFinite { get; } // 0x00000001821662F0-0x0000000182166310 
		DiscreteTime? ICapabilities.length { get; } // 0x0000000182166330-0x00000001821664F0 
		[Obsolete("isReadyToPlay has been deprecated. Use AudioClip.loadState to get more detailed information about the loading process instead.", true)]
		public bool isReadyToPlay { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Events
		private event PCMReaderCallback m_PCMReaderCallback {
			add; // 0x00000001821665E0-0x0000000182166680
			remove; // 0x0000000182166CC0-0x0000000182166D60
		}
		private event PCMSetPositionCallback m_PCMSetPositionCallback {
			add; // 0x0000000182166680-0x0000000182166720
			remove; // 0x0000000182166D60-0x0000000182166E00
		}
	
		// Nested types
		public delegate void PCMReaderCallback(float[] data); // TypeDefIndex: 14915; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void PCMSetPositionCallback(int position); // TypeDefIndex: 14916; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		private AudioClip(); // 0x0000000182166590-0x00000001821665E0
	
		// Methods
		private static bool GetData([NotNull] AudioClip clip, Span<float> data, int samplesOffset); // 0x0000000182165750-0x0000000182165840
		private static bool SetData([NotNull] AudioClip clip, ReadOnlySpan<float> data, int samplesOffset); // 0x0000000182166200-0x00000001821662F0
		private static AudioClip Construct_Internal(); // 0x0000000182164D90-0x0000000182164DF0
		private new string GetName(); // 0x0000000182165A30-0x0000000182165B20
		private void CreateUserSound(string name, int lengthSamples, int channels, int frequency, bool stream); // 0x0000000182164F50-0x00000001821650F0
		private bool IsLegacyFormat(); // 0x0000000182165BA0-0x0000000182165C00
		public bool LoadAudioData(); // 0x0000000182165C80-0x0000000182165CE0
		public bool UnloadAudioData(); // 0x0000000182166530-0x0000000182166590
		[NativeMethod(Name = "AudioClipBindings::IsValidAmbisonicChannelCount", IsFreeFunction = true)]
		internal static bool IsValidAmbisonicChannelCount(int channels); // 0x0000000182165C00-0x0000000182165C40
		public bool GetData(Span<float> data, int offsetSamples); // 0x0000000182165840-0x00000001821659E0
		public bool GetData(float[] data, int offsetSamples); // 0x0000000182165570-0x0000000182165750
		public bool SetData(float[] data, int offsetSamples); // 0x0000000182165FC0-0x0000000182166200
		public bool SetData(ReadOnlySpan<float> data, int offsetSamples); // 0x0000000182165D40-0x0000000182165FC0
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream); // 0x00000001821654B0-0x00000001821654E0
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback); // 0x0000000182165120-0x0000000182165150
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback); // 0x0000000182165190-0x00000001821654B0
		[RequiredByNativeCode]
		private void InvokePCMReaderCallback_Internal(float[] data); // 0x0000000182165B20-0x0000000182165B40
		[RequiredByNativeCode]
		private void InvokePCMSetPositionCallback_Internal(int position); // 0x0000000182165B40-0x0000000182165B60
		private void CheckIsNotPersistent(); // 0x0000000182164C80-0x0000000182164D60
		public GeneratorInstance CreateInstance(ControlContext context, AudioFormat? nestedFormat, ProcessorInstance.CreationParameters creationParameters); // 0x0000000182164DF0-0x0000000182164EE0
		[Obsolete("Create() with the _3D argument has been deprecated. Use the AudioSource.spatialBlend property to morph between 2D and 3D playback instead.", true)]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream); // 0x00000001821654E0-0x0000000182165510
		[Obsolete("Create() with the _3D argument has been deprecated. Use the AudioSource.spatialBlend property to morph between 2D and 3D playback instead.", true)]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback); // 0x00000001821650F0-0x0000000182165120
		[Obsolete("Create() with the _3D argument has been deprecated. Use the AudioSource.spatialBlend property to morph between 2D and 3D playback instead.", true)]
		public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback); // 0x0000000182165150-0x0000000182165190
		private static bool GetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset); // 0x0000000182165510-0x0000000182165570
		private static bool SetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset); // 0x0000000182165CE0-0x0000000182165D40
		private static IntPtr Construct_Internal_Injected(); // 0x0000000182164D60-0x0000000182164D90
		private static new void GetName_Injected(IntPtr _unity_self, ); // 0x00000001821659E0-0x0000000182165A30
		private static void CreateUserSound_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int lengthSamples, int channels, int frequency, bool stream); // 0x0000000182164EE0-0x0000000182164F50
		private static bool IsLegacyFormat_Injected(IntPtr _unity_self); // 0x0000000182165B60-0x0000000182165BA0
		private static float get_length_Injected(IntPtr _unity_self); // 0x0000000182166900-0x0000000182166940
		private static int get_samples_Injected(IntPtr _unity_self); // 0x0000000182166C20-0x0000000182166C60
		private static int get_channels_Injected(IntPtr _unity_self); // 0x00000001821667C0-0x0000000182166800
		private static int get_frequency_Injected(IntPtr _unity_self); // 0x0000000182166860-0x00000001821668A0
		private static AudioClipLoadType get_loadType_Injected(IntPtr _unity_self); // 0x0000000182166AE0-0x0000000182166B20
		private static bool LoadAudioData_Injected(IntPtr _unity_self); // 0x0000000182165C40-0x0000000182165C80
		private static bool UnloadAudioData_Injected(IntPtr _unity_self); // 0x00000001821664F0-0x0000000182166530
		private static bool get_preloadAudioData_Injected(IntPtr _unity_self); // 0x0000000182166B80-0x0000000182166BC0
		private static bool get_ambisonic_Injected(IntPtr _unity_self); // 0x0000000182166720-0x0000000182166760
		private static bool get_loadInBackground_Injected(IntPtr _unity_self); // 0x00000001821669A0-0x00000001821669E0
		private static AudioDataLoadState get_loadState_Injected(IntPtr _unity_self); // 0x0000000182166A40-0x0000000182166A80
	}
}
