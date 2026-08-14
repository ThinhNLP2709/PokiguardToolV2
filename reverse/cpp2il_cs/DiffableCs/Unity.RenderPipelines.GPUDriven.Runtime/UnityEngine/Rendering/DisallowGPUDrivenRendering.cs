namespace UnityEngine.Rendering;

[ExecuteInEditMode]
internal class DisallowGPUDrivenRendering : MonoBehaviour
{
	private bool m_AppliedRecursively; //Field offset: 0x20
	[FormerlySerializedAs("applyToChildrenRecursively")]
	public bool m_applyToChildrenRecursively; //Field offset: 0x21

	public bool applyToChildrenRecursively
	{
		 get { } //Length: 5
		 set { } //Length: 34
	}

	public DisallowGPUDrivenRendering() { }

	private static void AllowGPUDrivenRendering(Transform transform, bool allow) { }

	private static void AllowGPUDrivenRenderingRecursively(Transform transform, bool allow) { }

	public bool get_applyToChildrenRecursively() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnValidate() { }

	public void set_applyToChildrenRecursively(bool value) { }

}

