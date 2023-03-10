using UnityEngine;

public abstract class AudioEvent : ScriptableObject
{
	public abstract void PlayOneShot(AudioSource source);
}