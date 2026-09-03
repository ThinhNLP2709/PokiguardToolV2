/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public abstract class InputProcessor<TValue> : InputProcessor // TypeDefIndex: 6155
		where TValue : struct
	{
		// Constructors
		protected InputProcessor();
	
		// Methods
		public abstract TValue Process(TValue value, InputControl control);
		public override object ProcessAsObject(object value, InputControl control);
		public override unsafe void Process(void* buffer, int bufferSize, InputControl control);
	}
}
