using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synthy : MonoBehaviour
{

    public double frequ = 60.0;
    private double increme;
    private double phase;
    private const double samp_frequ = 48000.0;

    public float gain;
    public float volume = 0.1f;
    public List<float> a_Major_list = new List<float>();
    private List<float> old_list = new List<float>();
    public int thisScale;
    public bool sortet = false;
    public float wait_speed = 50.0f;
    private float waitet;


    private  void OnAudioFilterRead(float[] data, int channels)
    {
        increme = frequ * 2.0 * Mathf.PI / samp_frequ;

        for (int i = 0; i < data.Length; i+= channels)
        {
            phase += increme;
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }
            if (phase>(Mathf.PI *2))
            {
                phase = 0.0;
            }
    
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

        a_Major_list.Add(440);
        a_Major_list.Add(494);
        a_Major_list.Add(554);
        a_Major_list.Add(587);
        a_Major_list.Add(659);
        a_Major_list.Add(740);
        a_Major_list.Add(831);
        a_Major_list.Add(880);
    
        gain = volume;
        //Time.timeScale = 0.1f;
    }

    // Update is called once per frame
    void  Update()
    {
       // while (!sortet)
       // {
           // print("test");
            bool compare = true;
            bogosort();
        for (int j = 0; j < 4; j++)
        {

        
            for (int i = 0; i < a_Major_list.Count  ; i++)
            {

               // print(i);
                if (frequ>a_Major_list[i] || !compare)
                {
                    compare = false;
                }
                waitet = wait_speed;
                while (wait_speed>=0.0)
                {
                    wait_speed = wait_speed - Time.deltaTime;
                    frequ = a_Major_list[i];
                    print(Time.deltaTime);
                }
                wait_speed = waitet;
                
                
            }
            if (compare)
            {
               // sortet = true;
            }
        }
    }

    void bogosort()
    {
        //List<float> temp;
        int rdn;

       // temp = new List<float>();

        while (0 < a_Major_list.Count)
        {
            rdn = Random.Range(0, a_Major_list.Count );
            old_list.Add( a_Major_list[rdn]);
            a_Major_list.RemoveAt(rdn);
        }
        print(a_Major_list.Count);
        a_Major_list.Clear();
        foreach (float item in old_list)
        {
            a_Major_list.Add(item);
        }
        print(old_list.Count);
        old_list.Clear();

        // insert.
    }
    
}
