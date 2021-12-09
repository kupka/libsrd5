[![codecov](https://codecov.io/gh/kupka/libsrd5/branch/main/graph/badge.svg?token=541OS360LT)](https://codecov.io/gh/kupka/libsrd5)

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

## Copyright

libsrd5 Copyright 2021, Thomas Kupka

## License

[![GNU Affero General Public License](https://www.gnu.org/graphics/agplv3-155x51.png)](https://www.gnu.org/licenses/agpl-3.0.html)

libsrd5 is licensed under the GNU Affero General Public License (see LICENSE). 

Any names, values and play mechanics inside the `ogl` subfolder are licensed under the terms of the Open Game License (see libsrd5/ogl/LICENSE-OGL). 

By using and/or distributing libsrd5 in its full form, you must agree to and adhere to the terms of both licenses.