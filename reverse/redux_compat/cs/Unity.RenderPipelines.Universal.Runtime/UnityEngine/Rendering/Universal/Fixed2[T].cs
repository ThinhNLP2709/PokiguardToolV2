/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct Fixed2<T> // TypeDefIndex: 9506
		where T : struct
	{
		// Fields
		public T item1;
		public T item2;
	
		// Properties
		public T this[int index] { get => default; set {} }
	
		// Constructors
		public Fixed2(T item1);
		public Fixed2(T item1, T item2);
	
		// Methods
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckRange(int index);
	}
}
