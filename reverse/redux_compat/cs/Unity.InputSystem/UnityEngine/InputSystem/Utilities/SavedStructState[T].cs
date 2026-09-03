/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal sealed class SavedStructState<T> : ISavedState // TypeDefIndex: 6636
		where T : struct
	{
		// Fields
		private T m_State;
		private TypedRestore m_RestoreAction;
		private Action m_StaticDisposeCurrentState;
	
		// Nested types
		public delegate void TypedRestore(ref ref T state); // TypeDefIndex: 6637; 0x00000000-0x00000000
	
		// Constructors
		internal SavedStructState(ref ref T state, TypedRestore restoreAction, Action staticDisposeCurrentState = null);
	
		// Methods
		public void StaticDisposeCurrentState();
		public void RestoreSavedState();
	}
}
