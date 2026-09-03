/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal interface IPlayerEditorConnectionNative // TypeDefIndex: 7679
	{
		// Methods
		void Initialize();
		void DisconnectAll();
		void SendMessage(Guid messageId, byte[] data, int playerId);
		bool TrySendMessage(Guid messageId, byte[] data, int playerId);
		void Poll();
		void RegisterInternal(Guid messageId);
		void UnregisterInternal(Guid messageId);
		bool IsConnected();
	}
}
