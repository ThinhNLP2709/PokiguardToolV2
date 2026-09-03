/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public struct ProvideHandle // TypeDefIndex: 13753
	{
		// Fields
		private int m_Version; // 0x00
		private IGenericProviderOperation m_InternalOp; // 0x08
		private ResourceManager m_ResourceManager; // 0x10
	
		// Properties
		internal bool IsValid { get; } // 0x0000000182050D60-0x0000000182050DC0 
		internal IGenericProviderOperation InternalOp { get; } // 0x0000000182050CC0-0x0000000182050D60 
		public ResourceManager ResourceManager { get; } // 0x0000000180377550-0x0000000180377560 
		public Type Type { get; } // 0x0000000182050E20-0x0000000182050E80 
		public IResourceLocation Location { get; } // 0x0000000182050DC0-0x0000000182050E20 
		public int DependencyCount { get; } // 0x0000000182050C60-0x0000000182050CC0 
	
		// Constructors
		internal ProvideHandle(ResourceManager rm, IGenericProviderOperation op); // 0x0000000182050BD0-0x0000000182050C60
	
		// Methods
		public TDepObject GetDependency<TDepObject>(int index);
		public void GetDependencies(IList<object> list); // 0x00000001820508F0-0x0000000182050960
		public void SetProgressCallback(Func<float> callback); // 0x0000000182050A30-0x0000000182050B00
		public void SetDownloadProgressCallbacks(Func<DownloadStatus> callback); // 0x0000000182050960-0x0000000182050A30
		public void SetWaitForCompletionCallback(Func<bool> callback); // 0x0000000182050B00-0x0000000182050BD0
		public void Complete<T>(T result, bool status, Exception exception);
	}
}
