/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Activation
{
	internal class ActivationServices // TypeDefIndex: 2946
	{
		// Fields
		private static IActivator _constructionActivator; // 0x00
	
		// Properties
		private static IActivator ConstructionActivator { get; } // 0x00000001814CF490-0x00000001814CF530 
	
		// Methods
		public static IMessage Activate(RemotingProxy proxy, ConstructionCall ctorCall); // 0x00000001814CE4E0-0x00000001814CE6A0
		public static IMessage RemoteActivate(IConstructionCallMessage ctorCall); // 0x00000001814CF3D0-0x00000001814CF490
		public static ConstructionCall CreateConstructionCall(Type type, string activationUrl, object[] activationAttributes); // 0x00000001814CE6B0-0x00000001814CEF90
		public static IMessage CreateInstanceFromMessage(IConstructionCallMessage ctorCall); // 0x00000001814CEF90-0x00000001814CF2A0
		public static object CreateProxyForType(Type type); // 0x00000001814CF2A0-0x00000001814CF3C0
		public static object AllocateUninitializedClassInstance(Type type); // 0x00000001814CE6A0-0x00000001814CE6B0
		public static void EnableProxyActivation(Type type, bool enable); // 0x00000001814CF3C0-0x00000001814CF3D0
	}
}
