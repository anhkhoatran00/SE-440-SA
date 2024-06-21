using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ocean;
    [SerializeField] private float wavePower = 2f;


    // Update is called once per frame
    private Material _oceanMat;
    {

    }

    private void SetValue()
    {
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        _oceanMat = (Texture2D)_oceanMat.GetTexture("mainTex");
    }


    private void OnValidate()
    {
        if (!Application.isPlaying) return;
        if (ocean != null) 
        {
            SetValue();
        }
        _oceanMat.SetFloat("_wavePower",wavePower);
    }

    public float GetWaveHeight(Vector3 point)
    {
        float waveHeight = _oceanTex.GetPixelBilinear(point.x, point.z).g * wavePower;
        return waveHeight;
    }
}
