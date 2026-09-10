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

public class ManagerThongBao : MonoBehaviour // TypeDefIndex: 1326
{
	// Fields
	public const string PANEL_KEY = "PanelThongBao"; // Metadata: 0x0068CE64
	private const int MAX_NOTICES_SHOWN = 15; // Metadata: 0x0068CE72
	private const int MAX_CHARS_PER_NOTICE = 1500; // Metadata: 0x0068CE73
	private const int VERTEX_CAP = 65000; // Metadata: 0x0068CE75
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x0068CE79
	private const float SAFETY = 0.55f; // Metadata: 0x0068CE7A
	private long _maxIdShown; // 0x20
	private static readonly string[] RICH_TAGS; // 0x00
	[Header("Panel")]
	public GameObject panelThongBao; // 0x28
	public Button btnDongThongBao; // 0x30
	[Header("Content")]
	public UnityEngine.UI.Text txtThongBao; // 0x38
	public UnityEngine.UI.Text txtTieuDe; // 0x40
	public ScrollRect scrollRect; // 0x48
	[Header("Loading")]
	public GameObject loadingIndicator; // 0x50
	[Header("Badge (tu\u1EF3 ch\u1ECDn)")]
	public GameObject badge; // 0x58
	public UnityEngine.UI.Text txtBadgeCount; // 0x60
	[CompilerGenerated]
	private static Action<List<ThongBaoDTO>> DataLoaded; // 0x08

	// Events
	public static event Action<List<ThongBaoDTO>> DataLoaded {
		add; // 0x00000001805A0BF0-0x00000001805A0CE0
		remove; // 0x00000001805A0CE0-0x00000001805A0DD0
	}

	// Nested types
	[Serializable]
	public class ThongBaoDTO // TypeDefIndex: 1327
	{
		// Fields
		public long id; // 0x10
		public string tieuDe; // 0x18
		public string noiDung; // 0x20
		public string thoiGian; // 0x28
		public bool daDoc; // 0x30

		// Constructors
		public ThongBaoDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class ThongBaoResponse // TypeDefIndex: 1328
	{
		// Fields
		public List<ThongBaoDTO> item; // 0x10

		// Constructors
		public ThongBaoResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _LoadThongBao_d__29 : IEnumerator<object> // TypeDefIndex: 1329
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThongBao __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadThongBao_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A41C0-0x00000001805A4350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4350-0x00000001805A4390
	}

	// Constructors
	public ManagerThongBao(); // 0x00000001802EBA70-0x00000001802EBAF0
	static ManagerThongBao(); // 0x00000001805A0AA0-0x00000001805A0BF0

	// Methods
	private int ComputeMaxTotalChars(); // 0x000000018059F1A0-0x000000018059F3B0
	private static int VisibleLength(string s); // 0x00000001805A09F0-0x00000001805A0AA0
	private static string TruncateVisible(string s, int maxVisible); // 0x00000001805A0520-0x00000001805A0910
	private static void RaiseDataLoaded(List<ThongBaoDTO> items); // 0x00000001805A02A0-0x00000001805A0380
	private void Awake(); // 0x000000018059F010-0x000000018059F1A0
	public void MoPanel(ThongBaoListData prefill = null); // 0x000000018059F870-0x000000018059F9B0
	private static ThongBaoResponse ConvertPrefill(ThongBaoListData prefill); // 0x000000018059F3B0-0x000000018059F600
	public void DongPanel(); // 0x000000018059F600-0x000000018059F760
	[IteratorStateMachine(typeof(_LoadThongBao_d__29))]
	private IEnumerator LoadThongBao(); // 0x000000018059F800-0x000000018059F870
	private void OnReceived(ThongBaoResponse response); // 0x000000018059FA90-0x00000001805A02A0
	private void OnError(string error); // 0x000000018059F9B0-0x000000018059FA90
	private void SetLoading(bool isLoading); // 0x00000001805A0450-0x00000001805A0520
	private void SetContent(string tieuDe, string noiDung); // 0x00000001805A0380-0x00000001805A0450
	public void UpdateBadge(int unreadCount); // 0x00000001805A0910-0x00000001805A09F0
	private string FormatThoiGian(string isoString); // 0x000000018059F760-0x000000018059F800
}

