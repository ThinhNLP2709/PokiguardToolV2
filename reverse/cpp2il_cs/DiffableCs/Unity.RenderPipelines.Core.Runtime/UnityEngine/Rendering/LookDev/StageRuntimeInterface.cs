namespace UnityEngine.Rendering.LookDev;

public class StageRuntimeInterface
{
	private Func<Boolean, GameObject> m_AddGameObject; //Field offset: 0x10
	private Func<Camera> m_GetCamera; //Field offset: 0x18
	private Func<Light> m_GetSunLight; //Field offset: 0x20
	public object SRPData; //Field offset: 0x28

	public Camera camera
	{
		 get { } //Length: 27
	}

	public Light sunLight
	{
		 get { } //Length: 27
	}

	public StageRuntimeInterface(Func<Boolean, GameObject> AddGameObject, Func<Camera> GetCamera, Func<Light> GetSunLight) { }

	public GameObject AddGameObject(bool persistent = false) { }

	public Camera get_camera() { }

	public Light get_sunLight() { }

}

