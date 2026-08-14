namespace Unity.VisualScripting;

public abstract class LudiqBehaviour : MonoBehaviour, ISerializationCallbackReceiver
{
	[DoNotSerialize]
	[SerializeField]
	protected SerializationData _data; //Field offset: 0x20

	protected LudiqBehaviour() { }

	protected override void OnAfterDeserialize() { }

	protected override void OnAfterSerialize() { }

	protected override void OnBeforeDeserialize() { }

	protected override void OnBeforeSerialize() { }

	protected override void ShowData() { }

	public virtual string ToString() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

