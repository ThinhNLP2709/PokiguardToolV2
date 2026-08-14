namespace UnityEngine;

[NativeHeader("Modules/Animation/ScriptBindings/AnimationClip.bindings.h")]
[NativeType("Modules/Animation/AnimationClip.h")]
public sealed class AnimationClip : Motion
{

	public AnimationClip() { }

	[FreeFunction("AnimationClipBindings::Internal_CreateAnimationClip")]
	private static void Internal_CreateAnimationClip(AnimationClip self) { }

}

