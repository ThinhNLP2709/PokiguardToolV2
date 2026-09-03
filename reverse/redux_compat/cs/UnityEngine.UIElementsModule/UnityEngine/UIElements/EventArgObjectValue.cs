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
	internal class EventArgObjectValue : EventArgValue // TypeDefIndex: 3987
	{
		// Fields
		private static readonly ObjectPool<EventArgObjectValue> k_Pool; // 0x00
		private object value; // 0x20
		private Action<EventArgObjectValue, EventBase, EventCallbackInternal> invoke; // 0x28
	
		// Nested types
		private static class Invoker<TArg> // TypeDefIndex: 3988
		{
			// Fields
			public static readonly Action<EventArgObjectValue, EventBase, EventCallbackInternal> k_Invoke;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3989
			{
				// Fields
				public static readonly __c<TArg> __9;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal void _.cctor_b__1_0(EventArgObjectValue self, EventBase evt, EventCallbackInternal c);
			}
	
			// Constructors
			static Invoker();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3990
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823B21D0-0x00000001823B2240
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventArgObjectValue _.cctor_b__9_0(); // 0x00000001823B1E40-0x00000001823B1EC0
		}
	
		// Constructors
		public EventArgObjectValue(); // 0x000000018239D260-0x000000018239D2B0
		static EventArgObjectValue(); // 0x000000018239D150-0x000000018239D260
	
		// Methods
		public static EventArgObjectValue GetPooled<TArg>(int id, [IsReadOnly] in ref TArg value);
		public sealed override void Dispose(); // 0x000000018239D070-0x000000018239D110
		public sealed override void Invoke(EventBase evt, EventCallbackInternal c); // 0x000000018239D110-0x000000018239D150
		public sealed override bool ValueEquals<TArg>([IsReadOnly] in ref TArg other);
	}
}
