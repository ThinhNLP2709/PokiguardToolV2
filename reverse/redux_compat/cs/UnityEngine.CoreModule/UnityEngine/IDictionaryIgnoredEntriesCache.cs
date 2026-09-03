/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal interface IDictionaryIgnoredEntriesCache // TypeDefIndex: 7805
	{
		// Methods
		IgnoredEntriesData Get(EntityId hostId, string dictionaryPath);
		void Store(EntityId hostId, string dictionaryPath, IgnoredEntriesData ignoredEntriesData);
		void Clear(EntityId hostId, string dictionaryPath);
		bool HostHasIgnoredDictionaryEntries(EntityId hostId);
	}
}
