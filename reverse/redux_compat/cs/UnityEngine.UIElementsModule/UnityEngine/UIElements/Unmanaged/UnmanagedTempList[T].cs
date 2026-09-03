/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	internal struct UnmanagedTempList<T> : IDisposable // TypeDefIndex: 5000
		where T : struct
	{
		// Fields
		private NativeArray<T> m_NativeArray;
		private int m_Count;
	
		// Properties
		public ReadOnlySpan<T> Span { get; }
	
		// Constructors
		public UnmanagedTempList(int capacity);
	
		// Methods
		public void Add(T item);
		public void Dispose();
	}
}
