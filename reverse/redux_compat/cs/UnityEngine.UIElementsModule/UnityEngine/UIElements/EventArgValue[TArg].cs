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

namespace UnityEngine.UIElements
{
	internal class EventArgValue<TArg> : EventArgValue // TypeDefIndex: 3991
	{
		// Fields
		private static readonly EqualityComparer<TArg> k_EqualityComparer;
		private static ObjectPool<EventArgValue<TArg>> s_Pool;
		private TArg value;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3992
		{
			// Fields
			public static readonly __c<TArg> __9;
			public static Func<EventArgValue<TArg>> __9__4_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal EventArgValue<TArg> _GetPooled_b__4_0();
		}
	
		// Constructors
		public EventArgValue();
		static EventArgValue();
	
		// Methods
		public static EventArgValue<TArg> GetPooled(int id, [IsReadOnly] in ref TArg value);
		public sealed override void Dispose();
		public sealed override void Invoke(EventBase evt, EventCallbackInternal c);
		public sealed override bool ValueEquals<TOtherArg>([IsReadOnly] in ref TOtherArg other);
		private bool ValueEquals([IsReadOnly] in ref TArg other);
	}
}
