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

public class GuidePanelController : MonoBehaviour // TypeDefIndex: 765
{
	// Fields
	public const string PANEL_KEY = "PanelHuongDan"; // Metadata: 0x005EE6A8
	public const string ART_DIR = "Image/GuideUI/"; // Metadata: 0x005EE6B6
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
	private const int TEXT_CHAR_CAP = 8900; // Metadata: 0x005EE6C5
	private const string TITLE_COLOR = "#FFDD84"; // Metadata: 0x005EE6C9
	private readonly List<Button> _tabButtons; // 0xF8
	private readonly List<GameObject> _spawned; // 0x100
	private readonly Dictionary<string, Sprite> _spriteCache; // 0x108
	private static readonly HashSet<string> _warnedMissing; // 0x00
	private int _current; // 0x110
	private bool _built; // 0x114

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 766
	{
		// Fields
		public int idx; // 0x10
		public GuidePanelController __4__this; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildTabsOnce_b__0(); // 0x00000001804ED980-0x00000001804ED9B0
	}

	[CompilerGenerated]
	private sealed class _ScrollToTop_d__44 : IEnumerator<object> // TypeDefIndex: 767
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001804ED9B0-0x00000001804EDBA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804EDBA0-0x00000001804EDBE0
	}

	// Constructors
	public GuidePanelController(); // 0x00000001804ED640-0x00000001804ED8A0
	static GuidePanelController(); // 0x00000001804ED8A0-0x00000001804ED980

	// Methods
	private void Awake(); // 0x00000001804E7B90-0x00000001804E7E80
	public void Open(); // 0x00000001804E7E80-0x00000001804E8010
	public void Close(); // 0x00000001804E8010-0x00000001804E8210
	public int RenderForPreview(int chapter); // 0x00000001804E8210-0x00000001804E8570
	private void BuildTabsOnce(); // 0x00000001804E8570-0x00000001804E8C00
	private static UnityEngine.UI.Text FindLabel(GameObject go); // 0x00000001804E8C00-0x00000001804E8E60
	private static Image FindImage(GameObject go, string childName); // 0x00000001804E8E60-0x00000001804E9000
	private static UnityEngine.UI.Text FindText(GameObject go, string childName); // 0x00000001804E9000-0x00000001804E91A0
	public void SelectChapter(int index, bool force); // 0x00000001804E91A0-0x00000001804E9570
	[IteratorStateMachine(typeof(_ScrollToTop_d__44))]
	private IEnumerator ScrollToTop(); // 0x00000001804E9570-0x00000001804E9610
	private void RebuildContent(); // 0x00000001804E9610-0x00000001804E9950
	private void PaintTabs(int active); // 0x00000001804E9950-0x00000001804E9DA0
	private void RenderBlocks(List<GuideContent.Block> blocks); // 0x00000001804E9DA0-0x00000001804EA190
	private void ClearSpawned(); // 0x00000001804EA190-0x00000001804EA3C0
	private GameObject Spawn(GameObject template, string name); // 0x00000001804EA3C0-0x00000001804EA6C0
	private void SpawnHeading(GuideContent.Block b); // 0x00000001804EA6C0-0x00000001804EA860
	private void SpawnText(GuideContent.Block b); // 0x00000001804EA860-0x00000001804EAA20
	private void SpawnHero(GuideContent.Block b); // 0x00000001804EAA20-0x00000001804EAFE0
	private void SpawnIconRow(GuideContent.Block b); // 0x00000001804EAFE0-0x00000001804EB660
	private void SpawnIconList(GuideContent.Block b); // 0x00000001804EB660-0x00000001804EBEF0
	private void SpawnGallery(GuideContent.Block b); // 0x00000001804EBEF0-0x00000001804EC530
	private void SpawnSteps(GuideContent.Block b); // 0x00000001804EC530-0x00000001804ECA20
	private void SpawnTip(GuideContent.Block b); // 0x00000001804ECA20-0x00000001804ECBC0
	private static string Compose(string title, string desc); // 0x00000001804ECBC0-0x00000001804ECCA0
	private static void FillText(UnityEngine.UI.Text t, string text); // 0x00000001804ECCA0-0x00000001804ECE90
	private void SetSprite(Image img, string key); // 0x00000001804ECE90-0x00000001804ED090
	private Sprite ResolveSprite(string key); // 0x00000001804ED090-0x00000001804ED640
}

