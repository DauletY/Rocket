using System.Security.Cryptography;
using UnityEngine;

namespace Assets.Rocket.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public GameObject @object;
        AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                GameObject go = Instantiate(@object, transform.position, Quaternion.identity);
                ParticleSystem particle = go.GetComponent<ParticleSystem>();
                Destroy(particle.gameObject, 1f);
                Destroy(this.gameObject, 1f);
                audioSource.Play();
                
            }
        }
    }
}
