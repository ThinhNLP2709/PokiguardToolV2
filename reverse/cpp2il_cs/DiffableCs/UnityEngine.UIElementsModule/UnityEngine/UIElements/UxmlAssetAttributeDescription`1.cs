namespace UnityEngine.UIElements;

public class UxmlAssetAttributeDescription : TypedUxmlAttributeDescription<T>
{

	public UxmlAssetAttributeDescription`1() { }

	public virtual T GetValueFromBag(IUxmlAttributes bag, CreationContext cc) { }

	public bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, out T value) { }

}

