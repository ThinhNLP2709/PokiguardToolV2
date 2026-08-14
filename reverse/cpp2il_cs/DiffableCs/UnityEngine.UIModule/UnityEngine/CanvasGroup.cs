namespace UnityEngine;

[NativeClass("UI::CanvasGroup")]
[NativeHeader("Modules/UI/CanvasGroup.h")]
public sealed class CanvasGroup : Behaviour, ICanvasRaycastFilter
{

	[NativeProperty("Alpha", False, TargetType::Function (0))]
	public float alpha
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	[NativeProperty("BlocksRaycasts", False, TargetType::Function (0))]
	public bool blocksRaycasts
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	[NativeProperty("IgnoreParentGroups", False, TargetType::Function (0))]
	public bool ignoreParentGroups
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	[NativeProperty("Interactable", False, TargetType::Function (0))]
	public bool interactable
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public float get_alpha() { }

	private static float get_alpha_Injected(IntPtr _unity_self) { }

	public bool get_blocksRaycasts() { }

	private static bool get_blocksRaycasts_Injected(IntPtr _unity_self) { }

	public bool get_ignoreParentGroups() { }

	private static bool get_ignoreParentGroups_Injected(IntPtr _unity_self) { }

	public bool get_interactable() { }

	private static bool get_interactable_Injected(IntPtr _unity_self) { }

	public override bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera) { }

	public void set_alpha(float value) { }

	private static void set_alpha_Injected(IntPtr _unity_self, float value) { }

	public void set_blocksRaycasts(bool value) { }

	private static void set_blocksRaycasts_Injected(IntPtr _unity_self, bool value) { }

	public void set_ignoreParentGroups(bool value) { }

	private static void set_ignoreParentGroups_Injected(IntPtr _unity_self, bool value) { }

	public void set_interactable(bool value) { }

	private static void set_interactable_Injected(IntPtr _unity_self, bool value) { }

}

