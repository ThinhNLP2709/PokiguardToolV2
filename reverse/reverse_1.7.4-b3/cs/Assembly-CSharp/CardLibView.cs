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

[DisallowMultipleComponent]
public class CardLibView : LibPagedViewBase // TypeDefIndex: 2126
{
	// Fields
	private const string CELL_ART = "imgCard"; // Metadata: 0x005F05F0
	private const string CELL_NAME = "txtName"; // Metadata: 0x005F05F8
	private const string CARD_ART_DIR = "Image/Card/"; // Metadata: 0x005F0600
	private static readonly Color NameColor; // 0x00
	private readonly List<CardLibEntryDTO> _cards; // 0x68
	private bool _hasLoaded; // 0x70
	private bool _isLoading; // 0x71
	[NonSerialized]
	public Action onDataLoaded; // 0x78

	// Properties
	public int LoadedCount { get; } // 0x0000000180A086A0-0x0000000180A086C0 
	protected override int TotalCount { get; } // 0x0000000180A086A0-0x0000000180A086C0 
	protected override string EmptyMessage { get; } // 0x0000000180A0AE90-0x0000000180A0AEF0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2127
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_3; // 0x08

		// Constructors
		static __c(); // 0x0000000180A0C4A0-0x0000000180A0C540
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__18_3(string err); // 0x0000000180A0C540-0x0000000180A0C5C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2128
	{
		// Fields
		public CardLibView __4__this; // 0x10
		public bool ok; // 0x18
		public string firstError; // 0x20

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__0(CardLibResponse data); // 0x0000000180A0C5C0-0x0000000180A0C6E0
		internal void _LoadRoutine_b__1(string err); // 0x00000001802B4BC0-0x00000001802B4C20
		internal void _LoadRoutine_b__2(CardLibLegacyDTO[] arr); // 0x0000000180A0C6E0-0x0000000180A0C800
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 2129
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardLibView __4__this; // 0x20
		private __c__DisplayClass18_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180A0C800-0x0000000180A0CE90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A0CE90-0x0000000180A0CED0
	}

	// Constructors
	public CardLibView(); // 0x0000000180A0C350-0x0000000180A0C450
	static CardLibView(); // 0x0000000180A0C450-0x0000000180A0C4A0

	// Methods
	private void Reset(); // 0x0000000180A086E0-0x0000000180A086F0
	private void OnEnable(); // 0x0000000180A0AEF0-0x0000000180A0AF20
	private void OnDisable(); // 0x0000000180A0AF20-0x0000000180A0AF30
	public void EnsureLoaded(); // 0x0000000180A0AF30-0x0000000180A0B180
	[IteratorStateMachine(typeof(_LoadRoutine_d__18))]
	private IEnumerator LoadRoutine(); // 0x0000000180A0B180-0x0000000180A0B220
	protected override void BindCell(GameObject cell, int index); // 0x0000000180A0B220-0x0000000180A0BAB0
	private static string TooltipTitle(CardLibEntryDTO c); // 0x0000000180A0BAB0-0x0000000180A0BBF0
	private static string TooltipBody(CardLibEntryDTO c); // 0x0000000180A0BBF0-0x0000000180A0C0E0
	private static string LoaiVi(string code); // 0x0000000180A0C0E0-0x0000000180A0C350
}

