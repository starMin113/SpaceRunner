using UnityEngine;

public class TrailEffectController : MonoBehaviour
{
    public ParticleSystem trailPS;
    public void SetTrailActive(bool isActive)
    {
        if (isActive && !trailPS.isPlaying) trailPS.Play();
        else if (!isActive && trailPS.isPlaying) trailPS.Stop();
    }
}