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
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class ObjectPool<T> // TypeDefIndex: 4267
		where T : new()
	{
		// Fields
		private readonly Stack<T> m_Stack;
		private int m_MaxSize;
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal Func<T> CreateFunc;
	
		// Properties
		public int maxSize { get; set; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4268
		{
			// Fields
			public static readonly __c<T> __9;
			public static Func<T> __9__6_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal T _.ctor_b__6_0();
		}
	
		// Constructors
		public ObjectPool(Func<T> CreateFunc, int maxSize = 100 /* Metadata: 0x00660678 */);
	
		// Methods
		public int Size();
		public T Get();
		public void Release(T element);
	}
}
