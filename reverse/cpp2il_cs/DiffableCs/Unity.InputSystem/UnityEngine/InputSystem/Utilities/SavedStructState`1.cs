namespace UnityEngine.InputSystem.Utilities;

internal sealed class SavedStructState : ISavedState
{
	internal sealed class TypedRestore : MulticastDelegate
	{

		public TypedRestore(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref T state, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref T state, IAsyncResult result) { }

		public override void Invoke(ref T state) { }

	}

	private T m_State; //Field offset: 0x0
	private TypedRestore<T> m_RestoreAction; //Field offset: 0x0
	private Action m_StaticDisposeCurrentState; //Field offset: 0x0

	internal SavedStructState`1(ref T state, TypedRestore<T> restoreAction, Action staticDisposeCurrentState = null) { }

	public override void RestoreSavedState() { }

	public override void StaticDisposeCurrentState() { }

}

