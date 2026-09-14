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

[DisallowMultipleComponent]
public class CardLibView : LibPagedViewBase // TypeDefIndex: 2128
{
	// Fields
	private const string CELL_ART = "imgCard"; // Metadata: 0x005F19C1
	private const string CELL_NAME = "txtName"; // Metadata: 0x005F19C9
	private const string CARD_ART_DIR = "Image/Card/"; // Metadata: 0x005F19D1
	private static readonly Color NameColor; // 0x00
	private readonly List<CardLibEntryDTO> _cards; // 0x68
	private bool _hasLoaded; // 0x70
	private bool _isLoading; // 0x71
	[NonSerialized]
	public Action onDataLoaded; // 0x78

	// Properties
	public int LoadedCount { get; } // 0x0000000180A0C1E0-0x0000000180A0C200 
	protected override int TotalCount { get; } // 0x0000000180A0C1E0-0x0000000180A0C200 
	protected override string EmptyMessage { get; } // 0x0000000180A0EA10-0x0000000180A0EA70 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2129
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_3; // 0x08

		// Constructors
		static __c(); // 0x0000000180A10050-0x0000000180A100F0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__18_3(string err); // 0x0000000180A100F0-0x0000000180A10170
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 2130
	{
		// Fields
		public CardLibView __4__this; // 0x10
		public bool ok; // 0x18
		public string firstError; // 0x20

		// Constructors
		public __c__DisplayClass18_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__0(CardLibResponse data); // 0x0000000180A10170-0x0000000180A10290
		internal void _LoadRoutine_b__1(string err); // 0x00000001802B4BC0-0x00000001802B4C20
		internal void _LoadRoutine_b__2(CardLibLegacyDTO[] arr); // 0x0000000180A10290-0x0000000180A103B0
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 2131
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
		private bool MoveNext(); // 0x0000000180A103B0-0x0000000180A10A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A10A80-0x0000000180A10AC0
	}

	// Constructors
	public CardLibView(); // 0x0000000180A0FF00-0x0000000180A10000
	static CardLibView(); // 0x0000000180A10000-0x0000000180A10050

	// Methods
	private void Reset(); // 0x0000000180A0C220-0x0000000180A0C230
	private void OnEnable(); // 0x0000000180A0EA70-0x0000000180A0EAA0
	private void OnDisable(); // 0x0000000180A0EAA0-0x0000000180A0EAB0
	public void EnsureLoaded(); // 0x0000000180A0EAB0-0x0000000180A0ED30
	[IteratorStateMachine(typeof(_LoadRoutine_d__18))]
	private IEnumerator LoadRoutine(); // 0x0000000180A0ED30-0x0000000180A0EDD0
	protected override void BindCell(GameObject cell, int index); // 0x0000000180A0EDD0-0x0000000180A0F660
	private static string TooltipTitle(CardLibEntryDTO c); // 0x0000000180A0F660-0x0000000180A0F7A0
	private static string TooltipBody(CardLibEntryDTO c); // 0x0000000180A0F7A0-0x0000000180A0FC90
	private static string LoaiVi(string code); // 0x0000000180A0FC90-0x0000000180A0FF00
}

