/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[AddComponentMenu("UI (Canvas)/Dropdown - TextMeshPro", 35)]
	[RequireComponent(typeof(RectTransform))]
	[TMPHelpURL("index")]
	public class TMP_Dropdown : Selectable, IPointerClickHandler, ISubmitHandler, ICancelHandler // TypeDefIndex: 11803
	{
		// Fields
		private static readonly OptionData k_NothingOption; // 0x00
		private static readonly OptionData k_EverythingOption; // 0x08
		private static readonly OptionData k_MixedOption; // 0x10
		[SerializeField]
		private RectTransform m_Template; // 0x100
		[SerializeField]
		private TMP_Text m_CaptionText; // 0x108
		[SerializeField]
		private Image m_CaptionImage; // 0x110
		[SerializeField]
		private Graphic m_Placeholder; // 0x118
		[SerializeField]
		[Space]
		private TMP_Text m_ItemText; // 0x120
		[SerializeField]
		private Image m_ItemImage; // 0x128
		[SerializeField]
		[Space]
		private int m_Value; // 0x130
		[SerializeField]
		private bool m_MultiSelect; // 0x134
		[SerializeField]
		[Space]
		private OptionDataList m_Options; // 0x138
		[SerializeField]
		[Space]
		private DropdownEvent m_OnValueChanged; // 0x140
		[SerializeField]
		private float m_AlphaFadeSpeed; // 0x148
		private GameObject m_Dropdown; // 0x150
		private GameObject m_Blocker; // 0x158
		private List<DropdownItem> m_Items; // 0x160
		private TweenRunner<FloatTween> m_AlphaTweenRunner; // 0x168
		private bool validTemplate; // 0x170
		private Coroutine m_Coroutine; // 0x178
		private static readonly OptionData s_NoOptionData; // 0x18
	
		// Properties
		public RectTransform template { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x0000000182075DC0-0x0000000182075DF0
		public TMP_Text captionText { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000182075CC0-0x0000000182075CF0
		public Image captionImage { get; set; } // 0x000000018170B050-0x000000018170B060 0x0000000182075C90-0x0000000182075CC0
		public Graphic placeholder { get; set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000182075D90-0x0000000182075DC0
		public TMP_Text itemText { get; set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000182075D20-0x0000000182075D50
		public Image itemImage { get; set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000182075CF0-0x0000000182075D20
		public List<OptionData> options { get; set; } // 0x0000000182075C50-0x0000000182075C70 0x0000000182075D50-0x0000000182075D90
		public DropdownEvent onValueChanged { get; set; } // 0x0000000181C0F740-0x0000000181C0F750 0x0000000181380090-0x00000001813800B0
		public float alphaFadeSpeed { get; set; } // 0x0000000182075C40-0x0000000182075C50 0x0000000182075C80-0x0000000182075C90
		public int value { get; set; } // 0x0000000181CE61E0-0x0000000181CE61F0 0x0000000182075DF0-0x0000000182075E00
		public bool IsExpanded { get; } // 0x0000000182075BD0-0x0000000182075C30 
		public bool MultiSelect { get; set; } // 0x0000000182075C30-0x0000000182075C40 0x0000000182075C70-0x0000000182075C80
	
		// Nested types
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, ICancelHandler // TypeDefIndex: 11804
		{
			// Fields
			[SerializeField]
			private TMP_Text m_Text; // 0x20
			[SerializeField]
			private Image m_Image; // 0x28
			[SerializeField]
			private RectTransform m_RectTransform; // 0x30
			[SerializeField]
			private Toggle m_Toggle; // 0x38
	
			// Properties
			public TMP_Text text { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public Image image { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
			public RectTransform rectTransform { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
			public Toggle toggle { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
			// Constructors
			public DropdownItem(); // 0x00000001802E7A70-0x00000001802E7BC0
	
			// Methods
			public virtual void OnPointerEnter(PointerEventData eventData); // 0x000000018206CD30-0x000000018206CDB0
			public virtual void OnCancel(BaseEventData eventData); // 0x000000018206CCA0-0x000000018206CD30
		}
	
		[Serializable]
		public class OptionData // TypeDefIndex: 11805
		{
			// Fields
			[SerializeField]
			private string m_Text; // 0x10
			[SerializeField]
			private Sprite m_Image; // 0x18
			[SerializeField]
			private Color m_Color; // 0x20
	
			// Properties
			public string text { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public Sprite image { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public Color color { get; set; } // 0x0000000180D91A40-0x0000000180D91A50 0x0000000181424780-0x0000000181424790
	
			// Constructors
			public OptionData(); // 0x000000018206F0F0-0x000000018206F110
			public OptionData(string text); // 0x000000018206F180-0x000000018206F1C0
			public OptionData(Sprite image); // 0x000000018206F1C0-0x000000018206F200
			public OptionData(string text, Sprite image, Color color); // 0x000000018206F110-0x000000018206F180
		}
	
		[Serializable]
		public class OptionDataList // TypeDefIndex: 11806
		{
			// Fields
			[SerializeField]
			private List<OptionData> m_Options; // 0x10
	
			// Properties
			public List<OptionData> options { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
			// Constructors
			public OptionDataList(); // 0x000000018206F070-0x000000018206F0F0
		}
	
		[Serializable]
		public class DropdownEvent : UnityEvent<int> // TypeDefIndex: 11807
		{
			// Constructors
			public DropdownEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass76_0 // TypeDefIndex: 11808
		{
			// Fields
			public Toggle nothingToggle; // 0x10
			public Toggle everythingToggle; // 0x18
			public TMP_Dropdown __4__this; // 0x20
	
			// Constructors
			public __c__DisplayClass76_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Show_b__0(bool x); // 0x0000000182082410-0x0000000182082440
			internal void _Show_b__1(bool x); // 0x0000000182082440-0x0000000182082470
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass76_1 // TypeDefIndex: 11809
		{
			// Fields
			public DropdownItem item; // 0x10
			public TMP_Dropdown __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass76_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Show_b__2(bool x); // 0x0000000182082470-0x00000001820824A0
		}
	
		[CompilerGenerated]
		private sealed class _DelayedDestroyDropdownList_d__90 : IEnumerator<object> // TypeDefIndex: 11810
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public float delay; // 0x20
			public TMP_Dropdown __4__this; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DelayedDestroyDropdownList_d__90(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182082310-0x00000001820823D0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001820823D0-0x0000000182082410
		}
	
		// Constructors
		protected TMP_Dropdown(); // 0x0000000182075A50-0x0000000182075BD0
		static TMP_Dropdown(); // 0x0000000182075870-0x0000000182075A50
	
		// Methods
		public void SetValueWithoutNotify(int input); // 0x0000000182073B40-0x0000000182073B50
		private void SetValue(int value, bool sendCallback = true /* Metadata: 0x006A1F3F */); // 0x0000000182073B50-0x0000000182073CC0
		protected override void Awake(); // 0x0000000182072610-0x0000000182072720
		protected override void Start(); // 0x00000001820757D0-0x0000000182075870
		protected override void OnDisable(); // 0x0000000182073310-0x00000001820733C0
		public void RefreshShownValue(); // 0x0000000182073720-0x0000000182073A90
		public void AddOptions(List<OptionData> options); // 0x0000000182072080-0x00000001820720F0
		public void AddOptions(List<string> options); // 0x00000001820720F0-0x0000000182072250
		public void AddOptions(List<Sprite> options); // 0x0000000182072250-0x00000001820723B0
		public void ClearOptions(); // 0x0000000182072720-0x00000001820727D0
		private void SetupTemplate(); // 0x0000000182073CC0-0x00000001820742D0
		private static T GetOrAddComponent<T>(GameObject go)
			where T : Component;
		public virtual void OnPointerClick(PointerEventData eventData); // 0x00000001820733C0-0x00000001820733D0
		public virtual void OnSubmit(BaseEventData eventData); // 0x00000001820733C0-0x00000001820733D0
		public virtual void OnCancel(BaseEventData eventData); // 0x0000000182073300-0x0000000182073310
		public void Show(); // 0x00000001820742D0-0x00000001820757D0
		private static bool IsEverythingValue(int count, int value); // 0x00000001820732D0-0x0000000182073300
		private static int EverythingValue(int count); // 0x0000000182072EC0-0x0000000182072EF0
		protected virtual GameObject CreateBlocker(Canvas rootCanvas); // 0x00000001820727D0-0x0000000182072CE0
		protected virtual void DestroyBlocker(GameObject blocker); // 0x0000000182072E20-0x0000000182072E70
		protected virtual GameObject CreateDropdownList(GameObject template); // 0x0000000182072CE0-0x0000000182072D40
		protected virtual void DestroyDropdownList(GameObject dropdownList); // 0x0000000182072E70-0x0000000182072EC0
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate); // 0x0000000182072D40-0x0000000182072DA0
		protected virtual void DestroyItem(DropdownItem item); // 0x00000001802E76C0-0x00000001802E76D0
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items); // 0x0000000182071D70-0x0000000182072080
		private void AlphaFadeList(float duration, float alpha); // 0x0000000182072580-0x0000000182072610
		private void AlphaFadeList(float duration, float start, float end); // 0x00000001820723B0-0x0000000182072580
		private void SetAlpha(float alpha); // 0x0000000182073A90-0x0000000182073B40
		public void Hide(); // 0x0000000182072F10-0x0000000182073100
		[IteratorStateMachine(typeof(_DelayedDestroyDropdownList_d__90))]
		private IEnumerator DelayedDestroyDropdownList(float delay); // 0x0000000182072DA0-0x0000000182072E20
		private void ImmediateDestroyDropdownList(); // 0x0000000182073100-0x00000001820732D0
		private void OnSelectItem(Toggle toggle); // 0x00000001820733D0-0x0000000182073720
		private static int FirstActiveFlagIndex(int value); // 0x0000000182072EF0-0x0000000182072F10
	}
}
