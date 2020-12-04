using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public static GameObject PLAYER = Resources.Load<GameObject>("Prefabs/Snowman");
    public static GameObject BONUS = Resources.Load<GameObject>("Prefabs/Bonus");
}
