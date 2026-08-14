namespace UnityEngine.InputForUI;

internal interface IEventProviderImpl
{

	public void Initialize() { }

	public void OnFocusChanged(bool focus) { }

	public void Shutdown() { }

	public void Update() { }

}

