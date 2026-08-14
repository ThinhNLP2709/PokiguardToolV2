namespace UnityEngine.Rendering;

public class RenderPipelineGraphicsSettingsCollection
{
	[SerializeReference]
	private List<IRenderPipelineGraphicsSettings> m_List; //Field offset: 0x10

	public List<IRenderPipelineGraphicsSettings> settingsList
	{
		 get { } //Length: 5
	}

	public RenderPipelineGraphicsSettingsCollection() { }

	public List<IRenderPipelineGraphicsSettings> get_settingsList() { }

}

