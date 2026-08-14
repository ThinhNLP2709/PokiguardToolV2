namespace UnityEngine.Experimental.Rendering;

public class XRLayout
{
	private readonly List<ValueTuple`2<Camera, XRPass>> m_ActivePasses; //Field offset: 0x10

	public XRLayout() { }

	public void AddCamera(Camera camera, bool enableXR) { }

	internal void AddPass(Camera camera, XRPass xrPass) { }

	internal void Clear() { }

	public List<ValueTuple`2<Camera, XRPass>> GetActivePasses() { }

	internal void LogDebugInfo() { }

	public void ReconfigurePass(XRPass xrPass, Camera camera) { }

}

