namespace UnityEngine;

[DefaultMember("Item")]
[NativeHeader("Modules/Animation/AnimatorOverrideController.h")]
[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
[UsedByNativeCode]
public class AnimatorOverrideController : RuntimeAnimatorController
{
	public sealed class OnOverrideControllerDirtyCallback : MulticastDelegate
	{

		public OnOverrideControllerDirtyCallback(object object, IntPtr method) { }

		public override void Invoke() { }

	}

	internal OnOverrideControllerDirtyCallback OnOverrideControllerDirty; //Field offset: 0x18

	public string Item
	{
		 set { } //Length: 8
	}

	public AnimationClip Item
	{
		 set { } //Length: 242
	}

	public RuntimeAnimatorController runtimeAnimatorController
	{
		[NativeMethod("GetAnimatorController")]
		 get { } //Length: 144
	}

	public AnimatorOverrideController(RuntimeAnimatorController controller) { }

	[NativeMethod("GetAnimatorController")]
	public RuntimeAnimatorController get_runtimeAnimatorController() { }

	private static IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self) { }

	[FreeFunction("AnimationBindings::CreateAnimatorOverrideController")]
	private static void Internal_Create(AnimatorOverrideController self, RuntimeAnimatorController controller) { }

	private static void Internal_Create_Injected(AnimatorOverrideController self, IntPtr controller) { }

	[NativeMethod("SetClip")]
	private void Internal_SetClipByName(string name, AnimationClip clip) { }

	private static void Internal_SetClipByName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, IntPtr clip) { }

	[NativeConditional("UNITY_EDITOR")]
	[RequiredByNativeCode]
	internal static void OnInvalidateOverrideController(AnimatorOverrideController controller) { }

	public void set_Item(string name, AnimationClip value) { }

	public void set_Item(AnimationClip clip, AnimationClip value) { }

	private void SetClip(AnimationClip originalClip, AnimationClip overrideClip, bool notify) { }

	private static void SetClip_Injected(IntPtr _unity_self, IntPtr originalClip, IntPtr overrideClip, bool notify) { }

}

