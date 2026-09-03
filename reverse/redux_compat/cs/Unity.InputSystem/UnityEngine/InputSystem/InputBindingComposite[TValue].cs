/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public abstract class InputBindingComposite<TValue> : InputBindingComposite // TypeDefIndex: 6108
		where TValue : struct
	{
		// Properties
		public override Type valueType { get; }
		public override int valueSizeInBytes { get; }
	
		// Constructors
		protected InputBindingComposite();
	
		// Methods
		public abstract TValue ReadValue(ref InputBindingCompositeContext context);
		public override unsafe void ReadValue(ref InputBindingCompositeContext context, void* buffer, int bufferSize);
		public override object ReadValueAsObject(ref InputBindingCompositeContext context);
	}
}
