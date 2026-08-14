namespace UnityEngine.U2D.Animation;

[AddComponentMenu(null)]
[DefaultExecutionOrder(10)]
[ExecuteInEditMode]
internal class DeformationManagerUpdater : MonoBehaviour
{
	[CompilerGenerated]
	private Action<GameObject> <onDestroyingComponent>k__BackingField; //Field offset: 0x20
	private ProfilerMarker m_ProfilerMarker; //Field offset: 0x28

	public Action<GameObject> onDestroyingComponent
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public DeformationManagerUpdater() { }

	[CompilerGenerated]
	public Action<GameObject> get_onDestroyingComponent() { }

	private void LateUpdate() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void set_onDestroyingComponent(Action<GameObject> value) { }

}

