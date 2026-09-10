/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanAudio // TypeDefIndex: 312
{
	// Fields
	public static float MIN_FREQEUNCY_PERIOD; // 0x00
	public static int PROCESSING_ITERATIONS_MAX; // 0x04
	public static float[] generatedWaveDistances; // 0x08
	public static int generatedWaveDistancesCount; // 0x10
	private static float[] longList; // 0x18

	// Constructors
	public LeanAudio(); // 0x00000001802E9CB0-0x00000001802E9CC0
	static LeanAudio(); // 0x000000018031CAC0-0x000000018031CB30

	// Methods
	public static LeanAudioOptions options(); // 0x000000018031D920-0x000000018031DA50
	public static LeanAudioStream createAudioStream(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null); // 0x000000018031D150-0x000000018031D220
	public static AudioClip createAudio(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null); // 0x000000018031D6F0-0x000000018031D7B0
	private static int createAudioWave(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options); // 0x000000018031D220-0x000000018031D6F0
	private static AudioClip createAudioFromWave(int waveLength, LeanAudioOptions options); // 0x000000018031CB30-0x000000018031D150
	private static void OnAudioSetPosition(int newPosition); // 0x00000001802EB6C0-0x00000001802EB6D0
	public static AudioClip generateAudioFromCurve(AnimationCurve curve, int frequencyRate = 44100 /* Metadata: 0x0068ADA3 */); // 0x000000018031D7B0-0x000000018031D920
	public static AudioSource play(AudioClip audio, float volume); // 0x000000018031DC30-0x000000018031DCE0
	public static AudioSource play(AudioClip audio); // 0x000000018031DD50-0x000000018031DDE0
	public static AudioSource play(AudioClip audio, Vector3 pos); // 0x000000018031DCE0-0x000000018031DD50
	public static AudioSource play(AudioClip audio, Vector3 pos, float volume); // 0x000000018031DB80-0x000000018031DC30
	public static AudioSource playClipAt(AudioClip clip, Vector3 pos); // 0x000000018031DA50-0x000000018031DB80
	public static void printOutAudioClip(AudioClip audioClip, ref AnimationCurve curve, float scaleX = 1f /* Metadata: 0x0068ADA7 */); // 0x000000018031DDE0-0x000000018031DF90
}

