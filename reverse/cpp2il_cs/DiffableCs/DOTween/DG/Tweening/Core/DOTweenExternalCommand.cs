namespace DG.Tweening.Core;

public static class DOTweenExternalCommand
{
	[CompilerGenerated]
	private static Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath; //Field offset: 0x0

	public static event Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath
	{
		[CompilerGenerated]
		 add { } //Length: 215
		[CompilerGenerated]
		 remove { } //Length: 215
	}

	[CompilerGenerated]
	public static void add_SetOrientationOnPath(Action<PathOptions, Tween, Quaternion, Transform> value) { }

	internal static void Dispatch_SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans) { }

	[CompilerGenerated]
	public static void remove_SetOrientationOnPath(Action<PathOptions, Tween, Quaternion, Transform> value) { }

}

