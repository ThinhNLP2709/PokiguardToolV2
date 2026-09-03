/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	internal class XRLayoutBuilder // TypeDefIndex: 6255
	{
		// Fields
		private string parentLayout; // 0x10
		private string interfaceName; // 0x18
		private XRDeviceDescriptor descriptor; // 0x20
		private static readonly string[] poseSubControlNames; // 0x00
		private static readonly FeatureType[] poseSubControlTypes; // 0x08
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 6256
		{
			// Fields
			public XRLayoutBuilder layout; // 0x10
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal InputControlLayout _OnFindLayoutForDevice_b__0(); // 0x0000000181DA2730-0x0000000181DA2750
		}
	
		// Constructors
		public XRLayoutBuilder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static XRLayoutBuilder(); // 0x0000000181DA7AA0-0x0000000181DA7C90
	
		// Methods
		private static uint GetSizeOfFeature(XRFeatureDescriptor featureDescriptor); // 0x0000000181DA72E0-0x0000000181DA73A0
		private static string SanitizeString(string original, bool allowPaths = false /* Metadata: 0x00698D85 */); // 0x0000000181DA7940-0x0000000181DA7AA0
		internal static string OnFindLayoutForDevice(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeCommandDelegate); // 0x0000000181DA7560-0x0000000181DA7940
		private static string ConvertPotentialAliasToName(InputControlLayout layout, string nameOrAlias); // 0x0000000181DA7070-0x0000000181DA72A0
		private bool IsSubControl(string name); // 0x0000000181DA7530-0x0000000181DA7560
		private string GetParentControlName(string name); // 0x0000000181DA72A0-0x0000000181DA72E0
		private bool IsPoseControl(List<XRFeatureDescriptor> features, int startIndex); // 0x0000000181DA73A0-0x0000000181DA7530
		private InputControlLayout Build(); // 0x0000000181DA6160-0x0000000181DA7070
	}
}
