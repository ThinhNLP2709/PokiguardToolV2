namespace UnityEngine.ResourceManagement.ResourceProviders;

public struct SceneInstance
{
	private Scene m_Scene; //Field offset: 0x0
	private bool m_ReleaseOnSceneUnloaded; //Field offset: 0x4
	internal AsyncOperation m_Operation; //Field offset: 0x8

	internal bool ReleaseSceneOnSceneUnloaded
	{
		internal get { } //Length: 5
		internal set { } //Length: 4
	}

	public internal Scene Scene
	{
		 get { } //Length: 3
		internal set { } //Length: 3
	}

	public AsyncOperation ActivateAsync() { }

	public virtual bool Equals(object obj) { }

	internal bool get_ReleaseSceneOnSceneUnloaded() { }

	public Scene get_Scene() { }

	public virtual int GetHashCode() { }

	internal void set_ReleaseSceneOnSceneUnloaded(bool value) { }

	internal void set_Scene(Scene value) { }

}

