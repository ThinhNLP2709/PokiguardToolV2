/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class CircularRangeBuffer<T> : IDisposable // TypeDefIndex: 5026
		where T : struct
	{
		// Fields
		private Queue<PageInfo> m_PreviousPages;
		private NativeArray<T> m_CurrentPage;
		private int m_AllocHead;
		private int m_FreeHead;
		private int m_Count;
		private int m_Wasted;
		private int m_Capacity;
		[CompilerGenerated]
		private bool _disposed_k__BackingField;
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Nested types
		private class PageInfo // TypeDefIndex: 5027
		{
			// Fields
			public NativeArray<T> array;
			public int count;
	
			// Constructors
			public PageInfo();
		}
	
		// Constructors
		public CircularRangeBuffer(int capacity);
	
		// Methods
		private void CreateNewPage(int capacity);
		private NativeSlice<T> AllocateFromNewPage(int count);
		public NativeSlice<T> Allocate(int count);
		public void Free(int count);
		public void Dispose();
		protected virtual void Dispose(bool disposing);
	}
}
