using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long value)
    {
        byte[] buffer = new byte[9];
        byte prefix;
        byte[] payload;

        if (value >= 0 && value <= ushort.MaxValue)
        {
            prefix = 2;
            payload = BitConverter.GetBytes((ushort)value);
        }
        else if (value > ushort.MaxValue && value <= uint.MaxValue)
        {
            if (value <= int.MaxValue)
            {
                prefix = 252;
                payload = BitConverter.GetBytes((int)value);
            }
            else
            {
                prefix = 4;
                payload = BitConverter.GetBytes((uint)value);
            }
        }
        else if (value > uint.MaxValue && value <= long.MaxValue)
        {
            prefix = 248;
            payload = BitConverter.GetBytes(value);
        }
        else if (value < 0 && value >= short.MinValue)
        {
            prefix = 254; // 256 - 2
            payload = BitConverter.GetBytes((short)value);
        }
        else if (value >= int.MinValue && value < short.MinValue)
        {
            prefix = 252; // 256 - 4
            payload = BitConverter.GetBytes((int)value);
        }
        else
        {
            prefix = 248; // 256 - 8
            payload = BitConverter.GetBytes(value);
        }

        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        var prefix = buffer[0];

        var result = prefix switch
        {
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            8 => BitConverter.ToInt64(buffer, 1),
            254 => BitConverter.ToInt16(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            248 => BitConverter.ToInt64(buffer, 1),
            _ => 0
        };

        return result;
    }
}
