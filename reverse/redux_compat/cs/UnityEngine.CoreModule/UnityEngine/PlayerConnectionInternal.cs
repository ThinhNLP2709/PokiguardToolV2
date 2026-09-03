/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/PlayerConnection/PlayerConnectionInternal.bindings.h")]
	internal class PlayerConnectionInternal : IPlayerEditorConnectionNative // TypeDefIndex: 7680
	{
		// Constructors
		public PlayerConnectionInternal(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		void IPlayerEditorConnectionNative.SendMessage(Guid messageId, byte[] data, int playerId); // 0x00000001821F50F0-0x00000001821F51E0
		bool IPlayerEditorConnectionNative.TrySendMessage(Guid messageId, byte[] data, int playerId); // 0x00000001821F51E0-0x00000001821F52D0
		void IPlayerEditorConnectionNative.Poll(); // 0x00000001821F4A70-0x00000001821F4AA0
		void IPlayerEditorConnectionNative.RegisterInternal(Guid messageId); // 0x00000001821F50A0-0x00000001821F50F0
		void IPlayerEditorConnectionNative.UnregisterInternal(Guid messageId); // 0x00000001821F52D0-0x00000001821F5320
		void IPlayerEditorConnectionNative.Initialize(); // 0x00000001821F4A10-0x00000001821F4A40
		bool IPlayerEditorConnectionNative.IsConnected(); // 0x00000001821F4A40-0x00000001821F4A70
		void IPlayerEditorConnectionNative.DisconnectAll(); // 0x00000001821F49E0-0x00000001821F4A10
		[FreeFunction("PlayerConnection_Bindings::IsConnected")]
		private static bool IsConnected(); // 0x00000001821F4A40-0x00000001821F4A70
		[FreeFunction("PlayerConnection_Bindings::Initialize")]
		private static void Initialize(); // 0x00000001821F4A10-0x00000001821F4A40
		[FreeFunction("PlayerConnection_Bindings::RegisterInternal")]
		private static void RegisterInternal(string messageId); // 0x00000001821F4AE0-0x00000001821F4C20
		[FreeFunction("PlayerConnection_Bindings::UnregisterInternal")]
		private static void UnregisterInternal(string messageId); // 0x00000001821F5360-0x00000001821F54A0
		[FreeFunction("PlayerConnection_Bindings::SendMessage")]
		private static void SendMessage(string messageId, byte[] data, int playerId); // 0x00000001821F4C80-0x00000001821F4E60
		[FreeFunction("PlayerConnection_Bindings::TrySendMessage")]
		private static bool TrySendMessage(string messageId, byte[] data, int playerId); // 0x00000001821F4EC0-0x00000001821F50A0
		[FreeFunction("PlayerConnection_Bindings::PollInternal")]
		private static void PollInternal(); // 0x00000001821F4A70-0x00000001821F4AA0
		[FreeFunction("PlayerConnection_Bindings::DisconnectAll")]
		private static void DisconnectAll(); // 0x00000001821F49E0-0x00000001821F4A10
		private static void RegisterInternal_Injected(ref ManagedSpanWrapper messageId); // 0x00000001821F4AA0-0x00000001821F4AE0
		private static void UnregisterInternal_Injected(ref ManagedSpanWrapper messageId); // 0x00000001821F5320-0x00000001821F5360
		private static void SendMessage_Injected(ref ManagedSpanWrapper messageId, ref ManagedSpanWrapper data, int playerId); // 0x00000001821F4C20-0x00000001821F4C80
		private static bool TrySendMessage_Injected(ref ManagedSpanWrapper messageId, ref ManagedSpanWrapper data, int playerId); // 0x00000001821F4E60-0x00000001821F4EC0
	}
}
