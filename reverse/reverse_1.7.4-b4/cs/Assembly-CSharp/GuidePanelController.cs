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

public class GuidePanelController : MonoBehaviour // TypeDefIndex: 766
{
	// Fields
	public const string PANEL_KEY = "PanelHuongDan"; // Metadata: 0x005EFA79
	public const string ART_DIR = "Image/GuideUI/"; // Metadata: 0x005EFA87
	[Header("Ti\u00EAu \u0111\u1EC1")]
	public UnityEngine.UI.Text titleText; // 0x20
	public UnityEngine.UI.Text headingText; // 0x28
	public Image headingIcon; // 0x30
	[Header("N\u1ED9i dung")]
	public ScrollRect scrollRect; // 0x38
	[Header("Danh m\u1EE5c (c\u1ED9t tr\u00E1i)")]
	[Tooltip("Node cha c\u1EE7a c\u00E1c n\u00FAt danh m\u1EE5c \u2014 c\u00F3 VerticalLayoutGroup + ContentSizeFitter.")]
	public RectTransform tabRoot; // 0x40
	[Tooltip("N\u00FAt danh m\u1EE5c M\u1EAAU, lu\u00F4n inactive trong prefab. M\u1ED7i ch\u01B0\u01A1ng nh\u00E2n b\u1EA3n m\u1ED9t c\u00E1i.")]
	public GameObject tabTemplate; // 0x48
	public ScrollRect tabScroll; // 0x50
	[Header("N\u00FAt")]
	public Button btnClose; // 0x58
	[Header("Hi\u1EC7u \u1EE9ng \u2014 T\u00D9Y CH\u1ECCN")]
	public CanvasGroup canvasGroup; // 0x60
	[Header("M\u00E0u n\u00FAt danh m\u1EE5c")]
	public Sprite tabActiveSprite; // 0x68
	public Sprite tabInactiveSprite; // 0x70
	public Color tabActiveTextColor; // 0x78
	public Color tabInactiveTextColor; // 0x88
	[Header("M\u1EABu kh\u1ED1i n\u1ED9i dung \u2014 lu\u00F4n INACTIVE trong prefab")]
	public GameObject tplHeading; // 0x98
	public GameObject tplText; // 0xA0
	public GameObject tplHero; // 0xA8
	public GameObject tplIconRow; // 0xB0
	public GameObject tplIconRowCell; // 0xB8
	public GameObject tplIconList; // 0xC0
	public GameObject tplGallery; // 0xC8
	public GameObject tplGalleryCell; // 0xD0
	public GameObject tplSteps; // 0xD8
	public GameObject tplTip; // 0xE0
	public GameObject tplCycle; // 0xE8
	public GameObject tplBoard; // 0xF0
	private const int TEXT_CHAR_CAP = 8900; // Metadata: 0x005EFA96
	private const string TITLE_COLOR = "#FFDD84"; // Metadata: 0x005EFA9A
	private readonly List<Button> _tabButtons; // 0xF8
	private readonly List<GameObject> _spawned; // 0x100
	private readonly Dictionary<string, Sprite> _spriteCache; // 0x108
	private static readonly HashSet<string> _warnedMissing; // 0x00
	private int _current; // 0x110
	private bool _built; // 0x114

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 767
	{
		// Fields
		public int idx; // 0x10
		public GuidePanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildTabsOnce_b__0(); // 0x00000001804EEFF0-0x00000001804EF020
	}

	[CompilerGenerated]
	private sealed class _ScrollToTop_d__44 : IEnumerator<object> // TypeDefIndex: 768
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuidePanelController __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ScrollToTop_d__44(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001804EF020-0x00000001804EF210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EF210-0x00000001804EF250
	}

	// Constructors
	public GuidePanelController(); // 0x00000001804EECB0-0x00000001804EEF10
	static GuidePanelController(); // 0x00000001804EEF10-0x00000001804EEFF0

	// Methods
	private void Awake(); // 0x00000001804E9200-0x00000001804E94F0
	public void Open(); // 0x00000001804E94F0-0x00000001804E9680
	public void Close(); // 0x00000001804E9680-0x00000001804E9880
	public int RenderForPreview(int chapter); // 0x00000001804E9880-0x00000001804E9BE0
	private void BuildTabsOnce(); // 0x00000001804E9BE0-0x00000001804EA270
	private static UnityEngine.UI.Text FindLabel(GameObject go); // 0x00000001804EA270-0x00000001804EA4D0
	private static Image FindImage(GameObject go, string childName); // 0x00000001804EA4D0-0x00000001804EA670
	private static UnityEngine.UI.Text FindText(GameObject go, string childName); // 0x00000001804EA670-0x00000001804EA810
	public void SelectChapter(int index, bool force); // 0x00000001804EA810-0x00000001804EABE0
	[IteratorStateMachine(typeof(_ScrollToTop_d__44))]
	private IEnumerator ScrollToTop(); // 0x00000001804EABE0-0x00000001804EAC80
	private void RebuildContent(); // 0x00000001804EAC80-0x00000001804EAFC0
	private void PaintTabs(int active); // 0x00000001804EAFC0-0x00000001804EB410
	private void RenderBlocks(List<GuideContent.Block> blocks); // 0x00000001804EB410-0x00000001804EB800
	private void ClearSpawned(); // 0x00000001804EB800-0x00000001804EBA30
	private GameObject Spawn(GameObject template, string name); // 0x00000001804EBA30-0x00000001804EBD30
	private void SpawnHeading(GuideContent.Block b); // 0x00000001804EBD30-0x00000001804EBED0
	private void SpawnText(GuideContent.Block b); // 0x00000001804EBED0-0x00000001804EC090
	private void SpawnHero(GuideContent.Block b); // 0x00000001804EC090-0x00000001804EC650
	private void SpawnIconRow(GuideContent.Block b); // 0x00000001804EC650-0x00000001804ECCD0
	private void SpawnIconList(GuideContent.Block b); // 0x00000001804ECCD0-0x00000001804ED560
	private void SpawnGallery(GuideContent.Block b); // 0x00000001804ED560-0x00000001804EDBA0
	private void SpawnSteps(GuideContent.Block b); // 0x00000001804EDBA0-0x00000001804EE090
	private void SpawnTip(GuideContent.Block b); // 0x00000001804EE090-0x00000001804EE230
	private static string Compose(string title, string desc); // 0x00000001804EE230-0x00000001804EE310
	private static void FillText(UnityEngine.UI.Text t, string text); // 0x00000001804EE310-0x00000001804EE500
	private void SetSprite(Image img, string key); // 0x00000001804EE500-0x00000001804EE700
	private Sprite ResolveSprite(string key); // 0x00000001804EE700-0x00000001804EECB0
}

