/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	[Serializable]
	public class AssetReference : IKeyEvaluator // TypeDefIndex: 14074
	{
		// Fields
		[FormerlySerializedAs("m_assetGUID")]
		[SerializeField]
		protected internal string m_AssetGUID; // 0x10
		[SerializeField]
		private string m_SubObjectName; // 0x18
		[SerializeField]
		private string m_SubObjectType; // 0x20
		private AsyncOperationHandle m_Operation; // 0x28
	
		// Properties
		public AsyncOperationHandle OperationHandle { get; internal set; } // 0x0000000181333180-0x00000001813331A0 0x0000000181333200-0x0000000181333220
		public virtual object RuntimeKey { get; } // 0x0000000181C74AA0-0x0000000181C74B20 
		public virtual string AssetGUID { get; } // 0x0000000180377550-0x0000000180377560 
		public virtual string SubObjectName { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal virtual Type SubObjectType { get; } // 0x0000000181C74B20-0x0000000181C74B90 
		public bool IsDone { get; } // 0x0000000181C74A90-0x0000000181C74AA0 
		public virtual UnityEngine.Object Asset { get; } // 0x0000000181C749F0-0x0000000181C74A90 
	
		// Constructors
		public AssetReference(); // 0x0000000181C74930-0x0000000181C74980
		public AssetReference(string guid); // 0x0000000181C74980-0x0000000181C749F0
	
		// Methods
		public bool IsValid(); // 0x0000000181C74240-0x0000000181C74250
		public override string ToString(); // 0x0000000181C74790-0x0000000181C747E0
		private static AsyncOperationHandle<T> CreateFailedOperation<T>();
		public virtual AsyncOperationHandle<TObject> LoadAssetAsync<TObject>();
		public virtual AsyncOperationHandle<SceneInstance> LoadSceneAsync(LoadSceneMode loadMode = LoadSceneMode.Single /* Metadata: 0x006A952D */, bool activateOnLoad = true /* Metadata: 0x006A952E */, int priority = 100 /* Metadata: 0x006A952F */); // 0x0000000181C74250-0x0000000181C74490
		public virtual AsyncOperationHandle<SceneInstance> UnLoadScene(); // 0x0000000181C747E0-0x0000000181C74930
		public virtual AsyncOperationHandle<GameObject> InstantiateAsync(Vector3 position, Quaternion rotation, Transform parent = null); // 0x0000000181C73EA0-0x0000000181C74080
		public virtual AsyncOperationHandle<GameObject> InstantiateAsync(Transform parent = null, bool instantiateInWorldSpace = false /* Metadata: 0x006A9531 */); // 0x0000000181C74080-0x0000000181C74240
		public virtual bool RuntimeKeyIsValid(); // 0x0000000181C74700-0x0000000181C74790
		public virtual void ReleaseAsset(); // 0x0000000181C74490-0x0000000181C74520
		public virtual void ReleaseInstance(GameObject obj); // 0x0000000181C74520-0x0000000181C74700
		public virtual bool ValidateAsset(UnityEngine.Object obj); // 0x00000001802E7990-0x00000001802E79A0
		public virtual bool ValidateAsset(string path); // 0x00000001802E7990-0x00000001802E79A0
	}
}
