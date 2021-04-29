using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala : MonoBehaviour
{
    public Slider VoSlider;
    public Slider dSlider;
    public bool fired = false;
    public float vo;
    public float g;
    public float d;

    private Vector2 p = new Vector2();
    private Vector2 v = new Vector2();
    private Vector2 a = new Vector2();

    public Text Resultados;
    private string textResultados;

    float time = 0;

    void Start()
    {
        p = transform.position;
        v.x = vo;
        a = new Vector2(0, g);
    }

    private void Update()
    {
        v.x = VoSlider.value;
        vo = VoSlider.value;
        d = dSlider.value;

        if (Input.GetKeyDown(KeyCode.Space) && !fired){
            fired = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && fired){
            fired = false;
            Restart();
        }
    }

    void FixedUpdate()
    {
        

        if (fired == true) {
            firing();
        }     
    }

    void firing() {
        if (transform.position.x < d)
        {
            time += Time.fixedDeltaTime;
            v = v + (a * Time.fixedDeltaTime);
            p = p + (v * Time.fixedDeltaTime);
            transform.position = p;
        }
        else
        {
            Calcular();
            print("Simulated t: " + time);
            print("Simulated y: " + transform.position.y);
        }
    }

    void Restart() { 
        transform.position = new Vector3(0, 0);
        p = transform.position;
        v.x = vo;
        v.y = 0;
        a = new Vector2(0, g);
        time = 0;
        
    }

    void Calcular(){
        float t = d / vo;
        float y = (.5f) * (g) * Mathf.Pow(t,2);
        print("Real t:" +t);
        print("Real y:" +y);

        textResultados = "Resultados: \nTiempo real = " + t + "\nAltura real = " + y + "\nTiempo simulado = " + time + "\nAltura simulada = " + transform.position.y;
        Resultados.text = textResultados;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = Vector2.down * 10000;
        Vector3 pos = new Vector3(d, 15, 0);
        
        Gizmos.DrawRay(pos, direction);
    }
}
