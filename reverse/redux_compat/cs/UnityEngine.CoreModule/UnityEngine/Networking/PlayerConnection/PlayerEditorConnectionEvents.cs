/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Events;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Networking.PlayerConnection
{
	[Serializable]
	internal class PlayerEditorConnectionEvents // TypeDefIndex: 8177
	{
		// Fields
		[SerializeField]
		private List<MessageTypeSubscribers> m_MessageTypeSubscribers; // 0x10
		private Dictionary<Guid, MessageTypeSubscribers> m_SubscriberLookup; // 0x18
		[SerializeField]
		public ConnectionChangeEvent connectionEvent; // 0x20
		[SerializeField]
		public ConnectionChangeEvent disconnectionEvent; // 0x28
	
		// Properties
		public IReadOnlyList<MessageTypeSubscribers> messageTypeSubscribers { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		[Serializable]
		public class MessageEvent : UnityEvent<MessageEventArgs> // TypeDefIndex: 8178
		{
			// Constructors
			public MessageEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class ConnectionChangeEvent : UnityEvent<int> // TypeDefIndex: 8179
		{
			// Constructors
			public ConnectionChangeEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class MessageTypeSubscribers // TypeDefIndex: 8180
		{
			// Fields
			[SerializeField]
			private string m_messageTypeId; // 0x10
			public int subscriberCount; // 0x18
			public MessageEvent messageCallback; // 0x20
	
			// Properties
			public Guid MessageTypeId { get; set; } // 0x000000018224AB20-0x000000018224AB50 0x000000018224AB50-0x000000018224AB80
	
			// Constructors
			public MessageTypeSubscribers(); // 0x000000018224AAB0-0x000000018224AB20
		}
	
		// Constructors
		public PlayerEditorConnectionEvents(); // 0x000000018224D890-0x000000018224D970
	
		// Methods
		private void BuildLookup(); // 0x000000018224D360-0x000000018224D5F0
		public void InvokeMessageIdSubscribers(Guid messageId, byte[] data, int playerId); // 0x000000018224D5F0-0x000000018224D770
		public UnityEvent<MessageEventArgs> AddAndCreate(Guid messageId); // 0x000000018224D130-0x000000018224D360
		public void UnregisterManagedCallback(Guid messageId, UnityAction<MessageEventArgs> callback); // 0x000000018224D770-0x000000018224D890
	}
}
