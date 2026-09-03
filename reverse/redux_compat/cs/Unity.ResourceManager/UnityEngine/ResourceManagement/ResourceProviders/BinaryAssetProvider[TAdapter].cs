/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[DisplayName("Binary Asset Provider")]
	internal class BinaryAssetProvider<TAdapter> : BinaryDataProvider // TypeDefIndex: 13741
		where TAdapter : BinaryStorageBuffer.ISerializationAdapter, new()
	{
		// Constructors
		public BinaryAssetProvider();
	
		// Methods
		public override object Convert(Type type, byte[] data);
	}
}
