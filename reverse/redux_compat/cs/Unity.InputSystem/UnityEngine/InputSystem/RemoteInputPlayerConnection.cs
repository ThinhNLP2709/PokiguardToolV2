/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[Serializable]
	internal class RemoteInputPlayerConnection : ScriptableObject, IObserver<InputRemoting.Message>, IObservable<InputRemoting.Message> // TypeDefIndex: 6193
	{
		// Fields
		public static readonly Guid kNewDeviceMsg; // 0x00
		public static readonly Guid kNewLayoutMsg; // 0x10
		public static readonly Guid kNewEventsMsg; // 0x20
		public static readonly Guid kRemoveDeviceMsg; // 0x30
		public static readonly Guid kChangeUsagesMsg; // 0x40
		public static readonly Guid kStartSendingMsg; // 0x50
		public static readonly Guid kStopSendingMsg; // 0x60
		[SerializeField]
		private IEditorPlayerConnection m_Connection; // 0x18
		[NonSerialized]
		private Subscriber[] m_Subscribers; // 0x20
		[SerializeField]
		private int[] m_ConnectedIds; // 0x28
	
		// Nested types
		private class Subscriber : IDisposable // TypeDefIndex: 6194
		{
			// Fields
			public RemoteInputPlayerConnection owner; // 0x10
			public IObserver<InputRemoting.Message> observer; // 0x18
	
			// Constructors
			public Subscriber(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Dispose(); // 0x0000000181D88260-0x0000000181D882B0
		}
	
		// Constructors
		public RemoteInputPlayerConnection(); // 0x00000001805F5FD0-0x00000001805F5FE0
		static RemoteInputPlayerConnection(); // 0x0000000181D87C40-0x0000000181D87E30
	
		// Methods
		public void Bind(IEditorPlayerConnection connection, bool isConnected); // 0x0000000181D86CC0-0x0000000181D87490
		public IDisposable Subscribe(IObserver<InputRemoting.Message> observer); // 0x0000000181D87860-0x0000000181D87A70
		private void OnConnected(int id); // 0x0000000181D874A0-0x0000000181D87560
		private void OnDisconnected(int id); // 0x0000000181D87560-0x0000000181D87630
		private void OnNewDevice(MessageEventArgs args); // 0x0000000181D87630-0x0000000181D87640
		private void OnNewLayout(MessageEventArgs args); // 0x0000000181D87650-0x0000000181D87660
		private void OnNewEvents(MessageEventArgs args); // 0x0000000181D87640-0x0000000181D87650
		private void OnRemoveDevice(MessageEventArgs args); // 0x0000000181D87660-0x0000000181D87670
		private void OnChangeUsages(MessageEventArgs args); // 0x0000000181D87490-0x0000000181D874A0
		private void OnStartSending(MessageEventArgs args); // 0x0000000181D87670-0x0000000181D87680
		private void OnStopSending(MessageEventArgs args); // 0x0000000181D87680-0x0000000181D87690
		private void SendToSubscribers(InputRemoting.MessageType type, MessageEventArgs args); // 0x0000000181D87690-0x0000000181D87860
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnNext(InputRemoting.Message msg); // 0x0000000181D87A70-0x0000000181D87C40
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnError(Exception error); // 0x00000001802E76C0-0x00000001802E76D0
		void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnCompleted(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
