/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal struct NativeCustomSliceEnumerator<T> : IEnumerable<T>, IEnumerator<T> // TypeDefIndex: 14373
		where T : struct
	{
		// Fields
		private NativeCustomSlice<T> nativeCustomSlice;
		private int index;
	
		// Properties
		public T Current { get; }
		object IEnumerator.Current { get; }
	
		// Constructors
		internal NativeCustomSliceEnumerator(NativeSlice<byte> slice, int length, int stride);
	
		// Methods
		public IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public bool MoveNext();
		public void Reset();
		void IDisposable.Dispose();
	}
}
