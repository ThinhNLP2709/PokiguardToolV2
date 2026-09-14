/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LeanAudioOptions // TypeDefIndex: 310
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
	public enum LeanAudioWaveStyle // TypeDefIndex: 311
	{
		Sine = 0,
		Square = 1,
		Sawtooth = 2,
		Noise = 3
	}

	// Constructors
	public LeanAudioOptions(); // 0x00000001802DB580-0x00000001802DB5A0

	// Methods
	public LeanAudioOptions setFrequency(int frequencyRate); // 0x00000001802DB5A0-0x00000001802DB5B0
	public LeanAudioOptions setVibrato(Vector3[] vibrato); // 0x00000001802DB5B0-0x00000001802DB610
	public LeanAudioOptions setWaveNoise(); // 0x00000001802DB610-0x00000001802DB620
	public LeanAudioOptions setWaveNoiseScale(float waveScale); // 0x00000001802DB620-0x00000001802DB630
}

