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

public class ManagerThongBao : MonoBehaviour // TypeDefIndex: 1715
{
	// Fields
	public const string PANEL_KEY = "PanelThongBao"; // Metadata: 0x005F00F8
	private const int MAX_NOTICES_SHOWN = 15; // Metadata: 0x005F0106
	private const int MAX_CHARS_PER_NOTICE = 1500; // Metadata: 0x005F0107
	private const int VERTEX_CAP = 65000; // Metadata: 0x005F0109
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x005F010D
	private const float SAFETY = 0.55f; // Metadata: 0x005F010E
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
		add; // 0x00000001808B12B0-0x00000001808B1400
		remove; // 0x00000001808B1400-0x00000001808B1550
	}

	// Nested types
	[Serializable]
	public class ThongBaoDTO // TypeDefIndex: 1716
	{
		// Fields
		public long id; // 0x10
		public string tieuDe; // 0x18
		public string noiDung; // 0x20
		public string thoiGian; // 0x28
		public bool daDoc; // 0x30

		// Constructors
		public ThongBaoDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class ThongBaoResponse // TypeDefIndex: 1717
	{
		// Fields
		public List<ThongBaoDTO> item; // 0x10

		// Constructors
		public ThongBaoResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _LoadThongBao_d__29 : IEnumerator<object> // TypeDefIndex: 1718
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThongBao __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadThongBao_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808B3760-0x00000001808B3950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808B3950-0x00000001808B3990
	}

	// Constructors
	public ManagerThongBao(); // 0x000000018028A560-0x000000018028A5B0
	static ManagerThongBao(); // 0x00000001808B35D0-0x00000001808B3760

	// Methods
	private int ComputeMaxTotalChars(); // 0x00000001808B0920-0x00000001808B0BF0
	private static int VisibleLength(string s); // 0x00000001808B0BF0-0x00000001808B0CA0
	private static string TruncateVisible(string s, int maxVisible); // 0x00000001808B0CA0-0x00000001808B12B0
	private static void RaiseDataLoaded(List<ThongBaoDTO> items); // 0x00000001808B1550-0x00000001808B1640
	private void Awake(); // 0x00000001808B1640-0x00000001808B1A40
	public void MoPanel(ThongBaoListData prefill = null); // 0x00000001808B1A40-0x00000001808B1C90
	private static ThongBaoResponse ConvertPrefill(ThongBaoListData prefill); // 0x00000001808B1C90-0x00000001808B1F80
	public void DongPanel(); // 0x00000001808B1F80-0x00000001808B21F0
	[IteratorStateMachine(typeof(_LoadThongBao_d__29))]
	private IEnumerator LoadThongBao(); // 0x00000001808B21F0-0x00000001808B2290
	private void OnReceived(ThongBaoResponse response); // 0x00000001808B2290-0x00000001808B2C80
	private void OnError(string error); // 0x00000001808B2C80-0x00000001808B2D90
	private void SetLoading(bool isLoading); // 0x00000001808B2D90-0x00000001808B2FD0
	private void SetContent(string tieuDe, string noiDung); // 0x00000001808B2FD0-0x00000001808B31B0
	public void UpdateBadge(int unreadCount); // 0x00000001808B31B0-0x00000001808B3400
	private string FormatThoiGian(string isoString); // 0x00000001808B3400-0x00000001808B35D0
}

