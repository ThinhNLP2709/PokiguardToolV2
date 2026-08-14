namespace Unity.VisualScripting.FullSerializer;

[UsedImplicitly]
public class InputAction_DirectConverter : fsDirectConverter<InputAction>
{

	public InputAction_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref InputAction model) { }

	protected virtual fsResult DoSerialize(InputAction model, Dictionary<String, fsData> serialized) { }

	public static InputAction MakeInputActionWithId(string actionId, string actionName, string expectedControlType, InputActionType type) { }

}

