/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Resources
{
	[Serializable]
	[ComVisible(true)]
	public class ResourceManager // TypeDefIndex: 3262
	{
		// Fields
		[Obsolete("call InternalGetResourceSet instead")]
		protected Hashtable ResourceSets; // 0x10
		[NonSerialized]
		private Dictionary<string, ResourceSet> _resourceSets; // 0x18
		protected Assembly MainAssembly; // 0x20
		private CultureInfo _neutralResourcesCulture; // 0x28
		[NonSerialized]
		private CultureNameResourceSetPair _lastUsedResourceCache; // 0x30
		private bool UseManifest; // 0x38
		[OptionalField(VersionAdded = 1)]
		private bool UseSatelliteAssem; // 0x39
		[OptionalField]
		private UltimateResourceFallbackLocation _fallbackLoc; // 0x3C
		[OptionalField(VersionAdded = 1)]
		private Assembly _callingAssembly; // 0x40
		[OptionalField(VersionAdded = 4)]
		private RuntimeAssembly m_callingAssembly; // 0x48
		[NonSerialized]
		private IResourceGroveler resourceGroveler; // 0x50
		public static readonly int MagicNumber; // 0x00
		public static readonly int HeaderVersionNumber; // 0x04
		private static readonly Type _minResourceSet; // 0x08
		internal static readonly string ResReaderTypeName; // 0x10
		internal static readonly string ResSetTypeName; // 0x18
		internal static readonly string MscorlibName; // 0x20
		internal static readonly int DEBUG; // 0x28
	
		// Nested types
		internal class CultureNameResourceSetPair // TypeDefIndex: 3263
		{
			// Constructors
			public CultureNameResourceSetPair(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal class ResourceManagerMediator // TypeDefIndex: 3264
		{
			// Fields
			private ResourceManager _rm; // 0x10
	
			// Constructors
			internal ResourceManagerMediator(ResourceManager rm); // 0x00000001815134A0-0x0000000181513520
		}
	
		// Constructors
		protected ResourceManager(); // 0x0000000181513D10-0x0000000181513E10
		static ResourceManager(); // 0x0000000181513B20-0x0000000181513D10
	
		// Methods
		private void Init(); // 0x0000000181513760-0x0000000181513820
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x0000000181513A50-0x0000000181513AA0
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x0000000181513820-0x0000000181513A50
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx); // 0x0000000181513AA0-0x0000000181513B20
		internal static bool CompareNames(string asmTypeName1, string typeName2, AssemblyName asmName2); // 0x0000000181513520-0x0000000181513760
	}
}
