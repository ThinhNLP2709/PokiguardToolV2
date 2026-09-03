/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[Serializable]
	public struct Navigation : IEquatable<Navigation> // TypeDefIndex: 13096
	{
		// Fields
		[SerializeField]
		private Mode m_Mode; // 0x00
		[SerializeField]
		[Tooltip("Enables navigation to wrap around from last to first or first to last element. Does not work for automatic grid navigation")]
		private bool m_WrapAround; // 0x04
		[SerializeField]
		private Selectable m_SelectOnUp; // 0x08
		[SerializeField]
		private Selectable m_SelectOnDown; // 0x10
		[SerializeField]
		private Selectable m_SelectOnLeft; // 0x18
		[SerializeField]
		private Selectable m_SelectOnRight; // 0x20
	
		// Properties
		public Mode mode { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public bool wrapAround { get; set; } // 0x00000001813282D0-0x00000001813282E0 0x0000000181CCFCF0-0x0000000181CCFD00
		public Selectable selectOnUp { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		public Selectable selectOnDown { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public Selectable selectOnLeft { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Selectable selectOnRight { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public static Navigation defaultNavigation { get; } // 0x0000000182599BE0-0x0000000182599C00 
	
		// Nested types
		[Flags]
		public enum Mode // TypeDefIndex: 13097
		{
			None = 0,
			Horizontal = 1,
			Vertical = 2,
			Automatic = 3,
			Explicit = 4
		}
	
		// Methods
		public bool Equals(Navigation other); // 0x0000000182599B20-0x0000000182599BE0
	}
}
