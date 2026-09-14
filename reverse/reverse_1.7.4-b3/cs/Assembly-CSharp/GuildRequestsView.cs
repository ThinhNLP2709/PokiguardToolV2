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

public class GuildRequestsView : MonoBehaviour // TypeDefIndex: 926
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
	private sealed class __c // TypeDefIndex: 927
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805AA960-0x00000001805AAA00
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Reload_b__20_0(string err); // 0x00000001805AAA00-0x00000001805AAA70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass25_0 // TypeDefIndex: 928
	{
		// Fields
		public bool accept; // 0x10
		public GuildRequestItem it; // 0x18
		public GuildRequestRow row; // 0x20
		public GuildRequestsView __4__this; // 0x28

		// Constructors
		public __c__DisplayClass25_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Resolve_b__0(GuildActionData d); // 0x00000001805AAA70-0x00000001805AAE50
		internal void _Resolve_b__1(); // 0x00000001805AAE50-0x00000001805AAF50
	}

	[CompilerGenerated]
	private sealed class _CountdownLoop_d__30 : IEnumerator<object> // TypeDefIndex: 929
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
		private bool MoveNext(); // 0x00000001805AAF50-0x00000001805AB4E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AB4E0-0x00000001805AB520
	}

	// Constructors
	public GuildRequestsView(); // 0x00000001805AA590-0x00000001805AA740

	// Methods
	public void Init(GuildPanelController owner); // 0x00000001805A7060-0x00000001805A70C0
	private void EnsureWired(); // 0x00000001805A70C0-0x00000001805A7F30
	public void Open(); // 0x00000001805A7F30-0x00000001805A8140
	public void Close(); // 0x00000001805A8140-0x00000001805A8240
	private void OnDisable(); // 0x00000001805A8240-0x00000001805A8250
	public void Reload(); // 0x00000001805A8250-0x00000001805A8560
	private void Render(GuildRequestsData d); // 0x00000001805A8560-0x00000001805A8E70
	private GuildRequestRow EnsureRow(int index); // 0x00000001805A8E70-0x00000001805A92D0
	private void OnAgree(GuildRequestItem it); // 0x00000001805A92D0-0x00000001805A9370
	private void OnDecline(GuildRequestItem it); // 0x00000001805A9370-0x00000001805A9410
	private void Resolve(GuildRequestItem it, Func<int, string> urlOf, bool accept); // 0x00000001805A9410-0x00000001805A9840
	private GuildRequestRow FindRow(GuildRequestItem it); // 0x00000001805A9840-0x00000001805A99F0
	private void OnView(GuildRequestItem it); // 0x00000001805A99F0-0x00000001805A9B80
	private void OnClickRecruit(); // 0x00000001805A9B80-0x00000001805AA000
	private void StartCountdown(long remainSec); // 0x00000001805AA000-0x00000001805AA4D0
	[IteratorStateMachine(typeof(_CountdownLoop_d__30))]
	private IEnumerator CountdownLoop(long seconds); // 0x00000001805AA4D0-0x00000001805AA590
	private void StopCountdown(); // 0x00000001805A5CA0-0x00000001805A5D20
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_0(GuildRequestsData d); // 0x00000001805AA740-0x00000001805AA860
	[CompilerGenerated]
	private void _OnClickRecruit_b__28_1(); // 0x00000001805AA860-0x00000001805AA960
}

