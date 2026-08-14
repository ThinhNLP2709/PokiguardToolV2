namespace Unity.Properties;

public static class PropertyBag
{

	public static void AcceptWithSpecializedVisitor(IPropertyBag<TContainer> properties, IPropertyBagVisitor visitor, ref TContainer container) { }

	public static IPropertyBag GetPropertyBag(Type type) { }

	public static IPropertyBag<TContainer> GetPropertyBag() { }

	public static void Register(PropertyBag<TContainer> propertyBag) { }

	public static void RegisterList() { }

	public static void RegisterList() { }

	public static bool TryGetPropertyBagForValue(ref TValue value, out IPropertyBag propertyBag) { }

}

