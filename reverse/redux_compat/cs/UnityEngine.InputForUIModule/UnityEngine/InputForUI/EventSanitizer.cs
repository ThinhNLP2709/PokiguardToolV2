/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	internal struct EventSanitizer // TypeDefIndex: 15298
	{
		// Fields
		private IEventSanitizer[] _sanitizers; // 0x00
	
		// Nested types
		private interface IEventSanitizer // TypeDefIndex: 15299
		{
			// Methods
			void Reset();
			void BeforeProviderUpdate();
			void AfterProviderUpdate();
			void Inspect([IsReadOnly] in Event ev);
		}
	
		// Methods
		public void Reset(); // 0x00000001822A4C60-0x00000001822A4DC0
		public void BeforeProviderUpdate(); // 0x00000001822A4A10-0x00000001822A4B30
		public void AfterProviderUpdate(); // 0x00000001822A48F0-0x00000001822A4A10
		public void Inspect([IsReadOnly] in Event ev); // 0x00000001822A4B30-0x00000001822A4C60
	}
}
