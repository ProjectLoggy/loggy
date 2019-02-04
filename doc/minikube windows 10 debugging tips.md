# Minikube Windows 10 Debugging Tips

Minikube can be tricky to run on Windows 10, but these tips should help you get un-stuck.

This document, written in Feb 2019, refers to versions:

* Minikube v0.33.1
* Windows v10.0.17134.0

First off, when launching or installing Minikube, **always do so from an elevated command prompt**. Minikube needs admin permissions, and will likely fail with confusing error messages if you run from a normal un-elevated command prompt.

Download and install [Minikube](https://kubernetes.io/docs/tasks/tools/install-minikube/) using [Chocolatey](https://chocolatey.org/) (a Windows package manager).

## How to start Minikube on Windows 10

The official Minikube documentation states that you just need to run `minikube start` to  get going, but it's more complicated than that on Windows.

Steps:

1. Open "Hyper-V Manager".
2. Click on Actions -> Virtual Switch Manager
3. Add a new virtual network switch.
    - Give the new switch a name that's easy to remember (Eg. "minikubewifi")
    - **Important:** Link to "External Network" and make sure to choose the same kind of connection that your host machine is currently using! (eg. Ethernet vs. Wifi)
4. Run minikube from the commandline **with admin permissions**:
    - `minikube start --vm-driver="hyperv" --hyperv-virtual-switch="minikubewifi" --v=9`
    - Note the use of vm-driver and -hyperv-virtual-switch
    - Use the -v=9 (or -v=10) flag to show diagnostic info. You will need this if Minikube throws startup errors.
5. Run `minikube status` or `minikube dashboard` to view info about the cluster.

The following section describes how to debug some common issues.


## Debugging various kinds of errors

These steps helped us to get Minikube running locally. If there are better approaches, please send a PR to update these documents, or log an issue.


### 1. "Minikube start" fails with a vague "Exit status 1" error message.

* Run with -v=10 flag to ensure you get diagnostic info and error messages, then try again.
* Ensure you are running the command prompt as administrator.


### 2. Minikube hangs at "Starting VM..." step.

* Ensure the virtual network connection you are using (eg. "minikubeeth") is on the same type of network you are using (eg. ethernet/wifi).
* Run with -v=10 flag to ensure you get diagnostic info about what minikube is trying to do.


### 3. Hyper-V crashes when I try to add a new virtual switch.

If Hyper-V crashes with error message "Error applying Virtual Switch Properties changes. Failed while adding virtual Ethernet switch connections", consider doing the following:

* Run `netcfg -d` from an elevated command prompt. **See warning below!**
* **Warning:** This will delete network adapters from your machine, so that they are re-created after a restart. This seems to put Hyper-V in a better state. Use at your own risk.


### 4. Minikube fails to start, stop or delete and complains about a missing config.json file.

When performing some minikube actions, you might get an error reporting that the following file is missing: C:\users\username\.minikube\machines\minikube\config.json

To get past this error, do the following:

- Open Hyper-V Manager.
- Stop minikube virtual machine.
- Delete minikube virtual machine.
- Open Explorer and go to folder: C:\users\username\.minikube\machines
- Delete minikube folder (this will delete the minikube virtual machine and associated configuration).
- Open an elevated command prompt and start from scratch: `minikube start --vm-driver="hyperv" --hyperv-virtual-switch="minikubewifi" --v=9`

This should re-create the Minikube virtual machine in a working state.