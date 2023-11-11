using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is our abstraction for our class example of the Strategy Pattern.
/// In this example we create an abstract base, and child classes must implement
/// their own specific Shoot behaviors.
/// The advantage of the inheritance example over composition is that we can
/// hold more base data and state for more complex objects, like weapons.
/// </summary>

namespace Examples.Strategy
{
    public abstract class WeaponBase : MonoBehaviour
    {
        
        public abstract void Shoot();

     
    }
}

