/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class NavigateFocusRing : IFocusRing // TypeDefIndex: 4175
	{
		// Fields
		public static readonly ChangeDirection Left; // 0x00
		public static readonly ChangeDirection Right; // 0x08
		public static readonly ChangeDirection Up; // 0x10
		public static readonly ChangeDirection Down; // 0x18
		public static readonly FocusChangeDirection Next; // 0x20
		public static readonly FocusChangeDirection Previous; // 0x28
		private readonly VisualElement m_Root; // 0x10
		private readonly VisualElementFocusRing m_Ring; // 0x18
	
		// Properties
		private FocusController focusController { get; } // 0x00000001818C17E0-0x00000001818C1810 
	
		// Nested types
		public class ChangeDirection : FocusChangeDirection // TypeDefIndex: 4176
		{
			// Constructors
			public ChangeDirection(int i); // 0x000000018248E0B0-0x000000018248E110
		}
	
		private struct FocusableHierarchyTraversal // TypeDefIndex: 4177
		{
			// Fields
			public VisualElement root; // 0x00
			public VisualElement currentFocusable; // 0x08
			public VisualElement excludeSubtree; // 0x10
			public Rect validRect; // 0x18
			public bool firstPass; // 0x28
			public ChangeDirection direction; // 0x30
	
			// Methods
			private bool ValidateHierarchyTraversal(VisualElement v); // 0x0000000182498C00-0x0000000182498DC0
			private bool ValidateElement(VisualElement v); // 0x00000001824989F0-0x0000000182498C00
			private int Order(VisualElement a, VisualElement b); // 0x0000000182498280-0x0000000182498470
			private int StrictOrder(VisualElement a, VisualElement b); // 0x0000000182498470-0x0000000182498630
			private int StrictOrder(Rect ra, Rect rb); // 0x0000000182498630-0x00000001824987F0
			private int TieBreaker(Rect ra, Rect rb); // 0x00000001824987F0-0x00000001824989F0
			public VisualElement GetBestOverall(VisualElement candidate, VisualElement bestSoFar = null); // 0x0000000182497BD0-0x0000000182498280
		}
	
		// Constructors
		public NavigateFocusRing(VisualElement root); // 0x000000018249FEC0-0x000000018249FF50
		static NavigateFocusRing(); // 0x000000018249FB90-0x000000018249FEC0
	
		// Methods
		public FocusChangeDirection GetFocusChangeDirection(Focusable currentFocusable, EventBase e); // 0x000000018249EBD0-0x000000018249EFD0
		private static FocusChangeDirection GetNavigationChangeDirection(NavigationMoveEvent.Direction direction); // 0x000000018249EFD0-0x000000018249F1D0
		public virtual Focusable GetNextFocusable(Focusable currentFocusable, FocusChangeDirection direction); // 0x000000018249F2D0-0x000000018249F880
		private bool IsWorldSpaceNavigationValid(Focusable currentFocusable, out IPanelComponent panelComponent); // 0x000000018249FA20-0x000000018249FB10
		private Focusable GetNextFocusable2D(Focusable currentFocusable, ChangeDirection direction, VisualElement root); // 0x000000018249F1D0-0x000000018249F2D0
		internal static bool HasFocusableInDirection(VisualElement searchRoot, VisualElement current, NavigationMoveEvent.Direction direction, VisualElement excludeSubtree = null); // 0x000000018249F880-0x000000018249F960
		private static VisualElement FindBestInDirection(VisualElement searchRoot, VisualElement current, ChangeDirection direction, bool firstPass, VisualElement excludeSubtree); // 0x000000018249E760-0x000000018249EBD0
		private static ChangeDirection Opposite(ChangeDirection direction); // 0x000000018249FB10-0x000000018249FB90
		private static bool IsActive(VisualElement v); // 0x000000018249F960-0x000000018249F9D0
		private static bool IsNavigable(Focusable focusable); // 0x000000018249F9D0-0x000000018249FA20
	}
}
