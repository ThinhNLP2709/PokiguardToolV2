/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct Observable<T> // TypeDefIndex: 5391
	{
		// Fields
		[CompilerGenerated]
		private Action<T> onValueChanged;
		private T m_Value;
	
		// Properties
		public T value { get; set; }
	
		// Events
		public event Action<T> onValueChanged {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Constructors
		public Observable(T newValue);
	}
}
