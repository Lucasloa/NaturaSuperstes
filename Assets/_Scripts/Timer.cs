using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int counter = 0;
    public float timer = 0f;
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            counter++;
            timer -= 1f; // Reset the timer
            timerText.text = "Time: " + counter;
        }
    }
}
