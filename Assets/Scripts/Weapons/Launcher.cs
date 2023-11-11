using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an implementation of our abstract base class to use with
/// our Strategy Pattern inheritance example. The Launcher technically
/// uses a lot of the same Shoot() code from the Blaster, but it can be
/// customized individually if needed with this setup
/// </summary>

namespace Examples.Strategy
{
    public class Launcher : WeaponBase
    {
        public GameObject projectile;
	    public float power = 10.0f;
        public AudioClip shootSFX;

        public override void Shoot()
        {
            
			// if projectile is specified
			if (projectile)
			{
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

				// if the projectile does not have a rigidbody component, add one
				if (!newProjectile.GetComponent<Rigidbody>()) 
				{
					newProjectile.AddComponent<Rigidbody>();
				}
				// Apply force to the newProjectile's Rigidbody component if it has one
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
				
				// play sound effect if set
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
						// play the sound clip through the AudioSource component on the gameobject.
						// note: The audio will travel with the gameobject.
						newProjectile.GetComponent<AudioSource> ().PlayOneShot (shootSFX);
					} else {
						// dynamically create a new gameObject with an AudioSource
						// this automatically destroys itself once the audio is done
						AudioSource.PlayClipAtPoint (shootSFX, newProjectile.transform.position);
					}
				}
			}
		

        }
    }
}
