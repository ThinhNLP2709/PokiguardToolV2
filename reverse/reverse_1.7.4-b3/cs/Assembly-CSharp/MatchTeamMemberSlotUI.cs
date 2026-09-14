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

[DisallowMultipleComponent]
public class MatchTeamMemberSlotUI : MonoBehaviour // TypeDefIndex: 75
{
	// Fields
	[SerializeField]
	private Slider sliderHp; // 0x20
	[SerializeField]
	private Slider sliderMana; // 0x28
	[SerializeField]
	private Slider sliderPower; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text textHp; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text textMana; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text textPower; // 0x48
	[SerializeField]
	private Image portraitImage; // 0x50
	[SerializeField]
	private GameObject yourTurnRoot; // 0x58
	[SerializeField]
	private WeaponBadgeUI weaponBadge; // 0x60
	[CompilerGenerated]
	private int _BoundActor_k__BackingField; // 0x68
	[CompilerGenerated]
	private bool _MaskHpText_k__BackingField; // 0x6C
	private const float BAR_TWEEN_SEC = 0.15f; // Metadata: 0x005ED6B4
	private readonly Dictionary<Slider, Coroutine> _barTweens; // 0x70
	private const int MAX_STATUS_ICONS = 3; // Metadata: 0x005ED6B8
	private const float STATUS_ICON_SIZE = 22f; // Metadata: 0x005ED6B9
	private const float STATUS_ICON_GAP = 3f; // Metadata: 0x005ED6BD
	private RectTransform _statusRow; // 0x78
	private Image[] _statusIcons; // 0x80

	// Properties
	public int BoundActor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018046A770-0x000000018046A780 0x000000018046A780-0x000000018046A790
	public RectTransform PortraitRect { get; } // 0x000000018046A790-0x000000018046A9A0 
	public bool MaskHpText { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018046A9A0-0x000000018046A9B0 0x000000018046A9B0-0x000000018046A9C0

	// Nested types
	[CompilerGenerated]
	private sealed class _TweenBarCo_d__29 : IEnumerator<object> // TypeDefIndex: 76
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Slider slider; // 0x20
		public float target; // 0x28
		public MatchTeamMemberSlotUI __4__this; // 0x30
		private float _start_5__2; // 0x38
		private float _elapsed_5__3; // 0x3C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TweenBarCo_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018046E7C0-0x000000018046EA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046EA10-0x000000018046EA50
	}

	// Constructors
	public MatchTeamMemberSlotUI(); // 0x000000018046E6C0-0x000000018046E7C0

	// Methods
	private void Awake(); // 0x000000018046A9C0-0x000000018046B420
	public void BindActor(int actorNumber); // 0x000000018046B420-0x000000018046B430
	public void SetPortrait(Sprite sprite); // 0x000000018046B430-0x000000018046B5D0
	public void SetPortrait(Sprite sprite, string layers); // 0x000000018046B5D0-0x000000018046B710
	private void OnDestroy(); // 0x000000018046B710-0x000000018046B830
	public void SetWeapon(int imageId, string rarity, long userId); // 0x000000018046B830-0x000000018046BAD0
	public void SetBars(int curHp, int maxHp, int curMana, int maxMana, int curPow, int maxPow); // 0x000000018046BAD0-0x000000018046BF60
	private void TweenBar(Slider slider, int value, int max); // 0x000000018046BF60-0x000000018046C3C0
	[IteratorStateMachine(typeof(_TweenBarCo_d__29))]
	private IEnumerator TweenBarCo(Slider slider, float target); // 0x000000018046C3C0-0x000000018046C4E0
	public void SetYourTurnVisible(bool visible); // 0x000000018046C4E0-0x000000018046C630
	public void SetDeadState(bool isDead); // 0x000000018046C630-0x000000018046C7A0
	public void SetStatusIcons(IList<string> types); // 0x000000018046C7A0-0x000000018046CE20
	private bool EnsureStatusRow(); // 0x000000018046CE20-0x000000018046DB80
	private static Slider FindSlider(Transform root, string childName); // 0x000000018046DB80-0x000000018046DCA0
	private static UnityEngine.UI.Text FindText(Transform root, string childName); // 0x000000018046DCA0-0x000000018046DDC0
	private static Image ResolvePortraitImage(Transform root); // 0x000000018046DDC0-0x000000018046E270
	private static GameObject ResolveYourTurn(Transform root); // 0x000000018046E270-0x000000018046E450
	private static Transform FindDeepChild(Transform parent, string name); // 0x000000018046E450-0x000000018046E6C0
}

