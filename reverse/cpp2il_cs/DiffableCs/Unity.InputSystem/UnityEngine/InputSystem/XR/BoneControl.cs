namespace UnityEngine.InputSystem.XR;

public class BoneControl : InputControl<Bone>
{
	[CompilerGenerated]
	private IntegerControl <parentBoneIndex>k__BackingField; //Field offset: 0x140
	[CompilerGenerated]
	private Vector3Control <position>k__BackingField; //Field offset: 0x148
	[CompilerGenerated]
	private QuaternionControl <rotation>k__BackingField; //Field offset: 0x150

	[InputControl(offset = 0, displayName = "parentBoneIndex")]
	public IntegerControl parentBoneIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 4, displayName = "Position")]
	public Vector3Control position
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 16, displayName = "Rotation")]
	public QuaternionControl rotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public BoneControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public IntegerControl get_parentBoneIndex() { }

	[CompilerGenerated]
	public Vector3Control get_position() { }

	[CompilerGenerated]
	public QuaternionControl get_rotation() { }

	public virtual Bone ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_parentBoneIndex(IntegerControl value) { }

	[CompilerGenerated]
	public void set_position(Vector3Control value) { }

	[CompilerGenerated]
	public void set_rotation(QuaternionControl value) { }

	public virtual void WriteValueIntoState(Bone value, Void* statePtr) { }

}

