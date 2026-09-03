/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.ResourceLocators
{
	public class ContentCatalogDataEntry // TypeDefIndex: 14093
	{
		// Fields
		[CompilerGenerated]
		private string _InternalId_k__BackingField; // 0x10
		[CompilerGenerated]
		private string _Provider_k__BackingField; // 0x18
		[CompilerGenerated]
		private List<object> _Keys_k__BackingField; // 0x20
		[CompilerGenerated]
		private List<object> _Dependencies_k__BackingField; // 0x28
		[CompilerGenerated]
		private object _Data_k__BackingField; // 0x30
		[CompilerGenerated]
		private Type _ResourceType_k__BackingField; // 0x38
	
		// Properties
		public string InternalId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string Provider { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public List<object> Keys { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public List<object> Dependencies { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public object Data { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public Type ResourceType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public ContentCatalogDataEntry(Type type, string internalId, string provider, IEnumerable<object> keys, IEnumerable<object> dependencies = null, object extraData = null); // 0x0000000181C77920-0x0000000181C77A50
	}
}
