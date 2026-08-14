namespace UnityEngine.AddressableAssets;

public class AssetReference : IKeyEvaluator
{
	[FormerlySerializedAs("m_assetGUID")]
	[SerializeField]
	protected private string m_AssetGUID; //Field offset: 0x10
	[SerializeField]
	private string m_SubObjectName; //Field offset: 0x18
	[SerializeField]
	private string m_SubObjectType; //Field offset: 0x20
	private AsyncOperationHandle m_Operation; //Field offset: 0x28

	public override object Asset
	{
		 get { } //Length: 147
	}

	public override string AssetGUID
	{
		 get { } //Length: 5
	}

	public bool IsDone
	{
		 get { } //Length: 11
	}

	public internal AsyncOperationHandle OperationHandle
	{
		 get { } //Length: 21
		internal set { } //Length: 28
	}

	public override object RuntimeKey
	{
		 get { } //Length: 126
	}

	public override string SubObjectName
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	internal override Type SubObjectType
	{
		internal get { } //Length: 131
	}

	public AssetReference(string guid) { }

	public AssetReference() { }

	private static AsyncOperationHandle<T> CreateFailedOperation() { }

	public override object get_Asset() { }

	public override string get_AssetGUID() { }

	public bool get_IsDone() { }

	public AsyncOperationHandle get_OperationHandle() { }

	public override object get_RuntimeKey() { }

	public override string get_SubObjectName() { }

	internal override Type get_SubObjectType() { }

	public override AsyncOperationHandle<GameObject> InstantiateAsync(Transform parent = null, bool instantiateInWorldSpace = false) { }

	public override AsyncOperationHandle<GameObject> InstantiateAsync(Vector3 position, Quaternion rotation, Transform parent = null) { }

	public bool IsValid() { }

	public override AsyncOperationHandle<TObject> LoadAssetAsync() { }

	public override AsyncOperationHandle<SceneInstance> LoadSceneAsync(LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100) { }

	public override void ReleaseAsset() { }

	public override void ReleaseInstance(GameObject obj) { }

	public override bool RuntimeKeyIsValid() { }

	internal void set_OperationHandle(AsyncOperationHandle value) { }

	public override void set_SubObjectName(string value) { }

	public virtual string ToString() { }

	public override AsyncOperationHandle<SceneInstance> UnLoadScene() { }

	public override bool ValidateAsset(object obj) { }

	public override bool ValidateAsset(string path) { }

}

