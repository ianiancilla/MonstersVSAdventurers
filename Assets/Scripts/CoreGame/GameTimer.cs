using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 100f;

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

        bool timeUp = (Time.timeSinceLevelLoad >= levelTime);

        if (timeUp)
        {
            FindObjectOfType<LevelController>().TimeUp = true;
        }
    }

    private void UpdateSlider()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
    }
}
