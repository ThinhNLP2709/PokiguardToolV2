namespace UnityEngine.Rendering;

[ExecuteInEditMode]
internal class DisallowSmallMeshCulling : MonoBehaviour
{
	private bool m_AppliedRecursively; //Field offset: 0x20
	public bool m_applyToChildrenRecursively; //Field offset: 0x21

	public bool applyToChildrenRecursively
	{
		 get { } //Length: 5
		 set { } //Length: 34
	}

	public DisallowSmallMeshCulling() { }

	private static void AllowSmallMeshCulling(Transform transform, bool allow) { }

	private static void AllowSmallMeshCullingRecursively(Transform transform, bool allow) { }

	public bool get_applyToChildrenRecursively() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnValidate() { }

	public void set_applyToChildrenRecursively(bool value) { }

}

