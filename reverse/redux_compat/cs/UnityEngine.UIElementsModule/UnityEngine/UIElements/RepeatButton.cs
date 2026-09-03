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
	[UxmlElement]
	public class RepeatButton : TextElement // TypeDefIndex: 3907
	{
		// Fields
		private Clickable m_Clickable; // 0x2D0
		private bool m_AcceptClicksIfDisabled; // 0x2D8
		public static readonly string ussClassName; // 0x00
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x08
	
		// Properties
		internal bool acceptClicksIfDisabled { set; } // 0x00000001823A1960-0x00000001823A1990
	
		// Constructors
		public RepeatButton(); // 0x00000001823A18D0-0x00000001823A1960
		public RepeatButton(Action clickEvent, long delay, long interval); // 0x00000001823A1770-0x00000001823A18D0
		static RepeatButton(); // 0x00000001823A16D0-0x00000001823A1770
	
		// Methods
		public void SetAction(Action clickEvent, long delay, long interval); // 0x00000001823A15E0-0x00000001823A16D0
		internal void AddAction(Action clickEvent); // 0x00000001823A15B0-0x00000001823A15E0
	}
}
