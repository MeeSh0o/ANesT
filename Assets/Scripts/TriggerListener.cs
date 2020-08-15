using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public virtual bool OnTrigger(Trigger trigger)
    {
        return false;
    }
}