namespace UnityEngine.Rendering.LookDev;

public interface IDataProvider
{

	public IEnumerable<String> supportedDebugModes
	{
		 get { } //Length: 0
	}

	public void Cleanup(StageRuntimeInterface SRI) { }

	public void FirstInitScene(StageRuntimeInterface stage) { }

	public IEnumerable<String> get_supportedDebugModes() { }

	public void GetShadowMask(ref RenderTexture output, StageRuntimeInterface stage) { }

	public void OnBeginRendering(StageRuntimeInterface stage) { }

	public void OnEndRendering(StageRuntimeInterface stage) { }

	public void UpdateDebugMode(int debugIndex) { }

	public void UpdateSky(Camera camera, Sky sky, StageRuntimeInterface stage) { }

}

