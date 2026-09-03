/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class EventCallbackListPool // TypeDefIndex: 4017
	{
		// Fields
		private readonly ObjectPool<EventCallbackList> m_Items; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4018
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<EventCallbackList> __9__4_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182477F60-0x0000000182477FD0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventCallbackList _.ctor_b__4_0(); // 0x0000000182477E30-0x0000000182477E80
		}
	
		// Constructors
		public EventCallbackListPool(); // 0x00000001824713C0-0x0000000182471500
	
		// Methods
		[NotNull]
		public EventCallbackList Get(); // 0x00000001824712F0-0x0000000182471340
		[NotNull]
		public EventCallbackList Get([NotNull] EventCallbackList initializer); // 0x0000000182471270-0x00000001824712F0
		public void Release(EventCallbackList element); // 0x0000000182471340-0x00000001824713C0
	}
}
