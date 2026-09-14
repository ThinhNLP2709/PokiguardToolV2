/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class AvatarLibView : LibPagedViewBase // TypeDefIndex: 2124
{
	// Fields
	private const string CELL_FRAME = "frame"; // Metadata: 0x005F19A9
	private const string CELL_ART = "imgAvatar"; // Metadata: 0x005F19AF
	private const string CELL_NAME = "txtName"; // Metadata: 0x005F19B9
	private static readonly Color LockedIconColor; // 0x00
	private static readonly Color LockedNameColor; // 0x10
	private static readonly Color LockedFrameColor; // 0x20
	private static readonly Color OwnedNameFallback; // 0x30
	private readonly List<AvatarLibEntryDTO> _entries; // 0x68
	private bool _isLoading; // 0x70
	private bool _hasLoaded; // 0x71
	private bool _serverMissing; // 0x72
	[CompilerGenerated]
	private int _OwnedCount_k__BackingField; // 0x74
	[NonSerialized]
	public Action onDataLoaded; // 0x78
	private static Sprite _blankIcon; // 0x40

	// Properties
	public int LoadedCount { get; } // 0x0000000180A0C1E0-0x0000000180A0C200 
	public int OwnedCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A0C200-0x0000000180A0C210 0x0000000180A0C210-0x0000000180A0C220
	protected override int TotalCount { get; } // 0x0000000180A0C1E0-0x0000000180A0C200 
	protected override string EmptyMessage { get; } // 0x0000000180A0C230-0x0000000180A0C2E0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 2125
	{
		// Fields
		public AvatarLibView __4__this; // 0x10
		public bool ok; // 0x18
		public string error; // 0x20

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadRoutine_b__0(AvatarLibResponse data); // 0x0000000180A0E010-0x0000000180A0E160
		internal void _LoadRoutine_b__1(string err); // 0x00000001802B4BC0-0x00000001802B4C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 2126
	{
		// Fields
		public RectTransform cellRt; // 0x10
		public EquipItemDTO forTip; // 0x18

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BindCell_b__0(); // 0x0000000180A0E160-0x0000000180A0E1F0
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__26 : IEnumerator<object> // TypeDefIndex: 2127
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public AvatarLibView __4__this; // 0x20
		public long userId; // 0x28
		private __c__DisplayClass26_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180A0E1F0-0x0000000180A0E9D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A0E9D0-0x0000000180A0EA10
	}

	// Constructors
	public AvatarLibView(); // 0x0000000180A0DE70-0x0000000180A0DF70
	static AvatarLibView(); // 0x0000000180A0DF70-0x0000000180A0E010

	// Methods
	private void Reset(); // 0x0000000180A0C220-0x0000000180A0C230
	private void OnEnable(); // 0x0000000180A0C2E0-0x0000000180A0C310
	private void OnDisable(); // 0x0000000180A0C310-0x0000000180A0C320
	public void Reload(); // 0x0000000180A0C320-0x0000000180A0C600
	[IteratorStateMachine(typeof(_LoadRoutine_d__26))]
	private IEnumerator LoadRoutine(long userId); // 0x0000000180A0C600-0x0000000180A0C6C0
	protected override void BindCell(GameObject cell, int index); // 0x0000000180A0C6C0-0x0000000180A0D4A0
	private static string TooltipTitle(EquipItemDTO item, bool owned); // 0x0000000180A0D4A0-0x0000000180A0D5D0
	private static string TooltipBody(EquipItemDTO item); // 0x0000000180A0D5D0-0x0000000180A0D930
	private static Color RarityNameColor(int rarity); // 0x0000000180A0D930-0x0000000180A0DA60
	private static Sprite BlankIcon(); // 0x0000000180A0DA60-0x0000000180A0DE70
}

