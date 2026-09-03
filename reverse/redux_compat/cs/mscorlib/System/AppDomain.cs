/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public sealed class AppDomain : MarshalByRefObject // TypeDefIndex: 2441
	{
		// Fields
		private IntPtr _mono_app_domain; // 0x18
		private static string _process_guid; // 0x00
		[ThreadStatic]
		private static Dictionary<string, object> type_resolve_in_progress; // 0x80000000
		[ThreadStatic]
		private static Dictionary<string, object> assembly_resolve_in_progress; // 0x80000008
		[ThreadStatic]
		private static Dictionary<string, object> assembly_resolve_in_progress_refonly; // 0x80000010
		private object _evidence; // 0x20
		private object _granted; // 0x28
		private int _principalPolicy; // 0x30
		[CompilerGenerated]
		private AssemblyLoadEventHandler AssemblyLoad; // 0x38
		[CompilerGenerated]
		private ResolveEventHandler AssemblyResolve; // 0x40
		[CompilerGenerated]
		private EventHandler DomainUnload; // 0x48
		[CompilerGenerated]
		private EventHandler ProcessExit; // 0x50
		[CompilerGenerated]
		private ResolveEventHandler ResourceResolve; // 0x58
		[CompilerGenerated]
		private ResolveEventHandler TypeResolve; // 0x60
		[CompilerGenerated]
		private UnhandledExceptionEventHandler UnhandledException; // 0x68
		[CompilerGenerated]
		private EventHandler<FirstChanceExceptionEventArgs> FirstChanceException; // 0x70
		private object _domain_manager; // 0x78
		[CompilerGenerated]
		private ResolveEventHandler ReflectionOnlyAssemblyResolve; // 0x80
		private object _activation; // 0x88
		private object _applicationIdentity; // 0x90
		private List<string> compatibility_switch; // 0x98
	
		// Properties
		internal AppDomainSetup SetupInformationNoCopy { get; } // 0x000000018164BBF0-0x000000018164BC00 
		public string BaseDirectory { get; } // 0x000000018164BC00-0x000000018164BC30 
		public static AppDomain CurrentDomain { get; } // 0x000000018164BBD0-0x000000018164BBE0 
		[MonoTODO]
		public bool IsHomogenous { get; } // 0x00000001802E7990-0x00000001802E79A0 
		[MonoTODO]
		public bool IsFullyTrusted { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Events
		public event EventHandler DomainUnload {
			add; // 0x000000018164BA90-0x000000018164BB30
			remove; // 0x000000018164BC30-0x000000018164BCD0
		}
		public event UnhandledExceptionEventHandler UnhandledException {
			add; // 0x000000018164BB30-0x000000018164BBD0
			remove; // 0x000000018164BCD0-0x000000018164BD70
		}
	
		// Constructors
		private AppDomain(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		[Intrinsic]
		internal static bool IsAppXModel(); // 0x00000001802E7840-0x00000001802E7850
		private AppDomainSetup getSetup(); // 0x000000018164BBF0-0x000000018164BC00
		private string getFriendlyName(); // 0x000000018164BA80-0x000000018164BA90
		private static AppDomain getCurDomain(); // 0x000000018164BBD0-0x000000018164BBE0
		private Assembly[] GetAssemblies(bool refOnly); // 0x000000018164B340-0x000000018164B350
		public Assembly[] GetAssemblies(); // 0x000000018164B330-0x000000018164B340
		public object GetData(string name); // 0x000000018164B350-0x000000018164B360
		public override object InitializeLifetimeService(); // 0x00000001802E7860-0x00000001802E7870
		internal Assembly LoadAssembly(string assemblyRef, Evidence securityEvidence, bool refOnly, ref StackCrawlMark stackMark); // 0x000000018164B6E0-0x000000018164B6F0
		public Assembly Load(string assemblyString); // 0x000000018164B810-0x000000018164B940
		internal Assembly Load(string assemblyString, Evidence assemblySecurity, bool refonly, ref StackCrawlMark stackMark); // 0x000000018164B6F0-0x000000018164B810
		private static AppDomain InternalSetDomainByID(int domain_id); // 0x000000018164B500-0x000000018164B510
		private static AppDomain InternalSetDomain(AppDomain context); // 0x000000018164B510-0x000000018164B520
		internal static void InternalPushDomainRefByID(int domain_id); // 0x000000018164B4E0-0x000000018164B4F0
		internal static void InternalPopDomainRef(); // 0x000000018164B4D0-0x000000018164B4E0
		internal static Context InternalSetContext(Context context); // 0x000000018164B4F0-0x000000018164B500
		internal static Context InternalGetContext(); // 0x000000018164B4B0-0x000000018164B4C0
		internal static Context InternalGetDefaultContext(); // 0x000000018164B4B0-0x000000018164B4C0
		internal static string InternalGetProcessGuid(string newguid); // 0x000000018164B4C0-0x000000018164B4D0
		internal static object InvokeInDomainByID(int domain_id, MethodInfo method, object obj, object[] args); // 0x000000018164B520-0x000000018164B6C0
		internal static string GetProcessGuid(); // 0x000000018164B420-0x000000018164B4B0
		private static bool InternalIsFinalizingForUnload(int domain_id); // 0x0000000181449F80-0x0000000181449F90
		public bool IsFinalizingForUnload(); // 0x000000018164B6C0-0x000000018164B6E0
		private int getDomainID(); // 0x000000018164BBE0-0x000000018164BBF0
		public override string ToString(); // 0x000000018164BA80-0x000000018164BA90
		private void DoAssemblyLoad(Assembly assembly); // 0x000000018164AB70-0x000000018164AC00
		private Assembly DoAssemblyResolve(string name, Assembly requestingAssembly, bool refonly); // 0x000000018164AC00-0x000000018164AFA0
		internal Assembly DoTypeResolve(string name); // 0x000000018164AFD0-0x000000018164B330
		private void DoDomainUnload(); // 0x000000018164AFA0-0x000000018164AFD0
		internal byte[] GetMarshalledDomainObjRef(); // 0x000000018164B360-0x000000018164B420
		internal void ProcessMessageInDomain(byte[] arrRequest, CADMethodCallMessage cadMsg, out byte[] arrResponse, out CADMethodReturnMessage cadMrm); // 0x000000018164B940-0x000000018164BA80
	}
}
