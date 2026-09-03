/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal abstract class Identity // TypeDefIndex: 2877
	{
		// Fields
		protected string _objectUri; // 0x10
		protected IMessageSink _channelSink; // 0x18
		protected IMessageSink _envoySink; // 0x20
		private DynamicPropertyCollection _clientDynamicProperties; // 0x28
		private DynamicPropertyCollection _serverDynamicProperties; // 0x30
		protected ObjRef _objRef; // 0x38
		private bool _disposed; // 0x40
	
		// Properties
		public IMessageSink ChannelSink { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public IMessageSink EnvoySink { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string ObjectUri { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public bool IsConnected { get; } // 0x00000001814B9A50-0x00000001814B9A60 
		public bool Disposed { get; set; } // 0x00000001803B1170-0x00000001803B1180 0x000000018042B340-0x000000018042B350
		public DynamicPropertyCollection ClientDynamicProperties { get; } // 0x00000001814B99C0-0x00000001814B9A30 
		public bool HasServerDynamicSinks { get; } // 0x00000001814B9A30-0x00000001814B9A50 
	
		// Constructors
		public Identity(string objectUri); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public abstract ObjRef CreateObjRef(Type requestedType);
		public void NotifyClientDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async); // 0x00000001814B98C0-0x00000001814B9940
		public void NotifyServerDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async); // 0x00000001814B9940-0x00000001814B99C0
	}
}
