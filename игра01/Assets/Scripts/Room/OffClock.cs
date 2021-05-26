using UnityEngine;

public class OffClock : MonoBehaviour
{
    private static readonly int On = Animator.StringToHash("On");

    private void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().SetBool(On, false);
    }
}
