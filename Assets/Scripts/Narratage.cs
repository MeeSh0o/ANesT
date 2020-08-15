/// <summary>
/// 旁白
/// </summary>
public class Narratage : Dialog
{
    public static Narratage Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}