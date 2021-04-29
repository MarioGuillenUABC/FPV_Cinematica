using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{

    public Slider slider;
    private Text texto;
    public string inicio;

    void Start()
    {
        texto = this.GetComponent<Text>();

    }

    void Update()
    {
        texto.text = inicio + slider.value;
    }
}
