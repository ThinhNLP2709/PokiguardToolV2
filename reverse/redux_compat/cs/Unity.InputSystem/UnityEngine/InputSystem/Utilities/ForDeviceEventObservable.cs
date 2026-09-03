/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal class ForDeviceEventObservable : IObservable<InputEventPtr> // TypeDefIndex: 6617
	{
		// Fields
		private IObservable<InputEventPtr> m_Source; // 0x10
		private InputDevice m_Device; // 0x18
		private Type m_DeviceType; // 0x20
	
		// Nested types
		private class ForDevice : IObserver<InputEventPtr> // TypeDefIndex: 6618
		{
			// Fields
			private IObserver<InputEventPtr> m_Observer; // 0x10
			private InputDevice m_Device; // 0x18
			private Type m_DeviceType; // 0x20
	
			// Constructors
			public ForDevice(Type deviceType, InputDevice device, IObserver<InputEventPtr> observer); // 0x0000000181CF8BB0-0x0000000181CF8C20
	
			// Methods
			public void OnCompleted(); // 0x00000001802E76C0-0x00000001802E76D0
			public void OnError(Exception error); // 0x0000000181CF89E0-0x0000000181CF8A30
			public void OnNext(InputEventPtr value); // 0x0000000181CF8A30-0x0000000181CF8BB0
		}
	
		// Constructors
		public ForDeviceEventObservable(IObservable<InputEventPtr> source, Type deviceType, InputDevice device); // 0x0000000181CF8970-0x0000000181CF89E0
	
		// Methods
		public IDisposable Subscribe(IObserver<InputEventPtr> observer); // 0x0000000181CF8830-0x0000000181CF8970
	}
}
