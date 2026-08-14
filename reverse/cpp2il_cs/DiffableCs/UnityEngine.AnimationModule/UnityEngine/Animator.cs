namespace UnityEngine;

[NativeHeader("Modules/Animation/Animator.h")]
[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
[UsedByNativeCode]
public class Animator : Behaviour
{

	public AnimatorCullingMode cullingMode
	{
		 set { } //Length: 131
	}

	public bool hasBoundPlayables
	{
		[NativeMethod("HasBoundPlayables")]
		 get { } //Length: 118
	}

	public AnimatorControllerParameter[] parameters
	{
		[FreeFunction(Name = "AnimatorBindings::GetParameters", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	public RuntimeAnimatorController runtimeAnimatorController
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	public AnimatorUpdateMode updateMode
	{
		 set { } //Length: 131
	}

	[NativeMethod("HasBoundPlayables")]
	public bool get_hasBoundPlayables() { }

	private static bool get_hasBoundPlayables_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "AnimatorBindings::GetParameters", HasExplicitThis = True)]
	public AnimatorControllerParameter[] get_parameters() { }

	private static AnimatorControllerParameter[] get_parameters_Injected(IntPtr _unity_self) { }

	public RuntimeAnimatorController get_runtimeAnimatorController() { }

	private static IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self) { }

	private void GetAnimatorStateInfo(int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info) { }

	private static void GetAnimatorStateInfo_Injected(IntPtr _unity_self, int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info) { }

	public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex) { }

	public int GetInteger(string name) { }

	[FreeFunction(Name = "AnimatorBindings::GetIntegerString", HasExplicitThis = True)]
	private int GetIntegerString(string name) { }

	private static int GetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	public bool IsInTransition(int layerIndex) { }

	private static bool IsInTransition_Injected(IntPtr _unity_self, int layerIndex) { }

	public void Play(string stateName) { }

	public void Play(string stateName, int layer, float normalizedTime) { }

	[FreeFunction(Name = "AnimatorBindings::Play", HasExplicitThis = True)]
	public void Play(int stateNameHash, int layer, float normalizedTime) { }

	private static void Play_Injected(IntPtr _unity_self, int stateNameHash, int layer, float normalizedTime) { }

	private void Rebind(bool writeDefaultValues) { }

	public void Rebind() { }

	private static void Rebind_Injected(IntPtr _unity_self, bool writeDefaultValues) { }

	public void ResetTrigger(string name) { }

	[FreeFunction(Name = "AnimatorBindings::ResetTriggerString", HasExplicitThis = True)]
	private void ResetTriggerString(string name) { }

	private static void ResetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	public void set_cullingMode(AnimatorCullingMode value) { }

	private static void set_cullingMode_Injected(IntPtr _unity_self, AnimatorCullingMode value) { }

	public void set_runtimeAnimatorController(RuntimeAnimatorController value) { }

	private static void set_runtimeAnimatorController_Injected(IntPtr _unity_self, IntPtr value) { }

	public void set_updateMode(AnimatorUpdateMode value) { }

	private static void set_updateMode_Injected(IntPtr _unity_self, AnimatorUpdateMode value) { }

	public void SetInteger(string name, int value) { }

	[FreeFunction(Name = "AnimatorBindings::SetIntegerString", HasExplicitThis = True)]
	private void SetIntegerString(string name, int value) { }

	private static void SetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int value) { }

	public void SetTrigger(string name) { }

	[FreeFunction(Name = "AnimatorBindings::SetTriggerString", HasExplicitThis = True)]
	private void SetTriggerString(string name) { }

	private static void SetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name) { }

	[NativeMethod(Name = "ScriptingStringToCRC32", IsThreadSafe = True)]
	public static int StringToHash(string name) { }

	private static int StringToHash_Injected(ref ManagedSpanWrapper name) { }

	[NativeMethod("UpdateWithDelta")]
	public void Update(float deltaTime) { }

	private static void Update_Injected(IntPtr _unity_self, float deltaTime) { }

}

