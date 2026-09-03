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
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal class TextHandlePermanentCache // TypeDefIndex: 12710
	{
		// Fields
		internal LinkedList<TextCacheEntry> s_Cache; // 0x10
		private object syncRoot; // 0x18
	
		// Constructors
		public TextHandlePermanentCache(); // 0x000000018233F830-0x000000018233F8C0
	
		// Methods
		public void AddToCache(TextHandle textHandle); // 0x000000018233F060-0x000000018233F440
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		public void RemoveFromCache(TextHandle textHandle); // 0x000000018233F440-0x000000018233F6D0
		private void ResetEntryState(TextHandle handle); // 0x000000018233F6D0-0x000000018233F830
	}
}
