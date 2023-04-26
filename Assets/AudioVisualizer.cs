
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{

    private AudioSource source;

    public float size = 5;

    public float power = 2;

    private float finalSize;

    public float shrinkSpeed = 3;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        float[] samples = new float[735];
        
        source.clip.GetData(samples, source.timeSamples);

        print(samples[0]);

        float sum = 0;
        foreach(var sample in samples)
        {
            sum += Mathf.Abs(sample);
        }
        float average = sum / 735;
        print(average);

        var musicPower = (1 + Mathf.Pow(average, power) * size);
        
        if(musicPower > finalSize)
        {
            finalSize = musicPower;
        }
        else
        {
            finalSize -= shrinkSpeed * Time.deltaTime; 
        }

        transform.localScale = Vector3.one * finalSize;

        transform.Rotate(average, average, average);
    }
}
