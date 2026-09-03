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
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal abstract class ServerIdentity : Identity // TypeDefIndex: 2889
	{
		// Fields
		protected Type _objectType; // 0x48
		protected MarshalByRefObject _serverObject; // 0x50
		protected IMessageSink _serverSink; // 0x58
		protected Context _context; // 0x60
		protected Lease _lease; // 0x68
	
		// Properties
		public Type ObjectType { get; } // 0x00000001803272B0-0x00000001803272C0 
		public Lease Lease { get; } // 0x0000000180316960-0x0000000180316970 
		public Context Context { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		public ServerIdentity(string objectUri, Context context, Type objectType); // 0x00000001814C6C90-0x00000001814C6D00
	
		// Methods
		public void StartTrackingLifetime(ILease lease); // 0x00000001814C6950-0x00000001814C6C90
		public virtual void OnLifetimeExpired(); // 0x00000001814C6940-0x00000001814C6950
		public override ObjRef CreateObjRef(Type requestedType); // 0x00000001814C66B0-0x00000001814C68A0
		public void AttachServerObject(MarshalByRefObject serverObject, Context context); // 0x00000001814C6620-0x00000001814C66B0
		public abstract IMessage SyncObjectProcessMessage(IMessage msg);
		public abstract IMessageCtrl AsyncObjectProcessMessage(IMessage msg, IMessageSink replySink);
		protected void DisposeServerObject(); // 0x00000001814C68A0-0x00000001814C6940
	}
}
