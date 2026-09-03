/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI.CoroutineTween;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Legacy/Dropdown", 102)]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("Dropdown")]
	public class Dropdown : Selectable, IPointerClickHandler, ISubmitHandler, ICancelHandler // TypeDefIndex: 13026
	{
		// Fields
		[SerializeField]
		private RectTransform m_Template; // 0x100
		[SerializeField]
		private Text m_CaptionText; // 0x108
		[SerializeField]
		private Image m_CaptionImage; // 0x110
		[SerializeField]
		[Space]
		private Text m_ItemText; // 0x118
		[SerializeField]
		private Image m_ItemImage; // 0x120
		[SerializeField]
		[Space]
		private int m_Value; // 0x128
		[SerializeField]
		[Space]
		private OptionDataList m_Options; // 0x130
		[SerializeField]
		[Space]
		private DropdownEvent m_OnValueChanged; // 0x138
		[SerializeField]
		private float m_AlphaFadeSpeed; // 0x140
		private GameObject m_Dropdown; // 0x148
		private GameObject m_Blocker; // 0x150
		private List<DropdownItem> m_Items; // 0x158
		private TweenRunner<FloatTween> m_AlphaTweenRunner; // 0x160
		private bool validTemplate; // 0x168
		private const int kHighSortingLayer = 30000; // Metadata: 0x006A76E0
		private static readonly OptionData s_NoOptionData; // 0x00
	
		// Properties
		public RectTransform template { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x000000018236B100-0x000000018236B130
		public Text captionText { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x000000018236B030-0x000000018236B060
		public Image captionImage { get; set; } // 0x000000018170B050-0x000000018170B060 0x000000018236B000-0x000000018236B030
		public Text itemText { get; set; } // 0x000000018171E0D0-0x000000018171E0E0 0x000000018236B090-0x000000018236B0C0
		public Image itemImage { get; set; } // 0x000000018170C2D0-0x000000018170C2E0 0x000000018236B060-0x000000018236B090
		public List<OptionData> options { get; set; } // 0x000000018236AFE0-0x000000018236B000 0x000000018236B0C0-0x000000018236B100
		public DropdownEvent onValueChanged { get; set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
		public float alphaFadeSpeed { get; set; } // 0x0000000181C4BC20-0x0000000181C4BC30 0x0000000181C4C350-0x0000000181C4C360
		public int value { get; set; } // 0x000000018033D760-0x000000018033D770 0x000000018236B130-0x000000018236B140
	
		// Nested types
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, ICancelHandler // TypeDefIndex: 13027
		{
			// Fields
			[SerializeField]
			private Text m_Text; // 0x20
			[SerializeField]
			private Image m_Image; // 0x28
			[SerializeField]
			private RectTransform m_RectTransform; // 0x30
			[SerializeField]
			private Toggle m_Toggle; // 0x38
	
			// Properties
			public Text text { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public Image image { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
			public RectTransform rectTransform { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
			public Toggle toggle { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
			// Constructors
			public DropdownItem(); // 0x00000001802E7A70-0x00000001802E7BC0
	
			// Methods
			public virtual void OnPointerEnter(PointerEventData eventData); // 0x0000000182367D00-0x0000000182367D80
			public virtual void OnCancel(BaseEventData eventData); // 0x0000000182367C70-0x0000000182367D00
		}
	
		[Serializable]
		public class OptionData // TypeDefIndex: 13028
		{
			// Fields
			[SerializeField]
			private string m_Text; // 0x10
			[SerializeField]
			private Sprite m_Image; // 0x18
	
			// Properties
			public string text { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public Sprite image { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
			// Constructors
			public OptionData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			public OptionData(string text); // 0x00000001803855F0-0x0000000180385630
			public OptionData(Sprite image); // 0x0000000180D9D6B0-0x0000000180D9D6F0
			public OptionData(string text, Sprite image); // 0x0000000180CB0730-0x0000000180CB0780
		}
	
		[Serializable]
		public class OptionDataList // TypeDefIndex: 13029
		{
			// Fields
			[SerializeField]
			private List<OptionData> m_Options; // 0x10
	
			// Properties
			public List<OptionData> options { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
			// Constructors
			public OptionDataList(); // 0x0000000182379B60-0x0000000182379BE0
		}
	
		[Serializable]
		public class DropdownEvent : UnityEvent<int> // TypeDefIndex: 13030
		{
			// Constructors
			public DropdownEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass63_0 // TypeDefIndex: 13031
		{
			// Fields
			public DropdownItem item; // 0x10
			public Dropdown __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass63_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Show_b__0(bool x); // 0x000000018237A110-0x000000018237A250
		}
	
		[CompilerGenerated]
		private sealed class _DelayedDestroyDropdownList_d__75 : IEnumerator<object> // TypeDefIndex: 13032
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public float delay; // 0x20
			public Dropdown __4__this; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DelayedDestroyDropdownList_d__75(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182379E30-0x0000000182379EF0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182379EF0-0x0000000182379F30
		}
	
		// Constructors
		protected Dropdown(); // 0x000000018236AE60-0x000000018236AFE0
		static Dropdown(); // 0x000000018236ADE0-0x000000018236AE60
	
		// Methods
		public void SetValueWithoutNotify(int input); // 0x0000000182369560-0x0000000182369570
		private void Set(int value, bool sendCallback = true /* Metadata: 0x006A76DF */); // 0x0000000182369570-0x0000000182369690
		protected override void Awake(); // 0x0000000182368570-0x0000000182368640
		protected override void Start(); // 0x000000018236AD40-0x000000018236ADE0
		protected override void OnDisable(); // 0x0000000182369110-0x00000001823691C0
		public void RefreshShownValue(); // 0x00000001823692F0-0x00000001823694B0
		public void AddOptions(List<OptionData> options); // 0x0000000182368300-0x0000000182368370
		public void AddOptions(List<string> options); // 0x0000000182368040-0x00000001823681A0
		public void AddOptions(List<Sprite> options); // 0x00000001823681A0-0x0000000182368300
		public void ClearOptions(); // 0x0000000182368640-0x00000001823686A0
		private void SetupTemplate(Canvas rootCanvas); // 0x0000000182369690-0x0000000182369D00
		private static T GetOrAddComponent<T>(GameObject go)
			where T : Component;
		public virtual void OnPointerClick(PointerEventData eventData); // 0x00000001823691C0-0x00000001823691D0
		public virtual void OnSubmit(BaseEventData eventData); // 0x00000001823691C0-0x00000001823691D0
		public virtual void OnCancel(BaseEventData eventData); // 0x0000000182369100-0x0000000182369110
		public void Show(); // 0x0000000182369D00-0x000000018236AD40
		protected virtual GameObject CreateBlocker(Canvas rootCanvas); // 0x00000001823686A0-0x0000000182368BB0
		protected virtual void DestroyBlocker(GameObject blocker); // 0x0000000182368CF0-0x0000000182368D40
		protected virtual GameObject CreateDropdownList(GameObject template); // 0x0000000182368BB0-0x0000000182368C10
		protected virtual void DestroyDropdownList(GameObject dropdownList); // 0x0000000182368D40-0x0000000182368D90
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate); // 0x0000000182368C10-0x0000000182368C70
		protected virtual void DestroyItem(DropdownItem item); // 0x00000001802E76C0-0x00000001802E76D0
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items); // 0x0000000182367D80-0x0000000182368040
		private void AlphaFadeList(float duration, float alpha); // 0x00000001823684E0-0x0000000182368570
		private void AlphaFadeList(float duration, float start, float end); // 0x0000000182368370-0x00000001823684E0
		private void SetAlpha(float alpha); // 0x00000001823694B0-0x0000000182369560
		public void Hide(); // 0x0000000182368D90-0x0000000182368F60
		[IteratorStateMachine(typeof(_DelayedDestroyDropdownList_d__75))]
		private IEnumerator DelayedDestroyDropdownList(float delay); // 0x0000000182368C70-0x0000000182368CF0
		private void ImmediateDestroyDropdownList(); // 0x0000000182368F60-0x0000000182369100
		private void OnSelectItem(Toggle toggle); // 0x00000001823691D0-0x00000001823692F0
	}
}
