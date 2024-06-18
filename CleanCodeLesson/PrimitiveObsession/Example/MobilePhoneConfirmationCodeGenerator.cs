namespace CleanCodeLesson.PrimitiveObsession.Example;

using System.Globalization;
using System.Security.Cryptography;

public static class MobilePhoneConfirmationCodeGenerator
{
    private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

    public static string Generate(int length = 4)
    {
        if (length is < 1 or > 8)
            throw new ArgumentException("Код должен быть длиной от 1 до 8 символов.");

        return Random.GetRandomInt32((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length) - 1)
            .ToString(CultureInfo.InvariantCulture);
    }

    private static int GetRandomInt32(this RandomNumberGenerator generator, int minValue, int maxValue)
    {
        return (int)generator.GetRandomInt64(minValue, maxValue);
    }

    private static long GetRandomInt64(this RandomNumberGenerator generator, long minValue, long maxValue)
    {
        ArgumentNullException.ThrowIfNull(generator);
        if (minValue > maxValue)
            throw new ArgumentException("Минимальное значение не может быть больше максимального.");

        if ((minValue == long.MinValue) && (maxValue == long.MaxValue))
            return generator.GetRandomInt64();

        var valueCount = unchecked((ulong)(maxValue - minValue + 1));
        ulong fullScaleRandomValue;

        // Предотваращаем искажение пространства вариантов из-за некратности
        // множества значений ulong множеству допустимых значений результата.
        do
        {
            fullScaleRandomValue = generator.GetRandomUInt64();
        } while (ulong.MaxValue / valueCount == fullScaleRandomValue / valueCount);

        var scaledRandomValue = fullScaleRandomValue % valueCount;

        return unchecked((long)scaledRandomValue + minValue);
    }

    private static ulong GetRandomUInt64(this RandomNumberGenerator generator)
    {
        ArgumentNullException.ThrowIfNull(generator);

        var randomBytes = new byte[sizeof(ulong)];
        generator.GetBytes(randomBytes);
        var randomUInt64Array = new ulong[1];
        Buffer.BlockCopy(randomBytes, 0, randomUInt64Array, 0, sizeof(ulong));
        return randomUInt64Array[0];
    }

    private static long GetRandomInt64(this RandomNumberGenerator generator)
    {
        ArgumentNullException.ThrowIfNull(generator);

        return unchecked((long)generator.GetRandomUInt64());
    }
}