namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Export/Scripting/GameObject.bindings.h")]
[UsedByNativeCode]
public sealed class GameObject : object
{

	public bool activeInHierarchy
	{
		[NativeMethod(Name = "IsActive")]
		 get { } //Length: 118
	}

	public bool activeSelf
	{
		[NativeMethod(Name = "IsSelfActive")]
		 get { } //Length: 118
	}

	public GameObject gameObject
	{
		 get { } //Length: 6
	}

	public bool isStatic
	{
		[NativeMethod(Name = "SetIsStaticDeprecated")]
		 set { } //Length: 134
	}

	public int layer
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public Scene scene
	{
		[FreeFunction("GameObjectBindings::GetScene", HasExplicitThis = True)]
		 get { } //Length: 135
	}

	public ulong sceneCullingMask
	{
		[FreeFunction(Name = "GameObjectBindings::GetSceneCullingMask", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	public string tag
	{
		[FreeFunction("GameObjectBindings::GetTag", HasExplicitThis = True)]
		 get { } //Length: 262
	}

	public Transform transform
	{
		[FreeFunction("GameObjectBindings::GetTransform", HasExplicitThis = True)]
		 get { } //Length: 144
	}

	public GameObject(string name, Type[] components) { }

	public GameObject(string name) { }

	public GameObject() { }

	public T AddComponent() { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component AddComponent(Type componentType) { }

	[FreeFunction(Name = "Scripting::BroadcastScriptingMessage", HasExplicitThis = True)]
	public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) { }

	[ExcludeFromDocs]
	public void BroadcastMessage(string methodName) { }

	private static void BroadcastMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object parameter, SendMessageOptions options) { }

	public bool CompareTag(string tag) { }

	[FreeFunction(Name = "GameObjectBindings::CompareTag", HasExplicitThis = True)]
	private bool CompareTag_Internal(string tag) { }

	private static bool CompareTag_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper tag) { }

	[FreeFunction("GameObjectBindings::CreatePrimitive")]
	public static GameObject CreatePrimitive(PrimitiveType type) { }

	private static IntPtr CreatePrimitive_Injected(PrimitiveType type) { }

	[FreeFunction(Name = "GameObjectBindings::Find")]
	public static GameObject Find(string name) { }

	private static IntPtr Find_Injected(ref ManagedSpanWrapper name) { }

	[FreeFunction(Name = "GameObjectBindings::FindGameObjectsWithTag", ThrowsException = True)]
	public static GameObject[] FindGameObjectsWithTag(string tag) { }

	private static GameObject[] FindGameObjectsWithTag_Injected(ref ManagedSpanWrapper tag) { }

	[NativeMethod(Name = "IsActive")]
	public bool get_activeInHierarchy() { }

	private static bool get_activeInHierarchy_Injected(IntPtr _unity_self) { }

	[NativeMethod(Name = "IsSelfActive")]
	public bool get_activeSelf() { }

	private static bool get_activeSelf_Injected(IntPtr _unity_self) { }

	public GameObject get_gameObject() { }

	public int get_layer() { }

	private static int get_layer_Injected(IntPtr _unity_self) { }

	[FreeFunction("GameObjectBindings::GetScene", HasExplicitThis = True)]
	public Scene get_scene() { }

	private static void get_scene_Injected(IntPtr _unity_self, out Scene ret) { }

	[FreeFunction(Name = "GameObjectBindings::GetSceneCullingMask", HasExplicitThis = True)]
	public ulong get_sceneCullingMask() { }

	private static ulong get_sceneCullingMask_Injected(IntPtr _unity_self) { }

	[FreeFunction("GameObjectBindings::GetTag", HasExplicitThis = True)]
	public string get_tag() { }

	private static void get_tag_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	[FreeFunction("GameObjectBindings::GetTransform", HasExplicitThis = True)]
	public Transform get_transform() { }

	private static IntPtr get_transform_Injected(IntPtr _unity_self) { }

	public T GetComponent() { }

	[FreeFunction(Name = "GameObjectBindings::GetComponentFromType", HasExplicitThis = True, ThrowsException = True)]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponent(Type type) { }

	private static IntPtr GetComponent_Injected(IntPtr _unity_self, Type type) { }

	[FreeFunction(Name = "GameObjectBindings::GetComponentFastPath", HasExplicitThis = True, ThrowsException = True)]
	internal void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue) { }

	private static void GetComponentFastPath_Injected(IntPtr _unity_self, Type type, IntPtr oneFurtherThanResultValue) { }

	[ExcludeFromDocs]
	public T GetComponentInChildren() { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInChildren(Type type) { }

	[FreeFunction(Name = "GameObjectBindings::GetComponentInChildren", HasExplicitThis = True, ThrowsException = True)]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInChildren(Type type, bool includeInactive) { }

	public T GetComponentInChildren(bool includeInactive) { }

	private static IntPtr GetComponentInChildren_Injected(IntPtr _unity_self, Type type, bool includeInactive) { }

	[FreeFunction(Name = "GameObjectBindings::GetComponentInParent", HasExplicitThis = True, ThrowsException = True)]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInParent(Type type, bool includeInactive) { }

	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public Component GetComponentInParent(Type type) { }

	public T GetComponentInParent(bool includeInactive) { }

	[ExcludeFromDocs]
	public T GetComponentInParent() { }

	private static IntPtr GetComponentInParent_Injected(IntPtr _unity_self, Type type, bool includeInactive) { }

	public void GetComponents(List<T> results) { }

	public T[] GetComponents() { }

	public Component[] GetComponents(Type type) { }

	public Component[] GetComponentsInChildren(Type type, bool includeInactive) { }

	public T[] GetComponentsInChildren() { }

	public void GetComponentsInChildren(bool includeInactive, List<T> results) { }

	[ExcludeFromDocs]
	public Component[] GetComponentsInChildren(Type type) { }

	public T[] GetComponentsInChildren(bool includeInactive) { }

	[ExcludeFromDocs]
	public Component[] GetComponentsInParent(Type type) { }

	public void GetComponentsInParent(bool includeInactive, List<T> results) { }

	public T[] GetComponentsInParent(bool includeInactive) { }

	public T[] GetComponentsInParent() { }

	public Component[] GetComponentsInParent(Type type, bool includeInactive) { }

	[FreeFunction(Name = "GameObjectBindings::GetComponentsInternal", HasExplicitThis = True, ThrowsException = True)]
	private Array GetComponentsInternal(Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList) { }

	private static Array GetComponentsInternal_Injected(IntPtr _unity_self, Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList) { }

	[FreeFunction(Name = "MonoAddComponentWithType", HasExplicitThis = True)]
	private Component Internal_AddComponentWithType(Type componentType) { }

	private static IntPtr Internal_AddComponentWithType_Injected(IntPtr _unity_self, Type componentType) { }

	[FreeFunction(Name = "GameObjectBindings::Internal_CreateGameObject")]
	private static void Internal_CreateGameObject(GameObject self, string name) { }

	private static void Internal_CreateGameObject_Injected(GameObject self, ref ManagedSpanWrapper name) { }

	[FreeFunction(Name = "Scripting::SendScriptingMessage", HasExplicitThis = True)]
	public void SendMessage(string methodName, object value, SendMessageOptions options) { }

	private static void SendMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object value, SendMessageOptions options) { }

	[NativeMethod(Name = "SetIsStaticDeprecated")]
	public void set_isStatic(bool value) { }

	private static void set_isStatic_Injected(IntPtr _unity_self, bool value) { }

	public void set_layer(int value) { }

	private static void set_layer_Injected(IntPtr _unity_self, int value) { }

	[NativeMethod(Name = "SetSelfActive")]
	public void SetActive(bool value) { }

	private static void SetActive_Injected(IntPtr _unity_self, bool value) { }

	public bool TryGetComponent(Type type, out Component component) { }

	public bool TryGetComponent(out T component) { }

	[FreeFunction(Name = "GameObjectBindings::TryGetComponentFastPath", HasExplicitThis = True, ThrowsException = True)]
	internal void TryGetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue) { }

	private static void TryGetComponentFastPath_Injected(IntPtr _unity_self, Type type, IntPtr oneFurtherThanResultValue) { }

	[FreeFunction(Name = "GameObjectBindings::TryGetComponentFromType", HasExplicitThis = True, ThrowsException = True)]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	internal Component TryGetComponentInternal(Type type) { }

	private static IntPtr TryGetComponentInternal_Injected(IntPtr _unity_self, Type type) { }

}

