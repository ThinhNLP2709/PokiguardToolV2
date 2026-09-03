/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	public class TextStyleSheet : ScriptableObject // TypeDefIndex: 12674
	{
		// Fields
		[SerializeField]
		private List<TextStyle> m_StyleList; // 0x18
		private Dictionary<int, TextStyle> m_StyleLookupDictionary; // 0x20
		private object styleLookupLock; // 0x28
	
		// Properties
		internal List<TextStyle> styles { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public TextStyleSheet(); // 0x000000018234B300-0x000000018234B3B0
	
		// Methods
		private void Reset(); // 0x000000018234B2F0-0x000000018234B300
		public TextStyle GetStyle(int hashCode); // 0x000000018234AE10-0x000000018234AF50
		public TextStyle GetStyle(string name); // 0x000000018234AF50-0x000000018234AFF0
		public void RefreshStyles(); // 0x000000018234B2F0-0x000000018234B300
		private void LoadStyleDictionaryInternal(); // 0x000000018234AFF0-0x000000018234B2F0
	}
}
