# Morph

Morph is a Unity Package that helps in creating coroutine-based tweens. Define morphs for different properties and compose great-looking effects with ease.

## Installation

Add the Morph Package by editing your `manifest.json` file to include the following line:

```
{
  "dependencies": {
    "com.catsuko.morph": "https://github.com/Catsuko/Morph.git"
}
```

## Why

Often the need arises for a simple coroutine to take a value from A to B which leads to rewriting the same loops and tween specific behaviour over and over again.
The Morph package aims to simplify the process of creating coroutine-based tweens by doing the majority of this work for the developer.

## Usage

### Morphs

Morphs represent a change you wish to make over a period of time. This could be anything from the position of a Transform from A to B or the opacity of an image
fading in and out. Add a new Morph is as easy as implementing the `IMorph` interface, the Frame method will define the change that should happen at a specific
interval during the tween.

```
using UnityEngine;
using Morph;

public class PositionMorph : IMorph
{
	private readonly Vector3 _start, _end;
	private readonly Transform _transform;

	public PositionMorph (Vector3 start, Vector3 end, Transform transform) 
	{
		_start = start;
		_end = end;
		_transform = transform;
	}

	public void Frame (float time) 
	{
		_transform.position = Vector3.Lerp(_start, _end, time);
	}
}

```

### Morphers

Morphers are used to play Morphs, both the `Forwards` and `Backwards` methods will return an `IEnumerator` which can be started as a coroutine.

```
using UnityEngine;
using Morph;

public class MorpherExample : MonoBehaviour
{
	[SerializedField]
	private SmoothMorpher _morpher;

	public void Start () 
	{
		IMorph positionMorph = new PositionMorph(Vector3.zero, Vector3.one, transform);
		StartCoroutine(_morpher.Forwards(positionMorph));
	}
}
```

### Easing

Use the `WithEasing` method on an `IMorph` to add easing. The `AnimationCurve` you provide will be used to offset the time allowing you to create
smoother tweens.

```
AnimationCurve easingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
IEnumerator tween = morpher.Forwards(_position.WithEasing(easingCurve));
```

### Combining Morphs

The `And` method can be called on a `IMorph` to combine it with other Morphs which allows you to play multiple Morphs at the same time.

```
IEnumerator tween = morpher.Forwards(_position.And(_scale));
```

### Sequencing Morphs

You can easily create sequences of coroutines using the `Then` method. Useful for chaining morphs together and running them as a single coroutine.

```
IEnumerator tween = morpher.Forwards(_position).Then(morpher.Backwards(_position));
```

## License

This package is available as open source under the terms of the MIT License.
