/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	internal class ManagedObjectStore<T> // TypeDefIndex: 5175
	{
		// Fields
		private readonly int m_ChunkSize;
		private int m_Length;
		private readonly List<T[]> m_Chunks;
		private readonly Queue<int> m_Free;
	
		// Constructors
		public ManagedObjectStore(int chunkSize = 2048 /* Metadata: 0x00660AF1 */);
	
		// Methods
		public T GetValue(int index);
		public void UpdateValue(ref int index, T value);
	}
}
