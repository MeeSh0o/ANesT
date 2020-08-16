using System.Linq;
using UnityEngine;

public class BordTriggerListener : TriggerListener
{
    public PaintingPicture paint;

    public override bool OnTrigger(Trigger trigger)
    {
        return paint.NextPicture();
    }
}