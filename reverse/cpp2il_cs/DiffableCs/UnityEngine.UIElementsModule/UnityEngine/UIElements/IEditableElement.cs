namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal interface IEditableElement
{

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Action editingEnded
	{
		internal get { } //Length: 0
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Action editingStarted
	{
		internal get { } //Length: 0
	}

	internal Action get_editingEnded() { }

	internal Action get_editingStarted() { }

}

