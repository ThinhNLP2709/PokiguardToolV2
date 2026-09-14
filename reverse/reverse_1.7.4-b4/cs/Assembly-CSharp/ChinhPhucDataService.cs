/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ChinhPhucDataService : MonoBehaviour // TypeDefIndex: 1762
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
	public static ChinhPhucDataService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808D6EA0-0x00000001808D6EE0 0x00000001808D6EE0-0x00000001808D6F80
	public List<GroupDTO> Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public bool IsLoading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AD0-0x00000001802B4AE0 0x00000001808D6F80-0x00000001808D6F90

	// Events
	public event Action OnDataChanged {
		add; // 0x00000001808D6FD0-0x00000001808D70C0
		remove; // 0x00000001808D70C0-0x00000001808D71B0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1763
	{
		// Fields
		public List<GroupDTO> result; // 0x10
		public string err; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadCoroutine_b__0(List<GroupDTO> data); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _LoadCoroutine_b__1(string error); // 0x00000001802B4F80-0x00000001802B4FE0
	}

	[CompilerGenerated]
	private sealed class _LoadCoroutine_d__23 : IEnumerator<object> // TypeDefIndex: 1764
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
		private bool MoveNext(); // 0x00000001808D79F0-0x00000001808D81C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D81C0-0x00000001808D8200
	}

	// Constructors
	public ChinhPhucDataService(); // 0x00000001808D79A0-0x00000001808D79F0

	// Methods
	private static int CurrentUserId(); // 0x00000001808D6F90-0x00000001808D6FD0
	public static ChinhPhucDataService EnsureInstance(); // 0x00000001808D71B0-0x00000001808D7370
	private void Awake(); // 0x00000001808D7370-0x00000001808D75E0
	private void OnDestroy(); // 0x00000001808D75E0-0x00000001808D7740
	public void RequestLoad(bool forceRefresh = false /* Metadata: 0x005F154B */); // 0x00000001808D7740-0x00000001808D7800
	public void Invalidate(); // 0x00000001808D7800-0x00000001808D7900
	[IteratorStateMachine(typeof(_LoadCoroutine_d__23))]
	private IEnumerator LoadCoroutine(); // 0x00000001808D7900-0x00000001808D79A0
}

