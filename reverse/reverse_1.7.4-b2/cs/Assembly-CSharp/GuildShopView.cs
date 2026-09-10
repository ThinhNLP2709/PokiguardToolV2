/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildShopView : MonoBehaviour // TypeDefIndex: 786
{
	// Fields
	[SerializeField]
	private ScrollRect scroll; // 0x20
	[SerializeField]
	private RectTransform content; // 0x28
	[SerializeField]
	private GameObject cellTemplate; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtGuildCoin; // 0x38
	[SerializeField]
	private Transform imgGuildCoin; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtRefresh; // 0x48
	[SerializeField]
	private Button btnReset; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtResetPrice; // 0x58
	[SerializeField]
	private Button btnClose; // 0x60
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x68
	private readonly List<GuildShopCell> _pool; // 0x70
	private GuildPanelController _owner; // 0x78
	private bool _wired; // 0x80
	private GuildShopData _data; // 0x88
	private Coroutine _timerCo; // 0x90

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 787
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180497660-0x00000001804976D0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Reload_b__20_0(string err); // 0x00000001804967F0-0x0000000180496850
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 788
	{
		// Fields
		public GuildShopView __4__this; // 0x10
		public GuildShopItemData item; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickBuy_b__0(); // 0x0000000180496D20-0x0000000180496D50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 789
	{
		// Fields
		public GuildShopView __4__this; // 0x10
		public GuildShopItemData item; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SubmitBuy_b__0(GuildShopBuyData d); // 0x0000000180496E10-0x00000001804972B0
	}

	[CompilerGenerated]
	private sealed class _TimerLoop_d__28 : IEnumerator<object> // TypeDefIndex: 790
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildShopView __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TimerLoop_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001804964F0-0x00000001804967B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804967B0-0x00000001804967F0
	}

	// Constructors
	public GuildShopView(); // 0x0000000180487250-0x00000001804872D0

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180485A60-0x0000000180485A90
	private void EnsureWired(); // 0x0000000180484F20-0x0000000180485920
	public void Open(); // 0x0000000180486010-0x00000001804860E0
	public void Close(); // 0x0000000180484B60-0x0000000180484BF0
	private void OnDisable(); // 0x0000000180485FC0-0x0000000180486010
	public void Reload(); // 0x00000001804860E0-0x00000001804862B0
	private void Render(GuildShopData d); // 0x00000001804862B0-0x00000001804868A0
	private GuildShopCell EnsureCell(int index); // 0x0000000180484D20-0x0000000180484F20
	private void OnClickBuy(GuildShopItemData item); // 0x0000000180485A90-0x0000000180485DF0
	private void SubmitBuy(GuildShopItemData item); // 0x0000000180486BA0-0x0000000180486E70
	private void OnClickReset(); // 0x0000000180485DF0-0x0000000180485FC0
	private GuildShopCell FindCell(long itemId); // 0x0000000180485920-0x0000000180485A60
	private void StartTimer(long remainSec); // 0x00000001804868A0-0x0000000180486BA0
	[IteratorStateMachine(typeof(_TimerLoop_d__28))]
	private IEnumerator TimerLoop(long seconds); // 0x0000000180486E70-0x0000000180486EF0
	private void StopTimer(); // 0x0000000180485FC0-0x0000000180486010
	private static string CostName(string costType); // 0x0000000180484BF0-0x0000000180484D20
	[CompilerGenerated]
	private void _OnClickReset_b__25_0(); // 0x0000000180486EF0-0x0000000180487120
	[CompilerGenerated]
	private void _OnClickReset_b__25_1(GuildShopData d); // 0x0000000180487120-0x0000000180487250
}

