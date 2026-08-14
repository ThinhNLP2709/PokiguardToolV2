namespace UnityEngine.InputSystem.Utilities;

[DefaultMember("Item")]
internal struct CallbackArray
{
	private bool m_CannotMutateCallbacksArray; //Field offset: 0x0
	private InlinedArray<TDelegate> m_Callbacks; //Field offset: 0x0
	private InlinedArray<TDelegate> m_CallbacksToAdd; //Field offset: 0x0
	private InlinedArray<TDelegate> m_CallbacksToRemove; //Field offset: 0x0

	public TDelegate Item
	{
		 get { } //Length: 68
	}

	public int length
	{
		 get { } //Length: 4
	}

	public void AddCallback(TDelegate dlg) { }

	public void Clear() { }

	public TDelegate get_Item(int index) { }

	public int get_length() { }

	public void LockForChanges() { }

	public void RemoveCallback(TDelegate dlg) { }

	public void UnlockForChanges() { }

}

