/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Events;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Networking.PlayerConnection
{
	public interface IEditorPlayerConnection // TypeDefIndex: 8174
	{
		// Methods
		void Register(Guid messageId, UnityAction<MessageEventArgs> callback);
		void RegisterConnection(UnityAction<int> callback);
		void RegisterDisconnection(UnityAction<int> callback);
		void Send(Guid messageId, byte[] data);
	}
}
