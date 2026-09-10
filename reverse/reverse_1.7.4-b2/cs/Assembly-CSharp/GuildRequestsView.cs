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

public class GuildRequestsView : MonoBehaviour // TypeDefIndex: 778
{
	// Fields
	[SerializeField]
	private ScrollRect scroll; // 0x20
	[SerializeField]
	private RectTransform content; // 0x28
	[SerializeField]
	private GameObject rowTemplate; // 0x30
	[SerializeField]
	private Button btnClose; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x40
	[Header("Chi\u00EAu m\u1ED9")]
	[SerializeField]
	private GameObject recruitBox; // 0x48
	[SerializeField]
	private InputField inputRecruit; // 0x50
	[SerializeField]
	private Button btnRecruit; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtRecruitCd; // 0x60
	private readonly List<GuildRequestRow> _pool; // 0x68
	private readonly List<GuildRequestItem> _items; // 0x70
	private GuildPanelController _owner; // 0x78
	private bool _wired; // 0x80
	private bool _canManage; // 0x81
	private Coroutine _cdCo; // 0x88

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 779
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001804975F0-0x0000000180497660
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Reload_b__20_0(string err); // 0x0000000180496850-0x00000001804968B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 780
	{
		// Fields
		public bool accept; // 0x10
		public GuildRequestItem it; // 0x18
		public GuildRequestRow row; // 0x20
		public GuildRequestsView __4__this; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Resolve_b__0(GuildActionData d); // 0x00000001804972B0-0x0000000180497570
		internal void _Resolve_b__1(); // 0x0000000180497570-0x00000001804975F0
	}

	[CompilerGenerated]
	private sealed class _CountdownLoop_d__30 : IEnumerator<object> // TypeDefIndex: 781
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildRequestsView __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CountdownLoop_d__30(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180495F30-0x0000000180496270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180496270-0x00000001804962B0
	}

	// Constructors
	public GuildRequestsView(); // 0x0000000180482880-0x0000000180482940

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001804812F0-0x0000000180481320
	private void EnsureWired(); // 0x0000000180480890-0x00000001804811E0
	public void Open(); // 0x0000000180481870-0x0000000180481940
	public void Close(); // 0x0000000180480580-0x0000000180480610
	private void OnDisable(); // 0x0000000180481690-0x00000001804816E0
	public void Reload(); // 0x0000000180481940-0x0000000180481B30
	private void Render(GuildRequestsData d); // 0x0000000180481B30-0x00000001804820E0
	private GuildRequestRow EnsureRow(int index); // 0x0000000180480690-0x0000000180480890
	private void OnAgree(GuildRequestItem it); // 0x0000000180481320-0x00000001804813B0
	private void OnDecline(GuildRequestItem it); // 0x0000000180481600-0x0000000180481690
	private void Resolve(GuildRequestItem it, Func<int, string> urlOf, bool accept); // 0x00000001804820E0-0x0000000180482400
	private GuildRequestRow FindRow(GuildRequestItem it); // 0x00000001804811E0-0x00000001804812F0
	private void OnView(GuildRequestItem it); // 0x00000001804816E0-0x0000000180481870
	private void OnClickRecruit(); // 0x00000001804813B0-0x0000000180481600
	private void StartCountdown(long remainSec); // 0x0000000180482400-0x0000000180482740
	[IteratorStateMachine(typeof(_CountdownLoop_d__30))]
	private IEnumerator CountdownLoop(long seconds); // 0x0000000180480610-0x0000000180480690
	private void StopCountdown(); // 0x0000000180481690-0x00000001804816E0
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_0(GuildRequestsData d); // 0x0000000180482740-0x0000000180482800
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_1(); // 0x0000000180482800-0x0000000180482880
}

