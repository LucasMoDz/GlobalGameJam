using UnityEngine;
using System.Collections;

public class AudioContainer : MonoBehaviour {

    protected static AudioContainer _self;
    public static AudioContainer Self

    {
        get
        {
            if (_self == null)
                _self = FindObjectOfType(typeof(AudioContainer)) as AudioContainer;
            return _self;
        }
    }

    public AudioClip morte;
    public AudioClip vittoria;
    public AudioClip risucchio;
    public AudioClip sottofondo;
}
