using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public static GameObject PLAYER { get; private set; } = Resources.Load<GameObject>("Prefabs/Snowman");
    public static GameObject BONUS { get; private set; } = Resources.Load<GameObject>("Prefabs/Bonus");

    public static AudioClip JUMP { get; private set; } = Resources.Load<AudioClip>("Sounds/jump");
    public static AudioClip THROW { get; private set; } = Resources.Load<AudioClip>("Sounds/throw");
    public static AudioClip SNOWBALL_HIT { get; private set; } = Resources.Load<AudioClip>("Sounds/snowball_hit");
    public static AudioClip COLLECT { get; private set; } = Resources.Load<AudioClip>("Sounds/collect");

}
