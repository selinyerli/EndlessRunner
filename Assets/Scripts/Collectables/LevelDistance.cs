using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public float disDelay = 0.35f;
    private Text disDisplayText;
    private Text disEndDisplayText;
    private float timer;
    private bool startCounting = false;

    private void Start()
    {
        // Cache the Text components
        disDisplayText = disDisplay.GetComponent<Text>();
        disEndDisplayText = disEndDisplay.GetComponent<Text>();

        // Start the coroutine to delay the counting
        StartCoroutine(StartCountingAfterDelay());
    }

    private void Update()
    {
        if (startCounting)
        {
            // Increment the timer
            timer += Time.deltaTime;
            // Check if the delay has passed
            if (timer >= disDelay)
            {
                // Increment distance
                disRun += 1;
                // Update the UI
                disDisplayText.text = disRun.ToString();
                disEndDisplayText.text = disRun.ToString();
                // Reset the timer
                timer = 0f;
            }
        }
    }

    private IEnumerator StartCountingAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        startCounting = true;
    }
}