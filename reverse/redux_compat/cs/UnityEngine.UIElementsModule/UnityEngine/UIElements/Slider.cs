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
	public class Slider : BaseSlider<float> // TypeDefIndex: 3921
	{
		// Fields
		public static readonly string ussClassName; // 0x00
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x08
		public static readonly string labelUssClassName; // 0x10
		internal static readonly UniqueStyleString labelUssClassNameUnique; // 0x18
		public static readonly string inputUssClassName; // 0x20
		internal static readonly UniqueStyleString inputUssClassNameUnique; // 0x28
	
		// Constructors
		public Slider(float start, float end, SliderDirection direction = SliderDirection.Horizontal /* Metadata: 0x006604A0 */, float pageSize = 0f /* Metadata: 0x006604A1 */); // 0x00000001823AD980-0x00000001823ADAB0
		public Slider(string label, float start = 0f /* Metadata: 0x006604A5 */, float end = 10f /* Metadata: 0x006604A9 */, SliderDirection direction = SliderDirection.Horizontal /* Metadata: 0x006604AD */, float pageSize = 0f /* Metadata: 0x006604AE */); // 0x00000001823AD840-0x00000001823AD980
		static Slider(); // 0x00000001823AD670-0x00000001823AD840
	
		// Methods
		public override void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue); // 0x00000001823AD000-0x00000001823AD0F0
		internal override float SliderLerpUnclamped(float a, float b, float interpolant); // 0x00000001823AD370-0x00000001823AD570
		internal override float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue); // 0x00000001823AD570-0x00000001823AD5F0
		internal override float SliderRange(); // 0x00000001823AD5F0-0x00000001823AD670
		internal override float ParseStringToValue(string previousValue, string newValue); // 0x00000001823AD2A0-0x00000001823AD370
		internal override void ComputeValueFromKey(BaseSlider<float> sliderKey, bool isShift); // 0x00000001823AD0F0-0x00000001823AD2A0
	}
}
