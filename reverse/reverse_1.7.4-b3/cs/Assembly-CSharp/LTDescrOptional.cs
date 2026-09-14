/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public Transform toTrans { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8A70-0x00000001802D8A80 0x00000001802D8A80-0x00000001802D8AE0
	public Vector3 point { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8AE0-0x00000001802D8B00 0x00000001802D8B00-0x00000001802D8B10
	public Vector3 axis { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B10-0x00000001802D8B30 0x00000001802D8B30-0x00000001802D8B40
	public float lastVal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B40-0x00000001802D8B50 0x00000001802D8B50-0x00000001802D8B60
	public Quaternion origRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B60-0x00000001802D8B70 0x00000001802D8B70-0x00000001802D8B80
	public LTBezierPath path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8B80-0x00000001802D8B90 0x00000001802D8B90-0x00000001802D8BF0
	public LTSpline spline { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8BF0-0x00000001802D8C00 0x00000001802D8C00-0x00000001802D8C60
	public LTRect ltRect { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802A86B0-0x00000001802A86C0 0x00000001802A86C0-0x00000001802A8720
	public Action<float> onUpdateFloat { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8C60-0x00000001802D8C70 0x00000001802D8C70-0x00000001802D8CD0
	public Action<float, float> onUpdateFloatRatio { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8CD0-0x00000001802D8CE0 0x00000001802D8CE0-0x00000001802D8D40
	public Action<float, object> onUpdateFloatObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8D40-0x00000001802D8D50 0x00000001802D8D50-0x00000001802D8DB0
	public Action<Vector2> onUpdateVector2 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8DB0-0x00000001802D8DC0 0x00000001802D8DC0-0x00000001802D8E20
	public Action<Vector3> onUpdateVector3 { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8E20-0x00000001802D8E30 0x00000001802D8E30-0x00000001802D8E90
	public Action<Vector3, object> onUpdateVector3Object { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8E90-0x00000001802D8EA0 0x00000001802D8EA0-0x00000001802D8F00
	public Action<Color> onUpdateColor { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8F00-0x00000001802D8F10 0x00000001802D8F10-0x00000001802D8F70
	public Action<Color, object> onUpdateColorObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8F70-0x00000001802D8F80 0x00000001802D8F80-0x00000001802D8FE0
	public Action onComplete { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8FE0-0x00000001802D8FF0 0x00000001802D8FF0-0x00000001802D9050
	public Action<object> onCompleteObject { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D9050-0x00000001802D9060 0x00000001802D9060-0x00000001802D90C0
	public object onCompleteParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D90C0-0x00000001802D90D0 0x00000001802D90D0-0x00000001802D9130
	public object onUpdateParam { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D9130-0x00000001802D9140 0x00000001802D9140-0x00000001802D91A0
	public Action onStart { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D91A0-0x00000001802D91B0 0x00000001802D91B0-0x00000001802D9210

	// Constructors
	public LTDescrOptional(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void reset(); // 0x00000001802D9210-0x00000001802D96B0
	public void callOnUpdate(float val, float ratioPassed); // 0x00000001802D96B0-0x00000001802D98B0
}

