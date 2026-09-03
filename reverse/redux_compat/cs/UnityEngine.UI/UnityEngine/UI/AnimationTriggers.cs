/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[Serializable]
	public class AnimationTriggers // TypeDefIndex: 13009
	{
		// Fields
		private const string kDefaultNormalAnimName = "Normal"; // Metadata: 0x006A76A0
		private const string kDefaultHighlightedAnimName = "Highlighted"; // Metadata: 0x006A76A7
		private const string kDefaultPressedAnimName = "Pressed"; // Metadata: 0x006A76B3
		private const string kDefaultSelectedAnimName = "Selected"; // Metadata: 0x006A76BB
		private const string kDefaultDisabledAnimName = "Disabled"; // Metadata: 0x006A76C4
		[FormerlySerializedAs("normalTrigger")]
		[SerializeField]
		private string m_NormalTrigger; // 0x10
		[FormerlySerializedAs("highlightedTrigger")]
		[SerializeField]
		private string m_HighlightedTrigger; // 0x18
		[FormerlySerializedAs("pressedTrigger")]
		[SerializeField]
		private string m_PressedTrigger; // 0x20
		[SerializeField]
		private string m_SelectedTrigger; // 0x28
		[FormerlySerializedAs("disabledTrigger")]
		[SerializeField]
		private string m_DisabledTrigger; // 0x30
	
		// Properties
		public string normalTrigger { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string highlightedTrigger { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string pressedTrigger { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string selectedTrigger { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public string disabledTrigger { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Constructors
		public AnimationTriggers(); // 0x000000018235F7C0-0x000000018235F8B0
	}
}
