namespace Unity.VisualScripting.Antlr3.Runtime;

public class CommonTokenStream : ITokenStream, IIntStream
{
	protected ITokenSource tokenSource; //Field offset: 0x10
	protected IList tokens; //Field offset: 0x18
	protected IDictionary channelOverrideMap; //Field offset: 0x20
	protected HashList discardSet; //Field offset: 0x28
	protected int channel; //Field offset: 0x30
	protected bool discardOffChannelTokens; //Field offset: 0x34
	protected int lastMarker; //Field offset: 0x38
	protected int p; //Field offset: 0x3C

	public override int Count
	{
		 get { } //Length: 73
	}

	public override string SourceName
	{
		 get { } //Length: 94
	}

	public override ITokenSource TokenSource
	{
		 get { } //Length: 5
		 set { } //Length: 116
	}

	public CommonTokenStream() { }

	public CommonTokenStream(ITokenSource tokenSource) { }

	public CommonTokenStream(ITokenSource tokenSource, int channel) { }

	public override void Consume() { }

	public override void DiscardOffChannelTokens(bool discardOffChannelTokens) { }

	public override void DiscardTokenType(int ttype) { }

	protected override void FillBuffer() { }

	public override IToken Get(int i) { }

	public override int get_Count() { }

	public override string get_SourceName() { }

	public override ITokenSource get_TokenSource() { }

	public override IList GetTokens(int start, int stop, IList types) { }

	public override IList GetTokens(int start, int stop, BitSet types) { }

	public override IList GetTokens(int start, int stop) { }

	public override IList GetTokens() { }

	public override IList GetTokens(int start, int stop, int ttype) { }

	public override int Index() { }

	public override int LA(int i) { }

	protected override IToken LB(int k) { }

	public override IToken LT(int k) { }

	public override int Mark() { }

	public override void Release(int marker) { }

	public override void Reset() { }

	public override void Rewind() { }

	public override void Rewind(int marker) { }

	public override void Seek(int index) { }

	public override void set_TokenSource(ITokenSource value) { }

	public override void SetTokenTypeChannel(int ttype, int channel) { }

	[Obsolete("Please use the property Count instead.")]
	public override int Size() { }

	protected override int SkipOffTokenChannels(int i) { }

	protected override int SkipOffTokenChannelsReverse(int i) { }

	public override string ToString(IToken start, IToken stop) { }

	public override string ToString(int start, int stop) { }

	public virtual string ToString() { }

}

