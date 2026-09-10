/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class AudioEventManager // TypeDefIndex: 544
{
	// Fields
	[CompilerGenerated]
	private static Action<float> OnSFXVolumeChanged; // 0x00
	[CompilerGenerated]
	private static Action<float> OnMasterVolumeChanged; // 0x08

	// Events
	public static event Action<float> OnSFXVolumeChanged {
		add; // 0x00000001803C39A0-0x00000001803C3A70
		remove; // 0x00000001803C3B50-0x00000001803C3C20
	}
	public static event Action<float> OnMasterVolumeChanged {
		add; // 0x00000001803C38C0-0x00000001803C39A0
		remove; // 0x00000001803C3A70-0x00000001803C3B50
	}

	// Methods
	public static void NotifySFXVolumeChanged(float newVolume); // 0x00000001803C3860-0x00000001803C38C0
	public static void NotifyMasterVolumeChanged(float newVolume); // 0x00000001803C3800-0x00000001803C3860
}

