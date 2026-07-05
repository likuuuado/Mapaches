using UnityEngine;

public class Anger : MonoBehaviour
{
    public int maxAnger = 100;
    private int currentAnger;

    void Start()
    {
        currentAnger = 0;
    }

    public int CurrentAnger
    {
        get {return currentAnger;}
    }

    public void AddAnger(int amount)
    {
        currentAnger += amount;

        if (currentAnger > maxAnger)
            currentAnger = maxAnger;
    }

    public void ResetAnger()
    {
        currentAnger = 0;
    }

    public bool IsFull()
    {
        return currentAnger >= maxAnger;
    }
}
