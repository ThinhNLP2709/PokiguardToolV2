namespace UnityEngine.Rendering.UI;

[ExecuteAlways]
public class UIFoldout : Toggle
{
	public GameObject content; //Field offset: 0x128
	public GameObject arrowOpened; //Field offset: 0x130
	public GameObject arrowClosed; //Field offset: 0x138

	public UIFoldout() { }

	private void OnValidate() { }

	public void SetState(bool state) { }

	public void SetState(bool state, bool rebuildLayout) { }

	protected virtual void Start() { }

}

