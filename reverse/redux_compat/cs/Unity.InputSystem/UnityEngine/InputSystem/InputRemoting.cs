/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public sealed class InputRemoting : IObservable<UnityEngine.InputSystem.InputRemoting.Message>, IObserver<UnityEngine.InputSystem.InputRemoting.Message> // TypeDefIndex: 6172
	{
		// Fields
		private Flags m_Flags; // 0x10
		private InputManager m_LocalManager; // 0x18
		private Subscriber[] m_Subscribers; // 0x20
		private RemoteSender[] m_Senders; // 0x28
	
		// Properties
		public bool sending { get; private set; } // 0x0000000181675A10-0x0000000181675A20 0x0000000181D810A0-0x0000000181D810C0
		internal InputManager manager { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Nested types
		public enum MessageType // TypeDefIndex: 6173
		{
			Connect = 0,
			Disconnect = 1,
			NewLayout = 2,
			NewDevice = 3,
			NewEvents = 4,
			RemoveDevice = 5,
			RemoveLayout = 6,
			ChangeUsages = 7,
			StartSending = 8,
			StopSending = 9
		}
	
		public struct Message // TypeDefIndex: 6174
		{
			// Fields
			public int participantId; // 0x00
			public MessageType type; // 0x04
			public byte[] data; // 0x08
		}
	
		[Flags]
		private enum Flags // TypeDefIndex: 6175
		{
			Sending = 1,
			StartSendingOnConnect = 2
		}
	
		[Serializable]
		internal struct RemoteSender // TypeDefIndex: 6176
		{
			// Fields
			public int senderId; // 0x00
			public InternedString[] layouts; // 0x08
			public RemoteInputDevice[] devices; // 0x10
		}
	
		[Serializable]
		internal struct RemoteInputDevice // TypeDefIndex: 6177
		{
			// Fields
			public int remoteId; // 0x00
			public int localId; // 0x04
			public InputDeviceDescription description; // 0x08
		}
	
		internal class Subscriber : IDisposable // TypeDefIndex: 6178
		{
			// Fields
			public InputRemoting owner; // 0x10
			public IObserver<Message> observer; // 0x18
	
			// Constructors
			public Subscriber(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Dispose(); // 0x0000000181D882B0-0x0000000181D88300
		}
	
		private static class ConnectMsg // TypeDefIndex: 6179
		{
			// Methods
			public static void Process(InputRemoting receiver); // 0x0000000181D69C80-0x0000000181D69CD0
		}
	
		private static class StartSendingMsg // TypeDefIndex: 6180
		{
			// Methods
			public static void Process(InputRemoting receiver); // 0x0000000181D88020-0x0000000181D88040
		}
	
		private static class StopSendingMsg // TypeDefIndex: 6181
		{
			// Methods
			public static void Process(InputRemoting receiver); // 0x0000000181D88240-0x0000000181D88260
		}
	
		private static class DisconnectMsg // TypeDefIndex: 6182
		{
			// Methods
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D69CE0-0x0000000181D69ED0
		}
	
		private static class NewLayoutMsg // TypeDefIndex: 6183
		{
			// Nested types
			[Serializable]
			public struct Data // TypeDefIndex: 6184
			{
				// Fields
				public string name; // 0x00
				public string layoutJson; // 0x08
				public bool isOverride; // 0x10
			}
	
			// Methods
			public static Message? Create(InputRemoting sender, string layoutName); // 0x0000000181D85B40-0x0000000181D85DE0
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D85DE0-0x0000000181D85F10
		}
	
		private static class NewDeviceMsg // TypeDefIndex: 6185
		{
			// Nested types
			[Serializable]
			public struct Data // TypeDefIndex: 6186
			{
				// Fields
				public string name; // 0x00
				public string layout; // 0x08
				public int deviceId; // 0x10
				public string[] usages; // 0x18
				public InputDeviceDescription description; // 0x20
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6187
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<InternedString, string> __9__1_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181D8A080-0x0000000181D8A0F0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _Create_b__1_0(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
			}
	
			// Methods
			public static Message Create(InputDevice device); // 0x0000000181D84CB0-0x0000000181D84F60
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D84F60-0x0000000181D85740
		}
	
		private static class NewEventsMsg // TypeDefIndex: 6188
		{
			// Methods
			public static Message CreateResetEvent(InputDevice device, bool isHardReset); // 0x0000000181D85740-0x0000000181D857C0
			public static Message CreateStateEvent(InputDevice device); // 0x0000000181D857C0-0x0000000181D858D0
			public static unsafe Message Create(InputEvent* events, int eventCount); // 0x0000000181D858D0-0x0000000181D859D0
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D859D0-0x0000000181D85B40
		}
	
		private static class ChangeUsageMsg // TypeDefIndex: 6189
		{
			// Nested types
			[Serializable]
			public struct Data // TypeDefIndex: 6190
			{
				// Fields
				public int deviceId; // 0x00
				public string[] usages; // 0x08
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6191
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<InternedString, string> __9__1_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181D8A0F0-0x0000000181D8A2A0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _Create_b__1_0(InternedString x); // 0x0000000181D01A70-0x0000000181D01A90
			}
	
			// Methods
			public static Message Create(InputDevice device); // 0x0000000181D69730-0x0000000181D69910
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D69910-0x0000000181D69C80
		}
	
		private static class RemoveDeviceMsg // TypeDefIndex: 6192
		{
			// Methods
			public static Message Create(InputDevice device); // 0x0000000181D87E30-0x0000000181D87E80
			public static void Process(InputRemoting receiver, Message msg); // 0x0000000181D87E80-0x0000000181D87F10
		}
	
		// Constructors
		internal InputRemoting(InputManager manager, bool startSendingOnConnect = false /* Metadata: 0x00698C42 */); // 0x0000000181D81000-0x0000000181D810A0
	
		// Methods
		public void StartSending(); // 0x0000000181D80870-0x0000000181D80A40
		public void StopSending(); // 0x0000000181D80A40-0x0000000181D80C00
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnNext(Message msg); // 0x0000000181D80D00-0x0000000181D80FD0
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnError(Exception error); // 0x00000001802E76C0-0x00000001802E76D0
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnCompleted(); // 0x00000001802E76C0-0x00000001802E76D0
		public IDisposable Subscribe(IObserver<Message> observer); // 0x0000000181D80C00-0x0000000181D80D00
		private void SendInitialMessages(); // 0x0000000181D805A0-0x0000000181D805C0
		private void SendAllGeneratedLayouts(); // 0x0000000181D801B0-0x0000000181D80340
		private void SendLayout(string layoutName); // 0x0000000181D806C0-0x0000000181D80740
		private void SendAllDevices(); // 0x0000000181D7FFE0-0x0000000181D801B0
		private void SendDevice(InputDevice device); // 0x0000000181D804A0-0x0000000181D80530
		private void SendEvent(InputEventPtr eventPtr, InputDevice device); // 0x0000000181D80530-0x0000000181D805A0
		private void SendDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181D80340-0x0000000181D804A0
		private void SendLayoutChange(string layout, InputControlLayoutChange change); // 0x0000000181D805C0-0x0000000181D806C0
		private void Send(Message msg); // 0x0000000181D80740-0x0000000181D80870
		private int FindOrCreateSenderRecord(int senderId); // 0x0000000181D7FDA0-0x0000000181D7FE60
		private static InternedString BuildLayoutNamespace(int senderId); // 0x0000000181D7FCA0-0x0000000181D7FD20
		private int FindLocalDeviceId(int remoteDeviceId, int senderIndex); // 0x0000000181D7FD20-0x0000000181D7FDA0
		private InputDevice TryGetDeviceByRemoteId(int remoteDeviceId, int senderIndex); // 0x0000000181D80FD0-0x0000000181D81000
		public void RemoveRemoteDevices(int participantId); // 0x0000000181D7FE60-0x0000000181D7FFE0
		private static byte[] SerializeData<TData>(TData data);
		private static TData DeserializeData<TData>(byte[] data);
	}
}
