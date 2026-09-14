/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyOnlineGiftMailAdapter : MonoBehaviour // TypeDefIndex: 2689
	{
		// Fields
		[Header("C\u1ED9t tr\u00E1i \u2014 danh s\u00E1ch m\u1ED1c")]
		[Tooltip("Node Content c\u1EE7a ListMail (VerticalLayoutGroup) \u2014 ch\u00EDnh l\u00E0 field \'content\' c\u1EE7a Manager.")]
		public RectTransform listContent; // 0x20
		[Tooltip("ScrollRect c\u1EE7a c\u1ED9t danh s\u00E1ch \u2014 cu\u1ED9n l\u00EAn \u0111\u1EA7u m\u1ED7i l\u1EA7n n\u1EA1p.")]
		public ScrollRect listScroll; // 0x28
		[Tooltip("Ch\u1EEF \'Ch\u01B0a c\u00F3 m\u1ED1c qu\u00E0 n\u00E0o\'.")]
		public GameObject emptyLabel; // 0x30
		[Tooltip("Prefab m\u1EABu d\u00F2ng (PokyGiftMailItem) \u2014 ch\u1EC9 \u0111\u1EC3 b\u1EADt l\u1EA1i, xem RestoreTemplate().")]
		public GameObject rowTemplate; // 0x38
		[Header("Khung ph\u1EA3i \u2014 m\u1ED1c \u0111ang ch\u1ECDn")]
		public GameObject detailRoot; // 0x40
		public UnityEngine.UI.Text detailTitle; // 0x48
		public UnityEngine.UI.Text detailContent; // 0x50
		public UnityEngine.UI.Text detailSign; // 0x58
		public ScrollRect detailScroll; // 0x60
		[Tooltip("Content (HorizontalLayoutGroup) c\u1EE7a ListGift \u2014 n\u01A1i \u0111\u1EB7t b\u1EA3n sao icon qu\u00E0.")]
		public RectTransform giftContent; // 0x68
		[Header("N\u00FAt nh\u1EADn to b\u00EAn ph\u1EA3i")]
		public Button btnReceive; // 0x70
		public UnityEngine.UI.Text btnReceiveLabel; // 0x78
		[Header("\u1EA2nh n\u1EC1n d\u00F2ng")]
		public Sprite rowBgNormal; // 0x80
		public Sprite rowBgSelected; // 0x88
		private const string K_READY = "hub_gift_online_ready"; // Metadata: 0x005F2805
		private const string K_CLAIMED = "hub_gift_online_claimed"; // Metadata: 0x005F281B
		private const string K_LOCKED = "hub_gift_online_locked"; // Metadata: 0x005F2833
		private const string K_BTN = "hub_gift_online_btn"; // Metadata: 0x005F284A
		private const string K_REWARDS = "hub_gift_online_rewards"; // Metadata: 0x005F285E
		private const string K_DESC_READY = "hub_gift_online_desc_ready"; // Metadata: 0x005F2876
		private const string K_DESC_CLAIMED = "hub_gift_online_desc_claimed"; // Metadata: 0x005F2891
		private const string K_DESC_LOCKED = "hub_gift_online_desc_locked"; // Metadata: 0x005F28AE
		private const string K_WAIT = "hub_gift_online_wait"; // Metadata: 0x005F28CA
		private static readonly Color StatusReady; // 0x00
		private static readonly Color StatusClaimed; // 0x10
		private static readonly Color StatusLocked; // 0x20
		private readonly List<Row> _rows; // 0x90
		private int _selected; // 0x98
		private string _wantLabel; // 0xA0
		private bool _wired; // 0xA8
		private float _nextMirror; // 0xAC
		private static Sprite _tick; // 0x30
		private static bool _tickTried; // 0x38
	
		// Properties
		public int SelectedIndex { get; } // 0x00000001805527A0-0x00000001805527B0 
	
		// Nested types
		private class Row // TypeDefIndex: 2690
		{
			// Fields
			public GameObject go; // 0x10
			public Image bg; // 0x18
			public UnityEngine.UI.Text label; // 0x20
			public UnityEngine.UI.Text status; // 0x28
			public Button claim; // 0x30
			public UnityEngine.UI.Text claimLabel; // 0x38
			public Transform rewards; // 0x40
			public GameObject tick; // 0x48
			public HomePressScale press; // 0x50
			public Action handler; // 0x58
			public bool claimed; // 0x60
	
			// Constructors
			public Row(); // 0x000000018028A320-0x000000018028A330
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass42_0 // TypeDefIndex: 2691
		{
			// Fields
			public int index; // 0x10
			public PokyOnlineGiftMailAdapter __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Rebuild_b__0(); // 0x0000000180C50CD0-0x0000000180C50D00
			internal void _Rebuild_b__1(); // 0x0000000180C50CD0-0x0000000180C50D00
		}
	
		// Constructors
		public PokyOnlineGiftMailAdapter(); // 0x0000000180C509F0-0x0000000180C50AF0
		static PokyOnlineGiftMailAdapter(); // 0x0000000180C50AF0-0x0000000180C50CD0
	
		// Methods
		private void OnEnable(); // 0x0000000180C4C710-0x0000000180C4C910
		private void OnDisable(); // 0x0000000180C4C910-0x0000000180C4C9C0
		private void OnDestroy(); // 0x0000000180C4C9C0-0x0000000180C4CA70
		private void WireReceive(); // 0x0000000180C4CA70-0x0000000180C4CBE0
		private void OnStatus(OnlineGiftData data); // 0x0000000180C4CBE0-0x0000000180C4CD10
		private void ClearRowHandlers(); // 0x0000000180C4CD10-0x0000000180C4CEE0
		private void Rebuild(int expected); // 0x0000000180C4CEE0-0x0000000180C4DBC0
		private void RestoreTemplate(); // 0x0000000180C4DBC0-0x0000000180C4DD70
		private int PickDefault(); // 0x0000000180C4DD70-0x0000000180C4E0F0
		private void DressRow(Row row); // 0x0000000180C4E0F0-0x0000000180C4E850
		public void Select(int index); // 0x0000000180C4E850-0x0000000180C4F180
		private static string Desc(string milestone); // 0x0000000180C4F180-0x0000000180C4F270
		private void ClearGifts(); // 0x0000000180C4F270-0x0000000180C4F540
		private void CopyGifts(Transform src); // 0x0000000180C4F540-0x0000000180C4F8C0
		private void OnClickReceive(); // 0x0000000180C4F8C0-0x0000000180C4FAD0
		private void MirrorReceive(Row row); // 0x0000000180C4FAD0-0x0000000180C4FFA0
		private static string Wait(string clock); // 0x0000000180C4FFA0-0x0000000180C50090
		private void Update(); // 0x0000000180C50090-0x0000000180C50250
		private static Sprite TickSprite(); // 0x0000000180C50250-0x0000000180C50580
		private static UnityEngine.UI.Text Txt(Transform root, string path); // 0x0000000180C50580-0x0000000180C50700
		private static Image Img(Transform root, string path); // 0x0000000180C50700-0x0000000180C50880
		private static GameObject Go(Transform root, string path); // 0x0000000180C50880-0x0000000180C509F0
		private static T Comp<T>(Transform root, string path)
			where T : Component;
	}
}
