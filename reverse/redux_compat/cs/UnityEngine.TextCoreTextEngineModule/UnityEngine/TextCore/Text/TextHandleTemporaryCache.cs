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
	internal class TextHandleTemporaryCache // TypeDefIndex: 12713
	{
		// Fields
		internal LinkedList<TextCacheEntry> s_Cache; // 0x10
		internal int currentFrame; // 0x18
		private object syncRoot; // 0x20
	
		// Constructors
		public TextHandleTemporaryCache(); // 0x0000000182340690-0x0000000182340720
	
		// Methods
		public void ClearTemporaryCache(); // 0x000000018233FE70-0x0000000182340070
		public void AddTextInfoToCache(TextHandle textHandle, int hashCode); // 0x000000018233F8C0-0x000000018233FE70
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void RemoveFromCache(TextHandle handle); // 0x00000001823403E0-0x00000001823405D0
		internal void ResetEntryState(TextHandle handle); // 0x00000001823405D0-0x0000000182340670
		private void RefreshCaching(TextHandle textHandle); // 0x00000001823402A0-0x00000001823403E0
		private void RecycleTextInfoFromCache(TextHandle textHandle); // 0x0000000182340070-0x00000001823402A0
		public void UpdateCurrentFrame(); // 0x0000000182340670-0x0000000182340690
	}
}
