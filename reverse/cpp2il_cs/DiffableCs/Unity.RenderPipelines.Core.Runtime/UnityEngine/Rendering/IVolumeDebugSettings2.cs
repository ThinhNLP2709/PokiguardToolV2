namespace UnityEngine.Rendering;

[Obsolete("This variant is obsolete and kept only for not breaking user code. Use IVolumeDebugSettings instead. #from(23.2) (UnityUpgradable) -> IVolumeDebugSettings", False)]
public interface IVolumeDebugSettings2 : IVolumeDebugSettings
{

	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", False)]
	public Type targetRenderPipeline
	{
		 get { } //Length: 0
	}

	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", False)]
	public List<ValueTuple`2<String, Type>> volumeComponentsPathAndType
	{
		 get { } //Length: 0
	}

	public Type get_targetRenderPipeline() { }

	public List<ValueTuple`2<String, Type>> get_volumeComponentsPathAndType() { }

}

