/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal struct ResolvedResourcePath : IEquatable<ResolvedResourcePath> // TypeDefIndex: 5232
	{
		// Fields
		[CompilerGenerated]
		private readonly string _path_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly string _subAssetName_k__BackingField; // 0x08
	
		// Properties
		public string path { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public string subAssetName { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public bool isPathValid { get; } // 0x0000000182450740-0x0000000182450760 
		public bool hasSubAssetName { get; } // 0x0000000182450720-0x0000000182450740 
	
		// Constructors
		public ResolvedResourcePath(string path, string subAssetName); // 0x0000000180CC3FE0-0x0000000180CC4020
	
		// Methods
		public T LoadResource<T>(float dpiScaling = 1f /* Metadata: 0x00660BF7 */)
			where T : UnityEngine.Object;
		public bool Equals(ResolvedResourcePath other); // 0x0000000182450660-0x00000001824506C0
		public override string ToString(); // 0x00000001824506C0-0x0000000182450720
	}
}
