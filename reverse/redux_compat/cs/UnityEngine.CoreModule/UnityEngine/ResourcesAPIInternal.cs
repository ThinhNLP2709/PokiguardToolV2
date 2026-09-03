/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngineInternal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
	[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
	internal static class ResourcesAPIInternal // TypeDefIndex: 7700
	{
		// Nested types
		internal static class EntitiesAssetGC // TypeDefIndex: 7701
		{
			// Fields
			[AutoStaticsCleanupOnCodeReload]
			internal static AdditionalRootsHandlerDelegate AdditionalRootsHandler; // 0x00
			[CompilerGenerated]
			private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
			// Nested types
			internal delegate void AdditionalRootsHandlerDelegate(IntPtr state); // TypeDefIndex: 7702; 0x00000001804A78A0-0x00000001804A78B0
	
			// Constructors
			static EntitiesAssetGC(); // 0x00000001821E5F30-0x00000001821E6050
	
			// Methods
			[RequiredByNativeCode]
			private static void GetAdditionalRoots(IntPtr state); // 0x00000001821E5E50-0x00000001821E5EC0
			[CompilerGenerated]
			private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001821E5EC0-0x00000001821E5F30
		}
	
		// Methods
		[FreeFunction("Resources_Bindings::FindObjectsOfTypeAll")]
		[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
		public static Object[] FindObjectsOfTypeAll(Type type); // 0x00000001821F8080-0x00000001821F80C0
		[FreeFunction("GetShaderNameRegistry().FindShader")]
		public static Shader FindShaderByName(string name); // 0x00000001821F8100-0x00000001821F82C0
		[FreeFunction("Resources_Bindings::Load", ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
		public static Object Load(string path, [NotNull] Type systemTypeInstance); // 0x00000001821F8750-0x00000001821F8930
		[FreeFunction("Resources_Bindings::LoadAll", ThrowsException = true)]
		public static Object[] LoadAll([NotNull] string path, [NotNull] Type systemTypeInstance); // 0x00000001821F8310-0x00000001821F84E0
		[FreeFunction("Resources_Bindings::LoadAsyncInternal")]
		internal static ResourceRequest LoadAsyncInternal(string path, Type type); // 0x00000001821F8530-0x00000001821F8700
		[FreeFunction("Scripting::UnloadAssetFromScripting")]
		public static void UnloadAsset(Object assetToUnload); // 0x00000001821F8970-0x00000001821F89B0
		private static IntPtr FindShaderByName_Injected(ref ManagedSpanWrapper name); // 0x00000001821F80C0-0x00000001821F8100
		private static IntPtr Load_Injected(ref ManagedSpanWrapper path, Type systemTypeInstance); // 0x00000001821F8700-0x00000001821F8750
		private static Object[] LoadAll_Injected(ref ManagedSpanWrapper path, Type systemTypeInstance); // 0x00000001821F82C0-0x00000001821F8310
		private static IntPtr LoadAsyncInternal_Injected(ref ManagedSpanWrapper path, Type type); // 0x00000001821F84E0-0x00000001821F8530
		private static void UnloadAsset_Injected(IntPtr assetToUnload); // 0x00000001821F8930-0x00000001821F8970
	}
}
