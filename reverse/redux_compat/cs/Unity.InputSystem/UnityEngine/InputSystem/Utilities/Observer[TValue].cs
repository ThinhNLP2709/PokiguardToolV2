/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal class Observer<TValue> : IObserver<TValue> // TypeDefIndex: 6621
	{
		// Fields
		private Action<TValue> m_OnNext;
		private Action m_OnCompleted;
	
		// Constructors
		public Observer(Action<TValue> onNext, Action onCompleted = null);
	
		// Methods
		public void OnCompleted();
		public void OnError(Exception error);
		public void OnNext(TValue evt);
	}
}
