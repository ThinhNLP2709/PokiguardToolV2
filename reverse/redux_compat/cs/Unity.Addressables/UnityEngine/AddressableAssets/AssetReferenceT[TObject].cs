/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	[Serializable]
	public class AssetReferenceT<TObject> : AssetReference // TypeDefIndex: 14067
		where TObject : UnityEngine.Object
	{
		// Constructors
		public AssetReferenceT(string guid);
	
		// Methods
		public virtual AsyncOperationHandle<TObject> LoadAssetAsync();
		public override bool ValidateAsset(UnityEngine.Object obj);
		public override bool ValidateAsset(string mainAssetPath);
	}
}
