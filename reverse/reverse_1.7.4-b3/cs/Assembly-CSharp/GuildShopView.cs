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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildShopView : MonoBehaviour // TypeDefIndex: 934
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
	private sealed class __c // TypeDefIndex: 935
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805B5630-0x00000001805B56D0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__20_0(string err); // 0x00000001805B56D0-0x00000001805B5740
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 936
	{
		// Fields
		public GuildShopView __4__this; // 0x10
		public GuildShopItemData item; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickBuy_b__0(); // 0x00000001805B5740-0x00000001805B5770
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 937
	{
		// Fields
		public GuildShopView __4__this; // 0x10
		public GuildShopItemData item; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitBuy_b__0(GuildShopBuyData d); // 0x00000001805B5770-0x00000001805B5B30
	}

	[CompilerGenerated]
	private sealed class _TimerLoop_d__28 : IEnumerator<object> // TypeDefIndex: 938
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildShopView __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TimerLoop_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001805B5B30-0x00000001805B5ED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B5ED0-0x00000001805B5F10
	}

	// Constructors
	public GuildShopView(); // 0x00000001805B4F50-0x00000001805B5050

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001805B1750-0x00000001805B17B0
	private void EnsureWired(); // 0x00000001805B17B0-0x00000001805B26C0
	public void Open(); // 0x00000001805B26C0-0x00000001805B28D0
	public void Close(); // 0x00000001805B28D0-0x00000001805B29D0
	private void OnDisable(); // 0x00000001805B29D0-0x00000001805B29E0
	public void Reload(); // 0x00000001805B29E0-0x00000001805B2D90
	private void Render(GuildShopData d); // 0x00000001805B2D90-0x00000001805B3800
	private GuildShopCell EnsureCell(int index); // 0x00000001805B3800-0x00000001805B3C60
	private void OnClickBuy(GuildShopItemData item); // 0x00000001805B3C60-0x00000001805B3FE0
	private void SubmitBuy(GuildShopItemData item); // 0x00000001805B3FE0-0x00000001805B4480
	private void OnClickReset(); // 0x00000001805B4480-0x00000001805B46E0
	private GuildShopCell FindCell(long itemId); // 0x00000001805B46E0-0x00000001805B48B0
	private void StartTimer(long remainSec); // 0x00000001805B48B0-0x00000001805B4C60
	[IteratorStateMachine(typeof(_TimerLoop_d__28))]
	private IEnumerator TimerLoop(long seconds); // 0x00000001805B4C60-0x00000001805B4D20
	private void StopTimer(); // 0x00000001805B4D20-0x00000001805B4DA0
	private static string CostName(string costType); // 0x00000001805B4DA0-0x00000001805B4F50
	[CompilerGenerated]
	private void _OnClickReset_b__25_0(); // 0x00000001805B5050-0x00000001805B53B0
	[CompilerGenerated]
	private void _OnClickReset_b__25_1(GuildShopData d); // 0x00000001805B53B0-0x00000001805B5630
}

