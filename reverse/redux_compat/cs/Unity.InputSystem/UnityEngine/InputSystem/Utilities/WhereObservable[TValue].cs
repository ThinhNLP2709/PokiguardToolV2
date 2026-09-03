/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal class WhereObservable<TValue> : IObservable<TValue> // TypeDefIndex: 6626
	{
		// Fields
		private readonly IObservable<TValue> m_Source;
		private readonly Func<TValue, bool> m_Predicate;
	
		// Nested types
		private class Where : IObserver<TValue> // TypeDefIndex: 6627
		{
			// Fields
			private WhereObservable<TValue> m_Observable;
			private readonly IObserver<TValue> m_Observer;
	
			// Constructors
			public Where(WhereObservable<TValue> observable, IObserver<TValue> observer);
	
			// Methods
			public void OnCompleted();
			public void OnError(Exception error);
			public void OnNext(TValue evt);
		}
	
		// Constructors
		public WhereObservable(IObservable<TValue> source, Func<TValue, bool> predicate);
	
		// Methods
		public IDisposable Subscribe(IObserver<TValue> observer);
	}
}
