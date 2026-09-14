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

public class GuildContribPopup : GuildInfoPopup // TypeDefIndex: 769
{
	// Fields
	private const float ARM_SECONDS = 4f; // Metadata: 0x005EFAA2
	private static readonly long[] CHIPS; // 0x00
	private const float CARD_W = 800f; // Metadata: 0x005EFAA6
	private const float CARD_H = 720f; // Metadata: 0x005EFAAA
	private const float CARD_Y = 118f; // Metadata: 0x005EFAAE
	private const float CARD_L_X = 64f; // Metadata: 0x005EFAB2
	private const float CARD_R_X = 910f; // Metadata: 0x005EFAB6
	private const float PAD = 36f; // Metadata: 0x005EFABA
	private const float INNER_W = 728f; // Metadata: 0x005EFABE
	private const float BAR_Y = 160f; // Metadata: 0x005EFAC2
	private const float BAR_H = 52f; // Metadata: 0x005EFAC6
	private const float FILL_INSET = 7f; // Metadata: 0x005EFACA
	private const float FILL_H = 38f; // Metadata: 0x005EFACE
	private const float FILL_MAX_W = 714f; // Metadata: 0x005EFAD2
	private const float CHIP_X0 = 36f; // Metadata: 0x005EFAD6
	private const float CHIP_Y = 204f; // Metadata: 0x005EFADA
	private const float CHIP_W = 136f; // Metadata: 0x005EFADE
	private const float CHIP_H = 96f; // Metadata: 0x005EFAE2
	private const float CHIP_STEP = 148f; // Metadata: 0x005EFAE6
	private const float HOW_Y1 = 386f; // Metadata: 0x005EFAEA
	private const float HOW_Y2 = 470f; // Metadata: 0x005EFAEE
	private const float HOW_Y3 = 554f; // Metadata: 0x005EFAF2
	private const float HOW_H = 72f; // Metadata: 0x005EFAF6
	private GuildPanelController _owner; // 0x70
	private GuildInfo _guild; // 0x78
	private UnityEngine.UI.Text _secProgress; // 0x80
	private UnityEngine.UI.Text _txtLevel; // 0x88
	private UnityEngine.UI.Text _txtLevelMax; // 0x90
	private UnityEngine.UI.Text _txtExpLabel; // 0x98
	private Image _barBg; // 0xA0
	private Image _expFill; // 0xA8
	private UnityEngine.UI.Text _txtExp; // 0xB0
	private UnityEngine.UI.Text _txtTeam; // 0xB8
	private UnityEngine.UI.Text _secHowto; // 0xC0
	private UnityEngine.UI.Text _txtHowTeam; // 0xC8
	private UnityEngine.UI.Text _txtHowGold; // 0xD0
	private UnityEngine.UI.Text _txtHowExp; // 0xD8
	private UnityEngine.UI.Text _txtOff; // 0xE0
	private UnityEngine.UI.Text _secGold; // 0xE8
	private UnityEngine.UI.Text _txtWallet; // 0xF0
	private UnityEngine.UI.Text _txtPick; // 0xF8
	private readonly Button[] _chips; // 0x100
	private readonly Image[] _chipImgs; // 0x108
	private readonly UnityEngine.UI.Text[] _chipMains; // 0x110
	private readonly UnityEngine.UI.Text[] _chipSubs; // 0x118
	private readonly bool[] _chipOk; // 0x120
	private UnityEngine.UI.Text _txtCaption; // 0x128
	private UnityEngine.UI.Text _txtPreview; // 0x130
	private Button _btnDonate; // 0x138
	private Image _imgDonate; // 0x140
	private UnityEngine.UI.Text _txtDonateLabel; // 0x148
	private UnityEngine.UI.Text _txtNote; // 0x150
	private UnityEngine.UI.Text _flyGold; // 0x158
	private Vector2 _flyGoldHome; // 0x160
	private UnityEngine.UI.Text _flyExp; // 0x168
	private Vector2 _flyExpHome; // 0x170
	private bool _built; // 0x178
	private bool _sending; // 0x179
	private bool _armed; // 0x17A
	private Coroutine _disarmCo; // 0x180
	private int _pick; // 0x188
	private long _gold; // 0x190
	private float _expShown; // 0x198
	private bool _expTweening; // 0x19C

	// Properties
	private static Color DividerColor { get; } // 0x00000001804EF250-0x00000001804EF2D0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 770
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__86_1; // 0x08

		// Constructors
		static __c(); // 0x00000001804F8AF0-0x00000001804F8B90
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchGold_b__86_1(string _); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass75_0 // TypeDefIndex: 771
	{
		// Fields
		public GuildContribPopup __4__this; // 0x10
		public int idx; // 0x18

		// Constructors
		public __c__DisplayClass75_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildChip_b__0(); // 0x00000001804F8B90-0x00000001804F8BC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass96_0 // TypeDefIndex: 772
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
		internal void _Fly_b__0(float v); // 0x00000001804F8BC0-0x00000001804F8D50
		internal void _Fly_b__1(); // 0x00000001804F8D50-0x00000001804F8EA0
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__89 : IEnumerator<object> // TypeDefIndex: 773
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804F8EA0-0x00000001804F9010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804F9010-0x00000001804F9050
	}

	// Constructors
	public GuildContribPopup(); // 0x00000001804F86C0-0x00000001804F89A0
	static GuildContribPopup(); // 0x00000001804F89A0-0x00000001804F8A90

	// Methods
	public void Open(GuildPanelController owner, GuildInfo guild); // 0x00000001804EF2D0-0x00000001804EF3D0
	public void Close(); // 0x00000001804EF3D0-0x00000001804EF490
	protected override void OnDisable(); // 0x00000001804EF490-0x00000001804EF6C0
	private static void StopFly(UnityEngine.UI.Text node); // 0x00000001804EF6C0-0x00000001804EF8A0
	private void Build(); // 0x00000001804EF8A0-0x00000001804EFBE0
	private void BuildProgressCard(RectTransform card); // 0x00000001804EFBE0-0x00000001804F0C30
	private void BuildExpBar(RectTransform card); // 0x00000001804F0C30-0x00000001804F1140
	private UnityEngine.UI.Text BuildHowRow(RectTransform card, string suffix, float y, string icon, bool rich); // 0x00000001804F1140-0x00000001804F1360
	private void BuildGoldCard(RectTransform card); // 0x00000001804F1360-0x00000001804F24F0
	private void BuildChip(RectTransform card, int i); // 0x00000001804F24F0-0x00000001804F2CA0
	private void Render(); // 0x00000001804F2CA0-0x00000001804F3180
	private void RenderWallet(); // 0x00000001804F3180-0x00000001804F3270
	private void RenderExpBar(bool max); // 0x00000001804F3270-0x00000001804F3690
	private void RenderTeamLine(int exp2, int exp3, GuildHomeData home); // 0x00000001804F3690-0x00000001804F3FF0
	private void RenderHowto(int exp2, int exp3, int rate, GuildHomeData home); // 0x00000001804F3FF0-0x00000001804F5060
	private void RenderChips(GuildHomeData home, int rate, bool max); // 0x00000001804F5060-0x00000001804F59F0
	private void RenderCaption(int rate, bool max); // 0x00000001804F59F0-0x00000001804F5E60
	private void RenderPreview(int rate, bool max); // 0x00000001804F5E60-0x00000001804F6190
	private void RenderCta(int rate, bool max); // 0x00000001804F6190-0x00000001804F66B0
	private void SetFill(float ratio); // 0x00000001804F66B0-0x00000001804F6800
	private void FetchGold(); // 0x00000001804F6800-0x00000001804F6AA0
	private void Pick(int i); // 0x00000001804F6AA0-0x00000001804F6D20
	private void OnClickDonate(); // 0x00000001804F6D20-0x00000001804F7000
	[IteratorStateMachine(typeof(_DisarmAfter_d__89))]
	private IEnumerator DisarmAfter(float sec); // 0x00000001804F7000-0x00000001804F70C0
	private void Disarm(); // 0x00000001804F70C0-0x00000001804F71D0
	private void Donate(long amount); // 0x00000001804F71D0-0x00000001804F7690
	private void OnDonated(GuildDonateData d); // 0x00000001804F7690-0x00000001804F7B00
	private void TweenExp(); // 0x00000001804F7B00-0x00000001804F7EA0
	private void FlyGold(long gold); // 0x00000001804F7EA0-0x00000001804F7FE0
	private void FlyExp(long exp); // 0x00000001804F7FE0-0x00000001804F8140
	private static void Fly(UnityEngine.UI.Text node, Vector2 home, string value, Color color, float rise); // 0x00000001804F8140-0x00000001804F86C0
	[CompilerGenerated]
	private void _FetchGold_b__86_0(UserDTO u); // 0x00000001804F8A90-0x00000001804F8AB0
	[CompilerGenerated]
	private void _Donate_b__91_0(GuildDonateData d); // 0x00000001804F8AB0-0x00000001804F8AC0
	[CompilerGenerated]
	private void _Donate_b__91_1(); // 0x00000001804F8AC0-0x00000001804F8AD0
	[CompilerGenerated]
	private void _TweenExp_b__93_0(float v); // 0x00000001804F8AD0-0x00000001804F8AE0
	[CompilerGenerated]
	private void _TweenExp_b__93_1(); // 0x00000001804F8AE0-0x00000001804F8AF0
}

