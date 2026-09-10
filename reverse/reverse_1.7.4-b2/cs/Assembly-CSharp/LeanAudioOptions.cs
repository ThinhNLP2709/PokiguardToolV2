/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanAudioOptions // TypeDefIndex: 313
{
	// Fields
	public LeanAudioWaveStyle waveStyle; // 0x10
	public Vector3[] vibrato; // 0x18
	public Vector3[] modulation; // 0x20
	public int frequencyRate; // 0x28
	public float waveNoiseScale; // 0x2C
	public float waveNoiseInfluence; // 0x30
	public bool useSetData; // 0x34
	public LeanAudioStream stream; // 0x38

	// Nested types
	public enum LeanAudioWaveStyle // TypeDefIndex: 314
	{
		Sine = 0,
		Square = 1,
		Sawtooth = 2,
		Noise = 3
	}

	// Constructors
	public LeanAudioOptions(); // 0x000000018031C950-0x000000018031C970

	// Methods
	public LeanAudioOptions setFrequency(int frequencyRate); // 0x000000018031C970-0x000000018031C980
	public LeanAudioOptions setVibrato(Vector3[] vibrato); // 0x000000018031C980-0x000000018031C9A0
	public LeanAudioOptions setWaveSine(); // 0x000000018031C9E0-0x000000018031C9F0
	public LeanAudioOptions setWaveSquare(); // 0x000000018031C9F0-0x000000018031CA00
	public LeanAudioOptions setWaveSawtooth(); // 0x000000018031C9D0-0x000000018031C9E0
	public LeanAudioOptions setWaveNoise(); // 0x000000018031C9C0-0x000000018031C9D0
	public LeanAudioOptions setWaveStyle(LeanAudioWaveStyle style); // 0x000000018031CA00-0x000000018031CA10
	public LeanAudioOptions setWaveNoiseScale(float waveScale); // 0x000000018031C9B0-0x000000018031C9C0
	public LeanAudioOptions setWaveNoiseInfluence(float influence); // 0x000000018031C9A0-0x000000018031C9B0
}

