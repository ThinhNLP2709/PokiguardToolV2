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

public class GuildContribPopup : GuildInfoPopup // TypeDefIndex: 768
{
	// Fields
	private const int LEVEL_MAX = 30; // Metadata: 0x005EE6D1
	private const float ARM_SECONDS = 4f; // Metadata: 0x005EE6D2
	private static readonly long[] CHIPS; // 0x00
	private const float CARD_W = 800f; // Metadata: 0x005EE6D6
	private const float CARD_H = 720f; // Metadata: 0x005EE6DA
	private const float CARD_Y = 118f; // Metadata: 0x005EE6DE
	private const float CARD_L_X = 64f; // Metadata: 0x005EE6E2
	private const float CARD_R_X = 910f; // Metadata: 0x005EE6E6
	private const float PAD = 36f; // Metadata: 0x005EE6EA
	private const float INNER_W = 728f; // Metadata: 0x005EE6EE
	private const float BAR_Y = 160f; // Metadata: 0x005EE6F2
	private const float BAR_H = 52f; // Metadata: 0x005EE6F6
	private const float FILL_INSET = 7f; // Metadata: 0x005EE6FA
	private const float FILL_H = 38f; // Metadata: 0x005EE6FE
	private const float FILL_MAX_W = 714f; // Metadata: 0x005EE702
	private const float CHIP_X0 = 36f; // Metadata: 0x005EE706
	private const float CHIP_Y = 204f; // Metadata: 0x005EE70A
	private const float CHIP_W = 136f; // Metadata: 0x005EE70E
	private const float CHIP_H = 96f; // Metadata: 0x005EE712
	private const float CHIP_STEP = 148f; // Metadata: 0x005EE716
	private const float HOW_Y1 = 386f; // Metadata: 0x005EE71A
	private const float HOW_Y2 = 470f; // Metadata: 0x005EE71E
	private const float HOW_Y3 = 554f; // Metadata: 0x005EE722
	private const float HOW_H = 72f; // Metadata: 0x005EE726
	private GuildPanelController _owner; // 0x70
	private GuildInfo _guild; // 0x78
	private UnityEngine.UI.Text _secProgress; // 0x80
	private UnityEngine.UI.Text _txtLevel; // 0x88
	private UnityEngine.UI.Text _txtExpLabel; // 0x90
	private Image _barBg; // 0x98
	private Image _expFill; // 0xA0
	private UnityEngine.UI.Text _txtExp; // 0xA8
	private UnityEngine.UI.Text _txtTeam; // 0xB0
	private UnityEngine.UI.Text _secHowto; // 0xB8
	private UnityEngine.UI.Text _txtHowTeam; // 0xC0
	private UnityEngine.UI.Text _txtHowGold; // 0xC8
	private UnityEngine.UI.Text _txtHowExp; // 0xD0
	private UnityEngine.UI.Text _txtOff; // 0xD8
	private UnityEngine.UI.Text _secGold; // 0xE0
	private UnityEngine.UI.Text _txtWallet; // 0xE8
	private UnityEngine.UI.Text _txtPick; // 0xF0
	private readonly Button[] _chips; // 0xF8
	private readonly Image[] _chipImgs; // 0x100
	private readonly UnityEngine.UI.Text[] _chipMains; // 0x108
	private readonly UnityEngine.UI.Text[] _chipSubs; // 0x110
	private readonly bool[] _chipOk; // 0x118
	private UnityEngine.UI.Text _txtCaption; // 0x120
	private UnityEngine.UI.Text _txtPreview; // 0x128
	private Button _btnDonate; // 0x130
	private Image _imgDonate; // 0x138
	private UnityEngine.UI.Text _txtDonateLabel; // 0x140
	private UnityEngine.UI.Text _txtNote; // 0x148
	private UnityEngine.UI.Text _flyGold; // 0x150
	private Vector2 _flyGoldHome; // 0x158
	private UnityEngine.UI.Text _flyExp; // 0x160
	private Vector2 _flyExpHome; // 0x168
	private bool _built; // 0x170
	private bool _sending; // 0x171
	private bool _armed; // 0x172
	private Coroutine _disarmCo; // 0x178
	private int _pick; // 0x180
	private long _gold; // 0x188
	private float _expShown; // 0x190
	private bool _expTweening; // 0x194

	// Properties
	private static Color DividerColor { get; } // 0x00000001804EDBE0-0x00000001804EDC60 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 769
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__86_1; // 0x08

		// Constructors
		static __c(); // 0x00000001804F7350-0x00000001804F73F0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchGold_b__86_1(string _); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 770
	{
		// Fields
		public GuildContribPopup __4__this; // 0x10
		public int idx; // 0x18

		// Constructors
		public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildChip_b__0(); // 0x00000001804F73F0-0x00000001804F7420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 771
	{
		// Fields
		public UnityEngine.UI.Text node; // 0x10
		public RectTransform rt; // 0x18
		public Vector2 home; // 0x20
		public float rise; // 0x28
		public Color color; // 0x2C

		// Constructors
		public __c__DisplayClass96_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Fly_b__0(float v); // 0x00000001804F7420-0x00000001804F75B0
		internal void _Fly_b__1(); // 0x00000001804F75B0-0x00000001804F7700
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__89 : IEnumerator<object> // TypeDefIndex: 772
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public GuildContribPopup __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisarmAfter_d__89(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804F7700-0x00000001804F7870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F7870-0x00000001804F78B0
	}

	// Constructors
	public GuildContribPopup(); // 0x00000001804F6F20-0x00000001804F7200
	static GuildContribPopup(); // 0x00000001804F7200-0x00000001804F72F0

	// Methods
	public void Open(GuildPanelController owner, GuildInfo guild); // 0x00000001804EDC60-0x00000001804EDD60
	public void Close(); // 0x00000001804EDD60-0x00000001804EDE20
	protected override void OnDisable(); // 0x00000001804EDE20-0x00000001804EE050
	private static void StopFly(UnityEngine.UI.Text node); // 0x00000001804EE050-0x00000001804EE230
	private void Build(); // 0x00000001804EE230-0x00000001804EE570
	private void BuildProgressCard(RectTransform card); // 0x00000001804EE570-0x00000001804EF560
	private void BuildExpBar(RectTransform card); // 0x00000001804EF560-0x00000001804EFA70
	private UnityEngine.UI.Text BuildHowRow(RectTransform card, string suffix, float y, string icon, bool rich); // 0x00000001804EFA70-0x00000001804EFC90
	private void BuildGoldCard(RectTransform card); // 0x00000001804EFC90-0x00000001804F0E70
	private void BuildChip(RectTransform card, int i); // 0x00000001804F0E70-0x00000001804F1620
	private void Render(); // 0x00000001804F1620-0x00000001804F1A10
	private void RenderWallet(); // 0x00000001804F1A10-0x00000001804F1B00
	private void RenderExpBar(bool max); // 0x00000001804F1B00-0x00000001804F1F20
	private void RenderTeamLine(int exp2, int exp3, GuildHomeData home); // 0x00000001804F1F20-0x00000001804F2880
	private void RenderHowto(int exp2, int exp3, int rate, GuildHomeData home); // 0x00000001804F2880-0x00000001804F38F0
	private void RenderChips(GuildHomeData home, int rate, bool max); // 0x00000001804F38F0-0x00000001804F4280
	private void RenderCaption(int rate, bool max); // 0x00000001804F4280-0x00000001804F46D0
	private void RenderPreview(int rate, bool max); // 0x00000001804F46D0-0x00000001804F4A00
	private void RenderCta(int rate, bool max); // 0x00000001804F4A00-0x00000001804F4F20
	private void SetFill(float ratio); // 0x00000001804F4F20-0x00000001804F5070
	private void FetchGold(); // 0x00000001804F5070-0x00000001804F5310
	private void Pick(int i); // 0x00000001804F5310-0x00000001804F5590
	private void OnClickDonate(); // 0x00000001804F5590-0x00000001804F5870
	[IteratorStateMachine(typeof(_DisarmAfter_d__89))]
	private IEnumerator DisarmAfter(float sec); // 0x00000001804F5870-0x00000001804F5930
	private void Disarm(); // 0x00000001804F5930-0x00000001804F5A40
	private void Donate(long amount); // 0x00000001804F5A40-0x00000001804F5F00
	private void OnDonated(GuildDonateData d); // 0x00000001804F5F00-0x00000001804F6370
	private void TweenExp(); // 0x00000001804F6370-0x00000001804F6700
	private void FlyGold(long gold); // 0x00000001804F6700-0x00000001804F6840
	private void FlyExp(long exp); // 0x00000001804F6840-0x00000001804F69A0
	private static void Fly(UnityEngine.UI.Text node, Vector2 home, string value, Color color, float rise); // 0x00000001804F69A0-0x00000001804F6F20
	[CompilerGenerated]
	private void _FetchGold_b__86_0(UserDTO u); // 0x00000001804F72F0-0x00000001804F7310
	[CompilerGenerated]
	private void _Donate_b__91_0(GuildDonateData d); // 0x00000001804F7310-0x00000001804F7320
	[CompilerGenerated]
	private void _Donate_b__91_1(); // 0x00000001804F7320-0x00000001804F7330
	[CompilerGenerated]
	private void _TweenExp_b__93_0(float v); // 0x00000001804F7330-0x00000001804F7340
	[CompilerGenerated]
	private void _TweenExp_b__93_1(); // 0x00000001804F7340-0x00000001804F7350
}

