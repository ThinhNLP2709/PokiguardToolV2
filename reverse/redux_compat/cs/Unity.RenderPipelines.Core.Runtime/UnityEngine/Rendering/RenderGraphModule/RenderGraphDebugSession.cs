/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal abstract class RenderGraphDebugSession : IDisposable // TypeDefIndex: 5899
	{
		// Fields
		[CompilerGenerated]
		private string _connectionName_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly DebugDataContainer _debugDataContainer_k__BackingField; // 0x18
		[CompilerGenerated]
		private static Action onRegisteredGraphsChanged; // 0x00
		[CompilerGenerated]
		private static Action<string, EntityId> onDebugDataUpdated; // 0x08
		private static RenderGraphDebugSession s_CurrentDebugSession; // 0x10
		public static readonly List<string> s_EmptyRegisteredGraphs; // 0x18
		public static readonly List<RenderGraph.DebugExecutionItem> s_EmptyExecutions; // 0x20
	
		// Properties
		public abstract bool isActive { get; }
		public string connectionName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		private DebugDataContainer debugDataContainer { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public static bool hasActiveDebugSession { get; } // 0x0000000181EC5830-0x0000000181EC58A0 
		public static RenderGraphDebugSession currentDebugSession { get; } // 0x0000000181EC57E0-0x0000000181EC5830 
	
		// Events
		public static event Action onRegisteredGraphsChanged {
			add; // 0x0000000181EC5710-0x0000000181EC57E0
			remove; // 0x0000000181EC5990-0x0000000181EC5A60
		}
		public static event Action<string, EntityId> onDebugDataUpdated {
			add; // 0x0000000181EC5620-0x0000000181EC5710
			remove; // 0x0000000181EC58A0-0x0000000181EC5990
		}
	
		// Nested types
		protected class DebugDataContainer // TypeDefIndex: 5900
		{
			// Fields
			private readonly Dictionary<string, Dictionary<EntityId, RenderGraph.DebugData>> m_Container; // 0x10
	
			// Constructors
			public DebugDataContainer(); // 0x0000000181EBDC90-0x0000000181EBDD10
	
			// Methods
			public bool AddGraph(string graphName); // 0x0000000181EBD2A0-0x0000000181EBD380
			public bool RemoveGraph(string graphName); // 0x0000000181EBDB80-0x0000000181EBDBE0
			public bool AddExecution(string graphName, EntityId executionId, string executionName); // 0x0000000181EBD0C0-0x0000000181EBD2A0
			public List<string> GetRenderGraphs(); // 0x0000000181EBD8C0-0x0000000181EBD950
			public List<RenderGraph.DebugExecutionItem> GetExecutions(string graphName); // 0x0000000181EBD610-0x0000000181EBD8C0
			public RenderGraph.DebugData GetDebugData(string renderGraph, EntityId executionId); // 0x0000000181EBD500-0x0000000181EBD610
			public void SetDebugData(string renderGraph, EntityId executionId, RenderGraph.DebugData data); // 0x0000000181EBDBE0-0x0000000181EBDC90
			public void DeleteExecutionIds(string renderGraph, List<EntityId> executionIds); // 0x0000000181EBD3A0-0x0000000181EBD500
			public void Clear(); // 0x0000000181EBD380-0x0000000181EBD3A0
			public void Invalidate(); // 0x0000000181EBD950-0x0000000181EBDB80
		}
	
		// Constructors
		protected RenderGraphDebugSession(); // 0x0000000181EC5260-0x0000000181EC5620
		static RenderGraphDebugSession(); // 0x0000000181EC5170-0x0000000181EC5260
	
		// Methods
		protected void RegisterGraph(string graphName); // 0x0000000181EC4DA0-0x0000000181EC4ED0
		protected void UnregisterGraph(string graphName); // 0x0000000181EC50B0-0x0000000181EC5170
		protected void RegisterExecution(string graphName, EntityId executionId, string executionName); // 0x0000000181EC4B60-0x0000000181EC4DA0
		public virtual void Dispose(); // 0x0000000181EC4080-0x0000000181EC43C0
		protected void InvalidateData(); // 0x0000000181EC4750-0x0000000181EC4770
		public static void Create<TSession>()
			where TSession : RenderGraphDebugSession, new();
		internal static void Create(Type sessionType); // 0x0000000181EC3D90-0x0000000181EC3FD0
		public static void EndSession(); // 0x0000000181EC43C0-0x0000000181EC4460
		public static List<string> GetRegisteredGraphs(); // 0x0000000181EC4650-0x0000000181EC4750
		public static List<RenderGraph.DebugExecutionItem> GetExecutions(string graphName); // 0x0000000181EC45D0-0x0000000181EC4650
		public static RenderGraph.DebugData GetDebugData(string renderGraph, EntityId executionId); // 0x0000000181EC4460-0x0000000181EC45D0
		public static void SetDebugData(string renderGraph, EntityId executionId, RenderGraph.DebugData data); // 0x0000000181EC4ED0-0x0000000181EC50B0
		public static void DeleteExecutionIds(string renderGraph, List<EntityId> executionIds); // 0x0000000181EC3FD0-0x0000000181EC4080
		protected void RegisterAllLocallyKnownGraphsAndExecutions(); // 0x0000000181EC4770-0x0000000181EC4B60
	}
}
