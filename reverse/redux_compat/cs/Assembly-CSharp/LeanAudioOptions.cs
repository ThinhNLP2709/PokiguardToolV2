/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LeanAudioOptions // TypeDefIndex: 287
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
	public enum LeanAudioWaveStyle // TypeDefIndex: 288
	{
		Sine = 0,
		Square = 1,
		Sawtooth = 2,
		Noise = 3
	}

	// Constructors
	public LeanAudioOptions(); // 0x00000001806CFAE0-0x00000001806CFB00

	// Methods
	public LeanAudioOptions setFrequency(int frequencyRate); // 0x00000001806CFB00-0x00000001806CFB10
	public LeanAudioOptions setVibrato(Vector3[] vibrato); // 0x00000001806CFB10-0x00000001806CFB30
	public LeanAudioOptions setWaveSine(); // 0x00000001806CFB70-0x00000001806CFB80
	public LeanAudioOptions setWaveSquare(); // 0x00000001806CFB80-0x00000001806CFB90
	public LeanAudioOptions setWaveSawtooth(); // 0x00000001806CFB60-0x00000001806CFB70
	public LeanAudioOptions setWaveNoise(); // 0x00000001806CFB50-0x00000001806CFB60
	public LeanAudioOptions setWaveStyle(LeanAudioWaveStyle style); // 0x00000001806CFB90-0x00000001806CFBA0
	public LeanAudioOptions setWaveNoiseScale(float waveScale); // 0x00000001806CFB40-0x00000001806CFB50
	public LeanAudioOptions setWaveNoiseInfluence(float influence); // 0x00000001806CFB30-0x00000001806CFB40
}

