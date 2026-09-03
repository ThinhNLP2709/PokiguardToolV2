/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal abstract class RBTree<K> : IEnumerable // TypeDefIndex: 11303
	{
		// Fields
		private TreePage[] _pageTable;
		private int[] _pageTableMap;
		private int _inUsePageCount;
		private int _nextFreePageLine;
		public int root;
		private int _version;
		private int _inUseNodeCount;
		private int _inUseSatelliteTreeCount;
		private readonly TreeAccessMethod _accessMethod;
	
		// Properties
		public int Count { get; }
		public bool HasDuplicates { get; }
		public K this[int index] { get => default; }
	
		// Nested types
		private enum NodeColor // TypeDefIndex: 11304
		{
			red = 0,
			black = 1
		}
	
		private struct Node // TypeDefIndex: 11305
		{
			// Fields
			internal int _selfId;
			internal int _leftId;
			internal int _rightId;
			internal int _parentId;
			internal int _nextId;
			internal int _subTreeSize;
			internal K _keyOfNode;
			internal NodeColor<K> _nodeColor;
		}
	
		[IsReadOnly]
		private struct NodePath // TypeDefIndex: 11306
		{
			// Fields
			internal readonly int _nodeID;
			internal readonly int _mainTreeNodeID;
	
			// Constructors
			internal NodePath(int nodeID, int mainTreeNodeID);
		}
	
		private sealed class TreePage // TypeDefIndex: 11307
		{
			// Fields
			internal readonly Node<K>[] _slots;
			internal readonly int[] _slotMap;
			private int _inUseCount;
			private int _pageId;
			private int _nextFreeSlotLine;
	
			// Properties
			internal int InUseCount { get; set; }
			internal int PageId { get; set; }
	
			// Constructors
			internal TreePage(int size);
	
			// Methods
			internal int AllocSlot(RBTree<K> tree);
		}
	
		internal struct RBTreeEnumerator : IEnumerator<K> // TypeDefIndex: 11308
		{
			// Fields
			private readonly RBTree<K> _tree;
			private readonly int _version;
			private int _index;
			private int _mainTreeNodeId;
			private K _current;
	
			// Properties
			public K Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal RBTreeEnumerator(RBTree<K> tree);
			internal RBTreeEnumerator(RBTree<K> tree, int position);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		// Constructors
		protected RBTree(TreeAccessMethod accessMethod);
	
		// Methods
		protected abstract int CompareNode(K record1, K record2);
		protected abstract int CompareSateliteTreeNode(K record1, K record2);
		private void InitTree();
		private void FreePage(TreePage page);
		private TreePage AllocPage(int size);
		private void MarkPageFull(TreePage page);
		private void MarkPageFree(TreePage page);
		private static int GetIntValueFromBitMap(uint bitMap);
		private void FreeNode(int nodeId);
		private int GetIndexOfPageWithFreeSlot(bool allocatedPage);
		private int GetNewNode(K key);
		private int Successor(int x_id);
		private bool Successor(ref int nodeId, ref int mainTreeNodeId);
		private int Minimum(int x_id);
		private int LeftRotate(int root_id, int x_id, int mainTreeNode);
		private int RightRotate(int root_id, int x_id, int mainTreeNode);
		private int RBInsert(int root_id, int x_id, int mainTreeNodeID, int position, bool append);
		public void UpdateNodeKey(K currentKey, K newKey);
		public K DeleteByIndex(int i);
		public int RBDelete(int z_id);
		private int RBDeleteX(int root_id, int z_id, int mainTreeNodeID);
		private int RBDeleteFixup(int root_id, int x_id, int px_id, int mainTreeNodeID);
		private int SearchSubTree(int root_id, K key);
		private NodePath GetNodeByKey(K key);
		public int GetIndexByKey(K key);
		public int GetIndexByNode(int node);
		private int GetIndexByNodePath(NodePath path);
		private int ComputeIndexByNode(int nodeId);
		private int ComputeIndexWithSatelliteByNode(int nodeId);
		private NodePath GetNodeByIndex(int userIndex);
		private int ComputeNodeByIndex(int index, out int satelliteRootId);
		private int ComputeNodeByIndex(int x_id, int index);
		public int Insert(K item);
		public int Add(K item);
		public IEnumerator GetEnumerator();
		public int IndexOf(int nodeId, K item);
		public int Insert(int position, K item);
		public int InsertAt(int position, K item, bool append);
		public void RemoveAt(int position);
		public void Clear();
		public void CopyTo(Array array, int index);
		public void CopyTo(K[] array, int index);
		private void SetRight(int nodeId, int rightNodeId);
		private void SetLeft(int nodeId, int leftNodeId);
		private void SetParent(int nodeId, int parentNodeId);
		private void SetColor(int nodeId, NodeColor color);
		private void SetKey(int nodeId, K key);
		private void SetNext(int nodeId, int nextNodeId);
		private void SetSubTreeSize(int nodeId, int size);
		private void IncreaseSize(int nodeId);
		private void RecomputeSize(int nodeId);
		private void DecreaseSize(int nodeId);
		public int Right(int nodeId);
		public int Left(int nodeId);
		public int Parent(int nodeId);
		private NodeColor color(int nodeId);
		public int Next(int nodeId);
		public int SubTreeSize(int nodeId);
		public K Key(int nodeId);
	}
}
