/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[Serializable]
	[AssetFileNameExtension("guiskin", new string[0])]
	[ExecuteInEditMode]
	[RequiredByNativeCode]
	public sealed class GUISkin : ScriptableObject // TypeDefIndex: 13933
	{
		// Fields
		[SerializeField]
		private Font m_Font; // 0x18
		[SerializeField]
		private GUIStyle m_box; // 0x20
		[SerializeField]
		private GUIStyle m_button; // 0x28
		[SerializeField]
		private GUIStyle m_toggle; // 0x30
		[SerializeField]
		private GUIStyle m_label; // 0x38
		[SerializeField]
		private GUIStyle m_textField; // 0x40
		[SerializeField]
		private GUIStyle m_textArea; // 0x48
		[SerializeField]
		private GUIStyle m_window; // 0x50
		[SerializeField]
		private GUIStyle m_horizontalSlider; // 0x58
		[SerializeField]
		private GUIStyle m_horizontalSliderThumb; // 0x60
		[NonSerialized]
		private GUIStyle m_horizontalSliderThumbExtent; // 0x68
		[SerializeField]
		private GUIStyle m_verticalSlider; // 0x70
		[SerializeField]
		private GUIStyle m_verticalSliderThumb; // 0x78
		[NonSerialized]
		private GUIStyle m_verticalSliderThumbExtent; // 0x80
		[NonSerialized]
		private GUIStyle m_SliderMixed; // 0x88
		[SerializeField]
		private GUIStyle m_horizontalScrollbar; // 0x90
		[SerializeField]
		private GUIStyle m_horizontalScrollbarThumb; // 0x98
		[SerializeField]
		private GUIStyle m_horizontalScrollbarLeftButton; // 0xA0
		[SerializeField]
		private GUIStyle m_horizontalScrollbarRightButton; // 0xA8
		[SerializeField]
		private GUIStyle m_verticalScrollbar; // 0xB0
		[SerializeField]
		private GUIStyle m_verticalScrollbarThumb; // 0xB8
		[SerializeField]
		private GUIStyle m_verticalScrollbarUpButton; // 0xC0
		[SerializeField]
		private GUIStyle m_verticalScrollbarDownButton; // 0xC8
		[SerializeField]
		private GUIStyle m_ScrollView; // 0xD0
		[SerializeField]
		internal GUIStyle[] m_CustomStyles; // 0xD8
		[SerializeField]
		private GUISettings m_Settings; // 0xE0
		[NoAutoStaticsCleanup]
		internal static GUIStyle ms_Error; // 0x00
		private Dictionary<string, GUIStyle> m_Styles; // 0xE8
		[NoAutoStaticsCleanup]
		internal static SkinChangedDelegate m_SkinChanged; // 0x08
		[NoAutoStaticsCleanup]
		internal static GUISkin current; // 0x10
	
		// Properties
		public Font font { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000182282EF0-0x0000000182283070
		public GUIStyle box { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000182282D70-0x0000000182282DF0
		public GUIStyle label { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x00000001822833F0-0x0000000182283470
		public GUIStyle textField { get; set; } // 0x0000000180377940-0x0000000180377950 0x00000001822835F0-0x0000000182283670
		public GUIStyle textArea { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000182283570-0x00000001822835F0
		public GUIStyle button { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000182282DF0-0x0000000182282E70
		public GUIStyle toggle { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000182283670-0x00000001822836F0
		public GUIStyle window { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x0000000182283A70-0x0000000182283AF0
		public GUIStyle horizontalSlider { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x0000000182283370-0x00000001822833F0
		public GUIStyle horizontalSliderThumb { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001822832F0-0x0000000182283370
		internal GUIStyle horizontalSliderThumbExtent { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000182283270-0x00000001822832F0
		internal GUIStyle sliderMixed { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x00000001822834F0-0x0000000182283570
		public GUIStyle verticalSlider { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x00000001822839F0-0x0000000182283A70
		public GUIStyle verticalSliderThumb { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000182283970-0x00000001822839F0
		internal GUIStyle verticalSliderThumbExtent { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x00000001822838F0-0x0000000182283970
		public GUIStyle horizontalScrollbar { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x00000001822831F0-0x0000000182283270
		public GUIStyle horizontalScrollbarThumb { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x0000000182283170-0x00000001822831F0
		public GUIStyle horizontalScrollbarLeftButton { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x0000000182283070-0x00000001822830F0
		public GUIStyle horizontalScrollbarRightButton { get; set; } // 0x000000018033D510-0x000000018033D520 0x00000001822830F0-0x0000000182283170
		public GUIStyle verticalScrollbar { get; set; } // 0x00000001806BAE60-0x00000001806BAE70 0x0000000182283870-0x00000001822838F0
		public GUIStyle verticalScrollbarThumb { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x0000000182283770-0x00000001822837F0
		public GUIStyle verticalScrollbarUpButton { get; set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001822837F0-0x0000000182283870
		public GUIStyle verticalScrollbarDownButton { get; set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001822836F0-0x0000000182283770
		public GUIStyle scrollView { get; set; } // 0x00000001806CCB60-0x00000001806CCB70 0x0000000182283470-0x00000001822834F0
		public GUIStyle[] customStyles { get; set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x0000000182282E70-0x0000000182282EF0
		public GUISettings settings { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		internal static GUIStyle error { get; } // 0x0000000182282C70-0x0000000182282D70 
	
		// Nested types
		internal delegate void SkinChangedDelegate(); // TypeDefIndex: 13934; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		public GUISkin(); // 0x0000000182282BA0-0x0000000182282C70
	
		// Methods
		internal void OnEnable(); // 0x00000001822812B0-0x0000000182281320
		internal void Apply(); // 0x00000001822812B0-0x0000000182281320
		private void BuildStyleCache(); // 0x0000000182281320-0x0000000182282670
		public GUIStyle GetStyle(string styleName); // 0x00000001822827B0-0x0000000182282A90
		public GUIStyle FindStyle(string styleName); // 0x0000000182282670-0x0000000182282700
		internal void MakeCurrent(); // 0x0000000182282A90-0x0000000182282BA0
		public IEnumerator GetEnumerator(); // 0x0000000182282700-0x00000001822827B0
	}
}
