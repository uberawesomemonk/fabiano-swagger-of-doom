###Introduction###

This "tutorial" was created as a set of notes for myself while I helped my younger brother set up a VPS that could host RotMG. I've since filled in the spots with a little more detail, and created a repository to track the changes to his version of the source code. The tutorial below uses:

- Fabiano derived source
- Linux VPS
- Modified Client

**And creates a hosted RotMG Private server that allows for custom hacks, and easily supports at least 20 active users with little to no lag.**

## Linux Virtual Private Server (VPS) ##


**Why a VPS instead of Hamachi?**

Hamachi works well enough for a private server you play on "every now and then" with a couple of friends. If you're looking for something more robust, secure, and scalable, then you will need a VPS. What this means is, a VPS is not limited to the specs of your machine. They can add more RAM, CPU, etc. on demand as the server needs it. They are also more finely tuned to handle the amount of incoming/outgoing traffic -- ultimately reducing the amount of lag.

**Why a Linux VPS instead of a Windows VPS?**

That's a good question, especially considering the game is programmed in C# .NET, making it native to the Windows Operating system. Truthfully, hosting on a Windows VPS would be easier. However, you get much less "hardware" for the amount you pay. This allows you to support more active players per dollar you spend on hosting. Microsoft has also begun to move toward Linux compatibility and Open Source support. As far as stability is concerned, I've been able to run this RotMG server for weeks at a time with many active players and experience little to no downtime.

### Preparing the VPS ###

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
 
![Open Ports](/docs/img/open-ports.png?raw=true "Open Ports")

7. Add the game's database to your MySQL instance
    - Go to http://yourVPSip/phpmyadmin and sign in
    - Click the "SQL" menu item at the top of the screen
    - Navigate to the source code's "db" folder and open `rotmgprod.sql` with notepad or a text editor
    - Copy and paste the text from `rotmgprod.sql` to the text field in your phpMyAdmin
    - Click "Go"
    

### Customizing Source Code ###

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
    

### Customizing Game Client ###

This section was influenced largely by this [flashhacking.net thread](http://flashacking.net/showthread.php?7540-Tutorial-how-to-decompile-recompile-a-swf-file-with-rabcdasm). It covers:

- How to "Decompile" (take apart) a .swf file so that it can be modified
- Which values to modify for OUR SPECIFIC Client/Source to work with your VPS
- How to "Recompile" (put together) a decompiled .swf so that it can be used

To start, there are many different program's that can be used to modify .SWF files. We use rabacdasm here mainly out of personal preference. You're more than welcome to try other methods, but I cannot vouch for them. If you're using our source, the .ZIP contains rabacdasm. If you're using a different source, rabacdasm can be downloaded from its creators: HERE

**Using Our Source:**
1. Open up the "Root" folder of the source code
2. Navigate to --> Client Updater --> bin --> Final
3. Double click "decompile.bat"
4. Open the newly created "client-1.abc" with notepad
    - Find and replace `127.0.0.1` with `yourserverip:8888` (2 places)
    - Save and close the text document
5. Double click "recompile.bat"

Client.swf is now configured to work with your hosted server. Distribute it, use it locally, or embed it into a web page.


**Using Any Source:**
- In Progress


### Starting/Stopping Server ###

1. Use PuTTY to SSH into your VPS (user account, not root/admin)
2. Install packages necessary to run server executables:
    - `sudo apt-get install mono-complete`
    - `sudo apt-get install screen`
3. Start the RotMG Server
    - `sudo screen -S server`
    - `cd /home/{username}/rotmg/`
    - `mono ./server.exe`
    - Detach from the screen terminal (<kbd>CTRL</kbd>+<kbd>a</kbd>, <kbd>CTRL</kbd>+<kbd>d</kbd>)
4. Start the RotMG wServer
    - `sudo screen -S wserver`
    - `cd /home/{username}/rotmg`
    - `mono ./wServer.exe`
    - Detach from the screen terminal (<kbd>CTRL</kbd>+<kbd>a</kbd>, <kbd>CTRL</kbd>+<kbd>d</kbd>)
5. You should now be able to connect to the game using your modified game client! If you're not able to, check out the Debugging section of the readme.


### Automation and Debugging ###

Debugging is incredibly important. When things go wrong, it's important that you know how/where/why things went wrong so you can begin to fix the problem.

11. Turn on crontab to restart