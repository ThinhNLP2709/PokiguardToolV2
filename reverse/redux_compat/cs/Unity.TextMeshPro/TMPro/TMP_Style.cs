/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class TMP_Style // TypeDefIndex: 11881
	{
		// Fields
		internal static TMP_Style k_NormalStyle; // 0x00
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
	
		// Properties
		public static TMP_Style NormalStyle { get; } // 0x00000001820CCB00-0x00000001820CCBE0 
		public string name { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001820CCBF0-0x00000001820CCC30
		public int hashCode { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x00000001820CCBE0-0x00000001820CCBF0
		public string styleOpeningDefinition { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string styleClosingDefinition { get; } // 0x000000018033D240-0x000000018033D250 
		public uint[] styleOpeningTagArray { get; } // 0x000000018031E110-0x000000018031E120 
		public uint[] styleClosingTagArray { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		internal TMP_Style(string styleName, string styleOpeningDefinition, string styleClosingDefinition); // 0x00000001820CCA40-0x00000001820CCB00
	
		// Methods
		public void RefreshStyle(); // 0x00000001820CC890-0x00000001820CCA40
	}
}
