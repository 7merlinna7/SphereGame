using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public int GemScore { get; private set; }

    public void AddGem() => GemScore++;

    public void ResetGemScore() => GemScore = 0;
}
