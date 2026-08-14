namespace UnityEngine.InputSystem;

public interface IInputActionCollection : IEnumerable<InputAction>, IEnumerable
{

	public Nullable<InputBinding> bindingMask
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes
	{
		 get { } //Length: 0
	}

	public Nullable<ReadOnlyArray`1<InputDevice>> devices
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool Contains(InputAction action) { }

	public void Disable() { }

	public void Enable() { }

	public Nullable<InputBinding> get_bindingMask() { }

	public ReadOnlyArray<InputControlScheme> get_controlSchemes() { }

	public Nullable<ReadOnlyArray`1<InputDevice>> get_devices() { }

	public void set_bindingMask(Nullable<InputBinding> value) { }

	public void set_devices(Nullable<ReadOnlyArray`1<InputDevice>> value) { }

}

