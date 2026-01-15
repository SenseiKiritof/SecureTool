# X3SecureTool

## Prerequisites
- **.NET 8**
- **SSecureUtils installed**

## Local build and installation
```
dotnet pack -c Release
dotnet nuget push SecureTool/bin/Release/SecureTool.1.0.0.nupkg --source LocalPackages
dotnet tool install \
  --global \
  --add-source ~/nuget-local \
  SecureTool
```

## Nuget repo installation
```
dotnet tool install --global SecureTool
```

## Utilizzation
In the command line, type `secureTool`
You will be asked to select either encryption or decryption,
```
? What do you want to do?: 
› Encrypt
  Decrypt
```
then you will be prompted to enter the Encryption key, that must be 16 characters long
```
✔ What do you want to do?: Encrypt
? Type the encryption key: {ENC_KEY}
```
change {ENC_KEY} with your encryption key.

then you will be prompted to be processed.
```
✔ Type the encryption key: ********************************
? Type the string to Encrypt: {STRING_TO_ENCRYPT}
```
change {ENC_KEY} with your encryption key.
The tool will then perform the selected operation and display the result.

After the operation is completed, you will be prompted to select either to **Continue** encrypting,
**Restart** the tool, **ChangeMethod** (if you are in encryption, you will pass to decrypt and viceversa) or **Exit**.
```
Here's your result: 0Jhg4Xk92sfufHZStk/qKIzM8se8iu0qZbL1pUnTfDk=
? What do you want to do?: 
› Continue
  Restart
  ChangeMethod
  Exit
```