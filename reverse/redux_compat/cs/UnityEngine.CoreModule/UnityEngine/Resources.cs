/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngineInternal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
	[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
	public sealed class Resources // TypeDefIndex: 7704
	{
		// Methods
		internal static T[] ConvertObjects<T>(Object[] rawObjects)
			where T : Object;
		public static Object[] FindObjectsOfTypeAll(Type type); // 0x00000001821F1CD0-0x00000001821F1D40
		public static T[] FindObjectsOfTypeAll<T>()
			where T : Object;
		public static Object Load(string path); // 0x00000001821F9370-0x00000001821F93C0
		public static T Load<T>(string path)
			where T : Object;
		public static Object Load(string path, Type systemTypeInstance); // 0x00000001821F92F0-0x00000001821F9370
		public static ResourceRequest LoadAsync<T>(string path)
			where T : Object;
		public static ResourceRequest LoadAsync(string path, Type type); // 0x00000001821F9270-0x00000001821F92F0
		public static Object[] LoadAll(string path, Type systemTypeInstance); // 0x00000001821F91F0-0x00000001821F9270
		public static T[] LoadAll<T>(string path)
			where T : Object;
		[FreeFunction("GetScriptingBuiltinResource", ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public static Object GetBuiltinResource([NotNull] Type type, string path); // 0x00000001821F9010-0x00000001821F91F0
		public static T GetBuiltinResource<T>(string path)
			where T : Object;
		public static void UnloadAsset(Object assetToUnload); // 0x00000001821F93C0-0x00000001821F9430
		[FreeFunction("Resources_Bindings::UnloadUnusedAssets")]
		public static AsyncOperation UnloadUnusedAssets(); // 0x00000001821F9460-0x00000001821F9510
		[FreeFunction("Resources_Bindings::InstanceIDToObject")]
		public static Object EntityIdToObject(EntityId entityId); // 0x00000001821F8F60-0x00000001821F8FC0
		[FreeFunction("Resources_Bindings::DoesObjectWithInstanceIDExist", IsThreadSafe = true)]
		public static bool EntityIdIsValid(EntityId entityId); // 0x00000001821F8EE0-0x00000001821F8F20
		private static IntPtr GetBuiltinResource_Injected(Type type, ref ManagedSpanWrapper path); // 0x00000001821F8FC0-0x00000001821F9010
		private static IntPtr UnloadUnusedAssets_Injected(); // 0x00000001821F9430-0x00000001821F9460
		private static IntPtr EntityIdToObject_Injected(in EntityId entityId); // 0x00000001821F8F20-0x00000001821F8F60
		private static bool EntityIdIsValid_Injected(in EntityId entityId); // 0x00000001821F8EA0-0x00000001821F8EE0
	}
}
