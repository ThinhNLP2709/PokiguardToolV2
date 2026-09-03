/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Pool
{
	public struct PooledObject<T> : IDisposable // TypeDefIndex: 8171
		where T : class
	{
		// Fields
		private readonly T m_ToReturn;
		private readonly IObjectPool<T> m_Pool;
	
		// Constructors
		public PooledObject(T value, IObjectPool<T> pool);
	
		// Methods
		void IDisposable.Dispose();
	}
}
