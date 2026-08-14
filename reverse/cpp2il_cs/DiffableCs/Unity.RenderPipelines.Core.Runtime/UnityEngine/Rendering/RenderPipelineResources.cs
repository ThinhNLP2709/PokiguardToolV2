namespace UnityEngine.Rendering;

public abstract class RenderPipelineResources : ScriptableObject
{

	protected override string packagePath
	{
		 get { } //Length: 3
	}

	internal string packagePath_Internal
	{
		internal get { } //Length: 20
	}

	protected RenderPipelineResources() { }

	protected override string get_packagePath() { }

	internal string get_packagePath_Internal() { }

}

