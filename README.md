# SecureTool

## Prerequisites
- **.NET 8**
- **SSecureUtils 1.1.0 or later installed**

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

## Update
```
dotnet tool update --global SecureTool
```

Needed after every published version. Until you update, the tool keeps producing
the previous format: still readable everywhere, it just doesn't gain the tamper
detection.

From a local feed:
```
dotnet tool update --global SecureTool --add-source ~/nuget-local
```

To check which version is installed:
```
dotnet tool list --global | grep securetool
```

## Utilizzation
In the command line, type `secureTool`
You will be asked to select either encryption or decryption,
```
? What do you want to do?: 
› Encrypt
  Decrypt
```
then you will be prompted to enter the Encryption key, which must be at least 16 characters long
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

## Encrypted value format

Since version 1.1.0 the encrypted values carry a `v2:` prefix and use AES-GCM,
which hides the content *and* detects tampering: an altered value is rejected
instead of being decrypted into something else.

```
Here's your result: v2:0Jhg4Xk92sfufHZStk/qKIzM8se8iu0qZbL1pUnTfDk=
```

Values produced by earlier versions have no prefix and are still readable, both by
this tool and by anything using SSecureUtils. **Nothing already encrypted needs to
be re-encrypted**: values can migrate whenever they happen to be touched.

Decrypting with the wrong key, or a value that has been tampered with, now fails
with an error instead of returning garbage.
