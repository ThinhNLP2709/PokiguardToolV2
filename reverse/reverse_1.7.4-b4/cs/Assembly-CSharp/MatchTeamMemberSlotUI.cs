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
	private const float BAR_TWEEN_SEC = 0.15f; // Metadata: 0x005EEA84
	private readonly Dictionary<Slider, Coroutine> _barTweens; // 0x70
	private const int MAX_STATUS_ICONS = 3; // Metadata: 0x005EEA88
	private const float STATUS_ICON_SIZE = 22f; // Metadata: 0x005EEA89
	private const float STATUS_ICON_GAP = 3f; // Metadata: 0x005EEA8D
	private RectTransform _statusRow; // 0x78
	private Image[] _statusIcons; // 0x80

	// Properties
	public int BoundActor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018046B9E0-0x000000018046B9F0 0x000000018046B9F0-0x000000018046BA00
	public RectTransform PortraitRect { get; } // 0x000000018046BA00-0x000000018046BC10 
	public bool MaskHpText { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018046BC10-0x000000018046BC20 0x000000018046BC20-0x000000018046BC30

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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018046FA30-0x000000018046FC80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018046FC80-0x000000018046FCC0
	}

	// Constructors
	public MatchTeamMemberSlotUI(); // 0x000000018046F930-0x000000018046FA30

	// Methods
	private void Awake(); // 0x000000018046BC30-0x000000018046C690
	public void BindActor(int actorNumber); // 0x000000018046C690-0x000000018046C6A0
	public void SetPortrait(Sprite sprite); // 0x000000018046C6A0-0x000000018046C840
	public void SetPortrait(Sprite sprite, string layers); // 0x000000018046C840-0x000000018046C980
	private void OnDestroy(); // 0x000000018046C980-0x000000018046CAA0
	public void SetWeapon(int imageId, string rarity, long userId); // 0x000000018046CAA0-0x000000018046CD40
	public void SetBars(int curHp, int maxHp, int curMana, int maxMana, int curPow, int maxPow); // 0x000000018046CD40-0x000000018046D1D0
	private void TweenBar(Slider slider, int value, int max); // 0x000000018046D1D0-0x000000018046D630
	[IteratorStateMachine(typeof(_TweenBarCo_d__29))]
	private IEnumerator TweenBarCo(Slider slider, float target); // 0x000000018046D630-0x000000018046D750
	public void SetYourTurnVisible(bool visible); // 0x000000018046D750-0x000000018046D8A0
	public void SetDeadState(bool isDead); // 0x000000018046D8A0-0x000000018046DA10
	public void SetStatusIcons(IList<string> types); // 0x000000018046DA10-0x000000018046E090
	private bool EnsureStatusRow(); // 0x000000018046E090-0x000000018046EDF0
	private static Slider FindSlider(Transform root, string childName); // 0x000000018046EDF0-0x000000018046EF10
	private static UnityEngine.UI.Text FindText(Transform root, string childName); // 0x000000018046EF10-0x000000018046F030
	private static Image ResolvePortraitImage(Transform root); // 0x000000018046F030-0x000000018046F4E0
	private static GameObject ResolveYourTurn(Transform root); // 0x000000018046F4E0-0x000000018046F6C0
	private static Transform FindDeepChild(Transform parent, string name); // 0x000000018046F6C0-0x000000018046F930
}

