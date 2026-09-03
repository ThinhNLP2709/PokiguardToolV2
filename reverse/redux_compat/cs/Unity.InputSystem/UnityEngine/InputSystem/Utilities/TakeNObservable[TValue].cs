/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal class TakeNObservable<TValue> : IObservable<TValue> // TypeDefIndex: 6624
	{
		// Fields
		private IObservable<TValue> m_Source;
		private int m_Count;
	
		// Nested types
		private class Take : IObserver<TValue> // TypeDefIndex: 6625
		{
			// Fields
			private IObserver<TValue> m_Observer;
			private int m_Remaining;
	
			// Constructors
			public Take(TakeNObservable<TValue> observable, IObserver<TValue> observer);
	
			// Methods
			public void OnCompleted();
			public void OnError(Exception error);
			public void OnNext(TValue evt);
		}
	
		// Constructors
		public TakeNObservable(IObservable<TValue> source, int count);
	
		// Methods
		public IDisposable Subscribe(IObserver<TValue> observer);
	}
}
