/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LTDescrOptional // TypeDefIndex: 306
{
	// Fields
	[CompilerGenerated]
	private Transform _toTrans_k__BackingField; // 0x10
	[CompilerGenerated]
	private Vector3 _point_k__BackingField; // 0x18
	[CompilerGenerated]
	private Vector3 _axis_k__BackingField; // 0x24
	[CompilerGenerated]
	private float _lastVal_k__BackingField; // 0x30
	[CompilerGenerated]
	private Quaternion _origRotation_k__BackingField; // 0x34
	[CompilerGenerated]
	private LTBezierPath _path_k__BackingField; // 0x48
	[CompilerGenerated]
	private LTSpline _spline_k__BackingField; // 0x50
	public AnimationCurve animationCurve; // 0x58
	public int initFrameCount; // 0x60
	public Color color; // 0x64
	[CompilerGenerated]
	private LTRect _ltRect_k__BackingField; // 0x78
	[CompilerGenerated]
	private Action<float> _onUpdateFloat_k__BackingField; // 0x80
	[CompilerGenerated]
	private Action<float, float> _onUpdateFloatRatio_k__BackingField; // 0x88
	[CompilerGenerated]
	private Action<float, object> _onUpdateFloatObject_k__BackingField; // 0x90
	[CompilerGenerated]
	private Action<Vector2> _onUpdateVector2_k__BackingField; // 0x98
	[CompilerGenerated]
	private Action<Vector3> _onUpdateVector3_k__BackingField; // 0xA0
	[CompilerGenerated]
	private Action<Vector3, object> _onUpdateVector3Object_k__BackingField; // 0xA8
	[CompilerGenerated]
	private Action<Color> _onUpdateColor_k__BackingField; // 0xB0
	[CompilerGenerated]
	private Action<Color, object> _onUpdateColorObject_k__BackingField; // 0xB8
	[CompilerGenerated]
	private Action _onComplete_k__BackingField; // 0xC0
	[CompilerGenerated]
	private Action<object> _onCompleteObject_k__BackingField; // 0xC8
	[CompilerGenerated]
	private object _onCompleteParam_k__BackingField; // 0xD0
	[CompilerGenerated]
	private object _onUpdateParam_k__BackingField; // 0xD8
	[CompilerGenerated]
	private Action _onStart_k__BackingField; // 0xE0

	// Properties
	public Transform toTrans { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8AA0-0x00000001802D8AB0 0x00000001802D8AB0-0x00000001802D8B10
	public Vector3 point { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B10-0x00000001802D8B30 0x00000001802D8B30-0x00000001802D8B40
	public Vector3 axis { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B40-0x00000001802D8B60 0x00000001802D8B60-0x00000001802D8B70
	public float lastVal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B70-0x00000001802D8B80 0x00000001802D8B80-0x00000001802D8B90
	public Quaternion origRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B90-0x00000001802D8BA0 0x00000001802D8BA0-0x00000001802D8BB0
	public LTBezierPath path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8BB0-0x00000001802D8BC0 0x00000001802D8BC0-0x00000001802D8C20
	public LTSpline spline { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8C20-0x00000001802D8C30 0x00000001802D8C30-0x00000001802D8C90
	public LTRect ltRect { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802A86B0-0x00000001802A86C0 0x00000001802A86C0-0x00000001802A8720
	public Action<float> onUpdateFloat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8C90-0x00000001802D8CA0 0x00000001802D8CA0-0x00000001802D8D00
	public Action<float, float> onUpdateFloatRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8D00-0x00000001802D8D10 0x00000001802D8D10-0x00000001802D8D70
	public Action<float, object> onUpdateFloatObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8D70-0x00000001802D8D80 0x00000001802D8D80-0x00000001802D8DE0
	public Action<Vector2> onUpdateVector2 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8DE0-0x00000001802D8DF0 0x00000001802D8DF0-0x00000001802D8E50
	public Action<Vector3> onUpdateVector3 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8E50-0x00000001802D8E60 0x00000001802D8E60-0x00000001802D8EC0
	public Action<Vector3, object> onUpdateVector3Object { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8EC0-0x00000001802D8ED0 0x00000001802D8ED0-0x00000001802D8F30
	public Action<Color> onUpdateColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8F30-0x00000001802D8F40 0x00000001802D8F40-0x00000001802D8FA0
	public Action<Color, object> onUpdateColorObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8FA0-0x00000001802D8FB0 0x00000001802D8FB0-0x00000001802D9010
	public Action onComplete { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D9010-0x00000001802D9020 0x00000001802D9020-0x00000001802D9080
	public Action<object> onCompleteObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D9080-0x00000001802D9090 0x00000001802D9090-0x00000001802D90F0
	public object onCompleteParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D90F0-0x00000001802D9100 0x00000001802D9100-0x00000001802D9160
	public object onUpdateParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D9160-0x00000001802D9170 0x00000001802D9170-0x00000001802D91D0
	public Action onStart { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D91D0-0x00000001802D91E0 0x00000001802D91E0-0x00000001802D9240

	// Constructors
	public LTDescrOptional(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void reset(); // 0x00000001802D9240-0x00000001802D96E0
	public void callOnUpdate(float val, float ratioPassed); // 0x00000001802D96E0-0x00000001802D98E0
}

