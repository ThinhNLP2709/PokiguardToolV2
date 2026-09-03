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
	public abstract class InputControl<TValue> : InputControl // TypeDefIndex: 6134
		where TValue : struct
	{
		// Fields
		internal InlinedArray<InputProcessor<TValue>> m_ProcessorStack;
		private TValue m_CachedValue;
		private TValue m_UnprocessedCachedValue;
		internal bool evaluateProcessorsEveryRead;
	
		// Properties
		public override Type valueType { get; }
		public override int valueSizeInBytes { get; }
		[IsReadOnly]
		public ref TValue value { get; }
		[IsReadOnly]
		internal ref TValue unprocessedValue { get; }
		internal InputProcessor<TValue>[] processors { get; }
	
		// Constructors
		protected InputControl();
	
		// Methods
		public TValue ReadValue();
		public TValue ReadValueFromPreviousFrame();
		public TValue ReadDefaultValue();
		public unsafe TValue ReadValueFromState(void* statePtr);
		public unsafe TValue ReadValueFromStateWithCaching(void* statePtr);
		public unsafe TValue ReadUnprocessedValueFromStateWithCaching(void* statePtr);
		public TValue ReadUnprocessedValue();
		public abstract unsafe TValue ReadUnprocessedValueFromState(void* statePtr);
		public override unsafe object ReadValueFromStateAsObject(void* statePtr);
		public override unsafe void ReadValueFromStateIntoBuffer(void* statePtr, void* bufferPtr, int bufferSize);
		public override unsafe void WriteValueFromBufferIntoState(void* bufferPtr, int bufferSize, void* statePtr);
		public override unsafe void WriteValueFromObjectIntoState(object value, void* statePtr);
		public virtual unsafe void WriteValueIntoState(TValue value, void* statePtr);
		public override unsafe object ReadValueFromBufferAsObject(void* buffer, int bufferSize);
		private static bool CompareValue(ref ref TValue firstValue, ref ref TValue secondValue);
		public override unsafe bool CompareValue(void* firstStatePtr, void* secondStatePtr);
		public TValue ProcessValue(TValue value);
		public void ProcessValue(ref ref TValue value);
		internal TProcessor TryGetProcessor<TProcessor>()
			where TProcessor : InputProcessor<TValue>;
		internal override void AddProcessor(object processor);
		protected override void FinishSetup();
	}
}
