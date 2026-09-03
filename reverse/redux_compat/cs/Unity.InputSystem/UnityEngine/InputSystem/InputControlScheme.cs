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
	[Serializable]
	public struct InputControlScheme : IEquatable<InputControlScheme> // TypeDefIndex: 6114
	{
		// Fields
		[SerializeField]
		internal string m_Name; // 0x00
		[SerializeField]
		internal string m_BindingGroup; // 0x08
		[SerializeField]
		internal DeviceRequirement[] m_DeviceRequirements; // 0x10
	
		// Properties
		public string name { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public string bindingGroup { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		public ReadOnlyArray<DeviceRequirement> deviceRequirements { get; } // 0x0000000181D0CB60-0x0000000181D0CB90 
	
		// Nested types
		public struct MatchResult : IEnumerable<MatchResult.Match>, IDisposable // TypeDefIndex: 6115
		{
			// Fields
			internal Result m_Result; // 0x00
			internal float m_Score; // 0x04
			internal InputControlList<InputDevice> m_Devices; // 0x08
			internal InputControlList<InputControl> m_Controls; // 0x28
			internal DeviceRequirement[] m_Requirements; // 0x48
	
			// Properties
			public float score { get; } // 0x000000018035C790-0x000000018035C7A0 
			public bool isSuccessfulMatch { get; } // 0x0000000181D174A0-0x0000000181D174B0 
			public bool hasMissingRequiredDevices { get; } // 0x0000000181D17490-0x0000000181D174A0 
			public bool hasMissingOptionalDevices { get; } // 0x0000000181D17480-0x0000000181D17490 
			public InputControlList<InputDevice> devices { get; } // 0x0000000181D17370-0x0000000181D17480 
			public Match this[int index] { get => default; } // 0x0000000181D172C0-0x0000000181D17370 
	
			// Nested types
			internal enum Result // TypeDefIndex: 6116
			{
				AllSatisfied = 0,
				MissingRequired = 1,
				MissingOptional = 2
			}
	
			public struct Match // TypeDefIndex: 6117
			{
				// Fields
				internal int m_RequirementIndex; // 0x00
				internal DeviceRequirement[] m_Requirements; // 0x08
				internal InputControlList<InputControl> m_Controls; // 0x10
	
				// Properties
				public InputControl control { get; } // 0x0000000181D174B0-0x0000000181D174F0 
				public InputDevice device { get; } // 0x0000000181D174F0-0x0000000181D17540 
				public int requirementIndex { get; } // 0x0000000180732D10-0x0000000180732D20 
				public DeviceRequirement requirement { get; } // 0x0000000181D17580-0x0000000181D175C0 
				public bool isOptional { get; } // 0x0000000181D17540-0x0000000181D17580 
			}
	
			private struct Enumerator : IEnumerator<Match> // TypeDefIndex: 6118
			{
				// Fields
				internal int m_Index; // 0x00
				internal DeviceRequirement[] m_Requirements; // 0x08
				internal InputControlList<InputControl> m_Controls; // 0x10
	
				// Properties
				public Match Current { get; } // 0x0000000181D03CE0-0x0000000181D03DA0 
				object IEnumerator.Current { get; } // 0x0000000181D03C70-0x0000000181D03CE0 
	
				// Methods
				public bool MoveNext(); // 0x0000000181D03C40-0x0000000181D03C60
				public void Reset(); // 0x0000000181D03C60-0x0000000181D03C70
				public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			}
	
			// Methods
			public IEnumerator<Match> GetEnumerator(); // 0x0000000181D17210-0x0000000181D172B0
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D172B0-0x0000000181D172C0
			public void Dispose(); // 0x0000000181D171E0-0x0000000181D17210
		}
	
		[Serializable]
		public struct DeviceRequirement : IEquatable<DeviceRequirement> // TypeDefIndex: 6119
		{
			// Fields
			[SerializeField]
			internal string m_ControlPath; // 0x00
			[SerializeField]
			internal Flags m_Flags; // 0x08
	
			// Properties
			public string controlPath { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
			public bool isOptional { get; set; } // 0x0000000181D03B00-0x0000000181D03B10 0x0000000181D03C20-0x0000000181D03C40
			public bool isAND { get; set; } // 0x0000000181D03AE0-0x0000000181D03AF0 0x0000000181D03BE0-0x0000000181D03C00
			public bool isOR { get; set; } // 0x0000000181D03AF0-0x0000000181D03B00 0x0000000181D03C00-0x0000000181D03C20
	
			// Nested types
			[Flags]
			internal enum Flags // TypeDefIndex: 6120
			{
				None = 0,
				Optional = 1,
				Or = 2
			}
	
			// Methods
			public override string ToString(); // 0x0000000181D03A40-0x0000000181D03AE0
			public bool Equals(DeviceRequirement other); // 0x0000000181D03840-0x0000000181D038A0
			public override bool Equals(object obj); // 0x0000000181D038A0-0x0000000181D03970
			public override int GetHashCode(); // 0x0000000181D03970-0x0000000181D03A40
			public static bool operator ==(DeviceRequirement left, DeviceRequirement right); // 0x0000000181D03B10-0x0000000181D03B80
			public static bool operator !=(DeviceRequirement left, DeviceRequirement right); // 0x0000000181D03B80-0x0000000181D03BE0
		}
	
		[Serializable]
		internal struct SchemeJson // TypeDefIndex: 6121
		{
			// Fields
			public string name; // 0x00
			public string bindingGroup; // 0x08
			public DeviceJson[] devices; // 0x10
	
			// Nested types
			[Serializable]
			public struct DeviceJson // TypeDefIndex: 6122
			{
				// Fields
				public string devicePath; // 0x00
				public bool isOptional; // 0x08
				public bool isOR; // 0x09
	
				// Methods
				public DeviceRequirement ToDeviceEntry(); // 0x0000000181D037E0-0x0000000181D03840
				public static DeviceJson From(DeviceRequirement requirement); // 0x0000000181D03790-0x0000000181D037E0
			}
	
			// Methods
			public InputControlScheme ToScheme(); // 0x0000000181D19680-0x0000000181D19860
			public static SchemeJson ToJson(InputControlScheme scheme); // 0x0000000181D19170-0x0000000181D19370
			public static SchemeJson[] ToJson(InputControlScheme[] schemes); // 0x0000000181D19370-0x0000000181D19680
			public static InputControlScheme[] ToSchemes(SchemeJson[] schemes); // 0x0000000181D19860-0x0000000181D19980
		}
	
		// Constructors
		public InputControlScheme(string name, IEnumerable<DeviceRequirement> devices = null, string bindingGroup = null); // 0x0000000181D0C9B0-0x0000000181D0CB60
	
		// Methods
		internal void SetNameAndBindingGroup(string name, string bindingGroup = null); // 0x0000000181D0C640-0x0000000181D0C700
		public static InputControlScheme? FindControlSchemeForDevices<TDevices, TSchemes>(TDevices devices, TSchemes schemes, InputDevice mustIncludeDevice = null, bool allowUnsuccesfulMatch = false /* Metadata: 0x00698972 */)
			where TDevices : IReadOnlyList<InputDevice>
			where TSchemes : IEnumerable<InputControlScheme>;
		public static bool FindControlSchemeForDevices<TDevices, TSchemes>(TDevices devices, TSchemes schemes, out InputControlScheme controlScheme, out MatchResult matchResult, InputDevice mustIncludeDevice = null, bool allowUnsuccessfulMatch = false /* Metadata: 0x00698973 */)
			where TDevices : IReadOnlyList<InputDevice>
			where TSchemes : IEnumerable<InputControlScheme>;
		public static InputControlScheme? FindControlSchemeForDevice<TSchemes>(InputDevice device, TSchemes schemes)
			where TSchemes : IEnumerable<InputControlScheme>;
		public bool SupportsDevice(InputDevice device); // 0x0000000181D0C700-0x0000000181D0C830
		public MatchResult PickDevicesFrom<TDevices>(TDevices devices, InputDevice favorDevice = null)
			where TDevices : IReadOnlyList<InputDevice>;
		public bool Equals(InputControlScheme other); // 0x0000000181D0C270-0x0000000181D0C4F0
		public override bool Equals(object obj); // 0x0000000181D0C4F0-0x0000000181D0C590
		public override int GetHashCode(); // 0x0000000181D0C590-0x0000000181D0C640
		public override string ToString(); // 0x0000000181D0C830-0x0000000181D0C9B0
		public static bool operator ==(InputControlScheme left, InputControlScheme right); // 0x0000000181D0CB90-0x0000000181D0CBC0
		public static bool operator !=(InputControlScheme left, InputControlScheme right); // 0x0000000181D0CBC0-0x0000000181D0CBF0
	}
}
