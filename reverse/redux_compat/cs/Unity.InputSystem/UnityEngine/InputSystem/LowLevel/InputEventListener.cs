/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct InputEventListener : IObservable<InputEventPtr> // TypeDefIndex: 6465
	{
		// Fields
		internal static ObserverState s_ObserverState; // 0x00
	
		// Nested types
		internal class ObserverState // TypeDefIndex: 6466
		{
			// Fields
			public InlinedArray<IObserver<InputEventPtr>> observers; // 0x10
			public Action<InputEventPtr, InputDevice> onEventDelegate; // 0x28
	
			// Constructors
			public ObserverState(); // 0x0000000181DCF990-0x0000000181DCFA10
	
			// Methods
			[CompilerGenerated]
			private void _.ctor_b__2_0(InputEventPtr eventPtr, InputDevice device); // 0x0000000181DCF880-0x0000000181DCF990
		}
	
		private class DisposableObserver : IDisposable // TypeDefIndex: 6467
		{
			// Fields
			public IObserver<InputEventPtr> observer; // 0x10
	
			// Constructors
			public DisposableObserver(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Dispose(); // 0x0000000181DBF880-0x0000000181DBF9C0
		}
	
		// Methods
		public static InputEventListener operator +(InputEventListener _, Action<InputEventPtr, InputDevice> callback); // 0x0000000181DCB590-0x0000000181DCB700
		public static InputEventListener operator -(InputEventListener _, Action<InputEventPtr, InputDevice> callback); // 0x0000000181DCB700-0x0000000181DCB870
		public IDisposable Subscribe(IObserver<InputEventPtr> observer); // 0x0000000181DCB390-0x0000000181DCB590
	}
}
