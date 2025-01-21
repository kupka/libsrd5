[![codecov](https://codecov.io/gh/kupka/libsrd5/branch/main/graph/badge.svg?token=541OS360LT)](https://codecov.io/gh/kupka/libsrd5)

# tl;dr

Want to see libsrd5 in action? [Checkout the live example](https://kupka.github.io/libsrd5-examples/unity/index.html) (only desktop browsers are supported).

# libsrd5

An open source SRD 5.1 library in C#. It aims to implement most of the rules of the [5.1 SRD](https://dnd.wizards.com/articles/features/systems-reference-document-srd) 
with zero dependencies other than the .NET framework itself. Very few modern .NET framework features are used, in order to maximize portability.

The library contains races, classes, equipment, skills, feats, spells and game mechanics from the official SRD5. Please note, particularly for skills and spells,
that while the library contains all entries from the SRD5, not all of them have a useful implementation. For example, it is perfectly possible to have a character
learn and cast a `Thaumaturgy` cantrip. The library will not, however, provide you the semantics of what happens in your game when 
`"Your voice booms up to three times as loud as normal for 1 minute"`. On the other hand, when a character or monster casts a `Magic Missile` spell, the library
will correctly determine whether the target is in range, and how much damage it takes, if any.

## Usage

Add the nuget package to your .NET project and start coding!

```dotnet add <yourproject>.csproj package libsrd5```

You can find examples how to integrate libsrd5 in a Blazor and Unity3D project [here](https://github.com/kupka/libsrd5-examples). 
This example uses a very outdated version of libsrd5, an update will probably arrive in spring 2025.

## Copyright

libsrd5 Copyright 2021-2025, Thomas Kupka

## Current Status

The latest milestone finally contains **all** the monsters and their attacks from the SRD, though not all attack effects are fully implemented.
However, a ton already works, such as poison and grappling effects.

Next milestone will concentrate on implementing the spell effects, then I will work on the character classes.

## Acknowledgements

I would like to thank the creators of the [5e-database](https://github.com/5e-bits/5e-database). Their json
formatted SRD data came in quite handy to automate some pretty tedious tasks.

## License

[![GNU Affero General Public License](https://www.gnu.org/graphics/agplv3-155x51.png)](https://www.gnu.org/licenses/agpl-3.0.html)

libsrd5 is licensed under the GNU Affero General Public License (see LICENSE). 

Any names, values and play mechanics inside the `ogl` subfolder are dual-licensed under either the terms of the Open Game License 1.0a (see libsrd5/ogl/LICENSE-OGL) and the Creative Commons Attribution 4.0 International License ("CC-BY-4.0").

By using and/or distributing libsrd5 in its full form, you must agree to and adhere to the terms of the AGPL <ins>and one of</ins> either the OGL 1.0a or CC-BY-4.0.

This project has chosen to license the SRD 5.1 content under the terms of CC-BY-4.0.

> This work includes material taken from the System Reference Document 5.1 ("SRD 5.1") by Wizards of <br>
> the Coast LLC and available at https://dnd.wizards.com/resources/systems-reference-document. The<br>
> SRD 5.1 is licensed under the Creative Commons Attribution 4.0 International License available at<br>
> https://creativecommons.org/licenses/by/4.0/legalcode.