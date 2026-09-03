/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.AsyncOperations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal sealed class AsyncOpHandlesCacheKey : IOperationCacheKey // TypeDefIndex: 13710
	{
		// Fields
		private readonly HashSet<AsyncOperationHandle> m_Handles; // 0x10
	
		// Constructors
		public AsyncOpHandlesCacheKey(IList<AsyncOperationHandle> handles); // 0x00000001820468C0-0x0000000182046950
	
		// Methods
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
		public override bool Equals(object obj); // 0x0000000182046740-0x0000000182046800
		public bool Equals(IOperationCacheKey other); // 0x0000000182046800-0x00000001820468C0
		private bool Equals(AsyncOpHandlesCacheKey other); // 0x00000001820466C0-0x0000000182046740
	}
}
