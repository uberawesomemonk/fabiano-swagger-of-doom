# DJB Trio

This source is a fork of [Fabiano Swagger of Doom (FSOD)](https://github.com/ossimc82/fabiano-swagger-of-doom). Over 
time, we've also added a decompiled SWF Client source that 
[can be found here](https://github.com/kaos00723/RotMG_Client_27.7.X2). Information about how to modify, build, and
deploy the `Server`, `WorldServer` and `Client` are included below.

## About

## Project Layout
```
.
├── Admin Panel
├── Behavior Converter
├── db
├── DungeonGen
├── Json2Wmap
├── server
├── terrain
├── wServer
.   ├── file21.ext
    ├── file22.ext
    └── file23.ext
```

## Configuration

*Client Source:*

- `RSA_PUBLIC_KEY`: `com/company/assembleegameclient/parameters/Parameters.as`
- `SERVER:String`: `kabam/rotmg/application/impl/ProductionSetup.as`
- `ENCRYPTED:String`: `kabam/rotmg/application/impl/ProductionSetup.as`

`wserver/networking/Client.cs`
- The build version of the client needs to match the version the server expects
- `You should update dat0.xml and dat1.xml with any new items from the client XML's.`

## Resources

### Repositories of Note:

Repositories of other/similar projects. We're not the only people running and customizing ROTMG ;)

* [Nilly's Realm Server & World Server](https://github.com/cp-nilly/NR-CORE)
* [Nilly's Realm Client](https://github.com/cp-nilly/NR-27.7.X13)

### Useful Tutorials:

We've used these in whole or in part to help us at various points.

* [How to host using a Linux VPS](http://www.mpgh.net/forum/showthread.php?t=1101434)
* [27.7.X2 AS3 Client to FSOD](http://www.mpgh.net/forum/showthread.php?t=1163271)


## License Information

You are free to use this source as long as you credit the following contributers:

##### _Contributors to "Uber Realms" Source:_

csengineer13, uberawesomemonk

##### _Contributors to "Fabiano Swagger of Doom" Source:_
ossimc82 | Fabian Fischer, C453, Trapped, Donran, creepylava, Krazyshank, Barm, Nilly, sebastianfra12, Kieron