# Morph

Morph is a package that aims to simplify tweening in Unity. Provides coroutine friendly methods that can be used for smooth interpolation. Morphs are also easy to configure in the inspector, allowing the adjustment of handy options like duration and easing functions.

## Installation

`TODO`

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
using Morphs;

public class PositionMorph : MonoBehaviour 
{
	[SerializedField]
	private Vector3 _start, _end;

	public void Frame (float time) 
	{
		transform.position = Vector3.Lerp(_start, _end, time);
	}
}

```

### Morphers

Morphers are used to play Morphs, both the `Forwards` and `Backwards` methods will return an `IEnumerator` which can be started as a coroutine.

```
using UnityEngine;
using Morphs;

public class MorpherExample : MonoBehaviour
{
	[SerializedField]
	private PositionMorph _position;
	[SerializedField]
	private SmoothMorpher _morpher;

	public void Play () 
	{
		StartCoroutine(_morpher.Forwards(_position));
	}
}
```

### Easing

Use the `WithEasing` method on an `IMorph` to add easing. The `AnimationCurve` you provide will be used to offset the time allowing you to create
smoother tweens.

```
var easingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
var tween = morpher.Forwards(_position.WithEasing(easingCurve));
```

### Combining Morphs

The `And` method can be called on a `IMorph` to combine it with other Morphs which allows you to play multiple Morphs at the same time.

```
var tween = morpher.Forwards(_position.And(_scale));
```

### Sequencing Morphs

You can easily create sequences of coroutines using the `Then` method. Useful for chaining morphs together and running them as a single coroutine.

```
var tween = morpher.Forwards(_position).Then(morpher.Backwards(_position));
```

## License

This package is available as open source under the terms of the MIT License.