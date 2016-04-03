# Uber Realms #

Uber Realms is a private [Realm of the Mad God](http://uber-realms.com/download.html) (RotMG) server. In recent years, development and updates for RotMG have rapidly decreased. The global user base is still over 100,000 active weekly players, but there is a strong desire for new content and improved game play. The goal of this project is to:

- Make it easier for others to host private RotMG Servers (hosted and local)
- Clean up the existing code to make it less error prone and more efficient
- To provide a fun, more frequently updated, version of the RotMG Official Servers


## How Can I Play? ##

- Visit [Uber Realm's PLAY! Page](http://uber-realms.com/play/)
- Register an account
- Sign in, and play! (:


### Contact Us ###

1. [Uber-Realms Forum](http://uber-realms.com/forum)


## ~~ Index ~~ ##

- Frequently Asked Questions (FAQ)
- Self-Hosting
	- Local Machine (Hamachi)
	- Linux Virtual Private Server (VPS)
- Modifying Existing Code
- Credits


## Frequently Asked Questions (FAQ) ##

**Example question?**
*Exameple Answer*

## How Do I Host A Private Server? ##

Note, there are many different ways to "host" a server for yourself and your friends to play on. The easiest option is to "host" locally. The harder option, the one that will take money, time, and familiarity with servers, is to host using a "virtual private server". However, you will notice less lag, and be able to support more active/online users.

### Local Machine (Hamachi) ###

- Guide coming soon

### Linux Virtual Private Server (VPS) ###

To be expanded. These are just cliff notes at this point

#### Preparing the VPS ####

- [Download the source code as a .zip file](https://github.com/djb-code/fabiano-swagger-of-doom/archive/master.zip)
- Unzip the source code into it's own folder

1. Create a [Digital Ocean](https://m.do.co/c/890ee383410b) Account
2. Create a [new droplet](https://cloud.digitalocean.com/droplets/new) with the following specs:
    - Ubuntu 14.04.4 x64
    - 2 GB RAM / 2 CPUs
    - 40 GB SSD Disk
    - 3 TB Transfer
    - Choose a data center near you / your active players and click "Create"
3. You will get an e-mail with login credentials for your VPS. You will need the following applications:
    - [PuTTY](http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html) To SSH / Remotely login to your server
    - [FileZilla Client](https://filezilla-project.org/) To transfer game files to your server
4. If you are new to using PuTTY or FileZilla, check out:
    - [How to Log Into Your Droplet with PuTTY](https://www.digitalocean.com/community/tutorials/how-to-log-into-your-droplet-with-putty-for-windows-users)
    - [How to Use Filezilla to Transfer and Manage Fiels Securely on your VPS](https://www.digitalocean.com/community/tutorials/how-to-use-filezilla-to-transfer-and-manage-files-securely-on-your-vps)
5. Follow these sets of tutorials to prepare your server to host RotMG
    - [Initial Server Setup with Ubuntu 14.04](https://www.digitalocean.com/community/tutorials/initial-server-setup-with-ubuntu-14-04)
    - [How To Install Linux, Apache, MySQL, PHP (LAMP) stack on Ubuntu 14.04](https://www.digitalocean.com/community/tutorials/how-to-install-linux-apache-mysql-php-lamp-stack-on-ubuntu-14-04)
    - [How To Install and Secure phpMyAdmin on Ubuntu](https://www.digitalocean.com/community/tutorials/how-to-install-and-secure-phpmyadmin-on-ubuntu-12-04)
6. Follow ONLY the TimeZone and FireWall portions of [Additional Recommended Steps for New Ubuntu Servers](https://www.digitalocean.com/community/tutorials/additional-recommended-steps-for-new-ubuntu-14-04-servers)
    - Make sure to open the following ports:
 
![Open Ports](/docs/open-ports.png?raw=true "Open Ports")

7. Add the game's database to your MySQL instance
    - Go to http://yourVPSip/phpmyadmin and sign in
    - Click the "SQL" menu item at the top of the screen
    - Navigate to the source code's "db" folder and open `rotmgprod.sql` with notepad or a text editor
    - Copy and paste the text from `rotmgprod.sql` to the text field in your phpMyAdmin
    - Click "Go"
    

#### Customizing Source Code ####

1. Download and Install [Visual Studio Community](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)
2. Open the source code's .SLN file (it's in the root/main folder) with Visual Studio
3. Update the following files with your credentials:
    - AdminPanel/AdminPanel.cs
    - AdminPanel/Login.cs
    - server/Program.cs
    - server/server.cfg
    - server/list.cs
    - wServer/Program.cs
    - wServer/wServer.cfg
4. Build the solution to create the executable files you need to deploy:
    - Right click the `server` project in "Solution Explorer" and select "Set As Startup Project"
    - From the menu, select `Build` --> `Clean Solution`
    - Select `Build` --> `Rebuild Solution`
5. Upload the compiled/built code to your VPS
    - Open Filezilla and connect to your VPS/Droplet (user account, not root/admin)
    - Right click and create a new folder with the name "rotmg"
    - On your PC, navigate to the source code's main folder --> `bin` --> `Debug` 
    - Drag the contents of the `Debug` folder into the "rotmg" folder showing in Filezilla
    

#### Customizing Game Client ####

9. Install software to allow server's to run
    - Mono
    - Screen
10. Start server
11. Turn on crontab to restart


#### Starting/Stopping Server ####


#### Automation and Debugging ####


## How Do I Add or Change A Map/Character/Monster? ##

- Coming soon


##Additional License information

This is a fork of: [ossimc82's Repo](https://github.com/ossimc82/fabiano-swagger-of-doom). You are free to use this source as long as you credit the following contributers:

- ossimc82 | Fabian Fischer
- Zabex | Daniel Brown
- Uber | Joey Brown
- C453
- Trapped
- Donran
- creepylava
- Krazyshank
- Barm
- Nilly
- sebastianfra12
- Kieron