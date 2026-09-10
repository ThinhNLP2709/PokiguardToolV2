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
	private const float BAR_TWEEN_SEC = 0.15f; // Metadata: 0x0068AA97
	private readonly Dictionary<Slider, Coroutine> _barTweens; // 0x70
	private const int MAX_STATUS_ICONS = 3; // Metadata: 0x0068AA9B
	private const float STATUS_ICON_SIZE = 22f; // Metadata: 0x0068AA9C
	private const float STATUS_ICON_GAP = 3f; // Metadata: 0x0068AAA0
	private RectTransform _statusRow; // 0x78
	private Image[] _statusIcons; // 0x80

	// Properties
	public int BoundActor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C0B0-0x000000018039C0C0 0x000000018039D7E0-0x000000018039D7F0
	public RectTransform PortraitRect { get; } // 0x00000001804196B0-0x00000001804197A0 
	public bool MaskHpText { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018039C3C0-0x000000018039C3D0 0x000000018039DA40-0x000000018039DA50

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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TweenBarCo_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001804252F0-0x00000001804254C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804254C0-0x0000000180425500
	}

	// Constructors
	public MatchTeamMemberSlotUI(); // 0x0000000180419630-0x00000001804196B0

	// Methods
	private void Awake(); // 0x0000000180417930-0x0000000180417CA0
	public void BindActor(int actorNumber); // 0x0000000180417CA0-0x0000000180417CB0
	public void SetPortrait(Sprite sprite); // 0x0000000180418D00-0x0000000180418DA0
	public void SetPortrait(Sprite sprite, string layers); // 0x0000000180418C40-0x0000000180418D00
	private void OnDestroy(); // 0x0000000180418590-0x0000000180418620
	public void SetWeapon(int imageId, string rarity, long userId); // 0x00000001804191E0-0x00000001804192E0
	public void SetBars(int curHp, int maxHp, int curMana, int maxMana, int curPow, int maxPow); // 0x00000001804188A0-0x0000000180418B80
	private void TweenBar(Slider slider, int value, int max); // 0x0000000180419410-0x0000000180419630
	[IteratorStateMachine(typeof(_TweenBarCo_d__29))]
	private IEnumerator TweenBarCo(Slider slider, float target); // 0x0000000180419370-0x0000000180419410
	public void SetYourTurnVisible(bool visible); // 0x00000001804192E0-0x0000000180419370
	public void SetDeadState(bool isDead); // 0x0000000180418B80-0x0000000180418C40
	public void SetStatusIcons(IList<string> types); // 0x0000000180418DA0-0x00000001804191E0
	private bool EnsureStatusRow(); // 0x0000000180417CB0-0x0000000180418360
	private static Slider FindSlider(Transform root, string childName); // 0x0000000180418450-0x00000001804184F0
	private static UnityEngine.UI.Text FindText(Transform root, string childName); // 0x00000001804184F0-0x0000000180418590
	private static Image ResolvePortraitImage(Transform root); // 0x0000000180418620-0x00000001804187D0
	private static GameObject ResolveYourTurn(Transform root); // 0x00000001804187D0-0x00000001804188A0
	private static Transform FindDeepChild(Transform parent, string name); // 0x0000000180418360-0x0000000180418450
}

