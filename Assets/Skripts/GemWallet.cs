using UnityEngine;

public class GemWallet : MonoBehaviour
{
    public int GemScore { get; private set; }

    public void ResetGemScore()
    {
        GemScore = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Gem gem = other.GetComponent<Gem>();
        if (gem != null)
        {
            GemScore++;
            gem.CollectGem();
        }
    }
}
