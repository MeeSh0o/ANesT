using System.Linq;
using UnityEngine;

public class BordTriggerListener : TriggerListener
{
    public PaintingPicture paint;

    public override bool OnTrigger(Trigger trigger)
    {
        if (paint.NextPicture())
        {
            Stage.Instance.AddFlag("完成上色");
        }

        return false;
    }
}