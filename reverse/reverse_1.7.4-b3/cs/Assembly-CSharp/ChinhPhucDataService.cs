/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ChinhPhucDataService : MonoBehaviour // TypeDefIndex: 1760
{
	// Fields
	[CompilerGenerated]
	private static ChinhPhucDataService _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private List<GroupDTO> _Data_k__BackingField; // 0x20
	[CompilerGenerated]
	private bool _IsLoading_k__BackingField; // 0x28
	private int _dataOwnerUserId; // 0x2C
	[CompilerGenerated]
	private Action OnDataChanged; // 0x30
	private bool _pendingForceRefresh; // 0x38

	// Properties
	public static ChinhPhucDataService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808D3FA0-0x00000001808D3FE0 0x00000001808D3FE0-0x00000001808D4080
	public List<GroupDTO> Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public bool IsLoading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AD0-0x00000001802B4AE0 0x00000001808D4080-0x00000001808D4090

	// Events
	public event Action OnDataChanged {
		add; // 0x00000001808D40D0-0x00000001808D41C0
		remove; // 0x00000001808D41C0-0x00000001808D42B0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1761
	{
		// Fields
		public List<GroupDTO> result; // 0x10
		public string err; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadCoroutine_b__0(List<GroupDTO> data); // 0x00000001802D8A80-0x00000001802D8AE0
		internal void _LoadCoroutine_b__1(string error); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class _LoadCoroutine_d__23 : IEnumerator<object> // TypeDefIndex: 1762
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChinhPhucDataService __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadCoroutine_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001808D4AF0-0x00000001808D5290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D5290-0x00000001808D52D0
	}

	// Constructors
	public ChinhPhucDataService(); // 0x00000001808D4AA0-0x00000001808D4AF0

	// Methods
	private static int CurrentUserId(); // 0x00000001808D4090-0x00000001808D40D0
	public static ChinhPhucDataService EnsureInstance(); // 0x00000001808D42B0-0x00000001808D4470
	private void Awake(); // 0x00000001808D4470-0x00000001808D46E0
	private void OnDestroy(); // 0x00000001808D46E0-0x00000001808D4840
	public void RequestLoad(bool forceRefresh = false /* Metadata: 0x005F017A */); // 0x00000001808D4840-0x00000001808D4900
	public void Invalidate(); // 0x00000001808D4900-0x00000001808D4A00
	[IteratorStateMachine(typeof(_LoadCoroutine_d__23))]
	private IEnumerator LoadCoroutine(); // 0x00000001808D4A00-0x00000001808D4AA0
}

