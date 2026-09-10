/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanAudioStream // TypeDefIndex: 311
{
	// Fields
	public int position; // 0x10
	public AudioClip audioClip; // 0x18
	public float[] audioArr; // 0x20

	// Constructors
	public LeanAudioStream(float[] audioArr); // 0x000000018031CA80-0x000000018031CAC0

	// Methods
	public void OnAudioRead(float[] data); // 0x000000018031CA10-0x000000018031CA70
	public void OnAudioSetPosition(int newPosition); // 0x000000018031CA70-0x000000018031CA80
}

