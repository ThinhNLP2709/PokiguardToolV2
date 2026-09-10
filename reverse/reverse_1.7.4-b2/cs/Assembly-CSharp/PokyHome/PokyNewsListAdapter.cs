/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyNewsListAdapter : MonoBehaviour // TypeDefIndex: 2245
	{
		// Fields
		public const int MAX_ROWS = 40; // Metadata: 0x0068E37F
		public const int MAX_CHARS_PER_LINE = 1500; // Metadata: 0x0068E380
		[Header("Danh s\u00E1ch")]
		[Tooltip("Node Content c\u1EE7a Scroll View (VerticalLayoutGroup + ContentSizeFitter).")]
		public RectTransform listContent; // 0x20
		[Tooltip("ScrollRect c\u1EE7a khung cu\u1ED9n \u2014 cu\u1ED9n l\u00EAn \u0111\u1EA7u sau m\u1ED7i l\u1EA7n n\u1EA1p.")]
		public ScrollRect listScroll; // 0x28
		[Tooltip("Prefab m\u1ED9t d\u00F2ng th\u00F4ng b\u00E1o (PokyNewsRow).")]
		public GameObject rowPrefab; // 0x30
		[Header("\u1EA2nh")]
		[Tooltip("Icon nh\u1ECF tr\u01B0\u1EDBc d\u00F2ng ng\u00E0y (PopupNews::highlight). Null \u21D2 gi\u1EEF sprite s\u1EB5n c\u00F3 c\u1EE7a prefab.")]
		public Sprite iconDate; // 0x38
		[Header("M\u00E0u 4 ki\u1EC3u ch\u1EEF c\u1EE7a Poky")]
		[Tooltip("ti \u2014 ti\u00EAu \u0111\u1EC1 (Poky: xanh l\u00E1 0;1;0).")]
		public Color colorTitle; // 0x40
		[Tooltip("co \u2014 n\u1ED9i dung (Poky: l\u01A1 0;1;1).")]
		public Color colorInfo; // 0x50
		[Tooltip("hi \u2014 d\u00F2ng ng\u00E0y (Poky: v\u00E0ng 1;0,8;0).")]
		public Color colorHighlight; // 0x60
		[Tooltip("wa \u2014 n\u1ED9i dung KH\u1EA8N (Poky: \u0111\u1ECF 1;0;0).")]
		public Color colorWarning; // 0x70
		private readonly List<GameObject> _pool; // 0x80
		private long _seenIdAtOpen; // 0x88
		private bool _subscribed; // 0x90
		[CompilerGenerated]
		private int _VisibleRows_k__BackingField; // 0x94
		private static readonly string[] URGENT_WORDS; // 0x00
		private static readonly string[] RICH_TAGS; // 0x08
	
		// Properties
		public int VisibleRows { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018078C350-0x000000018078C360 0x000000018078C360-0x000000018078C370
	
		// Constructors
		public PokyNewsListAdapter(); // 0x000000018078C2A0-0x000000018078C350
		static PokyNewsListAdapter(); // 0x000000018078C000-0x000000018078C2A0
	
		// Methods
		private void OnEnable(); // 0x000000018078B0B0-0x000000018078B220
		private void OnDisable(); // 0x000000018078B0A0-0x000000018078B0B0
		private void OnDestroy(); // 0x000000018078B0A0-0x000000018078B0B0
		private void Unsubscribe(); // 0x000000018078BF60-0x000000018078C000
		private void OnData(List<ManagerThongBao.ThongBaoDTO> items); // 0x000000018078B010-0x000000018078B0A0
		private void Rebuild(List<ManagerThongBao.ThongBaoDTO> items); // 0x000000018078B2C0-0x000000018078B830
		private GameObject Row(int index); // 0x000000018078B830-0x000000018078BA30
		private void FillRow(GameObject row, ManagerThongBao.ThongBaoDTO tb); // 0x000000018078A7A0-0x000000018078ACB0
		private void FillEmptyRow(GameObject row); // 0x000000018078A540-0x000000018078A670
		private void FillNoteRow(GameObject row, string note); // 0x000000018078A670-0x000000018078A7A0
		private static UnityEngine.UI.Text Bind(GameObject row, string child, string value, Color color); // 0x000000018078A290-0x000000018078A420
		private static void SetActiveChild(GameObject row, string child, bool on); // 0x000000018078BE80-0x000000018078BF60
		private static Image FindImage(Transform root, string child); // 0x000000018078ACB0-0x000000018078AD60
		private static string OneLine(string s); // 0x000000018078B220-0x000000018078B2C0
		private static string Sanitize(string s, int maxVisible); // 0x000000018078BA30-0x000000018078BE80
		private static bool IsUrgent(string title); // 0x000000018078AE20-0x000000018078B010
		private static string Deaccent(string s); // 0x000000018078A420-0x000000018078A540
		private static string FormatTime(string iso); // 0x000000018078AD60-0x000000018078AE20
	}
}
