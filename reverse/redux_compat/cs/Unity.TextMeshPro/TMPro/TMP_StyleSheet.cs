/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[TMPHelpURL("StyleSheets")]
	public class TMP_StyleSheet : ScriptableObject // TypeDefIndex: 11882
	{
		// Fields
		[SerializeField]
		private List<TMP_Style> m_StyleList; // 0x18
		private Dictionary<int, TMP_Style> m_StyleLookupDictionary; // 0x20
	
		// Properties
		internal List<TMP_Style> styles { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public TMP_StyleSheet(); // 0x00000001820CC810-0x00000001820CC890
	
		// Methods
		private void Reset(); // 0x00000001820CC800-0x00000001820CC810
		public TMP_Style GetStyle(int hashCode); // 0x00000001820CC480-0x00000001820CC510
		public TMP_Style GetStyle(string name); // 0x00000001820CC3C0-0x00000001820CC480
		public void RefreshStyles(); // 0x00000001820CC800-0x00000001820CC810
		private void LoadStyleDictionaryInternal(); // 0x00000001820CC510-0x00000001820CC800
	}
}
