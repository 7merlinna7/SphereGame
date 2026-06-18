using UnityEngine;

public class Gem : MonoBehaviour
{
    public void StartGem()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        GemCollector gemCollector = other.GetComponent<GemCollector>();
        if (gemCollector != null)
        {
            gemCollector.AddGem();
            gameObject.SetActive(false);
        }
    }
}
