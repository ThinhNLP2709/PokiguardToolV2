/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Bindings;
using UnityEngine.Internal;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine
{
	[NativeClass("AudioSource", PersistentTypeId = 82)]
	[RequireComponent(typeof(Transform))]
	[StaticAccessor("AudioSourceBindings", StaticAccessorType.DoubleColon)]
	public sealed class AudioSource : AudioBehaviour // TypeDefIndex: 14919
	{
		// Fields
		private const string k_GetOutputDataMsg = "GetOutputData() returning a float[] has been deprecated. Use GetOutputData() that accepts a preallocated array instead."; // Metadata: 0x006A9AFD
		private const string k_GetSpectrumDataMsg = "GetSpectrumData() returning a float[] has been deprecated. Use GetSpectrumData() that accepts a preallocated array instead."; // Metadata: 0x006A9B76
	
		// Properties
		public float volume { get; set; } // 0x000000018216B590-0x000000018216B5F0 0x000000018216C940-0x000000018216C9B0
		public float pitch { get; set; } // 0x0000000182168800-0x0000000182168890 0x0000000182169920-0x00000001821699C0
		[NativeProperty("SecPosition")]
		public float time { get; set; } // 0x000000018216B450-0x000000018216B4B0 0x000000018216C7E0-0x000000018216C850
		[NativeProperty("SamplePosition")]
		public int timeSamples { [NativeMethod(IsThreadSafe = true)] get; [NativeMethod(IsThreadSafe = true)] set; } // 0x000000018216B3B0-0x000000018216B410 0x000000018216C730-0x000000018216C790
		public AudioClip clip { get; set; } // 0x000000018216A030-0x000000018216A100 0x000000018216B800-0x000000018216B880
		public AudioResource resource { get; set; } // 0x000000018216AE50-0x000000018216AF50 0x000000018216B800-0x000000018216B880
		public IAudioGenerator generator { get; set; } // 0x000000018216A450-0x000000018216A540 0x000000018216B990-0x000000018216BA70
		public ProcessorInstance generatorInstance { get; } // 0x000000018216A2E0-0x000000018216A380 
		internal unsafe void* generatorHeader { get; } // 0x000000018216A280-0x000000018216A2E0 
		internal Object generatorObject { get; set; } // 0x000000018216A3C0-0x000000018216A450 0x000000018216B800-0x000000018216B880
		public AudioMixerGroup outputAudioMixerGroup { get; set; } // 0x000000018216ABE0-0x000000018216AC70 0x000000018216BFC0-0x000000018216C040
		public bool isPlaying { [NativeName("IsPlayingScripting")] get; } // 0x000000018216A760-0x000000018216A7C0 
		internal bool isContainerPlaying { [NativeName("IsContainerPlaying")] get; } // 0x000000018216A6C0-0x000000018216A720 
		internal ActivePlayable[] containerActivePlayables { get; } // 0x000000018216A140-0x000000018216A1A0 
		public bool isVirtual { [NativeName("GetLastVirtualState")] get; } // 0x000000018216A800-0x000000018216A860 
		public bool loop { get; set; } // 0x000000018216A8A0-0x000000018216A900 0x000000018216BC20-0x000000018216BC80
		public bool ignoreListenerVolume { get; set; } // 0x000000018216A620-0x000000018216A680 0x000000018216BB70-0x000000018216BBD0
		public bool playOnAwake { get; set; } // 0x000000018216AD50-0x000000018216ADB0 0x000000018216C150-0x000000018216C1B0
		public bool ignoreListenerPause { get; set; } // 0x000000018216A580-0x000000018216A5E0 0x000000018216BAC0-0x000000018216BB20
		public AudioVelocityUpdateMode velocityUpdateMode { get; set; } // 0x000000018216B4F0-0x000000018216B550 0x000000018216C890-0x000000018216C8F0
		[NativeProperty("StereoPan")]
		public float panStereo { get; set; } // 0x000000018216ACB0-0x000000018216AD10 0x000000018216C090-0x000000018216C100
		[NativeProperty("SpatialBlendMix")]
		public float spatialBlend { get; set; } // 0x000000018216B130-0x000000018216B190 0x000000018216C460-0x000000018216C4D0
		public bool spatialize { get; set; } // 0x000000018216B270-0x000000018216B2D0 0x000000018216C5D0-0x000000018216C630
		public bool spatializePostEffects { get; set; } // 0x000000018216B1D0-0x000000018216B230 0x000000018216C520-0x000000018216C580
		public float reverbZoneMix { get; set; } // 0x000000018216AF90-0x000000018216AFF0 0x000000018216C2A0-0x000000018216C310
		public bool bypassEffects { get; set; } // 0x0000000182169E90-0x0000000182169EF0 0x000000018216B640-0x000000018216B6A0
		public bool bypassListenerEffects { get; set; } // 0x0000000182169F30-0x0000000182169F90 0x000000018216B6F0-0x000000018216B750
		public bool bypassReverbZones { get; set; } // 0x0000000182169FD0-0x000000018216A030 0x000000018216B7A0-0x000000018216B800
		public float dopplerLevel { get; set; } // 0x000000018216A1E0-0x000000018216A240 0x000000018216B8D0-0x000000018216B940
		public float spread { get; set; } // 0x000000018216B310-0x000000018216B370 0x000000018216C680-0x000000018216C6F0
		public int priority { get; set; } // 0x000000018216ADF0-0x000000018216AE50 0x000000018216C1F0-0x000000018216C250
		public bool mute { get; set; } // 0x000000018216AB40-0x000000018216ABA0 0x000000018216BF10-0x000000018216BF70
		public float minDistance { get; set; } // 0x000000018216AA40-0x000000018216AAA0 0x000000018216BDF0-0x000000018216BE60
		public float maxDistance { get; set; } // 0x000000018216A940-0x000000018216A9A0 0x000000018216BCD0-0x000000018216BD40
		public AudioRolloffMode rolloffMode { get; set; } // 0x000000018216B090-0x000000018216B0F0 0x000000018216C3B0-0x000000018216C410
		[Obsolete("minVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float minVolume { get; set; } // 0x000000018216AAA0-0x000000018216AB00 0x000000018216BE60-0x000000018216BEC0
		[Obsolete("maxVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float maxVolume { get; set; } // 0x000000018216A9A0-0x000000018216AA00 0x000000018216BD40-0x000000018216BDA0
		[Obsolete("rolloffFactor is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
		public float rolloffFactor { get; set; } // 0x000000018216AFF0-0x000000018216B050 0x000000018216C310-0x000000018216C370
	
		// Constructors
		public AudioSource(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static float GetPitch([NotNull] AudioSource source); // 0x0000000182168800-0x0000000182168890
		private static void SetPitch([NotNull] AudioSource source, float pitch); // 0x0000000182169920-0x00000001821699C0
		private static void PlayHelper([NotNull] AudioSource source, ulong delay); // 0x0000000182169010-0x00000001821690B0
		private void Play(double delay); // 0x00000001821695E0-0x0000000182169650
		private static void PlayOneShotHelper([NotNull] AudioSource source, [NotNull] AudioClip clip, float volumeScale); // 0x0000000182169110-0x0000000182169210
		private void Stop(bool stopOneShots); // 0x0000000182169D50-0x0000000182169DB0
		[NativeMethod(ThrowsException = true)]
		private static void SetCustomCurveHelper([NotNull] AudioSource source, AudioSourceCurveType type, AnimationCurve curve); // 0x0000000182169800-0x00000001821698D0
		private static AnimationCurve GetCustomCurveHelper([NotNull] AudioSource source, AudioSourceCurveType type); // 0x0000000182168510-0x00000001821685D0
		private static void GetOutputDataHelper([NotNull] AudioSource source, out float[] samples, int channel); // 0x0000000182168630-0x0000000182168740
		[NativeMethod(ThrowsException = true)]
		private static void GetSpectrumDataHelper([NotNull] AudioSource source, out float[] samples, int channel, FFTWindow window); // 0x00000001821689C0-0x0000000182168AE0
		[ExcludeFromDocs]
		public void Play(); // 0x0000000182169650-0x00000001821696F0
		public void Play([DefaultValue("0")] ulong delay); // 0x0000000182169010-0x00000001821690B0
		public void PlayDelayed(float delay); // 0x0000000182168F40-0x0000000182168FC0
		public void PlayScheduled(double time); // 0x0000000182169520-0x0000000182169590
		[ExcludeFromDocs]
		public void PlayOneShot(AudioClip clip); // 0x0000000182169210-0x0000000182169390
		public void PlayOneShot(AudioClip clip, [DefaultValue("1.0F")] float volumeScale); // 0x0000000182169390-0x0000000182169520
		public void SetScheduledStartTime(double time); // 0x0000000182169AD0-0x0000000182169B40
		public void SetScheduledEndTime(double time); // 0x0000000182169A10-0x0000000182169A80
		public void Stop(); // 0x0000000182169CF0-0x0000000182169D50
		public void Pause(); // 0x0000000182168BB0-0x0000000182168C10
		public void UnPause(); // 0x0000000182169DF0-0x0000000182169E50
		internal void SkipToNextElementIfHasContainer(); // 0x0000000182169C40-0x0000000182169CA0
		[ExcludeFromDocs]
		public static void PlayClipAtPoint(AudioClip clip, Vector3 position); // 0x0000000182168C10-0x0000000182168C40
		public static void PlayClipAtPoint(AudioClip clip, Vector3 position, [DefaultValue("1.0F")] float volume); // 0x0000000182168C40-0x0000000182168F40
		public void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve); // 0x0000000182169800-0x00000001821698D0
		public AnimationCurve GetCustomCurve(AudioSourceCurveType type); // 0x0000000182168510-0x00000001821685D0
		public void GetOutputData(float[] samples, int channel); // 0x00000001821687B0-0x00000001821687C0
		public void GetSpectrumData(float[] samples, int channel, FFTWindow window); // 0x0000000182168AE0-0x0000000182168AF0
		public bool SetSpatializerFloat(int index, float value); // 0x0000000182169B90-0x0000000182169C00
		public bool GetSpatializerFloat(int index, out float value); // 0x00000001821688E0-0x0000000182168950
		public bool GetAmbisonicDecoderFloat(int index, out float value); // 0x00000001821683C0-0x0000000182168430
		public bool SetAmbisonicDecoderFloat(int index, float value); // 0x0000000182169740-0x00000001821697B0
		internal float GetAudioRandomContainerRuntimeMeterValue(); // 0x0000000182168470-0x00000001821684D0
		[Obsolete("GetOutputData() returning a float[] has been deprecated. Use GetOutputData() that accepts a preallocated array instead.", true)]
		public float[] GetOutputData(int numSamples, int channel); // 0x0000000182168740-0x00000001821687B0
		[Obsolete("GetSpectrumData() returning a float[] has been deprecated. Use GetSpectrumData() that accepts a preallocated array instead.", true)]
		public float[] GetSpectrumData(int numSamples, int channel, FFTWindow window); // 0x0000000182168AF0-0x0000000182168B70
		private static float GetPitch_Injected(IntPtr source); // 0x00000001821687C0-0x0000000182168800
		private static void SetPitch_Injected(IntPtr source, float pitch); // 0x00000001821698D0-0x0000000182169920
		private static void PlayHelper_Injected(IntPtr source, ulong delay); // 0x0000000182168FC0-0x0000000182169010
		private static void Play_Injected(IntPtr _unity_self, double delay); // 0x0000000182169590-0x00000001821695E0
		private static void PlayOneShotHelper_Injected(IntPtr source, IntPtr clip, float volumeScale); // 0x00000001821690B0-0x0000000182169110
		private static void Stop_Injected(IntPtr _unity_self, bool stopOneShots); // 0x0000000182169CA0-0x0000000182169CF0
		private static void SetCustomCurveHelper_Injected(IntPtr source, AudioSourceCurveType type, IntPtr curve); // 0x00000001821697B0-0x0000000182169800
		private static IntPtr GetCustomCurveHelper_Injected(IntPtr source, AudioSourceCurveType type); // 0x00000001821684D0-0x0000000182168510
		private static void GetOutputDataHelper_Injected(IntPtr source, out BlittableArrayWrapper samples, int channel); // 0x00000001821685D0-0x0000000182168630
		private static void GetSpectrumDataHelper_Injected(IntPtr source, out BlittableArrayWrapper samples, int channel, FFTWindow window); // 0x0000000182168950-0x00000001821689C0
		private static float get_volume_Injected(IntPtr _unity_self); // 0x000000018216B550-0x000000018216B590
		private static void set_volume_Injected(IntPtr _unity_self, float value); // 0x000000018216C8F0-0x000000018216C940
		private static float get_time_Injected(IntPtr _unity_self); // 0x000000018216B410-0x000000018216B450
		private static void set_time_Injected(IntPtr _unity_self, float value); // 0x000000018216C790-0x000000018216C7E0
		private static int get_timeSamples_Injected(IntPtr _unity_self); // 0x000000018216B370-0x000000018216B3B0
		private static void set_timeSamples_Injected(IntPtr _unity_self, int value); // 0x000000018216C6F0-0x000000018216C730
		private static unsafe void* get_generatorHeader_Injected(IntPtr _unity_self); // 0x000000018216A240-0x000000018216A280
		private static IntPtr get_generatorObject_Injected(IntPtr _unity_self); // 0x000000018216A380-0x000000018216A3C0
		private static void set_generatorObject_Injected(IntPtr _unity_self, IntPtr value); // 0x000000018216B940-0x000000018216B990
		private static IntPtr get_outputAudioMixerGroup_Injected(IntPtr _unity_self); // 0x000000018216ABA0-0x000000018216ABE0
		private static void set_outputAudioMixerGroup_Injected(IntPtr _unity_self, IntPtr value); // 0x000000018216BF70-0x000000018216BFC0
		private static void SetScheduledStartTime_Injected(IntPtr _unity_self, double time); // 0x0000000182169A80-0x0000000182169AD0
		private static void SetScheduledEndTime_Injected(IntPtr _unity_self, double time); // 0x00000001821699C0-0x0000000182169A10
		private static void Pause_Injected(IntPtr _unity_self); // 0x0000000182168B70-0x0000000182168BB0
		private static void UnPause_Injected(IntPtr _unity_self); // 0x0000000182169DB0-0x0000000182169DF0
		private static void SkipToNextElementIfHasContainer_Injected(IntPtr _unity_self); // 0x0000000182169C00-0x0000000182169C40
		private static bool get_isPlaying_Injected(IntPtr _unity_self); // 0x000000018216A720-0x000000018216A760
		private static bool get_isContainerPlaying_Injected(IntPtr _unity_self); // 0x000000018216A680-0x000000018216A6C0
		private static ActivePlayable[] get_containerActivePlayables_Injected(IntPtr _unity_self); // 0x000000018216A100-0x000000018216A140
		private static bool get_isVirtual_Injected(IntPtr _unity_self); // 0x000000018216A7C0-0x000000018216A800
		private static bool get_loop_Injected(IntPtr _unity_self); // 0x000000018216A860-0x000000018216A8A0
		private static void set_loop_Injected(IntPtr _unity_self, bool value); // 0x000000018216BBD0-0x000000018216BC20
		private static bool get_ignoreListenerVolume_Injected(IntPtr _unity_self); // 0x000000018216A5E0-0x000000018216A620
		private static void set_ignoreListenerVolume_Injected(IntPtr _unity_self, bool value); // 0x000000018216BB20-0x000000018216BB70
		private static bool get_playOnAwake_Injected(IntPtr _unity_self); // 0x000000018216AD10-0x000000018216AD50
		private static void set_playOnAwake_Injected(IntPtr _unity_self, bool value); // 0x000000018216C100-0x000000018216C150
		private static bool get_ignoreListenerPause_Injected(IntPtr _unity_self); // 0x000000018216A540-0x000000018216A580
		private static void set_ignoreListenerPause_Injected(IntPtr _unity_self, bool value); // 0x000000018216BA70-0x000000018216BAC0
		private static AudioVelocityUpdateMode get_velocityUpdateMode_Injected(IntPtr _unity_self); // 0x000000018216B4B0-0x000000018216B4F0
		private static void set_velocityUpdateMode_Injected(IntPtr _unity_self, AudioVelocityUpdateMode value); // 0x000000018216C850-0x000000018216C890
		private static float get_panStereo_Injected(IntPtr _unity_self); // 0x000000018216AC70-0x000000018216ACB0
		private static void set_panStereo_Injected(IntPtr _unity_self, float value); // 0x000000018216C040-0x000000018216C090
		private static float get_spatialBlend_Injected(IntPtr _unity_self); // 0x000000018216B0F0-0x000000018216B130
		private static void set_spatialBlend_Injected(IntPtr _unity_self, float value); // 0x000000018216C410-0x000000018216C460
		private static bool get_spatialize_Injected(IntPtr _unity_self); // 0x000000018216B230-0x000000018216B270
		private static void set_spatialize_Injected(IntPtr _unity_self, bool value); // 0x000000018216C580-0x000000018216C5D0
		private static bool get_spatializePostEffects_Injected(IntPtr _unity_self); // 0x000000018216B190-0x000000018216B1D0
		private static void set_spatializePostEffects_Injected(IntPtr _unity_self, bool value); // 0x000000018216C4D0-0x000000018216C520
		private static float get_reverbZoneMix_Injected(IntPtr _unity_self); // 0x000000018216AF50-0x000000018216AF90
		private static void set_reverbZoneMix_Injected(IntPtr _unity_self, float value); // 0x000000018216C250-0x000000018216C2A0
		private static bool get_bypassEffects_Injected(IntPtr _unity_self); // 0x0000000182169E50-0x0000000182169E90
		private static void set_bypassEffects_Injected(IntPtr _unity_self, bool value); // 0x000000018216B5F0-0x000000018216B640
		private static bool get_bypassListenerEffects_Injected(IntPtr _unity_self); // 0x0000000182169EF0-0x0000000182169F30
		private static void set_bypassListenerEffects_Injected(IntPtr _unity_self, bool value); // 0x000000018216B6A0-0x000000018216B6F0
		private static bool get_bypassReverbZones_Injected(IntPtr _unity_self); // 0x0000000182169F90-0x0000000182169FD0
		private static void set_bypassReverbZones_Injected(IntPtr _unity_self, bool value); // 0x000000018216B750-0x000000018216B7A0
		private static float get_dopplerLevel_Injected(IntPtr _unity_self); // 0x000000018216A1A0-0x000000018216A1E0
		private static void set_dopplerLevel_Injected(IntPtr _unity_self, float value); // 0x000000018216B880-0x000000018216B8D0
		private static float get_spread_Injected(IntPtr _unity_self); // 0x000000018216B2D0-0x000000018216B310
		private static void set_spread_Injected(IntPtr _unity_self, float value); // 0x000000018216C630-0x000000018216C680
		private static int get_priority_Injected(IntPtr _unity_self); // 0x000000018216ADB0-0x000000018216ADF0
		private static void set_priority_Injected(IntPtr _unity_self, int value); // 0x000000018216C1B0-0x000000018216C1F0
		private static bool get_mute_Injected(IntPtr _unity_self); // 0x000000018216AB00-0x000000018216AB40
		private static void set_mute_Injected(IntPtr _unity_self, bool value); // 0x000000018216BEC0-0x000000018216BF10
		private static float get_minDistance_Injected(IntPtr _unity_self); // 0x000000018216AA00-0x000000018216AA40
		private static void set_minDistance_Injected(IntPtr _unity_self, float value); // 0x000000018216BDA0-0x000000018216BDF0
		private static float get_maxDistance_Injected(IntPtr _unity_self); // 0x000000018216A900-0x000000018216A940
		private static void set_maxDistance_Injected(IntPtr _unity_self, float value); // 0x000000018216BC80-0x000000018216BCD0
		private static AudioRolloffMode get_rolloffMode_Injected(IntPtr _unity_self); // 0x000000018216B050-0x000000018216B090
		private static void set_rolloffMode_Injected(IntPtr _unity_self, AudioRolloffMode value); // 0x000000018216C370-0x000000018216C3B0
		private static bool SetSpatializerFloat_Injected(IntPtr _unity_self, int index, float value); // 0x0000000182169B40-0x0000000182169B90
		private static bool GetSpatializerFloat_Injected(IntPtr _unity_self, int index, out float value); // 0x0000000182168890-0x00000001821688E0
		private static bool GetAmbisonicDecoderFloat_Injected(IntPtr _unity_self, int index, out float value); // 0x0000000182168370-0x00000001821683C0
		private static bool SetAmbisonicDecoderFloat_Injected(IntPtr _unity_self, int index, float value); // 0x00000001821696F0-0x0000000182169740
		private static float GetAudioRandomContainerRuntimeMeterValue_Injected(IntPtr _unity_self); // 0x0000000182168430-0x0000000182168470
	}
}
