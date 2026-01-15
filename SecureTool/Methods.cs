using Sharprompt;
using SSecureUtils.Utils;

namespace SecureTool;

public static class Methods
{
    public static  (Operations, string) SelectOptions()
    {
        var operation = Prompt.Select<Operations>("What do you want to do?");

        // Password input
        var key = Prompt.Password("Type the encryption key", validators: [Validators.Required(), Validators.MinLength(16)]);
    
        return (operation, key);
    }

    public static void RequestPassword(Operations operation, string key)
    {
        while (true) {
            var secret = Prompt.Password($"Type the string to {operation}", validators: [Validators.Required()]);

            var result = operation == Operations.Decrypt ? SecureUtils.Decrypt(secret, key) : SecureUtils.Encrypt(secret, key);

            Console.WriteLine($"Here's your result: {result}");

            var continueOrExit = Prompt.Select<NextAction>("What do you want to do?");

            switch (continueOrExit)
            {
                case NextAction.Continue:
                    continue;
                case NextAction.Change:
                    (operation, key) = SelectOptions();
                    continue;
            }

            break;
        }
    }
}