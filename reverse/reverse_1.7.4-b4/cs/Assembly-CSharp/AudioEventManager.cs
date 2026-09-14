/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class AudioEventManager // TypeDefIndex: 598
{
	// Fields
	[CompilerGenerated]
	private static Action<float> OnSFXVolumeChanged; // 0x00
	[CompilerGenerated]
	private static Action<float> OnMasterVolumeChanged; // 0x08

	// Events
	public static event Action<float> OnSFXVolumeChanged {
		add; // 0x000000018042CBB0-0x000000018042CCE0
		remove; // 0x000000018042CCE0-0x000000018042CE10
	}
	public static event Action<float> OnMasterVolumeChanged {
		add; // 0x000000018042CE10-0x000000018042CF50
		remove; // 0x000000018042CF50-0x000000018042D090
	}

	// Methods
	public static void NotifySFXVolumeChanged(float newVolume); // 0x000000018042D090-0x000000018042D0F0
	public static void NotifyMasterVolumeChanged(float newVolume); // 0x000000018042D0F0-0x000000018042D160
}

