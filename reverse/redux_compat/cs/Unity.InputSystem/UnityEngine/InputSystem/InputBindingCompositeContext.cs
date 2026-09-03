/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public struct InputBindingCompositeContext // TypeDefIndex: 6109
	{
		// Fields
		internal InputActionState m_State; // 0x00
		internal int m_BindingIndex; // 0x08
	
		// Properties
		public IEnumerable<PartBinding> controls { [IteratorStateMachine(typeof(_get_controls_d__2))] get; } // 0x0000000181D04870-0x0000000181D048F0 
	
		// Nested types
		public struct PartBinding // TypeDefIndex: 6110
		{
			// Fields
			[CompilerGenerated]
			private int _part_k__BackingField; // 0x00
			[CompilerGenerated]
			private InputControl _control_k__BackingField; // 0x08
	
			// Properties
			public int part { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
			public InputControl control { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		}
	
		private struct DefaultComparer<TValue> : IComparer<TValue> // TypeDefIndex: 6111
			where TValue : IComparable<TValue>
		{
			// Methods
			public int Compare(TValue x, TValue y);
		}
	
		[CompilerGenerated]
		private sealed class _get_controls_d__2 : IEnumerable<PartBinding>, IEnumerator<PartBinding> // TypeDefIndex: 6112
		{
			// Fields
			private int __1__state; // 0x10
			private PartBinding __2__current; // 0x18
			private int __l__initialThreadId; // 0x28
			public InputBindingCompositeContext __4__this; // 0x30
			public InputBindingCompositeContext __3____4__this; // 0x40
			private int _totalBindingCount_5__2; // 0x50
			private int _bindingIndex_5__3; // 0x54
			private InputActionState.BindingState _bindingState_5__4; // 0x58
			private int _controlStartIndex_5__5; // 0x78
			private int _i_5__6; // 0x7C
	
			// Properties
			PartBinding IEnumerator<UnityEngine.InputSystem.InputBindingCompositeContext.PartBinding>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181D1A900-0x0000000181D1ABA0 
	
			// Constructors
			[DebuggerHidden]
			public _get_controls_d__2(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000181D1A6E0-0x0000000181D1A820
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D1A8C0-0x0000000181D1A900
			[DebuggerHidden]
			IEnumerator<PartBinding> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputBindingCompositeContext.PartBinding>.GetEnumerator(); // 0x0000000181D1A820-0x0000000181D1A8C0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D1A820-0x0000000181D1A8C0
		}
	
		// Methods
		public float EvaluateMagnitude(int partNumber); // 0x0000000181D04710-0x0000000181D04740
		public TValue ReadValue<TValue>(int partNumber)
			where TValue : struct, IComparable<TValue>;
		public TValue ReadValue<TValue>(int partNumber, out InputControl sourceControl)
			where TValue : struct, IComparable<TValue>;
		public TValue ReadValue<TValue, TComparer>(int partNumber, TComparer comparer = default)
			where TValue : struct
			where TComparer : IComparer<TValue>;
		public TValue ReadValue<TValue, TComparer>(int partNumber, out InputControl sourceControl, TComparer comparer = default)
			where TValue : struct
			where TComparer : IComparer<TValue>;
		public bool ReadValueAsButton(int partNumber); // 0x0000000181D04770-0x0000000181D04810
		public unsafe void ReadValue(int partNumber, void* buffer, int bufferSize); // 0x0000000181D04840-0x0000000181D04870
		public object ReadValueAsObject(int partNumber); // 0x0000000181D04810-0x0000000181D04840
		public double GetPressTime(int partNumber); // 0x0000000181D04740-0x0000000181D04770
	}
}
