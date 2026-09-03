/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

internal class RenderGraphCompilationCache // TypeDefIndex: 5302
{
	// Fields
	private DynamicArray<HashEntry<CompilerContextData>> m_NativeHashEntries; // 0x10
	private Stack<CompilerContextData> m_NativeCompiledGraphPool; // 0x18
	private static readonly DynamicArray<HashEntry<CompilerContextData>> s_NativeEntryComparer; // 0x00
	private const int k_CachedGraphCount = 20; // Metadata: 0x00661470

	// Nested types
	private struct HashEntry<T> // TypeDefIndex: 5303
	{
		// Fields
		public int hash;
		public int lastFrameUsed;
		public T compiledGraph;
	}

	// Constructors
	public RenderGraphCompilationCache(); // 0x0000000181E275D0-0x0000000181E27710
	static RenderGraphCompilationCache(); // 0x0000000181E27540-0x0000000181E275D0

	// Methods
	private static int HashEntryComparer<T>(HashEntry<T> a, HashEntry<T> b);
	private static int FindHashEntryIndex(DynamicArray<HashEntry<CompilerContextData>> hashEntries, int hash); // 0x0000000181E27240-0x0000000181E272B0
	private bool GetCompilationCache(int hash, int frameIndex, out CompilerContextData outGraph, DynamicArray<HashEntry<CompilerContextData>> hashEntries, Stack<CompilerContextData> pool, DynamicArray<HashEntry<CompilerContextData>> comparer); // 0x0000000181E27370-0x0000000181E27540
	public bool GetCompilationCache(int hash, int frameIndex, out CompilerContextData outGraph); // 0x0000000181E272B0-0x0000000181E27370
	public void Clear(); // 0x0000000181E27180-0x0000000181E27240
	public void Cleanup(); // 0x0000000181E27090-0x0000000181E27180
}

