/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LeanAudioStream // TypeDefIndex: 308
{
	// Fields
	public int position; // 0x10
	public AudioClip audioClip; // 0x18
	public float[] audioArr; // 0x20

	// Constructors
	public LeanAudioStream(float[] audioArr); // 0x00000001802B4BC0-0x00000001802B4C20

	// Methods
	public void OnAudioRead(float[] data); // 0x00000001802D9FC0-0x00000001802DA020
	public void OnAudioSetPosition(int newPosition); // 0x000000018028E160-0x000000018028E170
}

