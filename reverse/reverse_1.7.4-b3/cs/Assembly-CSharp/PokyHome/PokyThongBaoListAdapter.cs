/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyThongBaoListAdapter : MonoBehaviour // TypeDefIndex: 2714
	{
		// Fields
		[Header("Danh s\u00E1ch (c\u1ED9t tr\u00E1i)")]
		[Tooltip("Node Content c\u1EE7a ListMail (c\u00F3 VerticalLayoutGroup).")]
		public RectTransform listContent; // 0x20
		[Tooltip("Prefab m\u1ED9t d\u00F2ng th\u01B0 (PokyMailItem).")]
		public GameObject itemPrefab; // 0x28
		[Tooltip("Ch\u1EEF \'B\u1EA1n ch\u01B0a c\u00F3 th\u01B0\'.")]
		public GameObject emptyLabel; // 0x30
		[Tooltip("ScrollRect c\u1EE7a c\u1ED9t danh s\u00E1ch \u2014 cu\u1ED9n l\u00EAn \u0111\u1EA7u m\u1ED7i l\u1EA7n n\u1EA1p.")]
		public ScrollRect listScroll; // 0x38
		[Header("N\u1ED9i dung (khung ph\u1EA3i)")]
		public UnityEngine.UI.Text detailTitle; // 0x40
		public UnityEngine.UI.Text detailContent; // 0x48
		public UnityEngine.UI.Text detailSign; // 0x50
		public ScrollRect detailScroll; // 0x58
		[Header("\u1EA2nh bi\u1EC3u t\u01B0\u1EE3ng th\u01B0")]
		public Sprite iconUnread; // 0x60
		public Sprite iconRead; // 0x68
		[Header("M\u00E0u d\u00F2ng \u0111ang ch\u1ECDn")]
		public Color rowNormal; // 0x70
		public Color rowSelected; // 0x80
		private readonly List<GameObject> _rows; // 0x90
		private readonly List<Image> _rowBgs; // 0x98
		private List<ManagerThongBao.ThongBaoDTO> _items; // 0xA0
		private int _selected; // 0xA8
	
		// Properties
		public int SelectedIndex { get; } // 0x00000001803C6390-0x00000001803C63A0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2715
		{
			// Fields
			public int index; // 0x10
			public PokyThongBaoListAdapter __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Rebuild_b__0(); // 0x0000000180C5D610-0x0000000180C5D640
		}
	
		// Constructors
		public PokyThongBaoListAdapter(); // 0x0000000180C5D440-0x0000000180C5D610
	
		// Methods
		private void OnEnable(); // 0x0000000180C5B850-0x0000000180C5B900
		private void OnDisable(); // 0x0000000180C5B900-0x0000000180C5B9B0
		private void OnDestroy(); // 0x0000000180C5B9B0-0x0000000180C5BA60
		private void OnData(List<ManagerThongBao.ThongBaoDTO> items); // 0x0000000180C5BA60-0x0000000180C5BAC0
		private void Rebuild(); // 0x0000000180C5BAC0-0x0000000180C5CB10
		public void Select(int index); // 0x0000000180C5CB10-0x0000000180C5CD60
		private void SetDetail(ManagerThongBao.ThongBaoDTO tb); // 0x0000000180C5CD60-0x0000000180C5D0C0
		private static UnityEngine.UI.Text FindText(Transform root, string name); // 0x0000000180C5D0C0-0x0000000180C5D240
		private static string FormatTime(string iso); // 0x0000000180C5D240-0x0000000180C5D440
	}
}
