namespace UnityEngine;

[RequireComponent(typeof(Transform))]
[StaticAccessor("AudioSourceBindings", StaticAccessorType::DoubleColon (2))]
public sealed class AudioSource : AudioBehaviour
{

	public AudioClip clip
	{
		 get { } //Length: 209
		 set { } //Length: 186
	}

	public bool isPlaying
	{
		[NativeName("IsPlayingScripting")]
		 get { } //Length: 118
	}

	public bool loop
	{
		 set { } //Length: 134
	}

	public float minDistance
	{
		 set { } //Length: 134
	}

	public bool mute
	{
		 set { } //Length: 134
	}

	public float pitch
	{
		 get { } //Length: 155
		 set { } //Length: 171
	}

	public bool playOnAwake
	{
		 set { } //Length: 134
	}

	public AudioResource resource
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	[NativeProperty("SpatialBlendMix")]
	public float spatialBlend
	{
		 set { } //Length: 134
	}

	public float volume
	{
		 get { } //Length: 118
		 set { } //Length: 216
	}

	public AudioClip get_clip() { }

	[NativeName("IsPlayingScripting")]
	public bool get_isPlaying() { }

	private static bool get_isPlaying_Injected(IntPtr _unity_self) { }

	public float get_pitch() { }

	public AudioResource get_resource() { }

	private static IntPtr get_resource_Injected(IntPtr _unity_self) { }

	public float get_volume() { }

	private static float get_volume_Injected(IntPtr _unity_self) { }

	private static float GetPitch(AudioSource source) { }

	private static float GetPitch_Injected(IntPtr source) { }

	public void Pause() { }

	private static void Pause_Injected(IntPtr _unity_self) { }

	[ExcludeFromDocs]
	public void Play() { }

	public static void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume) { }

	private static void PlayHelper(AudioSource source, ulong delay) { }

	private static void PlayHelper_Injected(IntPtr source, ulong delay) { }

	[ExcludeFromDocs]
	public void PlayOneShot(AudioClip clip) { }

	public void PlayOneShot(AudioClip clip, float volumeScale) { }

	private static void PlayOneShotHelper(AudioSource source, AudioClip clip, float volumeScale) { }

	private static void PlayOneShotHelper_Injected(IntPtr source, IntPtr clip, float volumeScale) { }

	public void set_clip(AudioClip value) { }

	public void set_loop(bool value) { }

	private static void set_loop_Injected(IntPtr _unity_self, bool value) { }

	public void set_minDistance(float value) { }

	private static void set_minDistance_Injected(IntPtr _unity_self, float value) { }

	public void set_mute(bool value) { }

	private static void set_mute_Injected(IntPtr _unity_self, bool value) { }

	public void set_pitch(float value) { }

	public void set_playOnAwake(bool value) { }

	private static void set_playOnAwake_Injected(IntPtr _unity_self, bool value) { }

	public void set_resource(AudioResource value) { }

	private static void set_resource_Injected(IntPtr _unity_self, IntPtr value) { }

	public void set_spatialBlend(float value) { }

	private static void set_spatialBlend_Injected(IntPtr _unity_self, float value) { }

	public void set_volume(float value) { }

	private static void set_volume_Injected(IntPtr _unity_self, float value) { }

	private static void SetPitch(AudioSource source, float pitch) { }

	private static void SetPitch_Injected(IntPtr source, float pitch) { }

	private void Stop(bool stopOneShots) { }

	public void Stop() { }

	private static void Stop_Injected(IntPtr _unity_self, bool stopOneShots) { }

	public void UnPause() { }

	private static void UnPause_Injected(IntPtr _unity_self) { }

}

