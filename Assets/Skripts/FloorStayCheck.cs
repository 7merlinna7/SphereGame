using UnityEngine;

public class FloorStayCheck : MonoBehaviour
{
    public bool IsOnFloor { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
            IsOnFloor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
            IsOnFloor = false;
    }
}
