namespace UnityEngine.Rendering;

public class RenderPipelineGraphicsSettingsContainer : ISerializationCallbackReceiver
{
	[HideInInspector]
	[SerializeField]
	private RenderPipelineGraphicsSettingsCollection m_RuntimeSettings; //Field offset: 0x10

	public List<IRenderPipelineGraphicsSettings> settingsList
	{
		 get { } //Length: 27
	}

	public RenderPipelineGraphicsSettingsContainer() { }

	public List<IRenderPipelineGraphicsSettings> get_settingsList() { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

}

