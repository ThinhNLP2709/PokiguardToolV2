/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class AudioEventManager // TypeDefIndex: 456
{
	// Fields
	[CompilerGenerated]
	private static Action<float> OnSFXVolumeChanged; // 0x00
	[CompilerGenerated]
	private static Action<float> OnMasterVolumeChanged; // 0x08

	// Events
	public static event Action<float> OnSFXVolumeChanged {
		add; // 0x000000018035C940-0x000000018035CA10
		remove; // 0x000000018035CAF0-0x000000018035CBC0
	}
	public static event Action<float> OnMasterVolumeChanged {
		add; // 0x000000018035C860-0x000000018035C940
		remove; // 0x000000018035CA10-0x000000018035CAF0
	}

	// Methods
	public static void NotifySFXVolumeChanged(float newVolume); // 0x000000018035C800-0x000000018035C860
	public static void NotifyMasterVolumeChanged(float newVolume); // 0x000000018035C7A0-0x000000018035C800
}

