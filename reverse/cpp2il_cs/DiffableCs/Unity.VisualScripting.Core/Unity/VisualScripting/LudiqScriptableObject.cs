namespace Unity.VisualScripting;

public abstract class LudiqScriptableObject : ScriptableObject, ISerializationCallbackReceiver
{
	[DoNotSerialize]
	[SerializeField]
	protected SerializationData _data; //Field offset: 0x18
	[CompilerGenerated]
	private Action OnDestroyActions; //Field offset: 0x28

	internal event Action OnDestroyActions
	{
		[CompilerGenerated]
		internal add { } //Length: 158
		[CompilerGenerated]
		internal remove { } //Length: 158
	}

	protected LudiqScriptableObject() { }

	[CompilerGenerated]
	internal void add_OnDestroyActions(Action value) { }

	protected override void OnAfterDeserialize() { }

	protected override void OnAfterSerialize() { }

	protected override void OnBeforeDeserialize() { }

	protected override void OnBeforeSerialize() { }

	private void OnDestroy() { }

	protected override void OnPostDeserializeInEditor() { }

	[CompilerGenerated]
	internal void remove_OnDestroyActions(Action value) { }

	protected override void ShowData() { }

	public virtual string ToString() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

