using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private Light dirLight;
    
    private ParticleSystem _ps;
    private bool _isRain = false;
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 5f;
    

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (_isRain && dirLight.intensity > 0.25f)
        {
            LightIntesity(-1);
        }
        else if (!_isRain && dirLight.intensity < 0.5f)
        {
            LightIntesity(1);
        }
    }

    private void LightIntesity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTime, maxTime));
            if (_isRain)
            {
                _ps.Stop();
            }
            else
            {
                _ps.Play();
            }
            _isRain = !_isRain;
        }
    }
}
