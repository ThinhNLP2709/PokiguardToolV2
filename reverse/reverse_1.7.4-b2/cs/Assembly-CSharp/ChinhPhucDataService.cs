/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChinhPhucDataService : MonoBehaviour // TypeDefIndex: 1378
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
	public static ChinhPhucDataService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A9B40-0x00000001805A9B80 0x00000001805A9C20-0x00000001805A9C80
	public List<GroupDTO> Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF660-0x00000001802FF670 0x0000000180308AD0-0x0000000180308AE0
	public bool IsLoading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180385C40-0x0000000180385C50 0x00000001805A9C80-0x00000001805A9C90

	// Events
	public event Action OnDataChanged {
		add; // 0x00000001805A9AA0-0x00000001805A9B40
		remove; // 0x00000001805A9B80-0x00000001805A9C20
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1379
	{
		// Fields
		public List<GroupDTO> result; // 0x10
		public string err; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadCoroutine_b__0(List<GroupDTO> data); // 0x0000000180317090-0x00000001803170A0
		internal void _LoadCoroutine_b__1(string error); // 0x0000000180317080-0x0000000180317090
	}

	[CompilerGenerated]
	private sealed class _LoadCoroutine_d__23 : IEnumerator<object> // TypeDefIndex: 1380
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChinhPhucDataService __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadCoroutine_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805B95E0-0x00000001805B9AE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B9AE0-0x00000001805B9B20
	}

	// Constructors
	public ChinhPhucDataService(); // 0x00000001805A9A90-0x00000001805A9AA0

	// Methods
	private static int CurrentUserId(); // 0x00000001805A9630-0x00000001805A9670
	public static ChinhPhucDataService EnsureInstance(); // 0x00000001805A9670-0x00000001805A97D0
	private void Awake(); // 0x00000001805A94F0-0x00000001805A9630
	private void OnDestroy(); // 0x00000001805A9900-0x00000001805A99D0
	public void RequestLoad(bool forceRefresh = false /* Metadata: 0x0068CF53 */); // 0x00000001805A99D0-0x00000001805A9A90
	public void Invalidate(); // 0x00000001805A97D0-0x00000001805A9890
	[IteratorStateMachine(typeof(_LoadCoroutine_d__23))]
	private IEnumerator LoadCoroutine(); // 0x00000001805A9890-0x00000001805A9900
}

