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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TermsPanelController : MonoBehaviour // TypeDefIndex: 1508
{
	// Fields
	[Header("N\u1ED9i dung")]
	public UnityEngine.UI.Text titleText; // 0x20
	[Tooltip("C\u00E1c kh\u1ED1i v\u0103n b\u1EA3n trong Content c\u1EE7a ScrollRect. \u0110i\u1EC1u kho\u1EA3n d\u00E0i \u0111\u01B0\u1EE3c chia \u0111\u1EC1u v\u00E0o \u0111\u00E2y v\u00EC m\u1ED9t Text legacy kh\u00F4ng hi\u1EC3n th\u1ECB n\u1ED5i qu\u00E1 ~16.000 k\u00FD t\u1EF1 (tr\u1EA7n vertex c\u1EE7a mesh).")]
	public UnityEngine.UI.Text[] bodyBlocks; // 0x28
	public ScrollRect scrollRect; // 0x30
	[Header("N\u00FAt")]
	public Button acceptButton; // 0x38
	public UnityEngine.UI.Text acceptLabel; // 0x40
	public Button declineButton; // 0x48
	public UnityEngine.UI.Text declineLabel; // 0x50
	[Header("Hi\u1EC7u \u1EE9ng \u2014 T\u00D9Y CH\u1ECCN")]
	public CanvasGroup canvasGroup; // 0x58
	[Tooltip("M\u0169i t\u00EAn nh\u00FAn b\u00E1o \'c\u00F2n n\u1EEFa, k\u00E9o xu\u1ED1ng\'. T\u1EF1 t\u1EAFt khi ng\u01B0\u1EDDi ch\u01A1i \u0111\u00E3 \u0111\u1ECDc t\u1EDBi cu\u1ED1i.")]
	public GameObject scrollHint; // 0x60
	[Tooltip("D\u00F2ng nh\u1EAFc d\u01B0\u1EDBi ch\u00E2n panel. T\u1EF1 \u1EA9n khi n\u00FAt \u0110\u1ED3ng \u00FD \u0111\u01B0\u1EE3c m\u1EDF kho\u00E1.")]
	public UnityEngine.UI.Text unlockHintText; // 0x68
	private const int VERTEX_CAP = 65000; // Metadata: 0x0064D741
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x0064D745
	private const float SAFETY = 0.55f; // Metadata: 0x0064D746
	private int _maxCharsPerBlock; // 0x70
	private Action<bool> _onDecision; // 0x78
	private int _userId; // 0x80
	private int _termsVersion; // 0x84
	private bool _sending; // 0x88
	private bool _confirmingDecline; // 0x89
	private bool _unlocked; // 0x8A
	private float? _scrollHintBaseY; // 0x8C

	// Nested types
	[CompilerGenerated]
	private sealed class _ReloadAfterMismatch_d__34 : IEnumerator<object> // TypeDefIndex: 1509
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TermsPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ReloadAfterMismatch_d__34(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057D1D0-0x000000018057D350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057D350-0x000000018057D390
	}

	[CompilerGenerated]
	private sealed class _UnlockIfContentFits_d__24 : IEnumerator<object> // TypeDefIndex: 1510
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public TermsPanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UnlockIfContentFits_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057E1C0-0x000000018057E310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057E310-0x000000018057E350
	}

	// Constructors
	public TermsPanelController(); // 0x00000001805760D0-0x00000001805760E0

	// Methods
	private void OnDisable(); // 0x0000000180574CE0-0x0000000180574CF0
	public void Show(TermsContentData content, int userId, Action<bool> onDecision); // 0x0000000180574F60-0x00000001805751F0
	private void StartReadGate(); // 0x0000000180575380-0x00000001805758B0
	[IteratorStateMachine(typeof(_UnlockIfContentFits_d__24))]
	private IEnumerator UnlockIfContentFits(); // 0x0000000180575EE0-0x0000000180575F50
	private bool HasAnyBodyText(); // 0x0000000180574830-0x0000000180574950
	private void OnScrolled(Vector2 _); // 0x0000000180574CF0-0x0000000180574D90
	private void UnlockAccept(); // 0x0000000180575CA0-0x0000000180575EE0
	private void ApplyContent(TermsContentData content); // 0x0000000180573D40-0x0000000180573E80
	private void FillBlocks(string body); // 0x00000001805742A0-0x0000000180574730
	private int ComputeMaxCharsPerBlock(); // 0x0000000180573E80-0x00000001805742A0
	private static List<string> SplitIntoChunks(string s, int maxLen, int maxChunks); // 0x00000001805751F0-0x0000000180575380
	private void WireButtons(); // 0x0000000180575F50-0x00000001805760D0
	private void OnAccept(); // 0x0000000180574950-0x0000000180574B30
	[IteratorStateMachine(typeof(_ReloadAfterMismatch_d__34))]
	private IEnumerator ReloadAfterMismatch(); // 0x0000000180574D90-0x0000000180574E00
	private void OnDecline(); // 0x0000000180574B30-0x0000000180574CE0
	private void Finish(bool accepted); // 0x0000000180574730-0x0000000180574830
	private void SetAcceptInteractable(bool on); // 0x0000000180574E00-0x0000000180574E90
	private void SetButtonLabels(string accept, string decline); // 0x0000000180574E90-0x0000000180574F60
	[CompilerGenerated]
	private void _OnAccept_b__33_0(bool ok, string code); // 0x00000001805758B0-0x0000000180575AE0
	[CompilerGenerated]
	private void _OnAccept_b__33_1(); // 0x0000000180575AE0-0x0000000180575AF0
	[CompilerGenerated]
	private void _ReloadAfterMismatch_b__34_0(TermsContentData fresh); // 0x0000000180575B00-0x0000000180575CA0
	[CompilerGenerated]
	private void _ReloadAfterMismatch_b__34_1(); // 0x0000000180575AE0-0x0000000180575AF0
	[CompilerGenerated]
	private void _OnDecline_b__35_0(); // 0x0000000180575AF0-0x0000000180575B00
}

