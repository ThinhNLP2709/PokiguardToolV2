namespace UnityEngine.Rendering;

[AddComponentMenu(null)]
[ExecuteAlways]
public class ProbeVolumePerSceneData : MonoBehaviour
{
	public struct ObsoletePerScenarioData
	{
		public int sceneHash; //Field offset: 0x0
		public TextAsset cellDataAsset; //Field offset: 0x8
		public TextAsset cellOptionalDataAsset; //Field offset: 0x10

	}

	private struct ObsoleteSerializablePerScenarioDataItem
	{
		public string scenario; //Field offset: 0x0
		public ObsoletePerScenarioData data; //Field offset: 0x8

	}

	[FormerlySerializedAs("bakingSet")]
	[SerializeField]
	internal ProbeVolumeBakingSet serializedBakingSet; //Field offset: 0x20
	[SerializeField]
	internal string sceneGUID; //Field offset: 0x28
	[FormerlySerializedAs("asset")]
	[SerializeField]
	internal ObsoleteProbeVolumeAsset obsoleteAsset; //Field offset: 0x30
	[FormerlySerializedAs("cellSharedDataAsset")]
	[SerializeField]
	internal TextAsset obsoleteCellSharedDataAsset; //Field offset: 0x38
	[FormerlySerializedAs("cellSupportDataAsset")]
	[SerializeField]
	internal TextAsset obsoleteCellSupportDataAsset; //Field offset: 0x40
	[FormerlySerializedAs("serializedScenarios")]
	[SerializeField]
	private List<ObsoleteSerializablePerScenarioDataItem> obsoleteSerializedScenarios; //Field offset: 0x48

	public ProbeVolumeBakingSet bakingSet
	{
		 get { } //Length: 5
	}

	public ProbeVolumePerSceneData() { }

	internal void Clear() { }

	public ProbeVolumeBakingSet get_bakingSet() { }

	internal void Initialize() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnValidate() { }

	internal void QueueSceneLoading() { }

	internal void QueueSceneRemoval() { }

	internal bool ResolveCellData() { }

}

