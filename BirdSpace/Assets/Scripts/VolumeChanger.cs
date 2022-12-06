using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
	[SerializeField] AudioSource Example;
	[SerializeField] Slider slide;
	float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
     	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void change(){
		PersistentData.Instance.SetVolume(slide.value);
		Example.volume = slide.value;
		Example.Play();
	}
}
