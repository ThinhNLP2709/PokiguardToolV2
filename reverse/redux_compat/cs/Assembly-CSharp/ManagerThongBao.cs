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

public class ManagerThongBao : MonoBehaviour // TypeDefIndex: 1112
{
	// Fields
	public const string PANEL_KEY = "PanelThongBao"; // Metadata: 0x0064D30D
	private const int MAX_NOTICES_SHOWN = 15; // Metadata: 0x0064D31B
	private const int MAX_CHARS_PER_NOTICE = 1500; // Metadata: 0x0064D31C
	private const int VERTEX_CAP = 65000; // Metadata: 0x0064D31E
	private const int VERTS_PER_CHAR = 4; // Metadata: 0x0064D322
	private const float SAFETY = 0.55f; // Metadata: 0x0064D323
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
		add; // 0x00000001804A6540-0x00000001804A6630
		remove; // 0x00000001804A6630-0x00000001804A6720
	}

	// Nested types
	[Serializable]
	public class ThongBaoDTO // TypeDefIndex: 1113
	{
		// Fields
		public long id; // 0x10
		public string tieuDe; // 0x18
		public string noiDung; // 0x20
		public string thoiGian; // 0x28
		public bool daDoc; // 0x30

		// Constructors
		public ThongBaoDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class ThongBaoResponse // TypeDefIndex: 1114
	{
		// Fields
		public List<ThongBaoDTO> item; // 0x10

		// Constructors
		public ThongBaoResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class _LoadThongBao_d__28 : IEnumerator<object> // TypeDefIndex: 1115
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerThongBao __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadThongBao_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A9410-0x00000001804A95A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A95A0-0x00000001804A95E0
	}

	// Constructors
	public ManagerThongBao(); // 0x00000001802E7A70-0x00000001802E7BC0
	static ManagerThongBao(); // 0x00000001804A63F0-0x00000001804A6540

	// Methods
	private int ComputeMaxTotalChars(); // 0x00000001804A4DB0-0x00000001804A4FC0
	private static int VisibleLength(string s); // 0x00000001804A6340-0x00000001804A63F0
	private static string TruncateVisible(string s, int maxVisible); // 0x00000001804A5E70-0x00000001804A6260
	private static void RaiseDataLoaded(List<ThongBaoDTO> items); // 0x00000001804A5BF0-0x00000001804A5CD0
	private void Awake(); // 0x00000001804A4C20-0x00000001804A4DB0
	public void MoPanel(); // 0x00000001804A5230-0x00000001804A5300
	public void DongPanel(); // 0x00000001804A4FC0-0x00000001804A5120
	[IteratorStateMachine(typeof(_LoadThongBao_d__28))]
	private IEnumerator LoadThongBao(); // 0x00000001804A51C0-0x00000001804A5230
	private void OnReceived(ThongBaoResponse response); // 0x00000001804A53E0-0x00000001804A5BF0
	private void OnError(string error); // 0x00000001804A5300-0x00000001804A53E0
	private void SetLoading(bool isLoading); // 0x00000001804A5DA0-0x00000001804A5E70
	private void SetContent(string tieuDe, string noiDung); // 0x00000001804A5CD0-0x00000001804A5DA0
	public void UpdateBadge(int unreadCount); // 0x00000001804A6260-0x00000001804A6340
	private string FormatThoiGian(string isoString); // 0x00000001804A5120-0x00000001804A51C0
}

