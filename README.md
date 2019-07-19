# Morph

Morph is a package that aims to simplify tweening in Unity. Provides coroutine friendly methods that can be used for smooth interpolation. Morphs are also easy to configure in the inspector, allowing the adjustment of handy options like duration and easing functions.

## Installation

`TODO`

## Why

Creating transitions and smooth value movements in Unity often requires writing coroutines that involve the exact same loop that will repeatedly run a lerp function until it is completed.
Furthermore to create juicier effects, often we define many fields like speed and animation curves which can lead to a lot of clutter.

Morph provides an easy to use interface that allows you to perform a transition forwards or backwards without needing write the same old boilerplate lerping coroutines that were mentioned previously.
The main idea is to allow developers to focus on what they want interpolated and have Morph take care of the timing and execution.

## Usage

Getting started with Morphs is straightforward, follow these steps:

1.	Add a `Morphs.SmoothMorph` field to one of your MonoBehaviours and then mark it with the `SerializeField` attribute.
2.	Add the `IMorphTarget` interface to your MonoBehaviour and implement the `Interpolate` method.
3.	Start a coroutine and call the morph using the direction you wish for it to play in, don't forget to specify a target for the morph.

Below is a simple example of a morph that will move the target's position up 10 units:

```

public class MorphExample : MonoBehaviour, IMorphTarget {
	
	[SerializeField]
	private SmoothMorph _morph;

	// Run Start as a coroutine and wait for the forwads morph.
	public IEnumerator Start () {
		yield return _morph.Forwards(this);
	}


	//Interpolate given a specific time step.
	public void Interpolate(float time) {
		transform.position = Vector3.Lerp(Vector3.zero, Vector3.up * 10f, time);
	}

}

```

To change settings like the duration of the morph or the curve used to perform easing, select your SmoothObject component in the inspector. Additionally, be aware that you can
pass in however many morph targets as you want at a time.

## License

This package is available as open source under the terms of the MIT License.