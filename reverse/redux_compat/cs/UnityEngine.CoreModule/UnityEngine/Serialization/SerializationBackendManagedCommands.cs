/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Serialization
{
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/WriteManagedReferenceToBuffer.h")]
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/WriteUnityObjectToBuffer.h")]
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/ReadManagedReferenceFromBuffer.h")]
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/GatherDictionaryEntries.h")]
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/DictionaryFieldUniqueIdentifierStack.h")]
	[NativeHeader("Runtime/Mono/SerializationBackend_DirectMemoryAccess/ReadUnityObjectFromBuffer.h")]
	[NoAutoStaticsCleanup]
	internal static class SerializationBackendManagedCommands // TypeDefIndex: 7944
	{
		// Fields
		private static readonly IntPtr s_writeEntityIdToBuffer; // 0x00
		private static readonly IntPtr s_readEntityIdFromBuffer; // 0x08
		private static readonly IntPtr s_writeEntityIdsArrayToBuffer; // 0x10
		private static readonly IntPtr s_writeEntityIdsToBuffer; // 0x18
		private static readonly IntPtr s_writeUnityObjectEntityIdsToBuffer; // 0x20
		private static readonly IntPtr s_readUnityObjectsIntoFields; // 0x28
		private static readonly IntPtr s_readUnityObjectsArrayIntoElements; // 0x30
		private static readonly IntPtr s_readEntityIdsArrayIntoElements; // 0x38
		private static readonly IntPtr s_readEntityIdsIntoFields; // 0x40
		[NoAutoStaticsCleanup]
		[ThreadStatic]
		private static Encoder s_Utf8Encoder; // 0x80000000
		private static readonly ConcurrentDictionary<Type, Type> s_ListTypeCache; // 0x48
	
		// Nested types
		internal struct BufferDataStager // TypeDefIndex: 7945
		{
			// Fields
			private readonly unsafe NativeBufferContext* m_Ctx; // 0x00
			private int m_Staged; // 0x08
	
			// Properties
			public unsafe byte* StagingPtr { get; } // 0x000000018222AF80-0x000000018222AFA0 
			public int StagingRoom { get; } // 0x000000018222AFA0-0x000000018222AFC0 
	
			// Constructors
			public unsafe BufferDataStager(NativeBufferContext* ctx); // 0x000000018222AF70-0x000000018222AF80
	
			// Methods
			public unsafe byte* Reserve(int n); // 0x000000018222ACC0-0x000000018222ADB0
			public unsafe byte* TryReserve(int n); // 0x000000018222AEE0-0x000000018222AF70
			public void Stage(int n); // 0x000000018222AE40-0x000000018222AEE0
			public void FlushStaged(int minNextWrite); // 0x00000001821FE340-0x00000001821FE840
			public unsafe void Bulk(byte* src, int n); // 0x000000018222AC10-0x000000018222ACC0
			public void ResyncWithNativeBuffer(); // 0x000000018222ADB0-0x000000018222AE40
		}
	
		private sealed class ListLayout // TypeDefIndex: 7946
		{
			// Fields
			public byte[] _items; // 0x10
			public int _size; // 0x18
		}
	
		private sealed class ObjectWrapper // TypeDefIndex: 7947
		{
			// Fields
			public byte Data; // 0x10
		}
	
		internal struct ManagedCommandsBlockCommandHeader // TypeDefIndex: 7948
		{
			// Fields
			public IntPtr func; // 0x00
			public uint commandSize; // 0x08
			public uint entryBufferSize; // 0x0C
			public uint totalPayloadSize; // 0x10
		}
	
		internal enum SerializationCallbackMethod // TypeDefIndex: 7949
		{
			OnBeforeSerialize = 0,
			OnAfterDeserialize = 1
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 7950
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Type, Type> __9__90_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001822543E0-0x0000000182254450
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Type _GetCachedListType_b__90_0(Type t); // 0x0000000182253C40-0x0000000182253D30
		}
	
		// Constructors
		static SerializationBackendManagedCommands(); // 0x000000018221CAC0-0x000000018221CD70
	
		// Methods
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static void WriteManagedReferenceToBuffer(IntPtr transferState, IntPtr outputPtr); // 0x000000018221CA70-0x000000018221CAC0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static object GetDictionaryEntriesForGather(IntPtr dictObjRaw, IntPtr transferState, IntPtr templatePtr, IntPtr indices, int indexCount); // 0x000000018221A250-0x000000018221A2C0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static object ReadUnityObjectFromBuffer(IntPtr resolverHandle, IntPtr inputPtr, IntPtr klass, int flags, IntPtr field, IntPtr fieldParent); // 0x000000018221C020-0x000000018221C090
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static void ReadManagedReferenceFromBuffer(IntPtr transferState, IntPtr instance, int fieldOffset, IntPtr inputPtr); // 0x000000018221BFB0-0x000000018221C020
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetWriteEntityIdToBufferFunctionPointer(); // 0x000000018221A560-0x000000018221A590
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetReadEntityIdFromBufferFunctionPointer(); // 0x000000018221A470-0x000000018221A4A0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetWriteEntityIdsArrayToBufferFunctionPointer(); // 0x000000018221A590-0x000000018221A5C0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetWriteEntityIdsToBufferFunctionPointer(); // 0x000000018221A5C0-0x000000018221A5F0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetWriteUnityObjectEntityIdsToBufferFunctionPointer(); // 0x000000018221A5F0-0x000000018221A620
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetReadUnityObjectsIntoFieldsFunctionPointer(); // 0x000000018221A530-0x000000018221A560
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetReadUnityObjectsArrayIntoElementsFunctionPointer(); // 0x000000018221A500-0x000000018221A530
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetReadEntityIdsArrayIntoElementsFunctionPointer(); // 0x000000018221A4A0-0x000000018221A4D0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		private static IntPtr GetReadEntityIdsIntoFieldsFunctionPointer(); // 0x000000018221A4D0-0x000000018221A500
		[NativeMethod(Name = "PushDictionaryFieldUniqueIdentifierStackFrame", IsFreeFunction = true, IsThreadSafe = true)]
		private static bool PushDictionaryFUIDFrame(IntPtr fuidContext); // 0x000000018221BD60-0x000000018221BDA0
		[NativeMethod(Name = "PopDictionaryFieldUniqueIdentifierStackFrame", IsFreeFunction = true, IsThreadSafe = true)]
		private static void PopDictionaryFUIDFrame(); // 0x000000018221A870-0x000000018221A8A0
		[NativeMethod(Name = "PushFieldUniqueIdentifierArrayIndex", IsFreeFunction = true, IsThreadSafe = true)]
		private static void PushFUIDArrayIndex(IntPtr fuidContext, int index); // 0x000000018221BDA0-0x000000018221BDE0
		[NativeMethod(Name = "SetFieldUniqueIdentifierCurrentArrayIndex", IsFreeFunction = true, IsThreadSafe = true)]
		private static void SetFUIDCurrentArrayIndex(IntPtr fuidContext, int index); // 0x000000018221C1F0-0x000000018221C230
		[NativeMethod(Name = "PopFieldUniqueIdentifierArrayIndex", IsFreeFunction = true, IsThreadSafe = true)]
		private static void PopFUIDArrayIndex(IntPtr fuidContext); // 0x000000018221A8A0-0x000000018221A8E0
		[FreeFunction("DictionaryFieldUniqueIdentifierBindings::FormatDictionaryFieldUniqueIdentifierForActiveContext", IsThreadSafe = true)]
		private static string FormatDictionaryFieldUniqueIdentifier(IntPtr dictionaryIdentifierTemplate); // 0x00000001822196C0-0x00000001822197C0
		private static unsafe void InvokeEnsureReadable(NativeReadBufferContext* ctx, int needed); // 0x000000018221A620-0x000000018221A640
		private static unsafe void InvokeSyncReader(NativeReadBufferContext* ctx); // 0x000000018221A690-0x000000018221A6B0
		private static unsafe void InvokeReadBytesDirect(NativeReadBufferContext* ctx, byte* dst, int n); // 0x000000018221A640-0x000000018221A660
		internal static Type UnmarshalSystemType(IntPtr handlePtr); // 0x000000018221C230-0x000000018221C270
		private static RuntimeMethodHandle UnmarshalRuntimeMethodHandle(IntPtr methodHandleValue); // 0x0000000180370C60-0x0000000180370C70
		private static unsafe T* ConsumeDirectCopyGroup<T>(ref byte* pos, out ref T* end)
			where T : struct;
		[RequiredByNativeCode]
		public static IntPtr ObjectsToSerializationBuffer(IntPtr pinnedBase, IntPtr runStart, IntPtr runEnd, IntPtr bufferContext, IntPtr transfer); // 0x000000018221A6B0-0x000000018221A860
		private static unsafe void ExecuteWriteCommands(NativeBufferContext* ctx, IntPtr pinnedBase, IntPtr entriesPtr, int entryBufferSize, IntPtr transfer, ref byte* output, ref BufferDataStager bufferDataStager, int repeatCount, long repeatStride, IntPtr fuidCtxForElements = default); // 0x00000001822182C0-0x0000000182219670
		private static unsafe void ConsumeString(NativeBufferContext* ctx, ref byte baseAddr, ref byte* pos, ref BufferDataStager bufferDataStager); // 0x0000000182215910-0x0000000182215A00
		private static unsafe void ConsumePropertyNamePlayer(NativeBufferContext* ctx, ref byte baseAddr, ref byte* pos, ref BufferDataStager bufferDataStager); // 0x0000000182215590-0x0000000182215620
		private static unsafe void WriteFramedString(NativeBufferContext* ctx, ReadOnlySpan<char> chars, ref BufferDataStager bufferDataStager); // 0x000000018221C3D0-0x000000018221CA70
		private static unsafe void WriteFramedDecimalInt32(NativeBufferContext* ctx, int value, ref BufferDataStager bufferDataStager); // 0x000000018221C280-0x000000018221C3D0
		private static object CreateWrapperInstance(IntPtr runtimeTypeHandle, IntPtr ctorFunctionPtr); // 0x0000000182215D70-0x0000000182215E50
		private static object GetOrCreateVrtInstance(ref byte baseAddr, uint fieldOffset, IntPtr runtimeTypeHandle, IntPtr ctorFunctionPtr); // 0x000000018221A330-0x000000018221A470
		private static unsafe void ConsumeValueReference(NativeBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* output, ref BufferDataStager bufferDataStager, ref byte* pos); // 0x0000000182215B90-0x0000000182215D70
		private static void InvokeRegisterGatheredRef(IntPtr fnPtr, IntPtr transferState, object obj); // 0x000000018221A660-0x000000018221A690
		private static unsafe void InvokeResolveMissingTypeForGather(IntPtr fnPtr, IntPtr transferState, IntPtr templatePtr, int* indices, int indexCount); // 0x00000001821FF870-0x0000000182200130
		[RequiredByNativeCode]
		public static int GatherRefs(object rootInstance, IntPtr gatherEntriesPtr, int gatherEntryBufferSize, IntPtr transferStatePtr, IntPtr registerRefFnPtr, IntPtr resolveMissingTypeFnPtr, int emitCallbacksFlag, int collectMissingTypesFlag); // 0x00000001822197C0-0x00000001822198F0
		private static unsafe void GatherWalkToEnd(ref byte baseAddr, object thisObject, byte* heapObjDataArea, ref byte* pos, byte* end, IntPtr transferState, IntPtr registerRefFnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x0000000182219F80-0x000000018221A0A0
		private static unsafe void GatherWalkOne(ref byte baseAddr, object thisObject, byte* heapObjDataArea, ref byte* pos, IntPtr transferState, IntPtr registerRefFnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x00000001822198F0-0x0000000182219F80
		private static unsafe void ProcessGatherRegisterRef(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221BC80-0x000000018221BD60
		private static unsafe void ProcessGatherRegisterRefArray(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221B950-0x000000018221BAD0
		private static unsafe void ProcessGatherRegisterRefList(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221BAD0-0x000000018221BC80
		private static unsafe void ProcessGatherRecurseClass(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221AE30-0x000000018221AF80
		private static unsafe void ProcessGatherRecurseStruct(ref byte baseAddr, object thisObject, byte* heapObjDataArea, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221B820-0x000000018221B950
		private static unsafe void ProcessGatherRecurseClassArray(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221A9F0-0x000000018221ABF0
		private static unsafe void ProcessGatherRecurseClassList(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221ABF0-0x000000018221AE30
		private static unsafe void ProcessGatherRecurseStructArray(ref byte baseAddr, object thisObject, byte* heapObjDataArea, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221B260-0x000000018221B550
		private static unsafe void ProcessGatherRecurseStructList(ref byte baseAddr, object thisObject, byte* heapObjDataArea, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221B550-0x000000018221B820
		private static unsafe void ProcessGatherRecurseDictionary(ref byte baseAddr, ref byte* pos, IntPtr transferState, IntPtr fnPtr, IntPtr resolveMissingTypeFnPtr, bool emitCallbacks, bool collectMissingTypes, int* indexStack, int indexDepth); // 0x000000018221AF80-0x000000018221B260
		private static unsafe void ProcessGatherInvokeOnBeforeSerializeClass(object thisObject, ref byte* pos); // 0x000000018221A8E0-0x000000018221A980
		private static unsafe void ProcessGatherInvokeOnBeforeSerializeStruct(ref byte baseAddr, ref byte* pos); // 0x000000018221A980-0x000000018221A9F0
		[RequiredByNativeCode]
		internal static IntPtr GetConstructorMethodFunctionPointer(IntPtr methodHandleValue); // 0x000000018221A1E0-0x000000018221A250
		[RequiredByNativeCode]
		internal static IntPtr GetMethodFunctionPointer(IntPtr methodHandleValue); // 0x000000018221A2C0-0x000000018221A330
		[RequiredByNativeCode]
		internal static IntPtr GetInterfaceMethodFunctionPointer(IntPtr typeHandleValue, SerializationCallbackMethod callbackMethod); // 0x00000001802E7860-0x00000001802E7870
		private static unsafe void ConsumeLinearCollection(NativeBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* output, ref BufferDataStager bufferDataStager, ref byte* pos); // 0x0000000182214D30-0x0000000182215590
		private static ulong ResolveUnityObjectEntityIdForWrite(object slot, int flags); // 0x000000018221C090-0x000000018221C0A0
		private static unsafe void ConsumeLinearCollectionUnityObjectArray(NativeBufferContext* ctx, byte[] dataAsBytes, int count, long stride, ref BufferDataStager bufferDataStager); // 0x0000000182214A70-0x0000000182214D30
		private static unsafe void ConsumeLinearCollectionEntityIdArray(NativeBufferContext* ctx, byte[] dataAsBytes, int count, long stride, ref BufferDataStager bufferDataStager); // 0x0000000182213C30-0x0000000182213E50
		private static uint AlignUp4(uint byteCount); // 0x00000001822126F0-0x0000000182212700
		private static unsafe void ConsumeDictionary(NativeBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* output, ref BufferDataStager bufferDataStager, ref byte* pos); // 0x0000000182213080-0x0000000182213670
		private static unsafe void ConsumeFixedBuffer(ref byte baseAddr, ref byte* pos, ref BufferDataStager bufferDataStager); // 0x00000001821FE840-0x00000001821FEFE0
		private static unsafe void PackEntityIdIntoLsoi(byte* dst, ulong entityId); // 0x000000018221A860-0x000000018221A870
		private static unsafe ulong UnpackEntityIdFromLsoi(byte* src); // 0x000000018221C270-0x000000018221C280
		private static unsafe void ConsumeLinearCollectionShufflePath(NativeBufferContext* ctx, byte[] dataAsBytes, int count, long stride, int elementWireSize, byte* body, int bodyLen, ref BufferDataStager bufferDataStager); // 0x00000001822144E0-0x0000000182214670
		private static unsafe void ExecuteShuffleBatch(byte* srcBase, byte* dstBase, int batch, long srcStride, int dstStride, byte* body, int bodyLen); // 0x0000000182217A60-0x00000001822182C0
		private static unsafe string DecodeStringBody(byte* bytes, int length); // 0x00000001821FEFE0-0x00000001821FF870
		private static unsafe void ConsumeStringRead(NativeReadBufferContext* ctx, ref byte baseAddr, ref byte* pos); // 0x00000001822156A0-0x0000000182215910
		private static unsafe int ReadFramedDecimalInt32(NativeReadBufferContext* ctx); // 0x000000018221BDE0-0x000000018221BFB0
		private static unsafe void ConsumePropertyNameRead(NativeReadBufferContext* ctx, ref byte baseAddr, ref byte* pos); // 0x0000000182215620-0x00000001822156A0
		private static unsafe void ConsumeLinearCollectionRead(NativeReadBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* pos); // 0x0000000182213E50-0x00000001822144E0
		private static Type GetCachedListType(Type elementType); // 0x000000018221A0A0-0x000000018221A1E0
		private static Array AllocateOrReuseArrayBacking(ref byte baseAddr, byte kind, uint fieldOffset, Type elementType, int count, out byte[] dataAsBytes); // 0x0000000182212700-0x0000000182212770
		private static void AssignArrayBacking(ref byte baseAddr, byte kind, uint fieldOffset, Array arr, byte[] dataAsBytes, int count, Type elementType); // 0x0000000182212770-0x0000000182212830
		private static unsafe void ConsumeLinearCollectionUnityObjectArrayRead(NativeReadBufferContext* ctx, ref byte baseAddr, ref byte* pos); // 0x0000000182214670-0x0000000182214A70
		private static unsafe void ConsumeLinearCollectionEntityIdArrayRead(NativeReadBufferContext* ctx, ref byte baseAddr, ref byte* pos); // 0x0000000182213890-0x0000000182213C30
		private static unsafe void ConsumeDictionaryRead(NativeReadBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* pos); // 0x0000000182212860-0x0000000182213080
		private static unsafe void ConsumeFixedBufferRead(NativeReadBufferContext* ctx, ref byte baseAddr, ref byte* pos); // 0x0000000182213670-0x0000000182213890
		private static unsafe void ExecuteReadShuffleBatch(byte* srcBase, byte* dstBase, int count, int srcStride, long dstStride, byte* body, int bodyLen); // 0x0000000182217200-0x0000000182217A60
		private static unsafe void ConsumeValueReferenceRead(NativeReadBufferContext* ctx, ref byte baseAddr, IntPtr transfer, ref byte* pos); // 0x0000000182215A00-0x0000000182215B90
		[RequiredByNativeCode]
		public static IntPtr SerializationBufferToObjects(IntPtr pinnedBase, IntPtr runStart, IntPtr runEnd, IntPtr readContext, IntPtr transfer); // 0x000000018221C0A0-0x000000018221C1F0
		private static unsafe void CommitReadSegment(NativeReadBufferContext* ctx, ref int currentSegmentSize); // 0x0000000182212830-0x0000000182212860
		private static unsafe void ExecuteReadCommands(NativeReadBufferContext* ctx, ref byte baseAddrParam, byte* entryBase, int entryBufSize, IntPtr transfer, ref int currentSegmentSize, int repeatCount, long repeatStride, IntPtr fuidCtxForElements = default); // 0x0000000182215E50-0x0000000182217200
		private static void FormatDictionaryFieldUniqueIdentifier_Injected(IntPtr dictionaryIdentifierTemplate, ); // 0x0000000182219670-0x00000001822196C0
	}
}
