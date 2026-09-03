/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[EventCategory(EventCategory.ChangeValue)]
	public class ChangeEvent<T> : EventBase<UnityEngine.UIElements.ChangeEvent<T>> // TypeDefIndex: 3960
	{
		// Fields
		[CompilerGenerated]
		private T _previousValue_k__BackingField;
		[CompilerGenerated]
		private T _newValue_k__BackingField;
	
		// Properties
		public T previousValue { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public T newValue { [CompilerGenerated] get; [CompilerGenerated] protected set; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3961
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal ChangeEvent<T> _.cctor_b__0_0();
		}
	
		// Constructors
		static ChangeEvent();
		public ChangeEvent();
	
		// Methods
		protected override void Init();
		private new void LocalInit();
		public static ChangeEvent<T> GetPooled(T previousValue, T newValue);
	}
}
