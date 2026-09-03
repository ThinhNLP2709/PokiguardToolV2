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
using UnityEngine.Events;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.SceneManagement
{
	[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
	[RequiredByNativeCode]
	public class SceneManager // TypeDefIndex: 8004
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static bool s_AllowLoadScene; // 0x00
		[CompilerGenerated]
		private static UnityAction<Scene, LoadSceneMode> sceneLoaded; // 0x08
		[CompilerGenerated]
		private static UnityAction<Scene> sceneUnloaded; // 0x10
		[CompilerGenerated]
		private static UnityAction<Scene, Scene> activeSceneChanged; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x20
	
		// Properties
		public static int sceneCount { [NativeHeader("Runtime/SceneManager/SceneManager.h")] [NativeMethod("GetSceneCount")] [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)] get; } // 0x00000001822522F0-0x0000000182252320 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event UnityAction<Scene, LoadSceneMode> sceneLoaded {
			add; // 0x0000000182252110-0x0000000182252200
			remove; // 0x0000000182252410-0x0000000182252500
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event UnityAction<Scene> sceneUnloaded {
			add; // 0x0000000182252200-0x00000001822522F0
			remove; // 0x0000000182252500-0x00000001822525F0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event UnityAction<Scene, Scene> activeSceneChanged {
			add; // 0x0000000182252020-0x0000000182252110
			remove; // 0x0000000182252320-0x0000000182252410
		}
	
		// Constructors
		static SceneManager(); // 0x0000000182251EF0-0x0000000182252020
	
		// Methods
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetActiveScene(); // 0x0000000182250A20-0x0000000182250A90
		[NativeMethod(ThrowsException = true)]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static bool SetActiveScene(Scene scene); // 0x0000000182251610-0x0000000182251680
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetSceneByName(string name); // 0x0000000182250BA0-0x0000000182250D70
		[NativeMethod(ThrowsException = true)]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetSceneAt(int index); // 0x0000000182250AD0-0x0000000182250B50
		[NativeMethod(ThrowsException = true)]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		private static AsyncOperation UnloadSceneAsyncInternal(Scene scene, UnloadSceneOptions options); // 0x00000001822516C0-0x0000000182251740
		private static AsyncOperation LoadSceneAsyncNameIndexInternal(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame); // 0x0000000182250F50-0x0000000182251030
		private static AsyncOperation UnloadSceneNameIndexInternal(string sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess); // 0x0000000182251900-0x00000001822519F0
		[NativeMethod(ThrowsException = true)]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static void MoveGameObjectToScene([NotNull] GameObject go, Scene scene); // 0x0000000182251510-0x00000001822515D0
		[RequiredByNativeCode]
		internal static AsyncOperation LoadFirstScene_Internal(bool async); // 0x0000000182250EE0-0x0000000182250F50
		public static void LoadScene(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode); // 0x00000001822512C0-0x0000000182251330
		[ExcludeFromDocs]
		public static void LoadScene(string sceneName); // 0x0000000182251460-0x00000001822514C0
		public static Scene LoadScene(string sceneName, LoadSceneParameters parameters); // 0x00000001822513C0-0x0000000182251460
		[ExcludeFromDocs]
		public static void LoadScene(int sceneBuildIndex); // 0x00000001822511F0-0x00000001822512C0
		public static Scene LoadScene(int sceneBuildIndex, LoadSceneParameters parameters); // 0x0000000182251330-0x00000001822513C0
		public static AsyncOperation LoadSceneAsync(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode); // 0x0000000182251030-0x00000001822510E0
		[ExcludeFromDocs]
		public static AsyncOperation LoadSceneAsync(string sceneName); // 0x00000001822510E0-0x0000000182251180
		public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters); // 0x0000000182251180-0x00000001822511F0
		public static AsyncOperation UnloadSceneAsync(string sceneName); // 0x00000001822517F0-0x0000000182251900
		public static AsyncOperation UnloadSceneAsync(Scene scene); // 0x0000000182251740-0x0000000182251790
		public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options); // 0x0000000182251790-0x00000001822517F0
		[RequiredByNativeCode]
		private static void Internal_SceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000182250DF0-0x0000000182250E70
		[RequiredByNativeCode]
		private static void Internal_SceneUnloaded(Scene scene); // 0x0000000182250E70-0x0000000182250EE0
		[RequiredByNativeCode]
		private static void Internal_ActiveSceneChanged(Scene previousActiveScene, Scene newActiveScene); // 0x0000000182250D70-0x0000000182250DF0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822519F0-0x0000000182251EF0
		private static void GetActiveScene_Injected(); // 0x00000001822509E0-0x0000000182250A20
		private static bool SetActiveScene_Injected(in Scene scene); // 0x00000001822515D0-0x0000000182251610
		private static void GetSceneByName_Injected(ref ManagedSpanWrapper name, ); // 0x0000000182250B50-0x0000000182250BA0
		private static void GetSceneAt_Injected(int index, ); // 0x0000000182250A90-0x0000000182250AD0
		private static IntPtr UnloadSceneAsyncInternal_Injected(in Scene scene, UnloadSceneOptions options); // 0x0000000182251680-0x00000001822516C0
		private static void MoveGameObjectToScene_Injected(IntPtr go, in Scene scene); // 0x00000001822514C0-0x0000000182251510
	}
}
