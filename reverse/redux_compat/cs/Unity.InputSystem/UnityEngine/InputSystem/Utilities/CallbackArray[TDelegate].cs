/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct CallbackArray<TDelegate> // TypeDefIndex: 6593
		where TDelegate : Delegate
	{
		// Fields
		private bool m_CannotMutateCallbacksArray;
		private InlinedArray<TDelegate> m_Callbacks;
		private InlinedArray<TDelegate> m_CallbacksToAdd;
		private InlinedArray<TDelegate> m_CallbacksToRemove;
	
		// Properties
		public int length { get; }
		public TDelegate this[int index] { get => default; }
	
		// Methods
		public void Clear();
		public void AddCallback(TDelegate dlg);
		public void RemoveCallback(TDelegate dlg);
		public void LockForChanges();
		public void UnlockForChanges();
	}
}
