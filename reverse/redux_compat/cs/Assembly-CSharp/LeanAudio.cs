/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LeanAudio // TypeDefIndex: 286
{
	// Fields
	public static float MIN_FREQEUNCY_PERIOD; // 0x00
	public static int PROCESSING_ITERATIONS_MAX; // 0x04
	public static float[] generatedWaveDistances; // 0x08
	public static int generatedWaveDistancesCount; // 0x10
	private static float[] longList; // 0x18

	// Constructors
	public LeanAudio(); // 0x00000001802E5CB0-0x00000001802E5CC0
	static LeanAudio(); // 0x00000001806CFC40-0x00000001806CFCB0

	// Methods
	public static LeanAudioOptions options(); // 0x00000001806D0AA0-0x00000001806D0BD0
	public static LeanAudioStream createAudioStream(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null); // 0x00000001806D02D0-0x00000001806D03A0
	public static AudioClip createAudio(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options = null); // 0x00000001806D0870-0x00000001806D0930
	private static int createAudioWave(AnimationCurve volume, AnimationCurve frequency, LeanAudioOptions options); // 0x00000001806D03A0-0x00000001806D0870
	private static AudioClip createAudioFromWave(int waveLength, LeanAudioOptions options); // 0x00000001806CFCB0-0x00000001806D02D0
	private static void OnAudioSetPosition(int newPosition); // 0x00000001802E76C0-0x00000001802E76D0
	public static AudioClip generateAudioFromCurve(AnimationCurve curve, int frequencyRate = 44100 /* Metadata: 0x0064C08B */); // 0x00000001806D0930-0x00000001806D0AA0
	public static AudioSource play(AudioClip audio, float volume); // 0x00000001806D0DB0-0x00000001806D0E60
	public static AudioSource play(AudioClip audio); // 0x00000001806D0ED0-0x00000001806D0F60
	public static AudioSource play(AudioClip audio, Vector3 pos); // 0x00000001806D0E60-0x00000001806D0ED0
	public static AudioSource play(AudioClip audio, Vector3 pos, float volume); // 0x00000001806D0D00-0x00000001806D0DB0
	public static AudioSource playClipAt(AudioClip clip, Vector3 pos); // 0x00000001806D0BD0-0x00000001806D0D00
	public static void printOutAudioClip(AudioClip audioClip, ref AnimationCurve curve, float scaleX = 1f /* Metadata: 0x0064C08F */); // 0x00000001806D0F60-0x00000001806D1110
}

