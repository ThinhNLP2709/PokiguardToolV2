/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Proxies
{
	[ComVisible(true)]
	public abstract class RealProxy // TypeDefIndex: 2905
	{
		// Fields
		private Type class_to_proxy; // 0x10
		internal Context _targetContext; // 0x18
		internal MarshalByRefObject _server; // 0x20
		private int _targetDomainId; // 0x28
		internal string _targetUri; // 0x30
		internal Identity _objectIdentity; // 0x38
		private object _objTP; // 0x40
		private object _stubData; // 0x48
	
		// Properties
		internal Identity ObjectIdentity { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		protected RealProxy(); // 0x00000001814BE700-0x00000001814BE710
		protected RealProxy(Type classToProxy); // 0x00000001814BE820-0x00000001814BE8D0
		internal RealProxy(Type classToProxy, ClientIdentity identity); // 0x00000001814BE630-0x00000001814BE700
		protected RealProxy(Type classToProxy, IntPtr stub, object stubData); // 0x00000001814BE710-0x00000001814BE820
	
		// Methods
		private static Type InternalGetProxyType(object transparentProxy); // 0x00000001814BD750-0x00000001814BD760
		public Type GetProxiedType(); // 0x00000001814BD5B0-0x00000001814BD620
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814BD520-0x00000001814BD5B0
		public abstract IMessage Invoke(IMessage msg);
		internal static object PrivateInvoke(RealProxy rp, IMessage msg, out Exception exc, out object[] out_args); // 0x00000001814BD770-0x00000001814BE010
		internal virtual object InternalGetTransparentProxy(string className); // 0x00000001814BD760-0x00000001814BD770
		public virtual object GetTransparentProxy(); // 0x00000001814BD620-0x00000001814BD750
		protected void AttachServer(MarshalByRefObject s); // 0x000000018033E830-0x000000018033E840
		internal void SetTargetDomain(int domainId); // 0x0000000180378100-0x0000000180378110
		internal object GetAppDomainTarget(); // 0x00000001814BD3F0-0x00000001814BD520
		private static object[] ProcessResponse(IMethodReturnMessage mrm, MonoMethodMessage call); // 0x00000001814BE010-0x00000001814BE630
	}
}
