/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[Obsolete("Unicode line breaking rules are now handled natively by Advanced Text Generator (ATG). This type is no longer required.", false)]
	public class UnicodeLineBreakingRules // TypeDefIndex: 12726
	{
		// Fields
		[SerializeField]
		private TextAsset m_UnicodeLineBreakingRules; // 0x10
		[SerializeField]
		private TextAsset m_LeadingCharacters; // 0x18
		[SerializeField]
		private TextAsset m_FollowingCharacters; // 0x20
		[SerializeField]
		private bool m_UseModernHangulLineBreakingRules; // 0x28
		private HashSet<uint> m_LeadingCharactersLookup; // 0x30
		private HashSet<uint> m_FollowingCharactersLookup; // 0x38
	
		// Properties
		internal HashSet<uint> leadingCharactersLookup { get; } // 0x000000018234D7F0-0x000000018234DD10 
		internal HashSet<uint> followingCharactersLookup { get; } // 0x000000018234D7C0-0x000000018234D7F0 
		public bool useModernHangulLineBreakingRules { get; } // 0x0000000180327270-0x0000000180327280 
	
		// Constructors
		public UnicodeLineBreakingRules(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void LoadLineBreakingRules(); // 0x000000018234D620-0x000000018234D7C0
		private static HashSet<uint> GetCharacters(TextAsset file); // 0x000000018234D550-0x000000018234D620
	}
}
