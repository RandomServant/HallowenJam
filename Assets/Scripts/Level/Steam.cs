using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Steam : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Player _player;

    [SerializeField] private float damageOfOneParticle = 0.05f;

    private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _player = FindObjectOfType<Player>();
        
        _particleSystem.trigger.AddCollider(_player.transform);
    }

    void OnParticleTrigger()
    {
        int numEnter = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(0, 0, 0, 0);
            enter[i] = p;
            _player.Death();
        }

        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
