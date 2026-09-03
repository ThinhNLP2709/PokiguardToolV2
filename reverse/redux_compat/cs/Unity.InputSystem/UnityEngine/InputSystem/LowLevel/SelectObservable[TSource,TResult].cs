/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal class SelectObservable<TSource, TResult> : IObservable<TResult> // TypeDefIndex: 6510
	{
		// Fields
		private readonly IObservable<TSource> m_Source;
		private readonly Func<TSource, TResult> m_Filter;
	
		// Nested types
		private class Select : IObserver<TSource> // TypeDefIndex: 6511
		{
			// Fields
			private SelectObservable<TSource, TResult> m_Observable;
			private readonly IObserver<TResult> m_Observer;
	
			// Constructors
			public Select(SelectObservable<TSource, TResult> observable, IObserver<TResult> observer);
	
			// Methods
			public void OnCompleted();
			public void OnError(Exception error);
			public void OnNext(TSource evt);
		}
	
		// Constructors
		public SelectObservable(IObservable<TSource> source, Func<TSource, TResult> filter);
	
		// Methods
		public IDisposable Subscribe(IObserver<TResult> observer);
	}
}
