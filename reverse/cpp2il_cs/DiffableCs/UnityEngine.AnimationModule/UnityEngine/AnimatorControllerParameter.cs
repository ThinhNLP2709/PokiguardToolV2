namespace UnityEngine;

[NativeAsStruct]
[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
[NativeHeader("Modules/Animation/AnimatorControllerParameter.h")]
[NativeType(CodegenOptions::Custom (1), "MonoAnimatorControllerParameter")]
[UsedByNativeCode]
public class AnimatorControllerParameter
{
	internal string m_Name; //Field offset: 0x10
	internal AnimatorControllerParameterType m_Type; //Field offset: 0x18
	internal float m_DefaultFloat; //Field offset: 0x1C
	internal int m_DefaultInt; //Field offset: 0x20
	internal bool m_DefaultBool; //Field offset: 0x24

	public string name
	{
		 get { } //Length: 7
	}

	public AnimatorControllerParameterType type
	{
		 get { } //Length: 6
	}

	public AnimatorControllerParameter() { }

	public virtual bool Equals(object o) { }

	public string get_name() { }

	public AnimatorControllerParameterType get_type() { }

	public virtual int GetHashCode() { }

}

