namespace CaptchaGenerator.Web.HelperClasses;

public static class PublicUtilities
{
    private static Random _randomNumber = new Random((int)DateTime.Now.Ticks);

    public static string GenerateRandomCode2(int totalAlha, int totalNumber)
    {
        var result = "";
        var alphaIndex = 0;

        #region Generate Character

        while (alphaIndex < totalAlha)
        {
            var alphCode = _randomNumber.Next(65, 90);
            var alphChar = Convert.ToChar(alphCode).ToString().ToUpper();
            if (alphChar == "O" ||
                alphChar == "I" ||
                alphChar == "L" ||
                alphChar == "Q") continue;

            result = result + alphChar;
            alphaIndex++;
        }

        #endregion

        #region Generate Generate Number

        var indexLoop = 0;
        while (indexLoop < totalNumber)
        {
            var ch = _randomNumber.Next(0, 9);

            if (ch == 0 ||
                ch == 1 ||
                ch == 7 ||
                ch == 8) continue;

            result = result + ch.ToString();
            _randomNumber.NextDouble();
            _randomNumber.Next(100, 1999);
            indexLoop++;
        }

        #endregion

        return result;
    }

}