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
	internal class EventCallbackPool // TypeDefIndex: 4020
	{
		// Fields
		internal static ObjectPool<EventCallbackInternal> s_Pool; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4021
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182477E80-0x0000000182477EF0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventCallbackInternal _.cctor_b__5_0(); // 0x0000000182477DE0-0x0000000182477E30
		}
	
		// Constructors
		public EventCallbackPool(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static EventCallbackPool(); // 0x0000000182471A60-0x0000000182471B70
	
		// Methods
		public EventCallbackInternal Get<TEvent>(Delegate userCallback, int argId, CallbackOptionsInternal callbackOptions)
			where TEvent : EventBase<TEvent>, new();
		public void Release(EventCallbackInternal c); // 0x00000001824719D0-0x0000000182471A60
	}
}
