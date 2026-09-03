/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	[Serializable]
	public class AssetLabelReference : IKeyEvaluator // TypeDefIndex: 14066
	{
		// Fields
		[FormerlySerializedAs("m_labelString")]
		[SerializeField]
		private string m_LabelString; // 0x10
	
		// Properties
		public string labelString { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public object RuntimeKey { get; } // 0x0000000181C73C30-0x0000000181C73C80 
	
		// Constructors
		public AssetLabelReference(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool RuntimeKeyIsValid(); // 0x0000000181C73BC0-0x0000000181C73C30
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
