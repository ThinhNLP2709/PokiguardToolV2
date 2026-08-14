namespace Unity.VisualScripting.Antlr3.Runtime.Tree;

public interface ITreeVisitorAction
{

	public object Post(object t) { }

	public object Pre(object t) { }

}

