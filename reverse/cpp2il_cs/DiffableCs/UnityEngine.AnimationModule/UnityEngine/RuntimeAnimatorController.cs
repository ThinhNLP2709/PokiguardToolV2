namespace UnityEngine;

[ExcludeFromObjectFactory]
[NativeHeader("Modules/Animation/RuntimeAnimatorController.h")]
[UsedByNativeCode]
public class RuntimeAnimatorController : object
{

	public AnimationClip[] animationClips
	{
		 get { } //Length: 469
	}

	protected RuntimeAnimatorController() { }

	public AnimationClip[] get_animationClips() { }

	private static AnimationClip[] get_animationClips_Injected(IntPtr _unity_self) { }

}

