namespace DG.Tweening.Plugins.Core;

public interface IPlugSetter
{

	public T2 EndValue() { }

	public TPlugOptions GetOptions() { }

	public DOGetter<T1> Getter() { }

	public DOSetter<T1> Setter() { }

}

