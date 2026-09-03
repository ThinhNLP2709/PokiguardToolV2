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

namespace UnityEngine.UIElements
{
	[Serializable]
	public abstract class UxmlSerializedData // TypeDefIndex: 4907
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		[UxmlIgnore]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal int uxmlAssetId; // 0x10
		private static UxmlAttributeFlags s_CurrentDeserializeFlags; // 0x00
	
		// Nested types
		[Flags]
		public enum UxmlAttributeFlags : byte // TypeDefIndex: 4908
		{
			Ignore = 0,
			OverriddenInUxml = 1,
			DefaultValue = 2
		}
	
		// Constructors
		protected UxmlSerializedData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static UxmlSerializedData(); // 0x00000001823E28F0-0x00000001823E2930
	
		// Methods
		public abstract object CreateInstance();
		public abstract void Deserialize(object obj);
	}
}
