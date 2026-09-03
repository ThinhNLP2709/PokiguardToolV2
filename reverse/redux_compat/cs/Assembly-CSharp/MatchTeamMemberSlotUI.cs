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

[DisallowMultipleComponent]
public class MatchTeamMemberSlotUI : MonoBehaviour // TypeDefIndex: 65
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
	private const float BAR_TWEEN_SEC = 0.15f; // Metadata: 0x0064BF81
	private readonly Dictionary<Slider, Coroutine> _barTweens; // 0x70

	// Properties
	public int BoundActor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
	public bool MaskHpText { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803002D0-0x00000001803002E0 0x00000001803002F0-0x0000000180300300

	// Nested types
	[CompilerGenerated]
	private sealed class _TweenBarCo_d__25 : IEnumerator<object> // TypeDefIndex: 66
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TweenBarCo_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018030EFC0-0x000000018030F190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018030F190-0x000000018030F1D0
	}

	// Constructors
	public MatchTeamMemberSlotUI(); // 0x0000000180300240-0x00000001803002C0

	// Methods
	private void Awake(); // 0x00000001802FF1C0-0x00000001802FF530
	public void BindActor(int actorNumber); // 0x00000001802FF530-0x00000001802FF540
	public void SetPortrait(Sprite sprite); // 0x00000001802FFD50-0x00000001802FFDF0
	public void SetWeapon(int imageId, string rarity, long userId); // 0x00000001802FFDF0-0x00000001802FFEF0
	public void SetBars(int curHp, int maxHp, int curMana, int maxMana, int curPow, int maxPow); // 0x00000001802FF9F0-0x00000001802FFC90
	private void TweenBar(Slider slider, int value, int max); // 0x0000000180300020-0x0000000180300240
	[IteratorStateMachine(typeof(_TweenBarCo_d__25))]
	private IEnumerator TweenBarCo(Slider slider, float target); // 0x00000001802FFF80-0x0000000180300020
	public void SetYourTurnVisible(bool visible); // 0x00000001802FFEF0-0x00000001802FFF80
	public void SetDeadState(bool isDead); // 0x00000001802FFC90-0x00000001802FFD50
	private static Slider FindSlider(Transform root, string childName); // 0x00000001802FF630-0x00000001802FF6D0
	private static UnityEngine.UI.Text FindText(Transform root, string childName); // 0x00000001802FF6D0-0x00000001802FF770
	private static Image ResolvePortraitImage(Transform root); // 0x00000001802FF770-0x00000001802FF920
	private static GameObject ResolveYourTurn(Transform root); // 0x00000001802FF920-0x00000001802FF9F0
	private static Transform FindDeepChild(Transform parent, string name); // 0x00000001802FF540-0x00000001802FF630
}

