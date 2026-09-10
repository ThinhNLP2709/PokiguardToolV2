/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class GuildContribPopup : MonoBehaviour // TypeDefIndex: 693
{
	// Fields
	private const int LEVEL_MAX = 30; // Metadata: 0x0068B929
	private const float ARM_SECONDS = 4f; // Metadata: 0x0068B92A
	private static readonly long[] CHIPS; // 0x00
	private const float PANEL_W = 800f; // Metadata: 0x0068B92E
	private const float PANEL_H = 440f; // Metadata: 0x0068B932
	private const float PAD = 24f; // Metadata: 0x0068B936
	private const float BAR_W = 752f; // Metadata: 0x0068B93A
	private const float BAR_H = 52f; // Metadata: 0x0068B93E
	private const float CHIP_W = 136f; // Metadata: 0x0068B942
	private const float CHIP_H = 84f; // Metadata: 0x0068B946
	private const float CHIP_STEP = 148f; // Metadata: 0x0068B94A
	private static readonly Color CHIP_ON; // 0x08
	private static readonly Color CHIP_OFF; // 0x18
	private static readonly Color CHIP_DEAD; // 0x28
	private static readonly Color CTA_ON; // 0x38
	private static readonly Color CTA_ARMED; // 0x48
	private static readonly Color CTA_DEAD; // 0x58
	private static readonly Color PANEL_FLAT; // 0x68
	private static readonly Color BAR_FLAT; // 0x78
	private GuildPanelController _owner; // 0x20
	private GuildInfo _guild; // 0x28
	private RectTransform _panel; // 0x30
	private UnityEngine.UI.Text _txtTitle; // 0x38
	private UnityEngine.UI.Text _txtWallet; // 0x40
	private UnityEngine.UI.Text _txtTeam; // 0x48
	private UnityEngine.UI.Text _txtCaption; // 0x50
	private Image _expFill; // 0x58
	private UnityEngine.UI.Text _expText; // 0x60
	private readonly Button[] _chips; // 0x68
	private readonly Image[] _chipImgs; // 0x70
	private readonly UnityEngine.UI.Text[] _chipTexts; // 0x78
	private readonly UnityEngine.UI.Text[] _chipSubs; // 0x80
	private readonly bool[] _chipOk; // 0x88
	private Button _btnCta; // 0x90
	private Image _imgCta; // 0x98
	private UnityEngine.UI.Text _txtCta; // 0xA0
	private UnityEngine.UI.Text _flyGold; // 0xA8
	private UnityEngine.UI.Text _flyExp; // 0xB0
	private GameObject _help; // 0xB8
	private RectTransform _helpPanel; // 0xC0
	private UnityEngine.UI.Text _helpTeam; // 0xC8
	private UnityEngine.UI.Text _helpPool; // 0xD0
	private UnityEngine.UI.Text _helpExp; // 0xD8
	private bool _built; // 0xE0
	private bool _sending; // 0xE1
	private bool _armed; // 0xE2
	private Coroutine _disarmCo; // 0xE8
	private int _pick; // 0xF0
	private long _gold; // 0xF8
	private float _expShown; // 0x100
	private bool _expTweening; // 0x104

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 694
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__69_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180468860-0x00000001804688D0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FetchGold_b__69_1(string _); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 695
	{
		// Fields
		public GuildContribPopup __4__this; // 0x10
		public int idx; // 0x18

		// Constructors
		public __c__DisplayClass56_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildChip_b__0(); // 0x0000000180468510-0x0000000180468690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 696
	{
		// Fields
		public UnityEngine.UI.Text node; // 0x10
		public RectTransform rt; // 0x18
		public Vector2 from; // 0x20
		public float rise; // 0x28
		public Color color; // 0x2C

		// Constructors
		public __c__DisplayClass85_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Fly_b__0(float v); // 0x0000000180468690-0x00000001804687A0
		internal void _Fly_b__1(); // 0x00000001804687A0-0x0000000180468830
	}

	[CompilerGenerated]
	private sealed class _DisarmAfter_d__78 : IEnumerator<object> // TypeDefIndex: 697
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float sec; // 0x20
		public GuildContribPopup __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisarmAfter_d__78(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180466A90-0x0000000180466B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180466B80-0x0000000180466BC0
	}

	// Constructors
	public GuildContribPopup(); // 0x0000000180458CB0-0x0000000180458DD0
	static GuildContribPopup(); // 0x0000000180458B50-0x0000000180458CB0

	// Methods
	public void Open(GuildPanelController owner, GuildInfo guild); // 0x0000000180455CD0-0x0000000180456000
	public void Close(); // 0x0000000180451D80-0x0000000180451DF0
	private void OnDisable(); // 0x0000000180455540-0x00000001804557C0
	private void Build(); // 0x0000000180450710-0x0000000180451CA0
	private void MakeBar(Transform parent, string name, Vector2 pos, float height, Color fillTint, Color textColor, out Image fill, out UnityEngine.UI.Text label); // 0x0000000180453E70-0x0000000180454610
	private void BuildChip(int i); // 0x000000018044FE50-0x0000000180450710
	private Button MakeCornerButton(string name, Vector2 pos, string glyph, Color bg, Color ink, UnityAction action); // 0x0000000180454610-0x0000000180454B00
	private UnityEngine.UI.Text MakeText(Transform parent, string name, Vector2 pos, Vector2 size, string value, int fontSize, Color color, FontStyle style); // 0x0000000180454D60-0x0000000180455330
	private Font SampleFont(); // 0x0000000180458570-0x00000001804586A0
	private static void PopIn(GameObject go); // 0x0000000180456180-0x00000001804562F0
	private void Render(); // 0x0000000180458040-0x0000000180458570
	private void RenderWallet(); // 0x0000000180457ED0-0x0000000180458040
	private void RenderExpBar(bool max); // 0x0000000180457520-0x0000000180457880
	private void RenderTeamLine(int exp2, int exp3); // 0x0000000180457D10-0x0000000180457ED0
	private void RenderCaption(int rate, bool max); // 0x00000001804562F0-0x0000000180456570
	private void RenderChips(GuildHomeData home, int rate, bool max); // 0x0000000180456570-0x0000000180456EE0
	private void RenderCta(int rate, bool max); // 0x0000000180456EE0-0x0000000180457520
	private static void SetFill(Image fill, float ratio); // 0x00000001804586A0-0x00000001804587E0
	private void FetchGold(); // 0x00000001804536C0-0x00000001804538A0
	private void OpenHelp(); // 0x0000000180455B80-0x0000000180455CD0
	private void CloseHelp(); // 0x0000000180451CA0-0x0000000180451D80
	private void EnsureHelp(); // 0x00000001804521E0-0x00000001804536C0
	private UnityEngine.UI.Text MakeHelpHead(Vector2 pos, string value, Color color); // 0x0000000180454C60-0x0000000180454D60
	private UnityEngine.UI.Text MakeHelpBody(Vector2 pos, float height); // 0x0000000180454B00-0x0000000180454C60
	private void RenderHelp(); // 0x0000000180457880-0x0000000180457D10
	private void Pick(int i); // 0x0000000180456000-0x0000000180456180
	private void OnClickDonate(); // 0x0000000180455330-0x0000000180455540
	[IteratorStateMachine(typeof(_DisarmAfter_d__78))]
	private IEnumerator DisarmAfter(float sec); // 0x0000000180451DF0-0x0000000180451E70
	private void Disarm(); // 0x0000000180451E70-0x0000000180451F00
	private void Donate(long amount); // 0x0000000180451F00-0x00000001804521E0
	private void OnDonated(GuildDonateData d); // 0x00000001804557C0-0x0000000180455B80
	private void TweenExp(); // 0x00000001804587E0-0x0000000180458AA0
	private void FlyGold(long gold); // 0x00000001804539D0-0x0000000180453B00
	private void FlyExp(long exp); // 0x00000001804538A0-0x00000001804539D0
	private static void Fly(UnityEngine.UI.Text node, string value, Color color, Vector2 from, float rise); // 0x0000000180453B00-0x0000000180453E70
	[CompilerGenerated]
	private void _FetchGold_b__69_0(UserDTO u); // 0x0000000180458AC0-0x0000000180458AE0
	[CompilerGenerated]
	private void _Donate_b__80_0(GuildDonateData d); // 0x0000000180458AA0-0x0000000180458AB0
	[CompilerGenerated]
	private void _Donate_b__80_1(); // 0x0000000180458AB0-0x0000000180458AC0
	[CompilerGenerated]
	private void _TweenExp_b__82_0(float v); // 0x0000000180458AE0-0x0000000180458B40
	[CompilerGenerated]
	private void _TweenExp_b__82_1(); // 0x0000000180458B40-0x0000000180458B50
}

