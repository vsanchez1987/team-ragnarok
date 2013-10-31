using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameSounds{
	public AudioClip HeavyMissile;
	public AudioClip Sheep;
	public AudioClip Block;
}

public class SoundManager : MonoBehaviour
{
	public GameSounds gameSounds;
}

