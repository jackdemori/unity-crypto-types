# Unity CryptoTypes
Custom primitive types with some tricks to prevent memory hacking.

All numeric types use a Caesar cipher style algorithm to encrypt the data, instead of using a fixed offset (which can be easily hacked) we generate a random offset on the variable constructor.