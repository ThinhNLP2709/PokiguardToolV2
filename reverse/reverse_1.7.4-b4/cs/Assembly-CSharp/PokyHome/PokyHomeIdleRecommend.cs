/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeIdleRecommend : MonoBehaviour // TypeDefIndex: 2650
	{
		// Fields
		public const float IDLE_SEC = 20f; // Metadata: 0x005F26FD
		private const float AUTO_HIDE_SEC = 10f; // Metadata: 0x005F2701
		[Header("L\u1EDBp tay (CanvasHand)")]
		public GameObject canvasHand; // 0x20
		public RectTransform handCanvasRect; // 0x28
		public RectTransform hand; // 0x30
		[Tooltip("\u1EA2nh ph\u1EE7 to\u00E0n m\u00E0n \u2014 ch\u1EA1m v\u00E0o l\u00E0 \u1EA9n tay.")]
		public Image imageTrigger; // 0x38
		[Tooltip("\u00D4 250\u00D7250 quanh m\u00F4-\u0111un \u2014 ch\u1EA1m v\u00E0o l\u00E0 m\u1EDF m\u00F4-\u0111un.")]
		public Image moduleClickHandle; // 0x40
		[Header("Ngu\u1ED3n d\u1EEF li\u1EC7u")]
		public PokyHomeLockState lockState; // 0x48
		public PokyHomeFeatureRouter router; // 0x50
		[Tooltip("Canvas ch\u1EE9a to\u00E0 nh\u00E0 \u2014 c\u1EA7n worldCamera c\u1EE7a n\u00F3 \u0111\u1EC3 quy \u0111\u1ED5i to\u1EA1 \u0111\u1ED9.")]
		public Canvas buildingCanvas; // 0x58
		[Tooltip("Popup c\u00E0i \u0111\u1EB7t \u2014 \u0111ang m\u1EDF th\u00EC kh\u00F4ng ch\u1EC9 \u0111\u01B0\u1EDDng.")]
		public HomeSettingsPopup settingsPopup; // 0x60
		private float _idleSince; // 0x68
		private float _hideAt; // 0x6C
		private PokyHomeModuleView _target; // 0x70
		private bool _shown; // 0x78
	
		// Constructors
		public PokyHomeIdleRecommend(); // 0x0000000180C2F680-0x0000000180C2F6D0
	
		// Methods
		private void Awake(); // 0x0000000180C2D4C0-0x0000000180C2D7A0
		private void OnDisable(); // 0x0000000180C2D7A0-0x0000000180C2D920
		private void Update(); // 0x0000000180C2D920-0x0000000180C2DD80
		public void Show(); // 0x0000000180C2DD80-0x0000000180C2E2E0
		public void Hide(); // 0x0000000180C2E2E0-0x0000000180C2E620
		private PokyHomeModuleView PickTarget(); // 0x0000000180C2E620-0x0000000180C2EAC0
		private void PlaceOver(RectTransform what, RectTransform target); // 0x0000000180C2EAC0-0x0000000180C2F0D0
		private static bool PointerActive(); // 0x0000000180C2F0D0-0x0000000180C2F1E0
		private void WireTrigger(Image img, EventTriggerType type, UnityAction<BaseEventData> action); // 0x0000000180C2F1E0-0x0000000180C2F4C0
		private void OnTouchAnywhere(BaseEventData _); // 0x0000000180C2F4C0-0x0000000180C2F4D0
		private void OnTouchModule(BaseEventData _); // 0x0000000180C2F4D0-0x0000000180C2F680
	}
}
