using UnityEngine;

/// <summary>
/// Toggles particle system
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class Particle : MonoBehaviour
{
    private ParticleSystem particleSystem = null;
    [SerializeField] private GameObject particlePrefab = null;
    private MonoBehaviour currentOwner = null;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        particleSystem.Play();
    }
    public void PlacePrefab()
    {
        GameObject particleObject = Instantiate(particlePrefab, transform.position, transform.rotation);
        ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();
        particleSystem.transform.parent = null; // Detach the particle system from its parent

        particleSystem.Play();
    }
    public void Stop()
    {
        particleSystem.Stop();
    }

    public void PlayWithExclusivity(MonoBehaviour owner)
    {
        if (currentOwner == null)
        {
            currentOwner = this;
            Play();
        }
    }

    public void StopWithExclusivity(MonoBehaviour owner)
    {
        if (currentOwner == this)
        {
            currentOwner = null;
            Stop();
        }
    }

    private void OnValidate()
    {
        if (particleSystem)
        {
            ParticleSystem.MainModule main = particleSystem.main;
            main.playOnAwake = false;
        }
    }
}
