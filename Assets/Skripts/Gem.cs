using UnityEngine;

public class Gem : MonoBehaviour
{
    public void StartGem()
    {
        gameObject.SetActive(true);
    }

    public void CollectGem()
    {
        gameObject.SetActive(false);
    }
}
