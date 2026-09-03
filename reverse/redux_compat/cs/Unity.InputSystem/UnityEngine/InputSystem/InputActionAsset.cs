/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public class InputActionAsset : ScriptableObject, IInputActionCollection2 // TypeDefIndex: 6051
	{
		// Fields
		public const string Extension = "inputactions"; // Metadata: 0x006988ED
		internal const string kDefaultAssetLayoutJson = "{}"; // Metadata: 0x006988FA
		[SerializeField]
		internal InputActionMap[] m_ActionMaps; // 0x18
		[SerializeField]
		internal InputControlScheme[] m_ControlSchemes; // 0x20
		[SerializeField]
		internal bool m_IsProjectWide; // 0x28
		[NonSerialized]
		internal InputActionState m_SharedStateForAllMaps; // 0x30
		[NonSerialized]
		internal InputBinding? m_BindingMask; // 0x38
		[NonSerialized]
		internal int m_ParameterOverridesCount; // 0x98
		[NonSerialized]
		internal InputActionRebindingExtensions.ParameterOverride[] m_ParameterOverrides; // 0xA0
		[NonSerialized]
		internal InputActionMap.DeviceArray m_Devices; // 0xA8
	
		// Properties
		public bool enabled { get; } // 0x0000000181CB4F00-0x0000000181CB5030 
		public ReadOnlyArray<InputActionMap> actionMaps { get; } // 0x0000000181CB4D50-0x0000000181CB4D80 
		public ReadOnlyArray<InputControlScheme> controlSchemes { get; } // 0x0000000181CB4E40-0x0000000181CB4E70 
		public IEnumerable<InputBinding> bindings { [IteratorStateMachine(typeof(_get_bindings_d__9))] get; } // 0x0000000181CB4DC0-0x0000000181CB4E40 
		public InputBinding? bindingMask { get; set; } // 0x0000000181CB4D80-0x0000000181CB4DC0 0x0000000181CB5030-0x0000000181CB51E0
		public ReadOnlyArray<InputDevice>? devices { get; set; } // 0x0000000181CB4E70-0x0000000181CB4F00 0x0000000181CB51E0-0x0000000181CB5260
		public InputAction this[string actionNameOrId] { get => default; } // 0x0000000181CB4CC0-0x0000000181CB4D50 
	
		// Nested types
		private static class JsonVersion // TypeDefIndex: 6052
		{
			// Fields
			public const int Version0 = 0; // Metadata: 0x006988FD
			public const int Version1 = 1; // Metadata: 0x006988FE
			public const int Current = 1; // Metadata: 0x006988FF
		}
	
		[Serializable]
		internal struct WriteFileJson // TypeDefIndex: 6053
		{
			// Fields
			public int version; // 0x00
			public string name; // 0x08
			public InputActionMap.WriteMapJson[] maps; // 0x10
			public InputControlScheme.SchemeJson[] controlSchemes; // 0x18
		}
	
		[Serializable]
		internal struct WriteFileJsonNoName // TypeDefIndex: 6054
		{
			// Fields
			public InputActionMap.WriteMapJson[] maps; // 0x00
			public InputControlScheme.SchemeJson[] controlSchemes; // 0x08
		}
	
		[Serializable]
		internal struct ReadFileJson // TypeDefIndex: 6055
		{
			// Fields
			public int version; // 0x00
			public string name; // 0x08
			public InputActionMap.ReadMapJson[] maps; // 0x10
			public InputControlScheme.SchemeJson[] controlSchemes; // 0x18
	
			// Methods
			public void ToAsset(InputActionAsset asset); // 0x0000000181CC5390-0x0000000181CC5480
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__33 : IEnumerator<InputAction> // TypeDefIndex: 6056
		{
			// Fields
			private int __1__state; // 0x10
			private InputAction __2__current; // 0x18
			public InputActionAsset __4__this; // 0x20
			private int _i_5__2; // 0x28
			private ReadOnlyArray<InputAction> _actions_5__3; // 0x30
			private int _actionCount_5__4; // 0x40
			private int _n_5__5; // 0x44
	
			// Properties
			InputAction IEnumerator<UnityEngine.InputSystem.InputAction>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181CC9B00-0x0000000181CC9B10
			private bool MoveNext(); // 0x0000000181CC9960-0x0000000181CC9AC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181CC9AC0-0x0000000181CC9B00
		}
	
		[CompilerGenerated]
		private sealed class _get_bindings_d__9 : IEnumerable<InputBinding>, IEnumerator<InputBinding> // TypeDefIndex: 6057
		{
			// Fields
			private int __1__state; // 0x10
			private InputBinding __2__current; // 0x18
			private int __l__initialThreadId; // 0x70
			public InputActionAsset __4__this; // 0x78
			private int _numActionMaps_5__2; // 0x80
			private int _i_5__3; // 0x84
			private InputBinding[] _bindings_5__4; // 0x88
			private int _numBindings_5__5; // 0x90
			private int _n_5__6; // 0x94
	
			// Properties
			InputBinding IEnumerator<UnityEngine.InputSystem.InputBinding>.Current { [DebuggerHidden] get; } // 0x00000001811073B0-0x00000001811073F0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181CC9DA0-0x0000000181CC9E20 
	
			// Constructors
			[DebuggerHidden]
			public _get_bindings_d__9(int __1__state); // 0x0000000181CC9E50-0x0000000181CC9E80
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181CC9E20-0x0000000181CC9E50
			private bool MoveNext(); // 0x0000000181CC9B10-0x0000000181CC9CC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181CC9D60-0x0000000181CC9DA0
			[DebuggerHidden]
			IEnumerator<InputBinding> IEnumerable<InputBinding>.GetEnumerator(); // 0x0000000181CC9CC0-0x0000000181CC9D60
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CC9CC0-0x0000000181CC9D60
		}
	
		// Constructors
		public InputActionAsset(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public string ToJson(); // 0x0000000181CB4BC0-0x0000000181CB4CC0
		public void LoadFromJson(string json); // 0x0000000181CB4060-0x0000000181CB4200
		public static InputActionAsset FromJson(string json); // 0x0000000181CB3C60-0x0000000181CB3D20
		public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false /* Metadata: 0x006988EB */); // 0x0000000181CB3410-0x0000000181CB3830
		public int FindBinding(InputBinding mask, out InputAction action); // 0x0000000181CB3830-0x0000000181CB3950
		public InputActionMap FindActionMap(string nameOrId, bool throwIfNotFound = false /* Metadata: 0x006988EC */); // 0x0000000181CB2EC0-0x0000000181CB3160
		public InputActionMap FindActionMap(Guid id); // 0x0000000181CB3160-0x0000000181CB3270
		public InputAction FindAction(Guid guid); // 0x0000000181CB3270-0x0000000181CB3410
		public int FindControlSchemeIndex(string name); // 0x0000000181CB3950-0x0000000181CB3A60
		public InputControlScheme? FindControlScheme(string name); // 0x0000000181CB3A60-0x0000000181CB3C60
		public bool IsUsableWithDevice(InputDevice device); // 0x0000000181CB3E00-0x0000000181CB4060
		public void Enable(); // 0x0000000181CB2D40-0x0000000181CB2EC0
		public void Disable(); // 0x0000000181CB2C10-0x0000000181CB2D40
		public bool Contains(InputAction action); // 0x0000000181CB2B80-0x0000000181CB2C10
		[IteratorStateMachine(typeof(_GetEnumerator_d__33))]
		public IEnumerator<InputAction> GetEnumerator(); // 0x0000000181CB3D20-0x0000000181CB3D90
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CB3D20-0x0000000181CB3D90
		internal void MarkAsDirty(); // 0x00000001802E76C0-0x00000001802E76D0
		internal bool IsEmpty(); // 0x0000000181CB3D90-0x0000000181CB3E00
		internal void OnWantToChangeSetup(); // 0x0000000181CB4AA0-0x0000000181CB4AF0
		internal void OnSetupChanged(); // 0x0000000181CB4A40-0x0000000181CB4AA0
		private void ReResolveIfNecessary(bool fullResolve); // 0x0000000181CB4AF0-0x0000000181CB4B30
		internal void ResolveBindingsIfNecessary(); // 0x0000000181CB4B30-0x0000000181CB4BC0
		private void OnDestroy(); // 0x0000000181CB4A00-0x0000000181CB4A40
		internal void MigrateJson(ref ReadFileJson parsedJson); // 0x0000000181CB4200-0x0000000181CB4A00
	}
}
