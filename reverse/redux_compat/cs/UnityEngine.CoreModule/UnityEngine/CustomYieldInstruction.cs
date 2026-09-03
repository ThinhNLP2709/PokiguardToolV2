/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public abstract class CustomYieldInstruction : IEnumerator // TypeDefIndex: 7741
	{
		// Properties
		public abstract bool keepWaiting { get; }
		public object Current { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		protected CustomYieldInstruction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool MoveNext(); // 0x0000000181542050-0x0000000181542070
		public virtual void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
