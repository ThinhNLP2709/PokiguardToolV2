/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Selectable", 35)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[SelectionBase]
	[UGUIHelpURL("Selectable")]
	public class Selectable : UIBehaviour, IMoveHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler // TypeDefIndex: 13114
	{
		// Fields
		protected static Selectable[] s_Selectables; // 0x00
		protected static int s_SelectableCount; // 0x08
		private bool m_EnableCalled; // 0x20
		[FormerlySerializedAs("navigation")]
		[SerializeField]
		private Navigation m_Navigation; // 0x28
		[FormerlySerializedAs("transition")]
		[SerializeField]
		private Transition m_Transition; // 0x50
		[FormerlySerializedAs("colors")]
		[SerializeField]
		private ColorBlock m_Colors; // 0x54
		[FormerlySerializedAs("spriteState")]
		[SerializeField]
		private SpriteState m_SpriteState; // 0xB0
		[FormerlySerializedAs("animationTriggers")]
		[SerializeField]
		private AnimationTriggers m_AnimationTriggers; // 0xD0
		[SerializeField]
		[Tooltip("Can the Selectable be interacted with?")]
		private bool m_Interactable; // 0xD8
		[FormerlySerializedAs("highlightGraphic")]
		[FormerlySerializedAs("m_HighlightGraphic")]
		[SerializeField]
		private Graphic m_TargetGraphic; // 0xE0
		private bool m_GroupsAllowInteraction; // 0xE8
		protected int m_CurrentIndex; // 0xEC
		[CompilerGenerated]
		private bool _isPointerInside_k__BackingField; // 0xF0
		[CompilerGenerated]
		private bool _isPointerDown_k__BackingField; // 0xF1
		[CompilerGenerated]
		private bool _hasSelection_k__BackingField; // 0xF2
		private readonly List<CanvasGroup> m_CanvasGroupCache; // 0xF8
	
		// Properties
		public static Selectable[] allSelectablesArray { get; } // 0x00000001825A5D50-0x00000001825A5DE0 
		public static int allSelectableCount { get; } // 0x00000001825A5D00-0x00000001825A5D50 
		[Obsolete("Replaced with allSelectablesArray to have better performance when disabling an element", true)]
		public static List<Selectable> allSelectables { get; } // 0x00000001825A5DE0-0x00000001825A5EF0 
		public Navigation navigation { get; set; } // 0x0000000181E96610-0x0000000181E96630 0x00000001825A62A0-0x00000001825A6320
		public Transition transition { get; set; } // 0x000000018033D660-0x000000018033D670 0x00000001825A63F0-0x00000001825A6450
		public ColorBlock colors { get; set; } // 0x00000001825A5F30-0x00000001825A5F70 0x00000001825A60E0-0x00000001825A6180
		public SpriteState spriteState { get; set; } // 0x00000001825A6060-0x00000001825A6080 0x00000001825A6320-0x00000001825A6390
		public AnimationTriggers animationTriggers { get; set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001825A6080-0x00000001825A60E0
		public Graphic targetGraphic { get; set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001825A6390-0x00000001825A63F0
		public bool interactable { get; set; } // 0x0000000180665200-0x0000000180665210 0x00000001825A6180-0x00000001825A62A0
		private bool isPointerInside { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181708F30-0x0000000181708F40 0x0000000181F65050-0x0000000181F65060
		private bool isPointerDown { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181709020-0x0000000181709030 0x0000000181F648F0-0x0000000181F64900
		private bool hasSelection { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181708EA0-0x0000000181708EB0 0x0000000181709030-0x0000000181709040
		public Image image { get; set; } // 0x00000001825A5FE0-0x00000001825A6060 0x00000001806CCDC0-0x00000001806CCDE0
		public Animator animator { get; } // 0x00000001825A5EF0-0x00000001825A5F30 
		protected SelectionState currentSelectionState { get; } // 0x00000001825A5F70-0x00000001825A5FE0 
	
		// Nested types
		public enum Transition // TypeDefIndex: 13115
		{
			None = 0,
			ColorTint = 1,
			SpriteSwap = 2,
			Animation = 3
		}
	
		protected enum SelectionState // TypeDefIndex: 13116
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Selected = 3,
			Disabled = 4
		}
	
		// Constructors
		protected Selectable(); // 0x00000001825A5B70-0x00000001825A5D00
		static Selectable(); // 0x00000001825A5AF0-0x00000001825A5B70
	
		// Methods
		public static int AllSelectablesNoAlloc(Selectable[] selectables); // 0x00000001825A3660-0x00000001825A36F0
		protected override void Awake(); // 0x00000001825A36F0-0x00000001825A3790
		protected override void OnCanvasGroupChanged(); // 0x00000001825A4B70-0x00000001825A4BB0
		private bool ParentGroupAllowsInteraction(); // 0x00000001825A5550-0x00000001825A56D0
		public virtual bool IsInteractable(); // 0x00000001825A49F0-0x00000001825A4A10
		protected override void OnDidApplyAnimationProperties(); // 0x00000001825A4C30-0x00000001825A4C40
		protected override void OnEnable(); // 0x00000001825A4DF0-0x00000001825A50B0
		protected override void OnTransformParentChanged(); // 0x00000001825A5520-0x00000001825A5550
		private void OnSetProperty(); // 0x00000001825A54A0-0x00000001825A5520
		protected override void OnDisable(); // 0x00000001825A4C40-0x00000001825A4DF0
		private void OnApplicationFocus(bool hasFocus); // 0x00000001825A4B00-0x00000001825A4B70
		protected virtual void InstantClearState(); // 0x00000001825A4860-0x00000001825A4980
		protected virtual void DoStateTransition(SelectionState state, bool instant); // 0x00000001825A3830-0x00000001825A3B00
		public Selectable FindSelectable(Vector3 dir); // 0x00000001825A3E70-0x00000001825A4640
		private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir); // 0x00000001825A4640-0x00000001825A4860
		private void Navigate(AxisEventData eventData, Selectable sel); // 0x00000001825A4A60-0x00000001825A4B00
		public virtual Selectable FindSelectableOnLeft(); // 0x00000001825A3C30-0x00000001825A3CF0
		public virtual Selectable FindSelectableOnRight(); // 0x00000001825A3CF0-0x00000001825A3DB0
		public virtual Selectable FindSelectableOnUp(); // 0x00000001825A3DB0-0x00000001825A3E70
		public virtual Selectable FindSelectableOnDown(); // 0x00000001825A3B70-0x00000001825A3C30
		public virtual void OnMove(AxisEventData eventData); // 0x00000001825A50B0-0x00000001825A51E0
		private void StartColorTween(Color targetColor, bool instant); // 0x00000001825A57A0-0x00000001825A58A0
		private void DoSpriteSwap(Sprite newSprite); // 0x00000001825A3790-0x00000001825A3830
		private void TriggerAnimation(string triggername); // 0x00000001825A58A0-0x00000001825A5AF0
		public bool IsHighlighted(); // 0x00000001825A4980-0x00000001825A49F0
		public bool IsPressed(); // 0x00000001825A4A10-0x00000001825A4A60
		private void EvaluateAndTransitionToSelectionState(); // 0x00000001825A3B00-0x00000001825A3B70
		public virtual void OnPointerDown(PointerEventData eventData); // 0x00000001825A51E0-0x00000001825A52F0
		public virtual void OnPointerUp(PointerEventData eventData); // 0x00000001825A53F0-0x00000001825A5420
		public virtual void OnPointerEnter(PointerEventData eventData); // 0x00000001825A52F0-0x00000001825A5370
		public virtual void OnPointerExit(PointerEventData eventData); // 0x00000001825A5370-0x00000001825A53F0
		public virtual void OnSelect(BaseEventData eventData); // 0x00000001825A5420-0x00000001825A54A0
		public virtual void OnDeselect(BaseEventData eventData); // 0x00000001825A4BB0-0x00000001825A4C30
		public virtual void Select(); // 0x00000001825A56D0-0x00000001825A57A0
	}
}
