/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	internal interface IGenericProviderOperation // TypeDefIndex: 13801
	{
		// Properties
		int ProvideHandleVersion { get; }
		IResourceLocation Location { get; }
		int DependencyCount { get; }
		Type RequestedType { get; }
	
		// Methods
		void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp);
		void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp, bool releaseDependenciesOnFailure);
		void GetDependencies(IList<object> dstList);
		TDepObject GetDependency<TDepObject>(int index);
		void SetProgressCallback(Func<float> callback);
		void ProviderCompleted<T>(T result, bool status, Exception e);
		void SetDownloadProgressCallback(Func<DownloadStatus> callback);
		void SetWaitForCompletionCallback(Func<bool> callback);
	}
}
