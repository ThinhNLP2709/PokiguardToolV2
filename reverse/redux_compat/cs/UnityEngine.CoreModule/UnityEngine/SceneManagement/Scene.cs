/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.SceneManagement
{
	[Serializable]
	[NativeHeader("Runtime/Export/SceneManager/Scene.bindings.h")]
	public struct Scene // TypeDefIndex: 8000
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private SceneHandle m_Handle; // 0x00
	
		// Properties
		public SceneHandle handle { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		internal string guid { get; } // 0x0000000182253150-0x0000000182253160 
		public string name { get; } // 0x00000001822531A0-0x00000001822531B0 
		public bool isLoaded { get; } // 0x0000000182253160-0x00000001822531A0 
		public int buildIndex { get; } // 0x0000000182253110-0x0000000182253150 
		public int rootCount { get; } // 0x00000001822531B0-0x00000001822531F0 
	
		// Methods
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static bool IsValidInternal(SceneHandle sceneHandle); // 0x0000000182252F10-0x0000000182252F50
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static string GetNameInternal(SceneHandle sceneHandle); // 0x0000000182252A80-0x0000000182252B50
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static string GetGUIDInternal(SceneHandle sceneHandle); // 0x00000001822528E0-0x00000001822529B0
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static bool GetIsLoadedInternal(SceneHandle sceneHandle); // 0x00000001822529F0-0x0000000182252A30
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static int GetBuildIndexInternal(SceneHandle sceneHandle); // 0x0000000182252850-0x0000000182252890
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static int GetRootCountInternal(SceneHandle sceneHandle); // 0x0000000182252B90-0x0000000182252BD0
		[NativeMethod("GetRootGameObjectsInternal")]
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		private static void GetRootGameObjectsInternalArray(SceneHandle sceneHandle, out GameObject[] resultRootArray); // 0x0000000182252C20-0x0000000182252C60
		public bool IsValid(); // 0x0000000182252F50-0x0000000182252F90
		private bool ValidateGetRootGameObjects(); // 0x0000000182252F90-0x0000000182253110
		public GameObject[] GetRootGameObjects(); // 0x0000000182252C60-0x0000000182252ED0
		public static bool operator ==(Scene lhs, Scene rhs); // 0x0000000181524170-0x0000000181524180
		public static bool operator !=(Scene lhs, Scene rhs); // 0x00000001822500C0-0x00000001822500E0
		public override int GetHashCode(); // 0x0000000182250090-0x00000001822500A0
		public override bool Equals(object other); // 0x0000000182252780-0x0000000182252810
		private static bool IsValidInternal_Injected(in SceneHandle sceneHandle); // 0x0000000182252ED0-0x0000000182252F10
		private static void GetNameInternal_Injected(in SceneHandle sceneHandle, ); // 0x0000000182252A30-0x0000000182252A80
		private static void GetGUIDInternal_Injected(in SceneHandle sceneHandle, ); // 0x0000000182252890-0x00000001822528E0
		private static bool GetIsLoadedInternal_Injected(in SceneHandle sceneHandle); // 0x00000001822529B0-0x00000001822529F0
		private static int GetBuildIndexInternal_Injected(in SceneHandle sceneHandle); // 0x0000000182252810-0x0000000182252850
		private static int GetRootCountInternal_Injected(in SceneHandle sceneHandle); // 0x0000000182252B50-0x0000000182252B90
		private static void GetRootGameObjectsInternalArray_Injected(in SceneHandle sceneHandle, out GameObject[] resultRootArray); // 0x0000000182252BD0-0x0000000182252C20
	}
}
