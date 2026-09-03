/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Layouts
{
	internal struct InputDeviceBuilder : IDisposable // TypeDefIndex: 6549
	{
		// Fields
		private InputDevice m_Device; // 0x00
		private InputControlLayout.CacheRefInstance m_LayoutCacheRef; // 0x08
		private Dictionary<string, InputControlLayout.ControlItem> m_ChildControlOverrides; // 0x10
		private List<uint> m_StateOffsetToControlMap; // 0x18
		private StringBuilder m_StringBuilder; // 0x20
		private const uint kSizeForControlUsingStateFromOtherControl = 4294967295; // Metadata: 0x00699175
		private static InputDeviceBuilder s_Instance; // 0x00
		private static int s_InstanceRef; // 0x28
	
		// Properties
		internal static ref InputDeviceBuilder instance { get; } // 0x0000000181CEE130-0x0000000181CEE170 
	
		// Nested types
		internal struct RefInstance : IDisposable // TypeDefIndex: 6550
		{
			// Methods
			public void Dispose(); // 0x0000000181CF6070-0x0000000181CF6140
		}
	
		// Methods
		public void Setup(InternedString layout, InternedString variants, InputDeviceDescription deviceDescription = default); // 0x0000000181CEDED0-0x0000000181CEE0B0
		public InputDevice Finish(); // 0x0000000181CEBB70-0x0000000181CEBDE0
		public void Dispose(); // 0x0000000181CEB320-0x0000000181CEB330
		private void Reset(); // 0x0000000181CEDA90-0x0000000181CEDAD0
		private InputControl InstantiateLayout(InternedString layout, InternedString variants, InternedString name, InputControl parent); // 0x0000000181CED980-0x0000000181CEDA50
		private InputControl InstantiateLayout(InputControlLayout layout, InternedString variants, InternedString name, InputControl parent); // 0x0000000181CED1F0-0x0000000181CED980
		private void AddChildControls(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls); // 0x0000000181CE97A0-0x0000000181CEA170
		private InputControl AddChildControl(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, InputControlLayout.ControlItem controlItem, int childIndex, string nameOverride = null); // 0x0000000181CE8C50-0x0000000181CE97A0
		private void InsertChildControlOverride(InputControl parent, ref InputControlLayout.ControlItem controlItem); // 0x0000000181CEC530-0x0000000181CEC900
		private string ChildControlOverridePath(InputControl parent, InternedString controlName); // 0x0000000181CEA9C0-0x0000000181CEAA40
		private void AddChildControlIfMissing(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, ref InputControlLayout.ControlItem controlItem); // 0x0000000181CE8B80-0x0000000181CE8C50
		private InputControl InsertChildControl(InputControlLayout layout, InternedString variant, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, ref InputControlLayout.ControlItem controlItem); // 0x0000000181CEC900-0x0000000181CECDA0
		private static void ApplyUseStateFrom(InputControl parent, ref InputControlLayout.ControlItem controlItem, InputControlLayout layout); // 0x0000000181CEA7B0-0x0000000181CEA9C0
		private static void ShiftChildIndicesInHierarchyOneUp(InputDevice device, int startIndex, InputControl exceptControl); // 0x0000000181CEE0B0-0x0000000181CEE130
		private void SetDisplayName(InputControl control, string longDisplayNameFromLayout, string shortDisplayNameFromLayout, bool shortName); // 0x0000000181CEDAD0-0x0000000181CEDE40
		private static void AddParentDisplayNameRecursive(InputControl control, StringBuilder stringBuilder, bool shortName); // 0x0000000181CEA4A0-0x0000000181CEA550
		private static void AddProcessors(InputControl control, ref InputControlLayout.ControlItem controlItem, string layoutName); // 0x0000000181CEA550-0x0000000181CEA7B0
		private static void SetFormat(InputControl control, InputControlLayout.ControlItem controlItem); // 0x0000000181CEDE40-0x0000000181CEDED0
		private static InputControlLayout FindOrLoadLayout(string name); // 0x0000000181CEBB10-0x0000000181CEBB70
		private static void ComputeStateLayout(InputControl control); // 0x0000000181CEAA40-0x0000000181CEB320
		private void FinalizeControlHierarchy(); // 0x0000000181CEB860-0x0000000181CEBB10
		private void FinalizeControlHierarchyRecursive(InputControl control, int controlIndex, InputControl[] allControls, bool noisy, bool dontReset, ref int controlIndiciesNextFreeIndex); // 0x0000000181CEB330-0x0000000181CEB860
		private void InsertControlBitRangeNode(ref InputDevice.ControlBitRangeNode parent, InputControl control, ref int controlIndiciesNextFreeIndex, ushort startOffset); // 0x0000000181CECDA0-0x0000000181CED1F0
		private ushort GetBestMidPoint(InputDevice.ControlBitRangeNode parent, ushort startOffset); // 0x0000000181CEBDE0-0x0000000181CEC460
		private void AddControlToNode(InputControl control, ref int controlIndiciesNextFreeIndex, int nodeIndex); // 0x0000000181CEA2A0-0x0000000181CEA4A0
		private void AddChildren(ref InputDevice.ControlBitRangeNode parent, InputDevice.ControlBitRangeNode left, InputDevice.ControlBitRangeNode right); // 0x0000000181CEA170-0x0000000181CEA2A0
		private ushort GetControlIndex(InputControl control); // 0x0000000181CEC460-0x0000000181CEC530
		internal static RefInstance Ref(); // 0x0000000181CEDA50-0x0000000181CEDA90
	}
}
