/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Contexts
{
	[ComVisible(true)]
	public class Context // TypeDefIndex: 2915
	{
		// Fields
		private int domain_id; // 0x10
		private int context_id; // 0x14
		private UIntPtr static_data; // 0x18
		private UIntPtr data; // 0x20
		[ContextStatic]
		private static object[] local_slots; // 0x00
		private static IMessageSink default_server_context_sink; // 0x08
		private IMessageSink server_context_sink_chain; // 0x28
		private IMessageSink client_context_sink_chain; // 0x30
		private List<IContextProperty> context_properties; // 0x38
		private static int global_count; // 0x10
		private LocalDataStoreHolder _localDataStore; // 0x40
		private static LocalDataStoreMgr _localDataStoreMgr; // 0x18
		private static DynamicPropertyCollection global_dynamic_properties; // 0x20
		private DynamicPropertyCollection context_dynamic_properties; // 0x48
		private ContextCallbackObject callback_object; // 0x50
	
		// Properties
		public static Context DefaultContext { get; } // 0x00000001814B8C70-0x00000001814B8C80 
		public virtual int ContextID { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public virtual IContextProperty[] ContextProperties { get; } // 0x00000001814B8C10-0x00000001814B8C70 
		internal bool IsDefaultContext { get; } // 0x00000001814B8E10-0x00000001814B8E20 
		internal bool NeedsContextSink { get; } // 0x00000001814B8FA0-0x00000001814B9030 
		internal static bool HasGlobalDynamicSinks { get; } // 0x00000001814B8DB0-0x00000001814B8E10 
		internal bool HasDynamicSinks { get; } // 0x00000001814B8C80-0x00000001814B8CA0 
		internal bool HasExitSinks { get; } // 0x00000001814B8CA0-0x00000001814B8DB0 
		private LocalDataStore MyLocalStore { get; } // 0x00000001814B8E20-0x00000001814B8FA0 
	
		// Constructors
		public Context(); // 0x00000001814B8B90-0x00000001814B8C10
		static Context(); // 0x00000001814B8B10-0x00000001814B8B90
	
		// Methods
		private static void RegisterContext(Context ctx); // 0x00000001814B84A0-0x00000001814B84B0
		private static void ReleaseContext(Context ctx); // 0x00000001814B8690-0x00000001814B86A0
		~Context(); // 0x00000001814B7A60-0x00000001814B7B00
		public static bool RegisterDynamicProperty(IDynamicProperty prop, ContextBoundObject obj, Context ctx); // 0x00000001814B84B0-0x00000001814B8690
		public static bool UnregisterDynamicProperty(string name, ContextBoundObject obj, Context ctx); // 0x00000001814B8930-0x00000001814B8B10
		private static DynamicPropertyCollection GetDynamicPropertyCollection(ContextBoundObject obj, Context ctx); // 0x00000001814B7EB0-0x00000001814B8040
		internal static void NotifyGlobalDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async); // 0x00000001814B83D0-0x00000001814B84A0
		internal void NotifyDynamicSinks(bool start, IMessage req_msg, bool client_site, bool async); // 0x00000001814B8350-0x00000001814B83D0
		public virtual IContextProperty GetProperty(string name); // 0x00000001814B80B0-0x00000001814B81F0
		public virtual void SetProperty(IContextProperty prop); // 0x00000001814B86F0-0x00000001814B88D0
		public virtual void Freeze(); // 0x00000001814B7B70-0x00000001814B7D00
		public override string ToString(); // 0x00000001814B88E0-0x00000001814B8930
		internal IMessageSink GetServerContextSinkChain(); // 0x00000001814B81F0-0x00000001814B8350
		internal IMessageSink GetClientContextSinkChain(); // 0x00000001814B7D00-0x00000001814B7E70
		internal IMessageSink CreateServerObjectSinkChain(MarshalByRefObject obj, bool forceInternalExecute); // 0x00000001814B77A0-0x00000001814B78F0
		internal IMessageSink CreateEnvoySink(MarshalByRefObject serverObject); // 0x00000001814B6F40-0x00000001814B70B0
		internal static Context SwitchToContext(Context newContext); // 0x00000001814B88D0-0x00000001814B88E0
		internal static Context CreateNewContext(IConstructionCallMessage msg); // 0x00000001814B70B0-0x00000001814B77A0
		public void DoCallBack(CrossContextDelegate deleg); // 0x00000001814B78F0-0x00000001814B7A60
		public static LocalDataStoreSlot AllocateDataSlot(); // 0x00000001814B6E70-0x00000001814B6ED0
		public static LocalDataStoreSlot AllocateNamedDataSlot(string name); // 0x00000001814B6ED0-0x00000001814B6F40
		public static void FreeNamedDataSlot(string name); // 0x00000001814B7B00-0x00000001814B7B70
		public static LocalDataStoreSlot GetNamedDataSlot(string name); // 0x00000001814B8040-0x00000001814B80B0
		public static object GetData(LocalDataStoreSlot slot); // 0x00000001814B7E70-0x00000001814B7EB0
		public static void SetData(LocalDataStoreSlot slot, object data); // 0x00000001814B86A0-0x00000001814B86F0
	}
}
