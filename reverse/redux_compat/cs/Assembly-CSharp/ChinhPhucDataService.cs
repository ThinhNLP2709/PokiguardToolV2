/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ChinhPhucDataService : MonoBehaviour // TypeDefIndex: 1162
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
	public static ChinhPhucDataService Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AE350-0x00000001804AE390 0x00000001804AE430-0x00000001804AE490
	public List<GroupDTO> Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	public bool IsLoading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0

	// Events
	public event Action OnDataChanged {
		add; // 0x00000001804AE2B0-0x00000001804AE350
		remove; // 0x00000001804AE390-0x00000001804AE430
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 1163
	{
		// Fields
		public List<GroupDTO> result; // 0x10
		public string err; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadCoroutine_b__0(List<GroupDTO> data); // 0x00000001803780D0-0x00000001803780E0
		internal void _LoadCoroutine_b__1(string error); // 0x00000001802FAF70-0x00000001802FAF80
	}

	[CompilerGenerated]
	private sealed class _LoadCoroutine_d__23 : IEnumerator<object> // TypeDefIndex: 1164
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChinhPhucDataService __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28
		private int _userId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadCoroutine_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804BD510-0x00000001804BDA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BDA10-0x00000001804BDA50
	}

	// Constructors
	public ChinhPhucDataService(); // 0x00000001804AE2A0-0x00000001804AE2B0

	// Methods
	private static int CurrentUserId(); // 0x00000001804ADE40-0x00000001804ADE80
	public static ChinhPhucDataService EnsureInstance(); // 0x00000001804ADE80-0x00000001804ADFE0
	private void Awake(); // 0x00000001804ADD00-0x00000001804ADE40
	private void OnDestroy(); // 0x00000001804AE110-0x00000001804AE1E0
	public void RequestLoad(bool forceRefresh = false /* Metadata: 0x0064D3F8 */); // 0x00000001804AE1E0-0x00000001804AE2A0
	public void Invalidate(); // 0x00000001804ADFE0-0x00000001804AE0A0
	[IteratorStateMachine(typeof(_LoadCoroutine_d__23))]
	private IEnumerator LoadCoroutine(); // 0x00000001804AE0A0-0x00000001804AE110
}

