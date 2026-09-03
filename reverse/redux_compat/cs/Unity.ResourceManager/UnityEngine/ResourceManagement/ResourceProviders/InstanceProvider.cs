/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public class InstanceProvider : IInstanceProvider // TypeDefIndex: 13760
	{
		// Fields
		private Dictionary<GameObject, AsyncOperationHandle<GameObject>> m_InstanceObjectToPrefabHandle; // 0x10
	
		// Constructors
		public InstanceProvider(); // 0x000000018204B750-0x000000018204B7D0
	
		// Methods
		public GameObject ProvideInstance(ResourceManager resourceManager, AsyncOperationHandle<GameObject> prefabHandle, InstantiationParameters instantiateParameters); // 0x000000018204B4A0-0x000000018204B560
		public void ReleaseInstance(ResourceManager resourceManager, GameObject instance); // 0x000000018204B560-0x000000018204B750
	}
}
