namespace UnityEngine.Rendering;

[Obsolete("This class is no longer necessary for APV implementation.")]
public class ProbeVolumeSceneData
{
	internal object parentAsset; //Field offset: 0x10
	[FormerlySerializedAs("sceneBounds")]
	[Obsolete("This data is now serialized directly in the baking set asset")]
	[SerializeField]
	internal SerializedDictionary<String, Bounds> obsoleteSceneBounds; //Field offset: 0x18
	[FormerlySerializedAs("hasProbeVolumes")]
	[Obsolete("This data is now serialized directly in the baking set asset")]
	[SerializeField]
	internal SerializedDictionary<String, Boolean> obsoleteHasProbeVolumes; //Field offset: 0x20

	public ProbeVolumeSceneData(object parentAsset) { }

	[Obsolete]
	public void SetParentObject(object parent) { }

}

