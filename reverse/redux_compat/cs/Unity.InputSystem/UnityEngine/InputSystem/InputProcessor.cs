/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public abstract class InputProcessor // TypeDefIndex: 6153
	{
		// Fields
		internal static TypeTable s_Processors; // 0x00
	
		// Properties
		public virtual CachingPolicy cachingPolicy { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		public enum CachingPolicy // TypeDefIndex: 6154
		{
			CacheResult = 0,
			EvaluateOnEveryRead = 1
		}
	
		// Constructors
		protected InputProcessor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract object ProcessAsObject(object value, InputControl control);
		public abstract unsafe void Process(void* buffer, int bufferSize, InputControl control);
		internal static Type GetValueTypeFromType(Type processorType); // 0x0000000181D11B40-0x0000000181D11BE0
	}
}
