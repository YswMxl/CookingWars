using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MenuOpciones : MonoBehaviour
{
    [Serialize]
    public void FullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void ChangeVolume(float volumen)
}
