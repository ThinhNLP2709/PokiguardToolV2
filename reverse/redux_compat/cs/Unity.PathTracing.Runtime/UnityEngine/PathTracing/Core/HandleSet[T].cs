/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class HandleSet<T> // TypeDefIndex: 13577
	{
		// Fields
		private readonly Stack<Handle<T>> _freeHandles;
		private ulong _nextHandleIndex;
	
		// Constructors
		public HandleSet();
	
		// Methods
		public Handle<T> Add();
		public void Remove(Handle<T> handle);
		public void Clear();
	}
}
