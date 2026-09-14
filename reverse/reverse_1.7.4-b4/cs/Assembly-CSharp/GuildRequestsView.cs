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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildRequestsView : MonoBehaviour // TypeDefIndex: 928
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
	private sealed class __c // TypeDefIndex: 929
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805AC2C0-0x00000001805AC360
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__20_0(string err); // 0x00000001805AC360-0x00000001805AC3D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 930
	{
		// Fields
		public bool accept; // 0x10
		public GuildRequestItem it; // 0x18
		public GuildRequestRow row; // 0x20
		public GuildRequestsView __4__this; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Resolve_b__0(GuildActionData d); // 0x00000001805AC3D0-0x00000001805AC7B0
		internal void _Resolve_b__1(); // 0x00000001805AC7B0-0x00000001805AC8B0
	}

	[CompilerGenerated]
	private sealed class _CountdownLoop_d__30 : IEnumerator<object> // TypeDefIndex: 931
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long seconds; // 0x20
		public GuildRequestsView __4__this; // 0x28
		private WaitForSecondsRealtime _wait_5__2; // 0x30
		private long _left_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CountdownLoop_d__30(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001805AC8B0-0x00000001805ACE40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ACE40-0x00000001805ACE80
	}

	// Constructors
	public GuildRequestsView(); // 0x00000001805ABEF0-0x00000001805AC0A0

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001805A89C0-0x00000001805A8A20
	private void EnsureWired(); // 0x00000001805A8A20-0x00000001805A9890
	public void Open(); // 0x00000001805A9890-0x00000001805A9AA0
	public void Close(); // 0x00000001805A9AA0-0x00000001805A9BA0
	private void OnDisable(); // 0x00000001805A9BA0-0x00000001805A9BB0
	public void Reload(); // 0x00000001805A9BB0-0x00000001805A9EC0
	private void Render(GuildRequestsData d); // 0x00000001805A9EC0-0x00000001805AA7D0
	private GuildRequestRow EnsureRow(int index); // 0x00000001805AA7D0-0x00000001805AAC30
	private void OnAgree(GuildRequestItem it); // 0x00000001805AAC30-0x00000001805AACD0
	private void OnDecline(GuildRequestItem it); // 0x00000001805AACD0-0x00000001805AAD70
	private void Resolve(GuildRequestItem it, Func<int, string> urlOf, bool accept); // 0x00000001805AAD70-0x00000001805AB1A0
	private GuildRequestRow FindRow(GuildRequestItem it); // 0x00000001805AB1A0-0x00000001805AB350
	private void OnView(GuildRequestItem it); // 0x00000001805AB350-0x00000001805AB4E0
	private void OnClickRecruit(); // 0x00000001805AB4E0-0x00000001805AB960
	private void StartCountdown(long remainSec); // 0x00000001805AB960-0x00000001805ABE30
	[IteratorStateMachine(typeof(_CountdownLoop_d__30))]
	private IEnumerator CountdownLoop(long seconds); // 0x00000001805ABE30-0x00000001805ABEF0
	private void StopCountdown(); // 0x00000001805A7600-0x00000001805A7680
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_0(GuildRequestsData d); // 0x00000001805AC0A0-0x00000001805AC1C0
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_1(); // 0x00000001805AC1C0-0x00000001805AC2C0
}

