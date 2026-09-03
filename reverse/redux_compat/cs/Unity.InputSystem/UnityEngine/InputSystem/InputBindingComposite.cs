/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public abstract class InputBindingComposite // TypeDefIndex: 6106
	{
		// Fields
		internal static TypeTable s_Composites; // 0x00
	
		// Properties
		public abstract Type valueType { get; }
		public abstract int valueSizeInBytes { get; }
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetPartNames_d__12 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 6107
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private string composite; // 0x28
			public string __3__composite; // 0x30
			private FieldInfo[] __7__wrap1; // 0x38
			private int __7__wrap2; // 0x40
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetPartNames_d__12(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
			private bool MoveNext(); // 0x0000000181D19E50-0x0000000181D1A040
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D1A0E0-0x0000000181D1A120
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x0000000181D1A040-0x0000000181D1A0E0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D1A040-0x0000000181D1A0E0
		}
	
		// Constructors
		protected InputBindingComposite(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract unsafe void ReadValue(ref InputBindingCompositeContext context, void* buffer, int bufferSize);
		public abstract object ReadValueAsObject(ref InputBindingCompositeContext context);
		public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181D048F0-0x0000000181D04900
		protected virtual void FinishSetup(ref InputBindingCompositeContext context); // 0x00000001802E76C0-0x00000001802E76D0
		internal void CallFinishSetup(ref InputBindingCompositeContext context); // 0x0000000181B591A0-0x0000000181B591C0
		internal static Type GetValueType(string composite); // 0x0000000181D04C20-0x0000000181D04D10
		public static string GetExpectedControlLayoutName(string composite, string part); // 0x0000000181D049F0-0x0000000181D04BA0
		[IteratorStateMachine(typeof(_GetPartNames_d__12))]
		internal static IEnumerable<string> GetPartNames(string composite); // 0x0000000181D04BA0-0x0000000181D04C20
		internal static string GetDisplayFormatString(string composite); // 0x0000000181D04900-0x0000000181D049F0
	}
}
