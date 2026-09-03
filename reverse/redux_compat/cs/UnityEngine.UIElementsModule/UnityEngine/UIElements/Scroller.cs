/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement(libraryPath = "Controls")]
	public class Scroller : VisualElement // TypeDefIndex: 3908
	{
		// Fields
		internal static readonly BindingId valueProperty; // 0x00
		internal static readonly BindingId lowValueProperty; // 0x98
		internal static readonly BindingId highValueProperty; // 0x130
		internal static readonly BindingId directionProperty; // 0x1C8
		[CompilerGenerated]
		private Action<float> valueChanged; // 0x1A8
		[CompilerGenerated]
		private readonly Slider _slider_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private readonly RepeatButton _lowButton_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private readonly RepeatButton _highButton_k__BackingField; // 0x1C0
		public static readonly string ussClassName; // 0x260
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x268
		public static readonly string horizontalVariantUssClassName; // 0x270
		internal static readonly UniqueStyleString horizontalVariantUssClassNameUnique; // 0x278
		public static readonly string verticalVariantUssClassName; // 0x280
		internal static readonly UniqueStyleString verticalVariantUssClassNameUnique; // 0x288
		public static readonly string sliderUssClassName; // 0x290
		internal static readonly UniqueStyleString sliderUssClassNameUnique; // 0x298
		public static readonly string lowButtonUssClassName; // 0x2A0
		internal static readonly UniqueStyleString lowButtonUssClassNameUnique; // 0x2A8
		public static readonly string highButtonUssClassName; // 0x2B0
		internal static readonly UniqueStyleString highButtonUssClassNameUnique; // 0x2B8
	
		// Properties
		public Slider slider { [CompilerGenerated] get; } // 0x0000000181CB22F0-0x0000000181CB2300 
		public RepeatButton lowButton { [CompilerGenerated] get; } // 0x000000018033D6C0-0x000000018033D6D0 
		public RepeatButton highButton { [CompilerGenerated] get; } // 0x0000000181CB22C0-0x0000000181CB22D0 
		[CreateProperty]
		[UxmlAttribute]
		public float lowValue { get; set; } // 0x00000001823ABA70-0x00000001823ABAA0 0x00000001823ABDD0-0x00000001823ABEE0
		[CreateProperty]
		[UxmlAttribute]
		public float highValue { get; set; } // 0x00000001823ABA40-0x00000001823ABA70 0x00000001823ABCC0-0x00000001823ABDD0
		[CreateProperty]
		[UxmlAttribute]
		public SliderDirection direction { get; set; } // 0x00000001823AB9E0-0x00000001823ABA40 0x00000001823ABAD0-0x00000001823ABCC0
		[CreateProperty]
		[UxmlAttribute]
		public float value { get; set; } // 0x00000001823ABAA0-0x00000001823ABAD0 0x00000001823ABEE0-0x00000001823AC010
	
		// Nested types
		private class ScrollerSlider : Slider // TypeDefIndex: 3909
		{
			// Constructors
			public ScrollerSlider(float start, float end, SliderDirection direction, float pageSize); // 0x00000001823AA8B0-0x00000001823AAA20
	
			// Methods
			internal override float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue); // 0x00000001823AA810-0x00000001823AA8B0
		}
	
		private static class Callbacks // TypeDefIndex: 3910
		{
			// Fields
			public static readonly EventCallbackDefinition<Slider> OnSliderValueChanged; // 0x00
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3911
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001823B22B0-0x00000001823B2320
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.cctor_b__1_0(ChangeEvent<float> e, Slider slider); // 0x00000001823B1D20-0x00000001823B1DE0
			}
	
			// Constructors
			static Callbacks(); // 0x000000018239A4B0-0x000000018239A5A0
		}
	
		// Constructors
		public Scroller(float lowValue, float highValue, Action<float> valueChanged, SliderDirection direction = SliderDirection.Vertical /* Metadata: 0x00660490 */); // 0x00000001823AB4F0-0x00000001823AB9E0
		static Scroller(); // 0x00000001823AADD0-0x00000001823AB4F0
	
		// Methods
		public void Adjust(float factor); // 0x00000001823AAA20-0x00000001823AAA70
		private void OnSliderValueChange(ChangeEvent<float> evt); // 0x00000001823AAA70-0x00000001823AAAF0
		public void ScrollPageUp(); // 0x00000001823AAD20-0x00000001823AADD0
		public void ScrollPageDown(); // 0x00000001823AABB0-0x00000001823AAC60
		public void ScrollPageUp(float factor); // 0x00000001823AAC60-0x00000001823AAD20
		public void ScrollPageDown(float factor); // 0x00000001823AAAF0-0x00000001823AABB0
	}
}
