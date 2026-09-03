/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq.Expressions.Interpreter
{
	internal sealed class InterpretedFrame // TypeDefIndex: 12304
	{
		// Fields
		[ThreadStatic]
		private static InterpretedFrame s_currentFrame; // 0x80000000
		internal readonly Interpreter Interpreter; // 0x10
		internal InterpretedFrame _parent; // 0x18
		private readonly int[] _continuations; // 0x20
		private int _continuationIndex; // 0x28
		private int _pendingContinuation; // 0x2C
		private object _pendingValue; // 0x30
		public readonly object[] Data; // 0x38
		public readonly IStrongBox[] Closure; // 0x40
		public int StackIndex; // 0x48
		public int InstructionIndex; // 0x4C
	
		// Properties
		public string Name { get; } // 0x00000001817D0BC0-0x00000001817D0BE0 
		public InterpretedFrame Parent { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetStackTraceDebugInfo_d__29 : IEnumerable<InterpretedFrameInfo>, IEnumerator<InterpretedFrameInfo> // TypeDefIndex: 12305
		{
			// Fields
			private int __1__state; // 0x10
			private InterpretedFrameInfo __2__current; // 0x18
			private int __l__initialThreadId; // 0x28
			public InterpretedFrame __4__this; // 0x30
			private InterpretedFrame _frame_5__2; // 0x38
	
			// Properties
			InterpretedFrameInfo IEnumerator<System.Linq.Expressions.Interpreter.InterpretedFrameInfo>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001817E6D20-0x00000001817E6D70 
	
			// Constructors
			[DebuggerHidden]
			public _GetStackTraceDebugInfo_d__29(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001817E6A20-0x00000001817E6C40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001817E6CE0-0x00000001817E6D20
			[DebuggerHidden]
			IEnumerator<InterpretedFrameInfo> IEnumerable<InterpretedFrameInfo>.GetEnumerator(); // 0x00000001817E6C40-0x00000001817E6CE0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817E6C40-0x00000001817E6CE0
		}
	
		// Constructors
		internal InterpretedFrame(Interpreter interpreter, IStrongBox[] closure); // 0x00000001817D0AA0-0x00000001817D0BC0
	
		// Methods
		public DebugInfo GetDebugInfo(int instructionIndex); // 0x00000001817CFAB0-0x00000001817CFBF0
		public void Push(object value); // 0x00000001817D00F0-0x00000001817D0180
		public void Push(bool value); // 0x00000001817D03F0-0x00000001817D04F0
		public void Push(int value); // 0x00000001817D0360-0x00000001817D03F0
		public void Push(byte value); // 0x00000001817D0220-0x00000001817D02C0
		public void Push(sbyte value); // 0x00000001817D02C0-0x00000001817D0360
		public void Push(short value); // 0x00000001817D0180-0x00000001817D0220
		public void Push(ushort value); // 0x00000001817D04F0-0x00000001817D0590
		public object Pop(); // 0x00000001817CFF70-0x00000001817CFFB0
		internal void SetStackDepth(int depth); // 0x00000001817D0820-0x00000001817D0840
		public object Peek(); // 0x00000001817CFEA0-0x00000001817CFED0
		public void Dup(); // 0x00000001817CF990-0x00000001817CFA30
		[IteratorStateMachine(typeof(_GetStackTraceDebugInfo_d__29))]
		public IEnumerable<InterpretedFrameInfo> GetStackTraceDebugInfo(); // 0x00000001817CFBF0-0x00000001817CFC70
		internal void SaveTraceToException(Exception exception); // 0x00000001817D0590-0x00000001817D0820
		internal InterpretedFrame Enter(); // 0x00000001817CFA30-0x00000001817CFAB0
		internal void Leave(InterpretedFrame prevFrame); // 0x00000001817CFE50-0x00000001817CFEA0
		internal bool IsJumpHappened(); // 0x00000001817CFE40-0x00000001817CFE50
		public void RemoveContinuation(); // 0x0000000180E31880-0x0000000180E31890
		public void PushContinuation(int continuation); // 0x00000001817CFFB0-0x00000001817CFFF0
		public int YieldToCurrentContinuation(); // 0x00000001817D0840-0x00000001817D08C0
		public int YieldToPendingContinuation(); // 0x00000001817D08C0-0x00000001817D0AA0
		internal void PushPendingContinuation(); // 0x00000001817CFFF0-0x00000001817D00F0
		internal void PopPendingContinuation(); // 0x00000001817CFED0-0x00000001817CFF70
		public int Goto(int labelIndex, object value, bool gotoExceptionHandler); // 0x00000001817CFC70-0x00000001817CFE40
	}
}
