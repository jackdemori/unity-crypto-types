# Unity Crypto Types
Custom primitive types with some tricks to prevent memory hacking.

Based on a practical tutorial to hack (and protect) Unity games Alan Zucconi. (2015).
http://www.alanzucconi.com/2015/09/02/a-practical-tutorial-to-hack-and-protect-unity-games/

All types uses a Caesar cipher style algorithm to encrypt the data, instead of using a fixed offset (which can be easily hacked digging into the source code) we generate a random offset on the variable constructor.

> NOTICE: The API is a work in progress and has not be totally tested.

## Usage

You can use this library in your game by downloading and importing its content of the Assets folder. All crypto types can be used in the same way of the primitive types you're used to.

```C#
using CryptoTypes;
...
public CryptoInt a = 1;
public CryptoLong b = 2;

public CryptoFloat height = 1.75f;
private CryptoDouble pi = 3.141592;
...
var random = height * pi + (a * b);
```

This library was made using Unity 2018.1.0f2 but it should work in any version from 5.X.
