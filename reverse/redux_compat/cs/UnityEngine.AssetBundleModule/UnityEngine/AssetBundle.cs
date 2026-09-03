/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngineInternal;

// Image 61: UnityEngine.AssetBundleModule.dll - Assembly: UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15752-15762

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("AssetBundle", PersistentTypeId = 142)]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromManagedStreamAsyncOperation.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleSaveAndLoadHelper.h")]
	[NativeHeader("AssetBundleScriptingClasses.h")]
	[NativeHeader("Scripting/ScriptingUtility.h")]
	[NativeHeader("Runtime/Scripting/ScriptingExportUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetUtility.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromFileAsyncOperation.h")]
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromMemoryAsyncOperation.h")]
	public class AssetBundle : Object // TypeDefIndex: 15755
	{
		// Constructors
		private AssetBundle(); // 0x0000000182164B10-0x0000000182164B60
	
		// Methods
		[FreeFunction("GetAllAssetBundles")]
		internal static AssetBundle[] GetAllLoadedAssetBundles_Native(); // 0x0000000182163A20-0x0000000182163A50
		public static IEnumerable<AssetBundle> GetAllLoadedAssetBundles(); // 0x0000000182163A20-0x0000000182163A50
		[FreeFunction("LoadFromFileAsync")]
		internal static AssetBundleCreateRequest LoadFromFileAsync_Internal(string path, uint crc, ulong offset); // 0x0000000182164750-0x0000000182164930
		public static AssetBundleCreateRequest LoadFromFileAsync(string path); // 0x0000000182164940-0x0000000182164950
		public static AssetBundleCreateRequest LoadFromFileAsync(string path, uint crc); // 0x0000000182164930-0x0000000182164940
		public T LoadAsset<T>(string name)
			where T : Object;
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
		public Object LoadAsset(string name, Type type); // 0x00000001821645B0-0x0000000182164700
		[NativeMethod("LoadAsset_Internal", ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
		private Object LoadAsset_Internal(string name, Type type); // 0x00000001821643B0-0x00000001821645B0
		public AssetBundleRequest LoadAssetAsync(string name, Type type); // 0x0000000182163E50-0x0000000182163FA0
		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type); // 0x0000000182164200-0x0000000182164350
		public AssetBundleRequest LoadAllAssetsAsync(); // 0x0000000182163A50-0x0000000182163B30
		public AssetBundleRequest LoadAllAssetsAsync<T>();
		public AssetBundleRequest LoadAllAssetsAsync(Type type); // 0x0000000182163B30-0x0000000182163BF0
		[NativeMethod("LoadAssetAsync_Internal", ThrowsException = true)]
		private AssetBundleRequest LoadAssetAsync_Internal(string name, Type type); // 0x0000000182163C50-0x0000000182163E50
		[NativeMethod("Unload", ThrowsException = true)]
		public void Unload(bool unloadAllLoadedObjects); // 0x0000000182164AB0-0x0000000182164B10
		[NativeMethod("UnloadAsync", ThrowsException = true)]
		public AssetBundleUnloadOperation UnloadAsync(bool unloadAllLoadedObjects); // 0x00000001821649A0-0x0000000182164A60
		[NativeMethod("LoadAssetWithSubAssetsAsync_Internal", ThrowsException = true)]
		private AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type); // 0x0000000182164000-0x0000000182164200
		private static IntPtr LoadFromFileAsync_Internal_Injected(ref ManagedSpanWrapper path, uint crc, ulong offset); // 0x0000000182164700-0x0000000182164750
		private static IntPtr LoadAsset_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type); // 0x0000000182164350-0x00000001821643B0
		private static IntPtr LoadAssetAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type); // 0x0000000182163BF0-0x0000000182163C50
		private static void Unload_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects); // 0x0000000182164A60-0x0000000182164AB0
		private static IntPtr UnloadAsync_Injected(IntPtr _unity_self, bool unloadAllLoadedObjects); // 0x0000000182164950-0x00000001821649A0
		private static IntPtr LoadAssetWithSubAssetsAsync_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, Type type); // 0x0000000182163FA0-0x0000000182164000
	}
}
