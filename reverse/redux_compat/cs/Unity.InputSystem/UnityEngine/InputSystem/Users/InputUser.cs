/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Users
{
	public struct InputUser : IEquatable<InputUser> // TypeDefIndex: 6285
	{
		// Fields
		public const uint InvalidId = 0; // Metadata: 0x00698DD9
		private static readonly ProfilerMarker k_InputUserOnChangeMarker; // 0x00
		private static readonly ProfilerMarker k_InputCheckForUnpairMarker; // 0x08
		private uint m_Id; // 0x00
		private static GlobalState s_GlobalState; // 0x10
	
		// Properties
		public bool valid { get; } // 0x0000000181D942E0-0x0000000181D943D0 
		public int index { get; } // 0x0000000181D93D40-0x0000000181D93F30 
		public uint id { get; } // 0x0000000180732D10-0x0000000180732D20 
		public InputUserAccountHandle? platformUserAccountHandle { get; } // 0x0000000181D94110-0x0000000181D941C0 
		public string platformUserAccountName { get; } // 0x0000000181D94250-0x0000000181D942E0 
		public string platformUserAccountId { get; } // 0x0000000181D941C0-0x0000000181D94250 
		public ReadOnlyArray<InputDevice> pairedDevices { get; } // 0x0000000181D94050-0x0000000181D94110 
		public ReadOnlyArray<InputDevice> lostDevices { get; } // 0x0000000181D93F90-0x0000000181D94050 
		public IInputActionCollection actions { get; } // 0x0000000181D93A10-0x0000000181D93AA0 
		public InputControlScheme? controlScheme { get; } // 0x0000000181D93BF0-0x0000000181D93CA0 
		public InputControlScheme.MatchResult controlSchemeMatch { get; } // 0x0000000181D93B20-0x0000000181D93BF0 
		public bool hasMissingRequiredDevices { get; } // 0x0000000181D93CA0-0x0000000181D93D40 
		public static ReadOnlyArray<InputUser> all { get; } // 0x0000000181D93AA0-0x0000000181D93B20 
		public static int listenForUnpairedDeviceActivity { get; set; } // 0x0000000181D93F30-0x0000000181D93F90 0x0000000181D94640-0x0000000181D94770
	
		// Events
		public static event Action<InputUser, InputUserChange, InputDevice> onChange {
			add; // 0x0000000181D937A0-0x0000000181D93860
			remove; // 0x0000000181D943D0-0x0000000181D94490
		}
		public static event Action<InputControl, InputEventPtr> onUnpairedDeviceUsed {
			add; // 0x0000000181D93920-0x0000000181D93A10
			remove; // 0x0000000181D94550-0x0000000181D94640
		}
		public static event Func<InputDevice, InputEventPtr, bool> onPrefilterUnpairedDeviceActivity {
			add; // 0x0000000181D93860-0x0000000181D93920
			remove; // 0x0000000181D94490-0x0000000181D94550
		}
	
		// Nested types
		public struct ControlSchemeChangeSyntax // TypeDefIndex: 6286
		{
			// Fields
			internal int m_UserIndex; // 0x00
	
			// Methods
			public ControlSchemeChangeSyntax AndPairRemainingDevices(); // 0x0000000181DA9CB0-0x0000000181DA9D10
		}
	
		[Flags]
		internal enum UserFlags // TypeDefIndex: 6287
		{
			BindToAllDevices = 1,
			UserAccountSelectionInProgress = 2
		}
	
		private struct UserData // TypeDefIndex: 6288
		{
			// Fields
			public InputUserAccountHandle? platformUserAccountHandle; // 0x00
			public string platformUserAccountName; // 0x18
			public string platformUserAccountId; // 0x20
			public int deviceCount; // 0x28
			public int deviceStartIndex; // 0x2C
			public IInputActionCollection actions; // 0x30
			public InputControlScheme? controlScheme; // 0x38
			public InputControlScheme.MatchResult controlSchemeMatch; // 0x58
			public int lostDeviceCount; // 0xA8
			public int lostDeviceStartIndex; // 0xAC
			public UserFlags flags; // 0xB0
		}
	
		private struct CompareDevicesByUserAccount : IComparer<InputDevice> // TypeDefIndex: 6289
		{
			// Fields
			public InputUserAccountHandle platformUserAccountHandle; // 0x00
	
			// Methods
			public int Compare(InputDevice x, InputDevice y); // 0x0000000181DA9A60-0x0000000181DA9CB0
			private static InputUserAccountHandle? GetUserAccountHandleForDevice(InputDevice device); // 0x0000000180A69590-0x0000000180A695A0
		}
	
		private struct OngoingAccountSelection // TypeDefIndex: 6290
		{
			// Fields
			public InputDevice device; // 0x00
			public uint userId; // 0x08
		}
	
		private struct GlobalState // TypeDefIndex: 6291
		{
			// Fields
			internal int pairingStateVersion; // 0x00
			internal uint lastUserId; // 0x04
			internal int allUserCount; // 0x08
			internal int allPairedDeviceCount; // 0x0C
			internal int allLostDeviceCount; // 0x10
			internal InputUser[] allUsers; // 0x18
			internal UserData[] allUserData; // 0x20
			internal InputDevice[] allPairedDevices; // 0x28
			internal InputDevice[] allLostDevices; // 0x30
			internal InlinedArray<OngoingAccountSelection> ongoingAccountSelections; // 0x38
			internal CallbackArray<Action<InputUser, InputUserChange, InputDevice>> onChange; // 0x58
			internal CallbackArray<Action<InputControl, InputEventPtr>> onUnpairedDeviceUsed; // 0xA8
			internal CallbackArray<Func<InputDevice, InputEventPtr, bool>> onPreFilterUnpairedDeviceUsed; // 0xF8
			internal Action<object, InputActionChange> actionChangeDelegate; // 0x148
			internal Action<InputDevice, InputDeviceChange> onDeviceChangeDelegate; // 0x150
			internal Action<InputEventPtr, InputDevice> onEventDelegate; // 0x158
			internal bool onActionChangeHooked; // 0x160
			internal bool onDeviceChangeHooked; // 0x161
			internal bool onEventHooked; // 0x162
			internal int listenForUnpairedDeviceActivity; // 0x164
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6292
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static SavedStructState<GlobalState> __9__88_0; // 0x08
			public static Action __9__88_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181DBCD70-0x0000000181DBCDE0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SaveAndResetState_b__88_0(ref GlobalState state); // 0x0000000181DBCAB0-0x0000000181DBCC70
			internal void _SaveAndResetState_b__88_1(); // 0x0000000181DBCC70-0x0000000181DBCCB0
		}
	
		// Constructors
		static InputUser(); // 0x0000000181D93700-0x0000000181D937A0
	
		// Methods
		public override string ToString(); // 0x0000000181D91840-0x0000000181D91B10
		public void AssociateActionsWithUser(IInputActionCollection actions); // 0x0000000181D8DE90-0x0000000181D8E3E0
		public ControlSchemeChangeSyntax ActivateControlScheme(string schemeName); // 0x0000000181D8D600-0x0000000181D8D6E0
		private bool TryFindControlScheme(string schemeName, out InputControlScheme scheme); // 0x0000000181D91B10-0x0000000181D91E00
		internal void FindControlScheme(string schemeName, out InputControlScheme scheme); // 0x0000000181D8E5E0-0x0000000181D8E700
		public ControlSchemeChangeSyntax ActivateControlScheme(InputControlScheme scheme); // 0x0000000181D8D460-0x0000000181D8D600
		private void ActivateControlSchemeInternal(int userIndex, InputControlScheme scheme); // 0x0000000181D8D010-0x0000000181D8D460
		public void UnpairDevice(InputDevice device); // 0x0000000181D92340-0x0000000181D92430
		public void UnpairDevices(); // 0x0000000181D924A0-0x0000000181D92870
		private static void RemoveLostDevicesForUser(int userIndex); // 0x0000000181D91120-0x0000000181D912A0
		public void UnpairDevicesAndRemoveUser(); // 0x0000000181D92430-0x0000000181D924A0
		public static InputControlList<InputDevice> GetUnpairedInputDevices(); // 0x0000000181D8EDD0-0x0000000181D8EE50
		public static int GetUnpairedInputDevices(ref InputControlList<InputDevice> list); // 0x0000000181D8EC10-0x0000000181D8EDD0
		public static InputUser? FindUserPairedToDevice(InputDevice device); // 0x0000000181D8EA50-0x0000000181D8EC10
		public static InputUser? FindUserByAccount(InputUserAccountHandle platformUserAccountHandle); // 0x0000000181D8E800-0x0000000181D8EA50
		public static InputUser CreateUserWithoutPairedDevices(); // 0x0000000181D8E3E0-0x0000000181D8E450
		public static InputUser PerformPairingWithDevice(InputDevice device, InputUser user = default, InputUserPairingOptions options = InputUserPairingOptions.None /* Metadata: 0x00698DD3 */); // 0x0000000181D906D0-0x0000000181D908E0
		private static bool InitiateUserAccountSelection(int userIndex, InputDevice device, InputUserPairingOptions options); // 0x0000000181D8F2A0-0x0000000181D8F4C0
		public bool Equals(InputUser other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override bool Equals(object obj); // 0x0000000181D8E540-0x0000000181D8E5E0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public static bool operator ==(InputUser left, InputUser right); // 0x0000000180A2DD00-0x0000000180A2DD10
		public static bool operator !=(InputUser left, InputUser right); // 0x0000000181CA6840-0x0000000181CA6850
		private static int AddUser(); // 0x0000000181D8DCE0-0x0000000181D8DE90
		private static void RemoveUser(int userIndex); // 0x0000000181D912A0-0x0000000181D91520
		private static void Notify(int userIndex, InputUserChange change, InputDevice device); // 0x0000000181D8F4C0-0x0000000181D8F780
		private static int TryFindUserIndex(uint userId); // 0x0000000181D91E00-0x0000000181D91EE0
		private static int TryFindUserIndex(InputUserAccountHandle platformHandle); // 0x0000000181D91FC0-0x0000000181D920F0
		private static int TryFindUserIndex(InputDevice device); // 0x0000000181D91EE0-0x0000000181D91FC0
		private static void AddDeviceToUser(int userIndex, InputDevice device, bool asLostDevice = false /* Metadata: 0x00698DD4 */, bool dontUpdateControlScheme = false /* Metadata: 0x00698DD5 */); // 0x0000000181D8D6E0-0x0000000181D8DCE0
		private static void RemoveDeviceFromUser(int userIndex, InputDevice device, bool asLostDevice = false /* Metadata: 0x00698DD6 */); // 0x0000000181D90B20-0x0000000181D91120
		private static void UpdateControlSchemeMatch(int userIndex, bool autoPairMissing = false /* Metadata: 0x00698DD7 */); // 0x0000000181D92870-0x0000000181D931C0
		private static long UpdatePlatformUserAccount(int userIndex, InputDevice device); // 0x0000000181D931C0-0x0000000181D93700
		private static long QueryPairedPlatformUserAccount(InputDevice device, out InputUserAccountHandle? platformAccountHandle, out string platformAccountName, out string platformAccountId); // 0x0000000181D908E0-0x0000000181D90B20
		private static bool InitiateUserAccountSelectionAtPlatformLevel(InputDevice device); // 0x0000000181D8F200-0x0000000181D8F2A0
		private static void OnActionChange(object obj, InputActionChange change); // 0x0000000181D8F780-0x0000000181D8F910
		private static void OnDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181D8F910-0x0000000181D90100
		private static int FindLostDevice(InputDevice device, int startIndex = 0 /* Metadata: 0x00698DD8 */); // 0x0000000181D8E700-0x0000000181D8E800
		private static void OnEvent(InputEventPtr eventPtr, InputDevice device); // 0x0000000181D90100-0x0000000181D906D0
		internal static ISavedState SaveAndResetState(); // 0x0000000181D91650-0x0000000181D91840
		private static void HookIntoActionChange(); // 0x0000000181D8EE50-0x0000000181D8EF90
		private static void UnhookFromActionChange(); // 0x0000000181D920F0-0x0000000181D921D0
		private static void HookIntoDeviceChange(); // 0x0000000181D8EF90-0x0000000181D8F0C0
		private static void UnhookFromDeviceChange(); // 0x0000000181D921D0-0x0000000181D92280
		private static void HookIntoEvents(); // 0x0000000181D8F0C0-0x0000000181D8F200
		private static void UnhookFromDeviceStateChange(); // 0x0000000181D92280-0x0000000181D92340
		private static void DisposeAndResetGlobalState(); // 0x0000000181D8E450-0x0000000181D8E540
		internal static void ResetGlobals(); // 0x0000000181D91520-0x0000000181D91650
	}
}
