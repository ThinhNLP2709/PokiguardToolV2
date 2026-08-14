//Type is in global namespace

public static class AudioEventManager
{
	[CompilerGenerated]
	private static Action<Single> OnSFXVolumeChanged; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Single> OnMasterVolumeChanged; //Field offset: 0x8

	public static event Action<Single> OnMasterVolumeChanged
	{
		[CompilerGenerated]
		 add { } //Length: 223
		[CompilerGenerated]
		 remove { } //Length: 223
	}

	public static event Action<Single> OnSFXVolumeChanged
	{
		[CompilerGenerated]
		 add { } //Length: 215
		[CompilerGenerated]
		 remove { } //Length: 215
	}

	[CompilerGenerated]
	public static void add_OnMasterVolumeChanged(Action<Single> value) { }

	[CompilerGenerated]
	public static void add_OnSFXVolumeChanged(Action<Single> value) { }

	public static void NotifyMasterVolumeChanged(float newVolume) { }

	public static void NotifySFXVolumeChanged(float newVolume) { }

	[CompilerGenerated]
	public static void remove_OnMasterVolumeChanged(Action<Single> value) { }

	[CompilerGenerated]
	public static void remove_OnSFXVolumeChanged(Action<Single> value) { }

}

