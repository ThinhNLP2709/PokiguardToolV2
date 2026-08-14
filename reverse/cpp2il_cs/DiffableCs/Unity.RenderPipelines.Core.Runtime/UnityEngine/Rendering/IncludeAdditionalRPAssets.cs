namespace UnityEngine.Rendering;

[CategoryInfo(Name = "H: RP Assets Inclusion", Order = 990)]
[HideInInspector]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public class IncludeAdditionalRPAssets : IRenderPipelineGraphicsSettings
{
	private enum Version
	{
		Initial = 0,
		Count = 1,
		Last = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_version; //Field offset: 0x10
	[SerializeField]
	private bool m_IncludeReferencedInScenes; //Field offset: 0x14
	[SerializeField]
	private bool m_IncludeAssetsByLabel; //Field offset: 0x15
	[SerializeField]
	private string m_LabelToInclude; //Field offset: 0x18

	public bool includeAssetsByLabel
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public bool includeReferencedInScenes
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public string labelToInclude
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.version
	{
		private get { } //Length: 4
	}

	public IncludeAdditionalRPAssets() { }

	public bool get_includeAssetsByLabel() { }

	public bool get_includeReferencedInScenes() { }

	public string get_labelToInclude() { }

	public void set_includeAssetsByLabel(bool value) { }

	public void set_includeReferencedInScenes(bool value) { }

	public void set_labelToInclude(string value) { }

	private override int UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_version() { }

}

