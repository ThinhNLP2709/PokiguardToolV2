/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[DebuggerDisplay("ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}")]
	[DebuggerTypeProxy(typeof(LazyDebugView<T>))]
	public class Lazy<T> // TypeDefIndex: 2295
	{
		// Fields
		private LazyHelper _state;
		private Func<T> _factory;
		private T _value;
	
		// Properties
		public bool IsValueCreated { get; }
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public T Value { get; }
	
		// Constructors
		public Lazy();
		public Lazy(Func<T> valueFactory);
		public Lazy(bool isThreadSafe);
		public Lazy(Func<T> valueFactory, bool isThreadSafe);
		private Lazy(Func<T> valueFactory, LazyThreadSafetyMode mode, bool useDefaultConstructor);
	
		// Methods
		private static T CreateViaDefaultConstructor();
		private void ViaConstructor();
		private void ViaFactory(LazyThreadSafetyMode mode);
		private void ExecutionAndPublication(LazyHelper executionAndPublication, bool useDefaultConstructor);
		private void PublicationOnly(LazyHelper publicationOnly, T possibleValue);
		private void PublicationOnlyViaConstructor(LazyHelper initializer);
		private void PublicationOnlyViaFactory(LazyHelper initializer);
		private void PublicationOnlyWaitForOtherThreadToPublish();
		private T CreateValue();
		public override string ToString();
	}
}
