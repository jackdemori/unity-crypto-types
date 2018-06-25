# Unity CryptoTypes
Custom primitive types with some tricks to prevent memory hacking. Based on a practical tutorial to hack (and protect) Unity games Alan Zucconi.(2015). http://www.alanzucconi.com/2015/09/02/a-practical-tutorial-to-hack-and-protect-unity-games/

All numeric types use a Caesar cipher style algorithm to encrypt the data, instead of using a fixed offset (which can be easily hacked) we generate a random offset on the variable constructor.