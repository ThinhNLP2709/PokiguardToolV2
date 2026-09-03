/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal class SelectManyObservable<TSource, TResult> : IObservable<TResult> // TypeDefIndex: 6622
	{
		// Fields
		private readonly IObservable<TSource> m_Source;
		private readonly Func<TSource, IEnumerable<TResult>> m_Filter;
	
		// Nested types
		private class Select : IObserver<TSource> // TypeDefIndex: 6623
		{
			// Fields
			private SelectManyObservable<TSource, TResult> m_Observable;
			private readonly IObserver<TResult> m_Observer;
	
			// Constructors
			public Select(SelectManyObservable<TSource, TResult> observable, IObserver<TResult> observer);
	
			// Methods
			public void OnCompleted();
			public void OnError(Exception error);
			public void OnNext(TSource evt);
		}
	
		// Constructors
		public SelectManyObservable(IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> filter);
	
		// Methods
		public IDisposable Subscribe(IObserver<TResult> observer);
	}
}
