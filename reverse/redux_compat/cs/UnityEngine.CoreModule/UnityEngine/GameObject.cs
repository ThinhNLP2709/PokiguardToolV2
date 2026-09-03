/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngineInternal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("GameObject", PersistentTypeId = 1)]
	[NativeHeader("Runtime/Export/Scripting/GameObject.bindings.h")]
	[UsedByNativeCode]
	public sealed class GameObject : Object // TypeDefIndex: 7755
	{
		// Properties
		public Transform transform { [FreeFunction("GameObjectBindings::GetTransform", HasExplicitThis = true)] get; } // 0x00000001821EB710-0x00000001821EB7A0 
		public TransformHandle transformHandle { [FreeFunction("GameObjectBindings::GetTransformHandle", HasExplicitThis = true)] get; } // 0x00000001821EB660-0x00000001821EB6D0 
		public int layer { get; set; } // 0x00000001821EB310-0x00000001821EB370 0x00000001821EB940-0x00000001821EB9A0
		public bool activeSelf { [NativeMethod(Name = "IsSelfActive")] get; } // 0x00000001821EB090-0x00000001821EB0F0 
		public bool activeInHierarchy { [NativeMethod(Name = "IsActive")] get; } // 0x00000001821EAFF0-0x00000001821EB050 
		public bool isStatic { [NativeMethod(Name = "GetIsStaticDeprecated")] get; [NativeMethod(Name = "SetIsStaticDeprecated")] set; } // 0x00000001821EB270-0x00000001821EB2D0 0x00000001821EB8A0-0x00000001821EB900
		internal bool isStaticBatchable { [NativeMethod(Name = "IsStaticBatchable")] get; } // 0x00000001821EB1D0-0x00000001821EB230 
		public string tag { [FreeFunction("GameObjectBindings::GetTag", HasExplicitThis = true)] get; [FreeFunction("GameObjectBindings::SetTag", HasExplicitThis = true)] set; } // 0x00000001821EB520-0x00000001821EB610 0x00000001821EB9F0-0x00000001821EBB60
		public Scene scene { [FreeFunction("GameObjectBindings::GetScene", HasExplicitThis = true)] get; } // 0x00000001821EB460-0x00000001821EB4D0 
		public ulong sceneCullingMask { [FreeFunction(Name = "GameObjectBindings::GetSceneCullingMask", HasExplicitThis = true)] get; } // 0x00000001821EB3B0-0x00000001821EB410 
		public GameObject gameObject { get; } // 0x0000000180370C60-0x0000000180370C70 
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.", true)]
		public bool active { [NativeMethod(Name = "IsActive")] get; [NativeMethod(Name = "SetSelfActive")] set; } // 0x00000001821EB130-0x00000001821EB190 0x00000001821EB7F0-0x00000001821EB850
	
		// Constructors
		public GameObject(string name); // 0x00000001821EADB0-0x00000001821EAE20
		public GameObject(); // 0x00000001821EAF50-0x00000001821EAFB0
		public GameObject(string name, params Type[] components); // 0x00000001821EAE20-0x00000001821EAF50
	
		// Methods
		[FreeFunction("GameObjectBindings::CreatePrimitive")]
		public static GameObject CreatePrimitive(PrimitiveType type); // 0x00000001821E8000-0x00000001821E8060
		public T GetComponent<T>();
		[FreeFunction(Name = "GameObjectBindings::GetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponent(Type type); // 0x00000001821E93F0-0x00000001821E9490
		[FreeFunction(Name = "GameObjectBindings::GetComponentFastPath", HasExplicitThis = true, ThrowsException = true)]
		internal Component GetComponentFastPath(Type type); // 0x00000001821E8EC0-0x00000001821E8F60
		[FreeFunction(Name = "Scripting::GetScriptingWrapperOfComponentOfGameObject", HasExplicitThis = true)]
		internal Component GetComponentByName(string type); // 0x00000001821E8BE0-0x00000001821E8DD0
		[FreeFunction(Name = "Scripting::GetScriptingWrapperOfComponentOfGameObjectWithCase", HasExplicitThis = true)]
		internal Component GetComponentByNameWithCase(string type, bool caseSensitive); // 0x00000001821E8990-0x00000001821E8B90
		public Component GetComponent(string type); // 0x00000001821E93E0-0x00000001821E93F0
		[FreeFunction(Name = "GameObjectBindings::GetComponentInChildren", HasExplicitThis = true, ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type type, bool includeInactive); // 0x00000001821E9060-0x00000001821E9110
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type type); // 0x00000001821E8FC0-0x00000001821E9060
		[ExcludeFromDocs]
		public T GetComponentInChildren<T>();
		public T GetComponentInChildren<T>([UnityEngine.Internal.DefaultValue("false")] bool includeInactive);
		[FreeFunction(Name = "GameObjectBindings::GetComponentInParent", HasExplicitThis = true, ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type type, bool includeInactive); // 0x00000001821E9170-0x00000001821E9220
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type type); // 0x00000001821E9220-0x00000001821E92C0
		[ExcludeFromDocs]
		public T GetComponentInParent<T>();
		public T GetComponentInParent<T>([UnityEngine.Internal.DefaultValue("false")] bool includeInactive);
		[FreeFunction(Name = "GameObjectBindings::GetComponentsInternal", HasExplicitThis = true, ThrowsException = true)]
		private Array GetComponentsInternal(Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList); // 0x00000001821E98B0-0x00000001821E9940
		private Array GetComponentsInternal<T>(bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, out List<T> resultList);
		public Component[] GetComponents(Type type); // 0x00000001821E99C0-0x00000001821E9AA0
		public T[] GetComponents<T>();
		public void GetComponents(Type type, List<Component> results); // 0x00000001821E9940-0x00000001821E99C0
		public void GetComponents<T>(List<T> results);
		[ExcludeFromDocs]
		public Component[] GetComponentsInChildren(Type type); // 0x00000001821E9580-0x00000001821E9660
		public Component[] GetComponentsInChildren(Type type, [UnityEngine.Internal.DefaultValue("false")] bool includeInactive); // 0x00000001821E9490-0x00000001821E9580
		public T[] GetComponentsInChildren<T>(bool includeInactive);
		public void GetComponentsInChildren<T>(bool includeInactive, List<T> results);
		public T[] GetComponentsInChildren<T>();
		public void GetComponentsInChildren<T>(List<T> results);
		[ExcludeFromDocs]
		public Component[] GetComponentsInParent(Type type); // 0x00000001821E9660-0x00000001821E9740
		public Component[] GetComponentsInParent(Type type, [UnityEngine.Internal.DefaultValue("false")] bool includeInactive); // 0x00000001821E9740-0x00000001821E9830
		public void GetComponentsInParent<T>(bool includeInactive, List<T> results);
		public T[] GetComponentsInParent<T>(bool includeInactive);
		public T[] GetComponentsInParent<T>();
		public bool TryGetComponent<T>(out ref T component);
		public bool TryGetComponent(Type type, out Component component); // 0x00000001821EAC30-0x00000001821EADB0
		[FreeFunction(Name = "GameObjectBindings::TryGetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		internal Component TryGetComponentInternal(Type type); // 0x00000001821EAB90-0x00000001821EAC30
		[FreeFunction(Name = "GameObjectBindings::TryGetComponentFastPath", HasExplicitThis = true, ThrowsException = true)]
		internal Component TryGetComponentFastPath(Type type); // 0x00000001821EAAA0-0x00000001821EAB40
		public static GameObject FindWithTag(string tag); // 0x00000001821E85E0-0x00000001821E85F0
		[FreeFunction(Name = "GameObjectBindings::FindGameObjectsWithTagForListInternal", ThrowsException = true)]
		private static void FindGameObjectsWithTagForListInternal(string tag, [NotNull] out List<GameObject> results); // 0x00000001821E82B0-0x00000001821E8440
		public static void FindGameObjectsWithTag(string tag, List<GameObject> results); // 0x00000001821E8480-0x00000001821E8490
		public void SendMessageUpwards(string methodName, SendMessageOptions options); // 0x00000001821EA440-0x00000001821EA460
		public void SendMessage(string methodName, SendMessageOptions options); // 0x00000001821EA690-0x00000001821EA6B0
		public void BroadcastMessage(string methodName, SendMessageOptions options); // 0x00000001821E7B10-0x00000001821E7B30
		[FreeFunction(Name = "MonoAddComponent", HasExplicitThis = true)]
		internal Component AddComponentInternal(string className); // 0x00000001821E77F0-0x00000001821E79E0
		[FreeFunction(Name = "MonoAddComponentWithType", HasExplicitThis = true)]
		private Component Internal_AddComponentWithType(Type componentType); // 0x00000001821E79E0-0x00000001821E7A80
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component AddComponent(Type componentType); // 0x00000001821E79E0-0x00000001821E7A80
		public T AddComponent<T>()
			where T : Component;
		public int GetComponentCount(); // 0x00000001821E8E10-0x00000001821E8E70
		[NativeName("QueryComponentAtIndex<Unity::Component>")]
		internal Component QueryComponentAtIndex(int index); // 0x00000001821EA170-0x00000001821EA210
		public Component GetComponentAtIndex(int index); // 0x00000001821E87F0-0x00000001821E8930
		public T GetComponentAtIndex<T>(int index)
			where T : Component;
		public int GetComponentIndex(Component component); // 0x00000001821E9310-0x00000001821E9390
		[NativeMethod(Name = "SetSelfActive")]
		public void SetActive(bool value); // 0x00000001821EA7B0-0x00000001821EA810
		public bool CompareTag(string tag); // 0x00000001821E7F50-0x00000001821E7F60
		public bool CompareTag(TagHandle tag); // 0x00000001821E7F60-0x00000001821E7FC0
		[FreeFunction(Name = "GameObjectBindings::CompareTag", HasExplicitThis = true)]
		private bool CompareTag_Internal(string tag); // 0x00000001821E7DD0-0x00000001821E7F50
		[FreeFunction(Name = "GameObjectBindings::CompareTagHandle", HasExplicitThis = true)]
		private bool CompareTagHandle_Internal(TagHandle tag); // 0x00000001821E7D20-0x00000001821E7D80
		[FreeFunction(Name = "GameObjectBindings::FindGameObjectWithTag", ThrowsException = true)]
		public static GameObject FindGameObjectWithTag(string tag); // 0x00000001821E80A0-0x00000001821E8260
		[FreeFunction(Name = "GameObjectBindings::FindGameObjectsWithTag", ThrowsException = true)]
		public static GameObject[] FindGameObjectsWithTag(string tag); // 0x00000001821E8490-0x00000001821E85E0
		[FreeFunction(Name = "Scripting::SendScriptingMessageUpwards", HasExplicitThis = true)]
		public void SendMessageUpwards(string methodName, [UnityEngine.Internal.DefaultValue("null")] object value, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821EA280-0x00000001821EA400
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName, object value); // 0x00000001821EA420-0x00000001821EA440
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName); // 0x00000001821EA400-0x00000001821EA420
		[FreeFunction(Name = "Scripting::SendScriptingMessage", HasExplicitThis = true)]
		public void SendMessage(string methodName, [UnityEngine.Internal.DefaultValue("null")] object value, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821EA4D0-0x00000001821EA650
		[ExcludeFromDocs]
		public void SendMessage(string methodName, object value); // 0x00000001821EA670-0x00000001821EA690
		[ExcludeFromDocs]
		public void SendMessage(string methodName); // 0x00000001821EA650-0x00000001821EA670
		[FreeFunction(Name = "Scripting::BroadcastScriptingMessage", HasExplicitThis = true)]
		public void BroadcastMessage(string methodName, [UnityEngine.Internal.DefaultValue("null")] object parameter, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821E7B30-0x00000001821E7CB0
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName, object parameter); // 0x00000001821E7AF0-0x00000001821E7B10
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName); // 0x00000001821E7CB0-0x00000001821E7CD0
		[FreeFunction(Name = "GameObjectBindings::Internal_CreateGameObject")]
		private static void Internal_CreateGameObject([Writable] GameObject self, string name); // 0x00000001821E9F40-0x00000001821EA090
		[FreeFunction(Name = "GameObjectBindings::Find")]
		public static GameObject Find(string name); // 0x00000001821E8630-0x00000001821E87F0
		[FreeFunction(Name = "GameObjectBindings::SetGameObjectsActiveByInstanceID")]
		private static void SetGameObjectsActive(IntPtr instanceIds, int instanceCount, bool active); // 0x00000001821EA8E0-0x00000001821EA940
		[Obsolete("Obsolete. Please use GameObject.SetGameObjectsActive(NativeArray<EntityId>, bool) instead.", true)]
		public static void SetGameObjectsActive(NativeArray<int> instanceIDs, bool active); // 0x00000001821EAA00-0x00000001821EAA50
		public static void SetGameObjectsActive(NativeArray<EntityId> entityIds, bool active); // 0x00000001821EA810-0x00000001821EA8E0
		[Obsolete("Obsolete. Please use GameObject.SetGameObjectsActive(ReadOnlySpan<EntityId>, bool) instead.", true)]
		public static void SetGameObjectsActive(ReadOnlySpan<int> instanceIDs, bool active); // 0x00000001821EA940-0x00000001821EA990
		public static void SetGameObjectsActive(ReadOnlySpan<EntityId> entityIds, bool active); // 0x00000001821EA990-0x00000001821EAA00
		[FreeFunction("GameObjectBindings::InstantiateGameObjectsByInstanceID")]
		private static void InstantiateGameObjects(EntityId sourceInstanceID, IntPtr newInstanceIDs, IntPtr newTransformInstanceIDs, int count, Scene destinationScene); // 0x00000001821E9C60-0x00000001821E9CD0
		[Obsolete("Obsolete. Please use GameObject.InstantiateGameObjects(EntityId, int, NativeArray<EntityId>, NativeArray<EntityId>, Scene) instead.", true)]
		public static void InstantiateGameObjects(int sourceInstanceID, int count, NativeArray<int> newInstanceIDs, NativeArray<int> newTransformInstanceIDs, Scene destinationScene = default); // 0x00000001821E9C10-0x00000001821E9C60
		public static void InstantiateGameObjects(EntityId sourceEntityId, int count, NativeArray<EntityId> newEntityIds, NativeArray<EntityId> newTransformEntityIds, Scene destinationScene = default); // 0x00000001821E9CD0-0x00000001821E9EA0
		[FreeFunction(Name = "GameObjectBindings::GetSceneByEntityId")]
		private static Scene GetSceneInternal(EntityId entityId); // 0x00000001821E9AF0-0x00000001821E9B40
		public static Scene GetScene(EntityId entityId); // 0x00000001821E9B50-0x00000001821E9BA0
		public bool IsDestroying(); // 0x00000001821EA0D0-0x00000001821EA130
		[EditorBrowsable(EditorBrowsableState.Never)]
		[NativeMethod(Name = "SetActiveRecursivelyDeprecated")]
		[Obsolete("Use SetActive() instead. Note: SetActive() respects explicitly inactive children, while SetActiveRecursively forced all descendants active.", true)]
		public void SetActiveRecursively(bool state); // 0x00000001821EA700-0x00000001821EA760
		[Obsolete("Obsolete. Please use GameObject.GetScene(EntityId entityId) instead.", true)]
		public static Scene GetScene(int instanceID); // 0x00000001821E9B40-0x00000001821E9B50
		private static IntPtr CreatePrimitive_Injected(PrimitiveType type); // 0x00000001821E7FC0-0x00000001821E8000
		private static IntPtr GetComponent_Injected(IntPtr _unity_self, Type type); // 0x00000001821E9390-0x00000001821E93E0
		private static IntPtr GetComponentFastPath_Injected(IntPtr _unity_self, Type type); // 0x00000001821E8E70-0x00000001821E8EC0
		private static IntPtr GetComponentByName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper type); // 0x00000001821E8B90-0x00000001821E8BE0
		private static IntPtr GetComponentByNameWithCase_Injected(IntPtr _unity_self, ref ManagedSpanWrapper type, bool caseSensitive); // 0x00000001821E8930-0x00000001821E8990
		private static IntPtr GetComponentInChildren_Injected(IntPtr _unity_self, Type type, bool includeInactive); // 0x00000001821E8F60-0x00000001821E8FC0
		private static IntPtr GetComponentInParent_Injected(IntPtr _unity_self, Type type, bool includeInactive); // 0x00000001821E9110-0x00000001821E9170
		private static Array GetComponentsInternal_Injected(IntPtr _unity_self, Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList); // 0x00000001821E9830-0x00000001821E98B0
		private static IntPtr TryGetComponentInternal_Injected(IntPtr _unity_self, Type type); // 0x00000001821EAB40-0x00000001821EAB90
		private static IntPtr TryGetComponentFastPath_Injected(IntPtr _unity_self, Type type); // 0x00000001821EAA50-0x00000001821EAAA0
		private static void FindGameObjectsWithTagForListInternal_Injected(ref ManagedSpanWrapper tag, out List<GameObject> results); // 0x00000001821E8260-0x00000001821E82B0
		private static IntPtr AddComponentInternal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper className); // 0x00000001821E77A0-0x00000001821E77F0
		private static IntPtr Internal_AddComponentWithType_Injected(IntPtr _unity_self, Type componentType); // 0x00000001821E9EA0-0x00000001821E9EF0
		private static int GetComponentCount_Injected(IntPtr _unity_self); // 0x00000001821E8DD0-0x00000001821E8E10
		private static IntPtr QueryComponentAtIndex_Injected(IntPtr _unity_self, int index); // 0x00000001821EA130-0x00000001821EA170
		private static int GetComponentIndex_Injected(IntPtr _unity_self, IntPtr component); // 0x00000001821E92C0-0x00000001821E9310
		private static IntPtr get_transform_Injected(IntPtr _unity_self); // 0x00000001821EB6D0-0x00000001821EB710
		private static void get_transformHandle_Injected(IntPtr _unity_self, ); // 0x00000001821EB610-0x00000001821EB660
		private static int get_layer_Injected(IntPtr _unity_self); // 0x00000001821EB2D0-0x00000001821EB310
		private static void set_layer_Injected(IntPtr _unity_self, int value); // 0x00000001821EB900-0x00000001821EB940
		private static void SetActive_Injected(IntPtr _unity_self, bool value); // 0x00000001821EA760-0x00000001821EA7B0
		private static bool get_activeSelf_Injected(IntPtr _unity_self); // 0x00000001821EB050-0x00000001821EB090
		private static bool get_activeInHierarchy_Injected(IntPtr _unity_self); // 0x00000001821EAFB0-0x00000001821EAFF0
		private static bool get_isStatic_Injected(IntPtr _unity_self); // 0x00000001821EB230-0x00000001821EB270
		private static void set_isStatic_Injected(IntPtr _unity_self, bool value); // 0x00000001821EB850-0x00000001821EB8A0
		private static bool get_isStaticBatchable_Injected(IntPtr _unity_self); // 0x00000001821EB190-0x00000001821EB1D0
		private static void get_tag_Injected(IntPtr _unity_self, ); // 0x00000001821EB4D0-0x00000001821EB520
		private static void set_tag_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x00000001821EB9A0-0x00000001821EB9F0
		private static bool CompareTag_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper tag); // 0x00000001821E7D80-0x00000001821E7DD0
		private static bool CompareTagHandle_Internal_Injected(IntPtr _unity_self, in TagHandle tag); // 0x00000001821E7CD0-0x00000001821E7D20
		private static IntPtr FindGameObjectWithTag_Injected(ref ManagedSpanWrapper tag); // 0x00000001821E8060-0x00000001821E80A0
		private static GameObject[] FindGameObjectsWithTag_Injected(ref ManagedSpanWrapper tag); // 0x00000001821E8440-0x00000001821E8480
		private static void SendMessageUpwards_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, [UnityEngine.Internal.DefaultValue("null")] object value, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821EA210-0x00000001821EA280
		private static void SendMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, [UnityEngine.Internal.DefaultValue("null")] object value, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821EA460-0x00000001821EA4D0
		private static void BroadcastMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, [UnityEngine.Internal.DefaultValue("null")] object parameter, [UnityEngine.Internal.DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821E7A80-0x00000001821E7AF0
		private static void Internal_CreateGameObject_Injected([Writable] GameObject self, ref ManagedSpanWrapper name); // 0x00000001821E9EF0-0x00000001821E9F40
		private static IntPtr Find_Injected(ref ManagedSpanWrapper name); // 0x00000001821E85F0-0x00000001821E8630
		private static void InstantiateGameObjects_Injected(in EntityId sourceInstanceID, IntPtr newInstanceIDs, IntPtr newTransformInstanceIDs, int count, in Scene destinationScene); // 0x00000001821E9BA0-0x00000001821E9C10
		private static void GetSceneInternal_Injected(in EntityId entityId, ); // 0x00000001821E9AA0-0x00000001821E9AF0
		private static void get_scene_Injected(IntPtr _unity_self, ); // 0x00000001821EB410-0x00000001821EB460
		private static ulong get_sceneCullingMask_Injected(IntPtr _unity_self); // 0x00000001821EB370-0x00000001821EB3B0
		private static bool IsDestroying_Injected(IntPtr _unity_self); // 0x00000001821EA090-0x00000001821EA0D0
		private static bool get_active_Injected(IntPtr _unity_self); // 0x00000001821EB0F0-0x00000001821EB130
		private static void set_active_Injected(IntPtr _unity_self, bool value); // 0x00000001821EB7A0-0x00000001821EB7F0
		private static void SetActiveRecursively_Injected(IntPtr _unity_self, bool state); // 0x00000001821EA6B0-0x00000001821EA700
	}
}
