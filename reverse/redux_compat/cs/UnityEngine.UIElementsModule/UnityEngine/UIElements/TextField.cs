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
	public class TextField : TextInputBaseField<string> // TypeDefIndex: 3896
	{
		// Fields
		internal static readonly BindingId multilineProperty; // 0x00
		public static readonly string ussClassName; // 0x98
		internal static readonly UniqueStyleString ussClassNameUnique; // 0xA0
		public static readonly string labelUssClassName; // 0xA8
		internal static readonly UniqueStyleString labelUssClassNameUnique; // 0xB0
		public static readonly string inputUssClassName; // 0xB8
		internal static readonly UniqueStyleString inputUssClassNameUnique; // 0xC0
	
		// Properties
		private TextInput textInput { get; } // 0x00000001823AE540-0x00000001823AE5B0 
		[CreateProperty]
		[MultilineDecorator]
		[UxmlAttribute]
		public bool multiline { get; set; } // 0x00000001823AE490-0x00000001823AE540 0x00000001823AE5B0-0x00000001823AE6C0
		public override string value { get; set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x00000001823AE6C0-0x00000001823AE750
	
		// Nested types
		private class TextInput : TextInputBaseField<string> // TypeDefIndex: 3897
		{
			// Properties
			private TextField parentTextField { get; } // 0x00000001823AF3B0-0x00000001823AF420 
			public bool multiline { get; set; } // 0x00000001823AF360-0x00000001823AF3B0 0x00000001823AF420-0x00000001823AF600
	
			// Constructors
			public TextInput(); // 0x00000001823AF300-0x00000001823AF360
		}
	
		// Constructors
		public TextField(); // 0x00000001823AE460-0x00000001823AE490
		public TextField(string label); // 0x00000001823AE430-0x00000001823AE460
		public TextField(string label, int maxLength, bool multiline, bool isPasswordField, char maskChar); // 0x00000001823AE130-0x00000001823AE430
		static TextField(); // 0x00000001823ADE40-0x00000001823AE130
	
		// Methods
		public override void SetValueWithoutNotify(string newValue); // 0x00000001823ADCF0-0x00000001823ADE20
		internal override void UpdateTextFromValue(); // 0x00000001823ADE20-0x00000001823ADE40
		[EventInterest(new Type[1] {typeof(FocusOutEvent) })]
		protected override void HandleEventBubbleUp(EventBase evt); // 0x00000001823ADAB0-0x00000001823ADC80
		internal override void OnViewDataReady(); // 0x00000001823ADC80-0x00000001823ADCF0
		protected override string ValueToString(string value); // 0x0000000180A68C50-0x0000000180A68C60
		protected override string StringToValue(string str); // 0x0000000180A68C50-0x0000000180A68C60
	}
}
