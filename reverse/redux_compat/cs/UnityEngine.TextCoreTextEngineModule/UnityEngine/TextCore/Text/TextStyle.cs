/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	public class TextStyle // TypeDefIndex: 12673
	{
		// Fields
		[SerializeField]
		private string m_Name; // 0x10
		[SerializeField]
		private int m_HashCode; // 0x18
		[SerializeField]
		private string m_OpeningDefinition; // 0x20
		[SerializeField]
		private string m_ClosingDefinition; // 0x28
		[SerializeField]
		private uint[] m_OpeningTagArray; // 0x30
		[SerializeField]
		private uint[] m_ClosingTagArray; // 0x38
		[SerializeField]
		internal uint[] m_OpeningTagUnicodeArray; // 0x40
		[SerializeField]
		internal uint[] m_ClosingTagUnicodeArray; // 0x48
	
		// Properties
		public int hashCode { get; } // 0x0000000180B23260-0x0000000180B23270 
		public string styleOpeningDefinition { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string styleClosingDefinition { get; } // 0x000000018033D240-0x000000018033D250 
		public uint[] styleOpeningTagArray { get; } // 0x000000018031E110-0x000000018031E120 
		public uint[] styleClosingTagArray { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		internal TextStyle(string styleName, string styleOpeningDefinition, string styleClosingDefinition); // 0x000000018234B5D0-0x000000018234B660
	
		// Methods
		public void RefreshStyle(); // 0x000000018234B3B0-0x000000018234B5D0
	}
}
