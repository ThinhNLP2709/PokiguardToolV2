/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public static class InputActionSetupExtensions // TypeDefIndex: 6084
	{
		// Nested types
		public struct BindingSyntax // TypeDefIndex: 6085
		{
			// Fields
			private readonly InputActionMap m_ActionMap; // 0x00
			private readonly InputAction m_Action; // 0x08
			internal readonly int m_BindingIndexInMap; // 0x10
	
			// Properties
			public bool valid { get; } // 0x0000000181CD2060-0x0000000181CD20A0 
			public int bindingIndex { get; } // 0x0000000181CD1EE0-0x0000000181CD1F50 
			public InputBinding binding { get; } // 0x0000000181CD1F50-0x0000000181CD2060 
	
			// Constructors
			internal BindingSyntax(InputActionMap map, int bindingIndexInMap, InputAction action = null); // 0x0000000181CD1E90-0x0000000181CD1EE0
	
			// Methods
			public BindingSyntax WithName(string name); // 0x0000000181CD1860-0x0000000181CD1970
			public BindingSyntax WithPath(string path); // 0x0000000181CD1970-0x0000000181CD1A80
			public BindingSyntax WithGroup(string group); // 0x0000000181CD1040-0x0000000181CD1230
			public BindingSyntax WithGroups(string groups); // 0x0000000181CD1230-0x0000000181CD1450
			public BindingSyntax WithInteraction(string interaction); // 0x0000000181CD1450-0x0000000181CD1640
			public BindingSyntax WithInteractions(string interactions); // 0x0000000181CD1640-0x0000000181CD1860
			public BindingSyntax WithInteraction<TInteraction>()
				where TInteraction : IInputInteraction;
			public BindingSyntax WithProcessor(string processor); // 0x0000000181CD1A80-0x0000000181CD1C70
			public BindingSyntax WithProcessors(string processors); // 0x0000000181CD1C70-0x0000000181CD1E90
			public BindingSyntax WithProcessor<TProcessor>();
			public BindingSyntax Triggering(InputAction action); // 0x0000000181CD0E50-0x0000000181CD1040
			public BindingSyntax To(InputBinding binding); // 0x0000000181CD0CB0-0x0000000181CD0E50
			public BindingSyntax NextBinding(); // 0x0000000181CD0A50-0x0000000181CD0A90
			public BindingSyntax PreviousBinding(); // 0x0000000181CD0B80-0x0000000181CD0BC0
			public BindingSyntax NextPartBinding(string partName); // 0x0000000181CD0AD0-0x0000000181CD0B80
			public BindingSyntax PreviousPartBinding(string partName); // 0x0000000181CD0C00-0x0000000181CD0CB0
			public BindingSyntax NextCompositeBinding(string compositeName = null); // 0x0000000181CD0A90-0x0000000181CD0AD0
			public BindingSyntax PreviousCompositeBinding(string compositeName = null); // 0x0000000181CD0BC0-0x0000000181CD0C00
			private BindingSyntax Iterate(bool next); // 0x0000000181CD0900-0x0000000181CD0A50
			private BindingSyntax IterateCompositeBinding(bool next, string compositeName); // 0x0000000181CD0600-0x0000000181CD0770
			private BindingSyntax IteratePartBinding(bool next, string partName); // 0x0000000181CD0770-0x0000000181CD0900
			public void Erase(); // 0x0000000181CD0150-0x0000000181CD0330
			public BindingSyntax InsertPartBinding(string partName, string path); // 0x0000000181CD0330-0x0000000181CD0600
		}
	
		public struct CompositeSyntax // TypeDefIndex: 6086
		{
			// Fields
			private readonly InputAction m_Action; // 0x00
			private readonly InputActionMap m_ActionMap; // 0x08
			private int m_BindingIndexInMap; // 0x10
	
			// Properties
			public int bindingIndex { get; } // 0x0000000181CD2310-0x0000000181CD2340 
	
			// Constructors
			internal CompositeSyntax(InputActionMap map, InputAction action, int compositeIndex); // 0x0000000181CD22C0-0x0000000181CD2310
	
			// Methods
			public CompositeSyntax With(string name, string binding, string groups = null, string processors = null); // 0x0000000181CD20A0-0x0000000181CD22C0
		}
	
		public struct ControlSchemeSyntax // TypeDefIndex: 6087
		{
			// Fields
			private readonly InputActionAsset m_Asset; // 0x00
			private readonly int m_ControlSchemeIndex; // 0x08
			private InputControlScheme m_ControlScheme; // 0x10
	
			// Constructors
			internal ControlSchemeSyntax(InputActionAsset asset, int index); // 0x0000000181CD28F0-0x0000000181CD2930
			internal ControlSchemeSyntax(InputControlScheme controlScheme); // 0x0000000181CD28A0-0x0000000181CD28F0
	
			// Methods
			public ControlSchemeSyntax WithBindingGroup(string bindingGroup); // 0x0000000181CD26B0-0x0000000181CD2800
			public ControlSchemeSyntax WithRequiredDevice<TDevice>()
				where TDevice : InputDevice;
			public ControlSchemeSyntax WithOptionalDevice<TDevice>()
				where TDevice : InputDevice;
			public ControlSchemeSyntax OrWithRequiredDevice<TDevice>()
				where TDevice : InputDevice;
			public ControlSchemeSyntax OrWithOptionalDevice<TDevice>()
				where TDevice : InputDevice;
			public ControlSchemeSyntax WithRequiredDevice(string controlPath); // 0x0000000181CD2850-0x0000000181CD28A0
			public ControlSchemeSyntax WithOptionalDevice(string controlPath); // 0x0000000181CD2800-0x0000000181CD2850
			public ControlSchemeSyntax OrWithRequiredDevice(string controlPath); // 0x0000000181CD2660-0x0000000181CD26B0
			public ControlSchemeSyntax OrWithOptionalDevice(string controlPath); // 0x0000000181CD2610-0x0000000181CD2660
			private string DeviceTypeToControlPath<TDevice>()
				where TDevice : InputDevice;
			public InputControlScheme Done(); // 0x0000000181CD2550-0x0000000181CD2610
			private void AddDeviceEntry(string controlPath, InputControlScheme.DeviceRequirement.Flags flags); // 0x0000000181CD2340-0x0000000181CD2550
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 6088
		{
			// Fields
			public InputBinding binding; // 0x10
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveAction_b__0(InputBinding b); // 0x0000000181CE30B0-0x0000000181CE3200
		}
	
		// Methods
		private static int AddBindingInternal(InputActionMap map, InputBinding binding, int bindingIndex = -1 /* Metadata: 0x00698935 */); // 0x0000000181CD4620-0x0000000181CD4830
	
		// Extension methods
		public static InputActionMap AddActionMap(this InputActionAsset asset, string name); // 0x0000000181CD4020-0x0000000181CD4220
		public static void AddActionMap(this InputActionAsset asset, InputActionMap map); // 0x0000000181CD3D30-0x0000000181CD4020
		public static void RemoveActionMap(this InputActionAsset asset, InputActionMap map); // 0x0000000181CD67F0-0x0000000181CD6960
		public static void RemoveActionMap(this InputActionAsset asset, string nameOrId); // 0x0000000181CD6960-0x0000000181CD6B80
		public static InputAction AddAction(this InputActionMap map, string name, InputActionType type = InputActionType.Value /* Metadata: 0x00698934 */, string binding = null, string interactions = null, string processors = null, string groups = null, string expectedControlLayout = null); // 0x0000000181CD4220-0x0000000181CD4620
		public static void RemoveAction(this InputAction action); // 0x0000000181CD6B80-0x0000000181CD6F70
		public static void RemoveAction(this InputActionAsset asset, string nameOrId); // 0x0000000181CD6F70-0x0000000181CD7090
		public static BindingSyntax AddBinding(this InputAction action, string path, string interactions = null, string processors = null, string groups = null); // 0x0000000181CD4830-0x0000000181CD4A20
		public static BindingSyntax AddBinding(this InputAction action, InputControl control); // 0x0000000181CD4DA0-0x0000000181CD4E50
		public static BindingSyntax AddBinding(this InputAction action, InputBinding binding = default); // 0x0000000181CD4B00-0x0000000181CD4C30
		public static BindingSyntax AddBinding(this InputActionMap actionMap, string path, string interactions = null, string groups = null, string action = null, string processors = null); // 0x0000000181CD4E50-0x0000000181CD50B0
		public static BindingSyntax AddBinding(this InputActionMap actionMap, string path, InputAction action, string interactions = null, string groups = null); // 0x0000000181CD50B0-0x0000000181CD5250
		public static BindingSyntax AddBinding(this InputActionMap actionMap, string path, Guid action, string interactions = null, string groups = null); // 0x0000000181CD4A20-0x0000000181CD4B00
		public static BindingSyntax AddBinding(this InputActionMap actionMap, InputBinding binding); // 0x0000000181CD4C30-0x0000000181CD4DA0
		public static CompositeSyntax AddCompositeBinding(this InputAction action, string composite, string interactions = null, string processors = null); // 0x0000000181CD5250-0x0000000181CD5480
		public static BindingSyntax ChangeBinding(this InputAction action, int index); // 0x0000000181CD61F0-0x0000000181CD62B0
		public static BindingSyntax ChangeBinding(this InputAction action, string name); // 0x0000000181CD5F10-0x0000000181CD5FE0
		public static BindingSyntax ChangeBinding(this InputActionMap actionMap, int index); // 0x0000000181CD5DF0-0x0000000181CD5F10
		public static BindingSyntax ChangeBindingWithId(this InputAction action, string id); // 0x0000000181CD5A70-0x0000000181CD5BA0
		public static BindingSyntax ChangeBindingWithId(this InputAction action, Guid id); // 0x0000000181CD5BA0-0x0000000181CD5CC0
		public static BindingSyntax ChangeBindingWithGroup(this InputAction action, string group); // 0x0000000181CD5940-0x0000000181CD5A70
		public static BindingSyntax ChangeBindingWithPath(this InputAction action, string path); // 0x0000000181CD5CC0-0x0000000181CD5DF0
		public static BindingSyntax ChangeBinding(this InputAction action, InputBinding match); // 0x0000000181CD5FE0-0x0000000181CD61F0
		public static BindingSyntax ChangeCompositeBinding(this InputAction action, string compositeName); // 0x0000000181CD62B0-0x0000000181CD6530
		public static void Rename(this InputAction action, string newName); // 0x0000000181CD71E0-0x0000000181CD74B0
		public static void AddControlScheme(this InputActionAsset asset, InputControlScheme controlScheme); // 0x0000000181CD5480-0x0000000181CD5760
		public static ControlSchemeSyntax AddControlScheme(this InputActionAsset asset, string name); // 0x0000000181CD5760-0x0000000181CD5940
		public static void RemoveControlScheme(this InputActionAsset asset, string name); // 0x0000000181CD7090-0x0000000181CD71E0
		public static InputControlScheme WithBindingGroup(this InputControlScheme scheme, string bindingGroup); // 0x0000000181CD74B0-0x0000000181CD76E0
		public static InputControlScheme WithDevice(this InputControlScheme scheme, string controlPath, bool required); // 0x0000000181CD76E0-0x0000000181CD7910
		public static InputControlScheme WithRequiredDevice(this InputControlScheme scheme, string controlPath); // 0x0000000181CD7A70-0x0000000181CD7BC0
		public static InputControlScheme WithOptionalDevice(this InputControlScheme scheme, string controlPath); // 0x0000000181CD7910-0x0000000181CD7A70
		public static InputControlScheme OrWithRequiredDevice(this InputControlScheme scheme, string controlPath); // 0x0000000181CD6690-0x0000000181CD67F0
		public static InputControlScheme OrWithOptionalDevice(this InputControlScheme scheme, string controlPath); // 0x0000000181CD6530-0x0000000181CD6690
	}
}
