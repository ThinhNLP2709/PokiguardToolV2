/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Networking.PlayerConnection
{
	[Serializable]
	public class PlayerConnection : ScriptableObject, IEditorPlayerConnection // TypeDefIndex: 8175
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static IPlayerEditorConnectionNative connectionNative; // 0x00
		[SerializeField]
		private PlayerEditorConnectionEvents m_PlayerEditorConnectionEvents; // 0x18
		[SerializeField]
		private List<int> m_connectedPlayers; // 0x20
		private bool m_IsInitilized; // 0x28
		[AutoStaticsCleanupOnCodeReload]
		private static PlayerConnection s_Instance; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		public static PlayerConnection instance { get; } // 0x000000018224CF90-0x000000018224D0D0 
		public bool isConnected { get; } // 0x000000018224D0D0-0x000000018224D130 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 8176
		{
			// Fields
			public bool msgReceived; // 0x10
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BlockUntilRecvMsg_b__0(MessageEventArgs args); // 0x000000018030F220-0x000000018030F230
		}
	
		// Constructors
		public PlayerConnection(); // 0x000000018224CE20-0x000000018224CF90
		static PlayerConnection(); // 0x000000018224CD00-0x000000018224CE20
	
		// Methods
		private static PlayerConnection CreateInstance(); // 0x000000018224BAE0-0x000000018224BBA0
		public void OnEnable(); // 0x000000018224C1B0-0x000000018224C210
		private IPlayerEditorConnectionNative GetConnectionNativeApi(); // 0x000000018224BCB0-0x000000018224BD40
		public void Register(Guid messageId, UnityAction<MessageEventArgs> callback); // 0x000000018224C3B0-0x000000018224C610
		public void Unregister(Guid messageId, UnityAction<MessageEventArgs> callback); // 0x000000018224CA30-0x000000018224CC50
		private bool HasSubscriber(Guid messageId); // 0x000000018224BD40-0x000000018224BF30
		public void RegisterConnection(UnityAction<int> callback); // 0x000000018224C210-0x000000018224C350
		public void RegisterDisconnection(UnityAction<int> callback); // 0x000000018224C350-0x000000018224C3B0
		public void UnregisterConnection(UnityAction<int> callback); // 0x000000018224C9D0-0x000000018224CA00
		public void UnregisterDisconnection(UnityAction<int> callback); // 0x000000018224CA00-0x000000018224CA30
		public void Send(Guid messageId, byte[] data); // 0x000000018224C610-0x000000018224C7F0
		public bool TrySend(Guid messageId, byte[] data); // 0x000000018224C7F0-0x000000018224C9D0
		public bool BlockUntilRecvMsg(Guid messageId, int timeout); // 0x000000018224B720-0x000000018224B9F0
		public void DisconnectAll(); // 0x000000018224BBA0-0x000000018224BC00
		[RequiredByNativeCode]
		private static void MessageCallbackInternal(IntPtr data, ulong size, ulong guid, string messageId); // 0x000000018224BF30-0x000000018224C1B0
		[RequiredByNativeCode]
		private static void ConnectedCallbackInternal(int playerId); // 0x000000018224B9F0-0x000000018224BAE0
		[RequiredByNativeCode]
		private static void DisconnectedCallback(int playerId); // 0x000000018224BC00-0x000000018224BCB0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018224CC50-0x000000018224CD00
	}
}
