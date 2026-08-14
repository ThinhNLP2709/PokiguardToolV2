namespace UnityEngine.InputSystem;

public struct InputActionProperty : IEquatable<InputActionProperty>, IEquatable<InputAction>, IEquatable<InputActionReference>
{
	[SerializeField]
	private bool m_UseReference; //Field offset: 0x0
	[SerializeField]
	private InputAction m_Action; //Field offset: 0x8
	[SerializeField]
	private InputActionReference m_Reference; //Field offset: 0x10

	public InputAction action
	{
		 get { } //Length: 138
	}

	public InputActionReference reference
	{
		 get { } //Length: 13
	}

	internal InputAction serializedAction
	{
		internal get { } //Length: 5
	}

	internal InputActionReference serializedReference
	{
		internal get { } //Length: 5
	}

	public InputActionProperty(InputAction action) { }

	public InputActionProperty(InputActionReference reference) { }

	public override bool Equals(InputActionProperty other) { }

	public override bool Equals(InputAction other) { }

	public override bool Equals(InputActionReference other) { }

	public virtual bool Equals(object obj) { }

	public InputAction get_action() { }

	public InputActionReference get_reference() { }

	internal InputAction get_serializedAction() { }

	internal InputActionReference get_serializedReference() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(InputActionProperty left, InputActionProperty right) { }

	public static bool op_Inequality(InputActionProperty left, InputActionProperty right) { }

}

