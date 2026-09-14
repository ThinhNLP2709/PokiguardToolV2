/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class AudioEventManager // TypeDefIndex: 597
{
	// Fields
	[CompilerGenerated]
	private static Action<float> OnSFXVolumeChanged; // 0x00
	[CompilerGenerated]
	private static Action<float> OnMasterVolumeChanged; // 0x08

	// Events
	public static event Action<float> OnSFXVolumeChanged {
		add; // 0x000000018042BB20-0x000000018042BC50
		remove; // 0x000000018042BC50-0x000000018042BD80
	}
	public static event Action<float> OnMasterVolumeChanged {
		add; // 0x000000018042BD80-0x000000018042BEC0
		remove; // 0x000000018042BEC0-0x000000018042C000
	}

	// Methods
	public static void NotifySFXVolumeChanged(float newVolume); // 0x000000018042C000-0x000000018042C060
	public static void NotifyMasterVolumeChanged(float newVolume); // 0x000000018042C060-0x000000018042C0D0
}

