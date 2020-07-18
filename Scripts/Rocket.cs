using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float time = 1;
    public Transform _haed;
    public GameObject _projectile;
    public GameObject _projectileParticle;
    public float _projectile_speed;
    public float destroy_time;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= time)
        {

            GameObject go = Instantiate(_projectile, _haed.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(_projectile_speed, _projectile_speed, _projectile_speed), ForceMode.Impulse);

            GameObject _go = Instantiate(_projectileParticle, _haed.position, Quaternion.identity);
            Transform _transform = _go.GetComponent<Transform>();
            ParticleSystem particle = _transform.GetComponent<ParticleSystem>();
            Destroy(_transform.gameObject, destroy_time);
            audioSource.Play();
        }
    }
}
