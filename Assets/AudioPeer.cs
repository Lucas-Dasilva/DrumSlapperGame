using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Listen to the audio source every frame and get a sample
[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{

    public AudioSource audioSource;
    public float _bpm;

    //Will split 20 thousand hertz into 512 sameples/ subbass = 0/ 20k hertz = 512
    public static float[] audioSamples = new float[1024];
    //float[] frequencyBand = new float[8];


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        //MakeFrequencyBand();

    }

    // Update is called once per frame
    void Update()
    {
        //GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        //audioSource.GetSpectrumData(audioSamples, 0,FFTWindow.Blackman );
    }

    void MakeFrequencyBand ()
    {
        //Debug.Log(audioSource.time);
        /*
         * 22050 / 1024 = 21hz per sample
         * 
         * 60 - 100hz = Kick bass
         * 120 - 250hz = snare drum
         * 500 - 2000hz = ride/crash
         * 3000 - 5000 = hi hat
         * 
         * Kick =   sameple[3] - sample[4]
         * snare = sample[5] - sample[12]
         * ride = sample[18] - sample[71]
         * hi hat = sample [143] - sample [238]
         * 
         */
    }
}
