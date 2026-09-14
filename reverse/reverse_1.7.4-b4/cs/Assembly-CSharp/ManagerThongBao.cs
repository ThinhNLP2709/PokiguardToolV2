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

public class ManagerThongBao : MonoBehaviour // TypeDefIndex: 1717
{
	// Fields
	public const string PANEL_KEY = "PanelThongBao"; // Metadata: 0x005F14C5
	private const int MAX_NOTICES_SHOWN = 15; // Metadata: 0x005F14D3
	private const int MAX_CHARS_PER_NOTICE = 1500; // Metadata: 0x005F14D4
	private const int VERTEX_CAP = 65000; // Metadata: 0x005F14D6
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x005F14DA
	private const float SAFETY = 0.55f; // Metadata: 0x005F14DB
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
		add; // 0x00000001808B3C00-0x00000001808B3D50
		remove; // 0x00000001808B3D50-0x00000001808B3EA0
	}

	// Nested types
	[Serializable]
	public class ThongBaoDTO // TypeDefIndex: 1718
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
	public class ThongBaoResponse // TypeDefIndex: 1719
	{
		// Fields
		public List<ThongBaoDTO> item; // 0x10

		// Constructors
		public ThongBaoResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _LoadThongBao_d__29 : IEnumerator<object> // TypeDefIndex: 1720
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808B60B0-0x00000001808B62D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808B62D0-0x00000001808B6310
	}

	// Constructors
	public ManagerThongBao(); // 0x000000018028A560-0x000000018028A5B0
	static ManagerThongBao(); // 0x00000001808B5F20-0x00000001808B60B0

	// Methods
	private int ComputeMaxTotalChars(); // 0x00000001808B3270-0x00000001808B3540
	private static int VisibleLength(string s); // 0x00000001808B3540-0x00000001808B35F0
	private static string TruncateVisible(string s, int maxVisible); // 0x00000001808B35F0-0x00000001808B3C00
	private static void RaiseDataLoaded(List<ThongBaoDTO> items); // 0x00000001808B3EA0-0x00000001808B3F90
	private void Awake(); // 0x00000001808B3F90-0x00000001808B4390
	public void MoPanel(ThongBaoListData prefill = null); // 0x00000001808B4390-0x00000001808B45E0
	private static ThongBaoResponse ConvertPrefill(ThongBaoListData prefill); // 0x00000001808B45E0-0x00000001808B48D0
	public void DongPanel(); // 0x00000001808B48D0-0x00000001808B4B40
	[IteratorStateMachine(typeof(_LoadThongBao_d__29))]
	private IEnumerator LoadThongBao(); // 0x00000001808B4B40-0x00000001808B4BE0
	private void OnReceived(ThongBaoResponse response); // 0x00000001808B4BE0-0x00000001808B55D0
	private void OnError(string error); // 0x00000001808B55D0-0x00000001808B56E0
	private void SetLoading(bool isLoading); // 0x00000001808B56E0-0x00000001808B5920
	private void SetContent(string tieuDe, string noiDung); // 0x00000001808B5920-0x00000001808B5B00
	public void UpdateBadge(int unreadCount); // 0x00000001808B5B00-0x00000001808B5D50
	private string FormatThoiGian(string isoString); // 0x00000001808B5D50-0x00000001808B5F20
}

