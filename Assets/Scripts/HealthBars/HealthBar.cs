using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
   public abstract void ShowHealth(float health, float healthMax);
}
