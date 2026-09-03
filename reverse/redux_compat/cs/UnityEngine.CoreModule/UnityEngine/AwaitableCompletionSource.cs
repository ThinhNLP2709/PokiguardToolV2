/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public class AwaitableCompletionSource // TypeDefIndex: 7732
	{
		// Fields
		private int _state; // 0x10
		[CompilerGenerated]
		private Awaitable _Awaitable_k__BackingField; // 0x18
	
		// Properties
		public Awaitable Awaitable { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Methods
		private bool CheckAndAcquireCompletionState(); // 0x00000001821E2C90-0x00000001821E2CC0
		public bool TrySetResult(); // 0x00000001821E2CC0-0x00000001821E2D10
	}
}
