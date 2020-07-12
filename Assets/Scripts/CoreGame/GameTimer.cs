using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 100f;

    bool timeUpSent = false;
    // cache
    Slider slider;

    private void Start()
    {
        // cache
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        UpdateSlider();
        TimeUpWarning();
    }

    private void TimeUpWarning()
    {
        if (!timeUpSent)
        {
            if (Time.timeSinceLevelLoad >= levelTime)
            {
                FindObjectOfType<LevelController>().TimeUp = true;
                timeUpSent = true;
            }
        }
    }

    private void UpdateSlider()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
    }
}
