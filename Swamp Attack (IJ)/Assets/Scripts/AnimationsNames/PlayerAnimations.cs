using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimations
{
    public static class Idle
    {
        public static string GetNameWithGun(string gunName)
        {
            return $"{gunName}Idle";
        }
    }

    public static class Attack
    {
        public static string GetNameWithGun(string gunName)
        {
            return $"{gunName}Attack";
        }
    }

    public static class Dying
    {
        public static string GetNameWithGun(string gunName)
        {
            return $"{gunName}Dying";
        }
    }
}
