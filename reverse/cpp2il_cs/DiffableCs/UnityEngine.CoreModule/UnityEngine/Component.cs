namespace UnityEngine;

[NativeClass("Unity::Component")]
[NativeHeader("Runtime/Export/Scripting/Component.bindings.h")]
[RequiredByNativeCode]
public class Component : object
{

	public GameObject gameObject
	{
		[FreeFunction("GetGameObject", HasExplicitThis = True)]
		 get { } //Length: 144
	}

	public Transform transform
	{
		[FreeFunction("GetTransform", HasExplicitThis = True, ThrowsException = True)]
		 get { } //Length: 144
	}

	public Component() { }

	[FreeFunction("BroadcastMessage", HasExplicitThis = True)]
	public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) { }

	private static void BroadcastMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object parameter, SendMessageOptions options) { }

	[FreeFunction("GetGameObject", HasExplicitThis = True)]
	public GameObject get_gameObject() { }

	private static IntPtr get_gameObject_Injected(IntPtr _unity_self) { }

	[FreeFunction("GetTransform", HasExplicitThis = True, ThrowsException = True)]
	public Transform get_transform() { }

	private static IntPtr get_transform_Injected(IntPtr _unity_self) { }

	public T GetComponent() { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponent(Type type) { }

	[FreeFunction(HasExplicitThis = True, ThrowsException = True)]
	internal void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue) { }

	private static void GetComponentFastPath_Injected(IntPtr _unity_self, Type type, IntPtr oneFurtherThanResultValue) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInChildren(Type t, bool includeInactive) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInChildren(Type t) { }

	public T GetComponentInChildren(bool includeInactive) { }

	[ExcludeFromDocs]
	public T GetComponentInChildren() { }

	public T GetComponentInParent() { }

	public T GetComponentInParent(bool includeInactive) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInParent(Type t) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInParent(Type t, bool includeInactive) { }

	public Component[] GetComponents(Type type) { }

	public void GetComponents(Type type, List<Component> results) { }

	public void GetComponents(List<T> results) { }

	public T[] GetComponents() { }

	[FreeFunction(HasExplicitThis = True, ThrowsException = True)]
	private void GetComponentsForListInternal(Type searchType, object resultList) { }

	private static void GetComponentsForListInternal_Injected(IntPtr _unity_self, Type searchType, object resultList) { }

	public void GetComponentsInChildren(List<T> results) { }

	public T[] GetComponentsInChildren() { }

	public void GetComponentsInChildren(bool includeInactive, List<T> result) { }

	public T[] GetComponentsInChildren(bool includeInactive) { }

	[ExcludeFromDocs]
	public Component[] GetComponentsInChildren(Type t) { }

	public T[] GetComponentsInParent(bool includeInactive) { }

	public T[] GetComponentsInParent() { }

	public void GetComponentsInParent(bool includeInactive, List<T> results) { }

	[ExcludeFromDocs]
	public Component[] GetComponentsInParent(Type t) { }

	public Component[] GetComponentsInParent(Type t, bool includeInactive) { }

	[FreeFunction("SendMessage", HasExplicitThis = True)]
	public void SendMessage(string methodName, object value, SendMessageOptions options) { }

	private static void SendMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object value, SendMessageOptions options) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public bool TryGetComponent(Type type, out Component component) { }

	public bool TryGetComponent(out T component) { }

}

