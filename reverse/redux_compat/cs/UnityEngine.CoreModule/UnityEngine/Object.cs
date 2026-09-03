/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngineInternal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[AssetGCFilterType]
	[NativeHeader("Runtime/SceneManager/SceneManager.h")]
	[NativeHeader("Runtime/GameCode/CloneObject.h")]
	[NativeHeader("Runtime/Export/Scripting/UnityEngineObject.bindings.h")]
	[RequiredByNativeCode(GenerateProxy = false)]
	public class Object // TypeDefIndex: 7787
	{
		// Fields
		private IntPtr m_CachedPtr; // 0x10
		internal static readonly int OffsetOfInstanceIDInCPlusPlusObject; // 0x00
		private const string objectIsNullMessage = "The Object you want to instantiate is null."; // Metadata: 0x0069D6AA
		private const string cloneDestroyedMessage = "Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake."; // Metadata: 0x0069D6D6
	
		// Properties
		public string name { get; set; } // 0x00000001821F4650-0x00000001821F4660 0x00000001821F49D0-0x00000001821F49E0
		public HideFlags hideFlags { get; set; } // 0x00000001821F45C0-0x00000001821F4650 0x00000001821F4930-0x00000001821F49D0
	
		// Nested types
		[VisibleToOtherModules]
		internal static class MarshalledUnityObject // TypeDefIndex: 7788
		{
			// Methods
			public static IntPtr Marshal<T>(T obj)
				where T : Object;
			public static IntPtr MarshalNotNull<T>(T obj)
				where T : Object;
			public static void TryThrowEditorNullExceptionObject(Object unityObj, string paramterName); // 0x00000001802E76C0-0x00000001802E76D0
			public static T Unmarshal<T>(IntPtr gcHandlePtr)
				where T : Object;
			public static GCHandle FromIntPtrUnsafe(IntPtr gcHandle); // 0x0000000180370C60-0x0000000180370C70
		}
	
		// Constructors
		public Object(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Object(); // 0x00000001821F4520-0x00000001821F4580
	
		// Methods
		public EntityId GetEntityId(); // 0x00000001821F2020-0x00000001821F20D0
		internal EntityId GetEntityIdForSerializationUnchecked(); // 0x00000001821F1FA0-0x00000001821F2020
		[Obsolete("Calling MemberwiseClone on a UnityEngine.Object will result in a corrupt object, use Instantiate or InstantiateAsync instead.", true)]
		protected new object MemberwiseClone(); // 0x00000001821F4000-0x00000001821F4040
		[Obsolete("GetInstanceID is deprecated. Use GetEntityId instead. This will be removed in a future version.", true)]
		public int GetInstanceID(); // 0x00000001821F20D0-0x00000001821F20E0
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public override bool Equals(object other); // 0x00000001821F1390-0x00000001821F15B0
		public static implicit operator bool([MaybeNullWhen(false)] [NotNullWhen(true)] Object exists); // 0x00000001821F4760-0x00000001821F47F0
		private static bool CompareBaseObjects(Object lhs, Object rhs); // 0x00000001821F0BB0-0x00000001821F0C80
		private void EnsureRunningOnMainThread(); // 0x00000001821F12D0-0x00000001821F1390
		private static bool IsNativeObjectAlive(Object o); // 0x00000001821F3E10-0x00000001821F3E30
		[RequiredByNativeCode]
		internal IntPtr GetCachedPtr(); // 0x0000000180377550-0x0000000180377560
		[RequiredByNativeCode]
		private void SetCachedPtr(IntPtr ptr); // 0x0000000180719060-0x0000000180719070
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Vector3 position, Quaternion rotation)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent, Vector3 position, Quaternion rotation)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Vector3 position, Quaternion rotation)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, Vector3 position, Quaternion rotation)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, Vector3 position, Quaternion rotation, CancellationToken cancellationToken)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations, CancellationToken cancellationToken)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, InstantiateParameters parameters, CancellationToken cancellationToken = default)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, InstantiateParameters parameters, CancellationToken cancellationToken = default)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Vector3 position, Quaternion rotation, InstantiateParameters parameters, CancellationToken cancellationToken = default)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Vector3 position, Quaternion rotation, InstantiateParameters parameters, CancellationToken cancellationToken = default)
			where T : Object;
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations, InstantiateParameters parameters, CancellationToken cancellationToken = default)
			where T : Object;
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Vector3 position, Quaternion rotation); // 0x00000001821F2A10-0x00000001821F2CF0
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent); // 0x00000001821F23D0-0x00000001821F2800
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original); // 0x00000001821F2800-0x00000001821F2A10
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Scene scene); // 0x00000001821F30D0-0x00000001821F3300
		public static T Instantiate<T>(T original, InstantiateParameters parameters)
			where T : Object;
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, InstantiateParameters parameters)
			where T : Object;
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Transform parent); // 0x00000001821F2370-0x00000001821F23D0
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace); // 0x00000001821F2CF0-0x00000001821F30D0
		public static T Instantiate<T>(T original)
			where T : Object;
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation)
			where T : Object;
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent)
			where T : Object;
		public static T Instantiate<T>(T original, Transform parent)
			where T : Object;
		public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays)
			where T : Object;
		[NativeMethod(Name = "Scripting::DestroyObjectFromScripting", IsFreeFunction = true, ThrowsException = true)]
		public static void Destroy(Object obj, [DefaultValue("0.0F")] float t); // 0x00000001821F0FF0-0x00000001821F1070
		[ExcludeFromDocs]
		public static void Destroy(Object obj); // 0x00000001821F1070-0x00000001821F1120
		[NativeMethod(Name = "Scripting::DestroyObjectFromScriptingImmediate", IsFreeFunction = true, ThrowsException = true)]
		public static void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets); // 0x00000001821F0DB0-0x00000001821F0E30
		[ExcludeFromDocs]
		public static void DestroyImmediate(Object obj); // 0x00000001821F0D00-0x00000001821F0DB0
		[Obsolete("Object.FindObjectsOfType has been deprecated. Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.  FindObjectsOfType sorts the results by InstanceID, but if you do not need this using FindObjectSortMode.None is considerably faster.", false)]
		public static Object[] FindObjectsOfType(Type type); // 0x00000001821F1D80-0x00000001821F1DF0
		[FreeFunction("UnityEngineObjectBindings::FindObjectsOfType")]
		[Obsolete("Object.FindObjectsOfType has been deprecated. Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.  FindObjectsOfType sorts the results by InstanceID but if you do not need this using FindObjectSortMode.None is considerably faster.", false)]
		[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
		public static Object[] FindObjectsOfType(Type type, bool includeInactive); // 0x00000001821F1DF0-0x00000001821F1E40
		[Obsolete("FindObjectsByType with FindObjectsSortMode parameter has been deprecated. Use FindObjectsByType(Type) or FindObjectsByType(Type, FindObjectsInactive) instead. InstanceID will be replaced in the future with EntityId and previous sort order cannot be maintained.", false)]
		public static Object[] FindObjectsByType(Type type, FindObjectsSortMode sortMode); // 0x00000001821F1B60-0x00000001821F1BE0
		[FreeFunction("UnityEngineObjectBindings::FindObjectsByType")]
		[Obsolete("FindObjectsByType with FindObjectsSortMode parameter has been deprecated. Use FindObjectsByType(Type) or FindObjectsByType(Type, FindObjectsInactive) instead. InstanceID will be replaced in the future with EntityId and previous sort order cannot be maintained.", false)]
		[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
		public static Object[] FindObjectsByType(Type type, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode); // 0x00000001821F1B10-0x00000001821F1B60
		public static Object[] FindObjectsByType(Type type); // 0x00000001821F1BE0-0x00000001821F1C50
		public static Object[] FindObjectsByType(Type type, FindObjectsInactive findObjectsInactive); // 0x00000001821F1C50-0x00000001821F1CD0
		[FreeFunction("AllocateEntityIds")]
		internal static EntityId[] AllocateEntityIds(int count); // 0x00000001821F0A50-0x00000001821F0B50
		[FreeFunction("GetSceneManager().DontDestroyOnLoad", ThrowsException = true)]
		public static void DontDestroyOnLoad([NotNull] Object target); // 0x00000001821F1210-0x00000001821F12D0
		[Obsolete("use Object.Destroy instead.")]
		public static void DestroyObject(Object obj, [DefaultValue("0.0F")] float t); // 0x00000001821F0E30-0x00000001821F0EF0
		[ExcludeFromDocs]
		[Obsolete("use Object.Destroy instead.")]
		public static void DestroyObject(Object obj); // 0x00000001821F0EF0-0x00000001821F0FA0
		[Obsolete("Object.FindSceneObjectsOfType has been deprecated, Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.  FindSceneObjectsOfType sorts the results by InstanceID but if you do not need this using FindObjectSortMode.None is considerably faster.", false)]
		public static Object[] FindSceneObjectsOfType(Type type); // 0x00000001821F1E40-0x00000001821F1EE0
		[FreeFunction("UnityEngineObjectBindings::FindObjectsOfTypeIncludingAssets")]
		[Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
		public static Object[] FindObjectsOfTypeIncludingAssets(Type type); // 0x00000001821F1D40-0x00000001821F1D80
		[Obsolete("Object.FindObjectsOfType has been deprecated. Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.  FindObjectsOfType sorts the results by InstanceID but if you do not need this using FindObjectSortMode.None is considerably faster.", false)]
		public static T[] FindObjectsOfType<T>()
			where T : Object;
		[Obsolete("FindObjectsByType with FindObjectsSortMode parameter has been deprecated. Use FindObjectsByType<T>() or FindObjectsByType<T>(FindObjectsInactive) instead. InstanceID will be replaced in the future with EntityId and previous sort order cannot be maintained.", false)]
		public static T[] FindObjectsByType<T>(FindObjectsSortMode sortMode)
			where T : Object;
		[Obsolete("Object.FindObjectsOfType has been deprecated. Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.  FindObjectsOfType sorts the results by InstanceID but if you do not need this using FindObjectSortMode.None is considerably faster.", false)]
		public static T[] FindObjectsOfType<T>(bool includeInactive)
			where T : Object;
		[Obsolete("FindObjectsByType with FindObjectsSortMode parameter has been deprecated. Use FindObjectsByType<T>() or FindObjectsByType<T>(FindObjectsInactive) instead. InstanceID will be replaced in the future with EntityId and previous sort order cannot be maintained.", false)]
		public static T[] FindObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode)
			where T : Object;
		[Obsolete("Object.FindObjectOfType has been deprecated. Use Object.FindAnyObjectByType instead.", false)]
		public static T FindObjectOfType<T>()
			where T : Object;
		[Obsolete("Object.FindObjectOfType has been deprecated. Use Object.FindAnyObjectByType instead.", false)]
		public static T FindObjectOfType<T>(bool includeInactive)
			where T : Object;
		[Obsolete("FindFirstObjectByType has been deprecated because it relies on instance ID ordering. Use FindAnyObjectByType instead, which does not depend on ordering.", false)]
		public static T FindFirstObjectByType<T>()
			where T : Object;
		public static T FindAnyObjectByType<T>()
			where T : Object;
		[Obsolete("FindFirstObjectByType has been deprecated because it relies on instance ID ordering. Use FindAnyObjectByType instead, which does not depend on ordering.", false)]
		public static T FindFirstObjectByType<T>(FindObjectsInactive findObjectsInactive)
			where T : Object;
		public static T FindAnyObjectByType<T>(FindObjectsInactive findObjectsInactive)
			where T : Object;
		public static T[] FindObjectsByType<T>()
			where T : Object;
		public static T[] FindObjectsByType<T>(FindObjectsInactive findObjectsInactive)
			where T : Object;
		[Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
		public static Object[] FindObjectsOfTypeAll(Type type); // 0x00000001821F1CD0-0x00000001821F1D40
		private static void CheckNullArgument(object arg, string message); // 0x00000001821F0B50-0x00000001821F0BB0
		private static void ThrowArgumentExceptionForParentBeingDestroyed(string nameOfObjectToInstantiate, string parentName, string parameterName); // 0x00000001821F4250-0x00000001821F4370
		[Obsolete("Object.FindObjectOfType has been deprecated. Use Object.FindAnyObjectByType instead.", false)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public static Object FindObjectOfType(Type type); // 0x00000001821F1A80-0x00000001821F1B10
		[Obsolete("FindFirstObjectByType has been deprecated because it relies on instance ID ordering. Use FindAnyObjectByType instead, which does not depend on ordering.", false)]
		public static Object FindFirstObjectByType(Type type); // 0x00000001821F1710-0x00000001821F17B0
		public static Object FindAnyObjectByType(Type type); // 0x00000001821F15B0-0x00000001821F1680
		[Obsolete("Object.FindObjectOfType has been deprecated. Use Object.FindAnyObjectByType instead.", false)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public static Object FindObjectOfType(Type type, bool includeInactive); // 0x00000001821F19D0-0x00000001821F1A80
		[Obsolete("FindFirstObjectByType has been deprecated because it relies on instance ID ordering. Use FindAnyObjectByType instead, which does not depend on ordering.", false)]
		public static Object FindFirstObjectByType(Type type, FindObjectsInactive findObjectsInactive); // 0x00000001821F17B0-0x00000001821F1860
		public static Object FindAnyObjectByType(Type type, FindObjectsInactive findObjectsInactive); // 0x00000001821F1680-0x00000001821F1710
		public override string ToString(); // 0x00000001821F43C0-0x00000001821F4410
		public static bool operator ==(Object x, Object y); // 0x00000001821F4660-0x00000001821F4760
		public static bool operator !=(Object x, Object y); // 0x00000001821F47F0-0x00000001821F48F0
		[NativeMethod(Name = "Object::GetOffsetOfInstanceIdMember", IsFreeFunction = true, IsThreadSafe = true)]
		private static int GetOffsetOfInstanceIDInCPlusPlusObject(); // 0x00000001821F2260-0x00000001821F2290
		[NativeMethod(Name = "CurrentThreadIsMainThread", IsFreeFunction = true, IsThreadSafe = true)]
		private static bool CurrentThreadIsMainThread(); // 0x00000001821F0C80-0x00000001821F0CB0
		[NativeMethod(Name = "CloneObject", IsFreeFunction = true, ThrowsException = true)]
		private static Object Internal_CloneSingle([NotNull] Object data); // 0x00000001821F3740-0x00000001821F3810
		[FreeFunction("CloneObjectToScene")]
		private static Object Internal_CloneSingleWithScene([NotNull] Object data, Scene scene); // 0x00000001821F3620-0x00000001821F3700
		[FreeFunction("CloneObjectWithParams")]
		private static Object Internal_CloneSingleWithParams([NotNull] Object data, InstantiateParameters parameters); // 0x00000001821F3350-0x00000001821F3430
		[FreeFunction("InstantiateObjectWithParams")]
		private static Object Internal_InstantiateSingleWithParams([NotNull] Object data, Vector3 position, Quaternion rotation, InstantiateParameters parameters); // 0x00000001821F39F0-0x00000001821F3B00
		[FreeFunction("CloneObject")]
		private static Object Internal_CloneSingleWithParent([NotNull] Object data, [NotNull] Transform parent, bool worldPositionStays); // 0x00000001821F3490-0x00000001821F35D0
		[FreeFunction("InstantiateAsyncObjects")]
		private static IntPtr Internal_InstantiateAsyncWithParams([NotNull] Object original, int count, InstantiateParameters parameters, IntPtr positions, int positionsCount, IntPtr rotations, int rotationsCount); // 0x00000001821F3870-0x00000001821F3980
		[FreeFunction("InstantiateObject")]
		private static Object Internal_InstantiateSingle([NotNull] Object data, Vector3 pos, Quaternion rot); // 0x00000001821F3D20-0x00000001821F3E10
		[FreeFunction("InstantiateObject")]
		private static Object Internal_InstantiateSingleWithParent([NotNull] Object data, [NotNull] Transform parent, Vector3 pos, Quaternion rot); // 0x00000001821F3B70-0x00000001821F3CC0
		[FreeFunction("UnityEngineObjectBindings::ToString")]
		private static string ToString(Object obj); // 0x00000001821F4410-0x00000001821F4520
		[FreeFunction("UnityEngineObjectBindings::GetName", HasExplicitThis = true)]
		private string GetName(); // 0x00000001821F2130-0x00000001821F2260
		[FreeFunction("UnityEngineObjectBindings::IsPersistent")]
		internal static bool IsPersistent([NotNull] Object obj); // 0x00000001821F3E70-0x00000001821F3F30
		[FreeFunction("UnityEngineObjectBindings::SetName", HasExplicitThis = true)]
		private void SetName(string name); // 0x00000001821F4090-0x00000001821F4250
		[NativeMethod(Name = "UnityEngineObjectBindings::DoesObjectWithInstanceIDExist", IsFreeFunction = true, IsThreadSafe = true)]
		internal static bool DoesObjectWithInstanceIDExist(EntityId instanceID); // 0x00000001821F1160-0x00000001821F11D0
		[FreeFunction("UnityEngineObjectBindings::FindObjectFromInstanceID")]
		[VisibleToOtherModules]
		internal static Object FindObjectFromInstanceID(EntityId instanceID); // 0x00000001821F1950-0x00000001821F19D0
		[FreeFunction("UnityEngineObjectBindings::FindObjectFromInstanceIDThreadSafe", IsThreadSafe = true)]
		[VisibleToOtherModules]
		internal static Object FindObjectFromInstanceIDThreadSafe(EntityId instanceID); // 0x00000001821F18A0-0x00000001821F1910
		[FreeFunction("UnityEngineObjectBindings::GetPtrFromInstanceID")]
		private static IntPtr GetPtrFromInstanceID(EntityId instanceID, Type objectType, out bool isMonoBehaviour); // 0x00000001821F22F0-0x00000001821F2370
		[FreeFunction("UnityEngineObjectBindings::ForceLoadFromInstanceID")]
		[VisibleToOtherModules]
		internal static Object ForceLoadFromInstanceID(EntityId instanceID); // 0x00000001821F1F20-0x00000001821F1FA0
		[FreeFunction("UnityEngineObjectBindings::MarkObjectDirty", HasExplicitThis = true)]
		internal void MarkDirty(); // 0x00000001821F3F70-0x00000001821F4000
		private static void Destroy_Injected(IntPtr obj, [DefaultValue("0.0F")] float t); // 0x00000001821F0FA0-0x00000001821F0FF0
		private static void DestroyImmediate_Injected(IntPtr obj, [DefaultValue("false")] bool allowDestroyingAssets); // 0x00000001821F0CB0-0x00000001821F0D00
		private static void AllocateEntityIds_Injected(int count, ); // 0x00000001821F0A10-0x00000001821F0A50
		private static void DontDestroyOnLoad_Injected(IntPtr target); // 0x00000001821F11D0-0x00000001821F1210
		private static HideFlags get_hideFlags_Injected(IntPtr _unity_self); // 0x00000001821F4580-0x00000001821F45C0
		private static void set_hideFlags_Injected(IntPtr _unity_self, HideFlags value); // 0x00000001821F48F0-0x00000001821F4930
		private static IntPtr Internal_CloneSingle_Injected(IntPtr data); // 0x00000001821F3700-0x00000001821F3740
		private static IntPtr Internal_CloneSingleWithScene_Injected(IntPtr data, in Scene scene); // 0x00000001821F35D0-0x00000001821F3620
		private static IntPtr Internal_CloneSingleWithParams_Injected(IntPtr data, in InstantiateParameters parameters); // 0x00000001821F3300-0x00000001821F3350
		private static IntPtr Internal_InstantiateSingleWithParams_Injected(IntPtr data, in Vector3 position, in Quaternion rotation, in InstantiateParameters parameters); // 0x00000001821F3980-0x00000001821F39F0
		private static IntPtr Internal_CloneSingleWithParent_Injected(IntPtr data, IntPtr parent, bool worldPositionStays); // 0x00000001821F3430-0x00000001821F3490
		private static IntPtr Internal_InstantiateAsyncWithParams_Injected(IntPtr original, int count, in InstantiateParameters parameters, IntPtr positions, int positionsCount, IntPtr rotations, int rotationsCount); // 0x00000001821F3810-0x00000001821F3870
		private static IntPtr Internal_InstantiateSingle_Injected(IntPtr data, in Vector3 pos, in Quaternion rot); // 0x00000001821F3CC0-0x00000001821F3D20
		private static IntPtr Internal_InstantiateSingleWithParent_Injected(IntPtr data, IntPtr parent, in Vector3 pos, in Quaternion rot); // 0x00000001821F3B00-0x00000001821F3B70
		private static void ToString_Injected(IntPtr obj, ); // 0x00000001821F4370-0x00000001821F43C0
		private static void GetName_Injected(IntPtr _unity_self, ); // 0x00000001821F20E0-0x00000001821F2130
		private static bool IsPersistent_Injected(IntPtr obj); // 0x00000001821F3E30-0x00000001821F3E70
		private static void SetName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x00000001821F4040-0x00000001821F4090
		private static bool DoesObjectWithInstanceIDExist_Injected(in EntityId instanceID); // 0x00000001821F1120-0x00000001821F1160
		private static IntPtr FindObjectFromInstanceID_Injected(in EntityId instanceID); // 0x00000001821F1910-0x00000001821F1950
		private static Object FindObjectFromInstanceIDThreadSafe_Injected(in EntityId instanceID); // 0x00000001821F1860-0x00000001821F18A0
		private static IntPtr GetPtrFromInstanceID_Injected(in EntityId instanceID, Type objectType, out bool isMonoBehaviour); // 0x00000001821F2290-0x00000001821F22F0
		private static IntPtr ForceLoadFromInstanceID_Injected(in EntityId instanceID); // 0x00000001821F1EE0-0x00000001821F1F20
		private static void MarkDirty_Injected(IntPtr _unity_self); // 0x00000001821F3F30-0x00000001821F3F70
	}
}
