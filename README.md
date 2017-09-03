# DJB Code

This source is a fork of [Fabiano Swagger of Doom (FSOD)](https://github.com/ossimc82/fabiano-swagger-of-doom). Over 
time, we've also added a decompiled SWF Client source that 
[can be found here](https://github.com/kaos00723/RotMG_Client_27.7.X2). Information about how to modify, build, and
deploy the `Server`, `WorldServer` and `Client` are included below.

## Contributing

1. Fork this repository
2. Clone the forked repository
3. Before committing code, create a branch-per-feature, or branch-per-bug
4. Create pull requests against `djb-code\dev`

```
.
├── master
│   ├── release/v0.1.1
│   └── release/v0.1.0
└── dev
    ├── {user}/name-of-feature-or-bugfix
    ├── {user}/name-of-feature-or-bugfix
    └── {user}/name-of-feature-or-bugfix
```

5. In an ideal world, someone will review your pull request, and after some back and forth, it will be merged into the `master` branch. This will trigger an automated build, test, and deploy to the Production Environment. Commit messages will be used to build a release description.

## Getting Started

### App Server & World Server

#### Requirements
- VisualStudio Community 2017
- Local MySQL Database (Or a remote one you can connect to)

#### Overview

```
.
├── Admin Panel
├── Behavior Converter
├── db
├── DungeonGen
├── Json2Wmap
├── server
    ├── server.cfg
    └── server.local.cfg
├── terrain
└── wServer
    ├── wServer.cfg
    └── wServer.local.cfg
```


### Configuration

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