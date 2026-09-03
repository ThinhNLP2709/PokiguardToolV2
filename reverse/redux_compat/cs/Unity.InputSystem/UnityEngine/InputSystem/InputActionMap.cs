/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[Serializable]
	public sealed class InputActionMap : ICloneable, ISerializationCallbackReceiver, IInputActionCollection2, IDisposable // TypeDefIndex: 6059
	{
		// Fields
		private static readonly ProfilerMarker k_ResolveBindingsProfilerMarker; // 0x00
		[SerializeField]
		internal string m_Name; // 0x10
		[SerializeField]
		internal string m_Id; // 0x18
		[SerializeField]
		internal InputActionAsset m_Asset; // 0x20
		[SerializeField]
		internal InputAction[] m_Actions; // 0x28
		[SerializeField]
		internal InputBinding[] m_Bindings; // 0x30
		[NonSerialized]
		private InputBinding[] m_BindingsForEachAction; // 0x38
		[NonSerialized]
		private InputControl[] m_ControlsForEachAction; // 0x40
		[NonSerialized]
		internal int m_EnabledActionsCount; // 0x48
		[NonSerialized]
		internal InputAction m_SingletonAction; // 0x50
		[NonSerialized]
		internal int m_MapIndexInState; // 0x58
		[NonSerialized]
		internal InputActionState m_State; // 0x60
		[NonSerialized]
		internal InputBinding? m_BindingMask; // 0x68
		[NonSerialized]
		private Flags m_Flags; // 0xC8
		[NonSerialized]
		internal int m_ParameterOverridesCount; // 0xCC
		[NonSerialized]
		internal InputActionRebindingExtensions.ParameterOverride[] m_ParameterOverrides; // 0xD0
		[NonSerialized]
		internal DeviceArray m_Devices; // 0xD8
		[NonSerialized]
		internal CallbackArray<Action<InputAction.CallbackContext>> m_ActionCallbacks; // 0xE8
		[NonSerialized]
		internal Dictionary<string, int> m_ActionIndexByNameOrId; // 0x138
		internal static int s_DeferBindingResolution; // 0x08
		internal static bool s_NeedToResolveBindings; // 0x0C
	
		// Properties
		public string name { get; } // 0x0000000180377550-0x0000000180377560 
		public InputActionAsset asset { get; } // 0x00000001802F8630-0x00000001802F8640 
		public Guid id { get; } // 0x0000000181CB9040-0x0000000181CB90C0 
		internal Guid idDontGenerate { get; } // 0x0000000181CB8FF0-0x0000000181CB9040 
		public bool enabled { get; } // 0x0000000181874B30-0x0000000181874B40 
		public ReadOnlyArray<InputAction> actions { get; } // 0x0000000181CB8D30-0x0000000181CB8D60 
		public ReadOnlyArray<InputBinding> bindings { get; } // 0x0000000181CB8DC0-0x0000000181CB8DF0 
		IEnumerable<InputBinding> IInputActionCollection2.bindings { get; } // 0x0000000181CB8A50-0x0000000181CB8AB0 
		public ReadOnlyArray<InputControlScheme> controlSchemes { get; } // 0x0000000181CB8DF0-0x0000000181CB8EA0 
		public InputBinding? bindingMask { get; set; } // 0x0000000181CB8D60-0x0000000181CB8DA0 0x0000000181CB9120-0x0000000181CB92B0
		public ReadOnlyArray<InputDevice>? devices { get; set; } // 0x0000000181CB8EB0-0x0000000181CB8FF0 0x0000000181CB9310-0x0000000181CB9360
		public InputAction this[string actionNameOrId] { get => default; } // 0x0000000181CB8C20-0x0000000181CB8D30 
		private bool needToResolveBindings { get; set; } // 0x0000000181CB90C0-0x0000000181CB90D0 0x0000000181CB9360-0x0000000181CB9380
		private bool bindingResolutionNeedsFullReResolve { get; set; } // 0x0000000181CB8DA0-0x0000000181CB8DB0 0x0000000181CB92B0-0x0000000181CB92D0
		private bool controlsForEachActionInitialized { get; set; } // 0x0000000181CB8EA0-0x0000000181CB8EB0 0x0000000181CB92F0-0x0000000181CB9310
		private bool bindingsForEachActionInitialized { get; set; } // 0x0000000181CB8DB0-0x0000000181CB8DC0 0x0000000181CB92D0-0x0000000181CB92F0
	
		// Events
		public event Action<InputAction.CallbackContext> actionTriggered {
			add; // 0x0000000181CB8BD0-0x0000000181CB8C20
			remove; // 0x0000000181CB90D0-0x0000000181CB9120
		}
	
		// Nested types
		[Flags]
		private enum Flags // TypeDefIndex: 6060
		{
			NeedToResolveBindings = 1,
			BindingResolutionNeedsFullReResolve = 2,
			ControlsForEachActionInitialized = 4,
			BindingsForEachActionInitialized = 8
		}
	
		internal struct DeviceArray // TypeDefIndex: 6061
		{
			// Fields
			private bool m_HaveValue; // 0x00
			private int m_DeviceCount; // 0x04
			private InputDevice[] m_DeviceArray; // 0x08
	
			// Methods
			public int IndexOf(InputDevice device); // 0x0000000181CB2450-0x0000000181CB2460
			public bool Remove(InputDevice device); // 0x0000000181CB2460-0x0000000181CB24A0
			public ReadOnlyArray<InputDevice>? Get(); // 0x0000000181CB23B0-0x0000000181CB2450
			public bool Set(ReadOnlyArray<InputDevice>? devices); // 0x0000000181CB24A0-0x0000000181CB25F0
		}
	
		[Serializable]
		internal struct BindingOverrideListJson // TypeDefIndex: 6062
		{
			// Fields
			public List<BindingOverrideJson> bindings; // 0x00
		}
	
		[Serializable]
		internal struct BindingOverrideJson // TypeDefIndex: 6063
		{
			// Fields
			public string action; // 0x00
			public string id; // 0x08
			public string path; // 0x10
			public string interactions; // 0x18
			public string processors; // 0x20
	
			// Methods
			public static BindingOverrideJson FromBinding(InputBinding binding, string actionName); // 0x0000000181CB1090-0x0000000181CB1190
			public static BindingOverrideJson FromBinding(InputBinding binding); // 0x0000000181CB1190-0x0000000181CB1210
			public static InputBinding ToBinding(BindingOverrideJson bindingOverride); // 0x0000000181CB1210-0x0000000181CB1340
		}
	
		[Serializable]
		internal struct BindingJson // TypeDefIndex: 6064
		{
			// Fields
			public string name; // 0x00
			public string id; // 0x08
			public string path; // 0x10
			public string interactions; // 0x18
			public string processors; // 0x20
			public string groups; // 0x28
			public string action; // 0x30
			public bool isComposite; // 0x38
			public bool isPartOfComposite; // 0x39
	
			// Methods
			public InputBinding ToBinding(); // 0x0000000181CB0F40-0x0000000181CB1090
			public static BindingJson FromBinding(ref InputBinding binding); // 0x0000000181CB0E80-0x0000000181CB0F40
		}
	
		[Serializable]
		internal struct ReadActionJson // TypeDefIndex: 6065
		{
			// Fields
			public string name; // 0x00
			public string type; // 0x08
			public string id; // 0x10
			public string expectedControlType; // 0x18
			public string expectedControlLayout; // 0x20
			public string processors; // 0x28
			public string interactions; // 0x30
			public bool passThrough; // 0x38
			public bool initialStateCheck; // 0x39
			public BindingJson[] bindings; // 0x40
	
			// Methods
			public InputAction ToAction(string actionName = null); // 0x0000000181CC5130-0x0000000181CC5390
		}
	
		[Serializable]
		internal struct WriteActionJson // TypeDefIndex: 6066
		{
			// Fields
			public string name; // 0x00
			public string type; // 0x08
			public string id; // 0x10
			public string expectedControlType; // 0x18
			public string processors; // 0x20
			public string interactions; // 0x28
			public bool initialStateCheck; // 0x30
	
			// Methods
			public static WriteActionJson FromAction(InputAction action); // 0x0000000181CCA6C0-0x0000000181CCA7D0
		}
	
		[Serializable]
		internal struct ReadMapJson // TypeDefIndex: 6067
		{
			// Fields
			public string name; // 0x00
			public string id; // 0x08
			public ReadActionJson[] actions; // 0x10
			public BindingJson[] bindings; // 0x18
		}
	
		[Serializable]
		internal struct WriteMapJson // TypeDefIndex: 6068
		{
			// Fields
			public string name; // 0x00
			public string id; // 0x08
			public WriteActionJson[] actions; // 0x10
			public BindingJson[] bindings; // 0x18
	
			// Methods
			public static WriteMapJson FromMap(InputActionMap map); // 0x0000000181CCAB30-0x0000000181CCAFF0
		}
	
		[Serializable]
		internal struct WriteFileJson // TypeDefIndex: 6069
		{
			// Fields
			public WriteMapJson[] maps; // 0x00
	
			// Methods
			public static WriteFileJson FromMap(InputActionMap map); // 0x0000000181CCA7D0-0x0000000181CCA880
			public static WriteFileJson FromMaps(IEnumerable<InputActionMap> maps); // 0x0000000181CCA880-0x0000000181CCAB30
		}
	
		[Serializable]
		internal struct ReadFileJson // TypeDefIndex: 6070
		{
			// Fields
			public ReadActionJson[] actions; // 0x00
			public ReadMapJson[] maps; // 0x08
	
			// Methods
			public InputActionMap[] ToMaps(); // 0x0000000181CC5480-0x0000000181CC63B0
		}
	
		// Constructors
		public InputActionMap(); // 0x0000000181CB8B10-0x0000000181CB8B90
		public InputActionMap(string name); // 0x0000000181CB8B90-0x0000000181CB8BD0
		static InputActionMap(); // 0x0000000181CB8AB0-0x0000000181CB8B10
	
		// Methods
		public void Dispose(); // 0x0000000181CB5650-0x0000000181CB5670
		internal int FindActionIndex(string nameOrId); // 0x0000000181CB56E0-0x0000000181CB5AA0
		private void SetUpActionLookupTable(); // 0x0000000181CB7B40-0x0000000181CB7D00
		internal void ClearActionLookupTable(); // 0x0000000181CB5260-0x0000000181CB5280
		private int FindActionIndex(Guid id); // 0x0000000181CB5AA0-0x0000000181CB5BC0
		public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false /* Metadata: 0x00698909 */); // 0x0000000181CB5CF0-0x0000000181CB5E20
		public InputAction FindAction(Guid id); // 0x0000000181CB5BC0-0x0000000181CB5CF0
		public bool IsUsableWithDevice(InputDevice device); // 0x0000000181CB6360-0x0000000181CB64D0
		public void Enable(); // 0x0000000181CB5670-0x0000000181CB56E0
		public void Disable(); // 0x0000000181CB5620-0x0000000181CB5650
		public InputActionMap Clone(); // 0x0000000181CB52E0-0x0000000181CB55F0
		object ICloneable.Clone(); // 0x0000000181CB87E0-0x0000000181CB87F0
		public bool Contains(InputAction action); // 0x0000000181CB55F0-0x0000000181CB5620
		public override string ToString(); // 0x0000000181CB8990-0x0000000181CB8A50
		public IEnumerator<InputAction> GetEnumerator(); // 0x0000000181CB62D0-0x0000000181CB6360
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CB62D0-0x0000000181CB6360
		internal ReadOnlyArray<InputBinding> GetBindingsForSingleAction(InputAction action); // 0x0000000181CB61D0-0x0000000181CB6250
		internal ReadOnlyArray<InputControl> GetControlsForSingleAction(InputAction action); // 0x0000000181CB6250-0x0000000181CB62D0
		private void SetUpPerActionControlAndBindingArrays(); // 0x0000000181CB7D00-0x0000000181CB87E0
		internal void OnWantToChangeSetup(); // 0x0000000181CB6A50-0x0000000181CB6CA0
		internal void OnSetupChanged(); // 0x0000000181CB6790-0x0000000181CB6A50
		internal void OnBindingModified(); // 0x0000000181CB6720-0x0000000181CB6790
		internal void ClearCachedActionData(bool onlyControls = false /* Metadata: 0x0069890A */); // 0x0000000181CB5280-0x0000000181CB52E0
		internal void GenerateId(); // 0x0000000181CB6180-0x0000000181CB61D0
		internal bool LazyResolveBindings(bool fullResolve); // 0x0000000181CB64D0-0x0000000181CB65B0
		internal bool ResolveBindingsIfNecessary(); // 0x0000000181CB6CA0-0x0000000181CB6CE0
		internal void ResolveBindings(); // 0x0000000181CB6CE0-0x0000000181CB7B40
		public int FindBinding(InputBinding mask, out InputAction action); // 0x0000000181CB5EB0-0x0000000181CB60D0
		internal int FindBindingRelativeToMap(InputBinding mask); // 0x0000000181CB5E20-0x0000000181CB5EB0
		public static InputActionMap[] FromJson(string json); // 0x0000000181CB60D0-0x0000000181CB6180
		public static string ToJson(IEnumerable<InputActionMap> maps); // 0x0000000181CB87F0-0x0000000181CB88A0
		public string ToJson(); // 0x0000000181CB88A0-0x0000000181CB8990
		public void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnAfterDeserialize(); // 0x0000000181CB65B0-0x0000000181CB6720
	}
}
