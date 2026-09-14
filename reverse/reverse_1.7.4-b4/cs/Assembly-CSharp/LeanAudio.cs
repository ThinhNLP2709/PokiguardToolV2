/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LeanAudio // TypeDefIndex: 309
{
	// Fields
	public static float MIN_FREQEUNCY_PERIOD; // 0x00
	public static int PROCESSING_ITERATIONS_MAX; // 0x04
	public static float[] generatedWaveDistances; // 0x08
	public static int generatedWaveDistancesCount; // 0x10
	private static float[] longList; // 0x18

	// Constructors
	static LeanAudio(); // 0x00000001802DB510-0x00000001802DB580

	// Methods
	public static LeanAudioOptions options(); // 0x00000001802DA020-0x00000001802DA1E0
	public static AudioClip createAudio(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null); // 0x00000001802DA1E0-0x00000001802DA2A0
	private static int createAudioWave(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options); // 0x00000001802DA2A0-0x00000001802DA8A0
	private static AudioClip createAudioFromWave(int waveLength, LeanAudioOptions options); // 0x00000001802DA8A0-0x00000001802DB090
	private static void OnAudioSetPosition(int newPosition); // 0x000000018028A320-0x000000018028A330
	public static AudioSource play(AudioClip audio); // 0x00000001802DB090-0x00000001802DB120
	public static AudioSource play(AudioClip audio, Vector3 pos, float volume); // 0x00000001802DB120-0x00000001802DB270
	public static AudioSource playClipAt(AudioClip clip, Vector3 pos); // 0x00000001802DB270-0x00000001802DB510
}

