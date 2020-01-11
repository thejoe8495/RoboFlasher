


# RoboFlasher or Xiaomi Flasher for Windows

> My goal is to create a easy tool for Windows to flash your Roborock. Pack firmwares, backup settings and create a system to change settings for all devices.

---

## Table of Contents

- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
- [Support](#support)
- [License](#license)
- [Thanks](#thanks)


---

## Usage

### First install valetudo
- Reset your roborock from mi cloud
- Connect to roborock's open Wifi
- Discover device
- Copy new firmware pkg in /firmware/ folder
- Change to firmware tab
- Install firmware
- **wait on install finished (not only the download)**
- Change to expert tab
- Select MiIO.config_router
- Insert your WLAN-data in parameters
- Send the WLAN to roborock

---

## Features

- Flash images/firmware/voicepacks
- Custom SSH/MiiO commands

### Comming

- Find roborock token
- Set Up a new Roborock
- Pack new firmwares with webinterface
- Download and install new webinterfaces from web 

---

## Contributing

> To get started...

### Step 1

- **Option 1**
    - 🍴 Fork this repo!

- **Option 2**
    - 👯 Clone this repo to your local machine using `https://github.com/thejoe8495/RoboFlasher.git`

### Step 2

- **HACK AWAY!** 🔨🔨🔨

### Step 3

- 🔃 Create a new pull request using <a href="https://github.com/thejoe8495/RoboFlasher/compare/" target="_blank">`https://github.com/thejoe8495/RoboFlasher/compare/`</a>.

---

## Support

Open a new issue 😉

### Known Issues

- Discover device the app hangs
- SSH Keys with openssl don't work
- (Not testet) Flashing Firmware

---

## Thanks

Thank to Dlid for his MiHome c# Library 
 [![](https://avatars0.githubusercontent.com/u/4271305?s=460&v=4)](https://github.com/dlid/Dlid.MiHome)
 
### Components
https://github.com/dlid/Dlid.MiHome

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://opensource.org/licenses/mit-license.php)