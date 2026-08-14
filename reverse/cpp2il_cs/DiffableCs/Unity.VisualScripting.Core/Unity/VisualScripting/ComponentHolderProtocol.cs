namespace Unity.VisualScripting;

[Extension]
public static class ComponentHolderProtocol
{

	[Extension]
	public static T AddComponent(object uo) { }

	[Extension]
	public static GameObject GameObject(object uo) { }

	[Extension]
	public static T GetComponent(object uo) { }

	[Extension]
	public static Component GetComponent(object uo, Type type) { }

	[Extension]
	public static T GetComponentInChildren(object uo) { }

	[Extension]
	public static Component GetComponentInChildren(object uo, Type type) { }

	[Extension]
	public static Component GetComponentInParent(object uo, Type type) { }

	[Extension]
	public static T GetComponentInParent(object uo) { }

	[Extension]
	public static T[] GetComponents(object uo) { }

	[Extension]
	public static Component[] GetComponents(object uo, Type type) { }

	[Extension]
	public static Component[] GetComponentsInChildren(object uo, Type type) { }

	[Extension]
	public static T[] GetComponentsInChildren(object uo) { }

	[Extension]
	public static Component[] GetComponentsInParent(object uo, Type type) { }

	[Extension]
	public static T[] GetComponentsInParent(object uo) { }

	[Extension]
	public static T GetOrAddComponent(object uo) { }

	[Extension]
	public static bool IsComponentHolder(object uo) { }

	public static bool IsComponentHolderType(Type type) { }

}

