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

[DisallowMultipleComponent]
public class CardLibView : LibPagedViewBase // TypeDefIndex: 1763
{
	// Fields
	private const string CELL_ART = "imgCard"; // Metadata: 0x0068D79E
	private const string CELL_NAME = "txtName"; // Metadata: 0x0068D7A6
	private const string CARD_ART_DIR = "Image/Card/"; // Metadata: 0x0068D7AE
	private static readonly Color NameColor; // 0x00
	private readonly List<CardLibEntryDTO> _cards; // 0x68
	private bool _hasLoaded; // 0x70
	private bool _isLoading; // 0x71
	[NonSerialized]
	public Action onDataLoaded; // 0x78

	// Properties
	public int LoadedCount { get; } // 0x00000001806729A0-0x00000001806729C0 
	protected override int TotalCount { get; } // 0x00000001806729A0-0x00000001806729C0 
	protected override string EmptyMessage { get; } // 0x0000000180672950-0x00000001806729A0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1764
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__18_3; // 0x08

		// Constructors
		static __c(); // 0x00000001806881C0-0x0000000180688230
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoutine_b__18_3(string err); // 0x00000001806874A0-0x0000000180687510
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass18_0 // TypeDefIndex: 1765
	{
		// Fields
		public CardLibView __4__this; // 0x10
		public bool ok; // 0x18
		public string firstError; // 0x20

		// Constructors
		public __c__DisplayClass18_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadRoutine_b__0(CardLibResponse data); // 0x0000000180687D90-0x0000000180687EC0
		internal void _LoadRoutine_b__1(string err); // 0x0000000180308AD0-0x0000000180308AE0
		internal void _LoadRoutine_b__2(CardLibLegacyDTO[] arr); // 0x0000000180687EC0-0x0000000180687FE0
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__18 : IEnumerator<object> // TypeDefIndex: 1766
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CardLibView __4__this; // 0x20
		private __c__DisplayClass18_0 __8__1; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180685E20-0x0000000180686270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180686270-0x00000001806862B0
	}

	// Constructors
	public CardLibView(); // 0x00000001806728D0-0x0000000180672950
	static CardLibView(); // 0x0000000180672890-0x00000001806728D0

	// Methods
	private void Reset(); // 0x0000000180672130-0x0000000180672140
	private void OnEnable(); // 0x0000000180671FF0-0x0000000180672130
	private void OnDisable(); // 0x0000000180671FE0-0x0000000180671FF0
	public void EnsureLoaded(); // 0x0000000180671CD0-0x0000000180671E00
	[IteratorStateMachine(typeof(_LoadRoutine_d__18))]
	private IEnumerator LoadRoutine(); // 0x0000000180671E00-0x0000000180671E70
	protected override void BindCell(GameObject cell, int index); // 0x0000000180671870-0x0000000180671CD0
	private static string TooltipTitle(CardLibEntryDTO c); // 0x00000001806727C0-0x0000000180672890
	private static string TooltipBody(CardLibEntryDTO c); // 0x0000000180672140-0x00000001806727C0
	private static string LoaiVi(string code); // 0x0000000180671E70-0x0000000180671FE0
}

