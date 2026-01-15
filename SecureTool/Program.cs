using SecureTool;

var (operation, key) = Methods.SelectOptions(); 

Methods.RequestPassword(operation, key);

/*var secret = Prompt.Password($"Type the string to {operation}", validators: [Validators.Required()]);

var result = operation == Operations.Decrypt ? SecureUtils.Decrypt(secret, key) : SecureUtils.Encrypt(secret, key);

Console.WriteLine($"Here's your result: {result}");*/
return;
