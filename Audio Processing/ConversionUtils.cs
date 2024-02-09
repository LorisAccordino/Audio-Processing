namespace AudioProcessing
{
    public class ConversionUtils
    {
        public static short[] ConvertFloatArrayToShortArray(float[] floatArray)
        {
            short[] shortArray = new short[floatArray.Length];
            for (int i = 0; i < floatArray.Length; i++)
            {
                float normalizedValue = Math.Clamp(floatArray[i], -1.0f, 1.0f);
                short pcmValue = (short)(normalizedValue * short.MaxValue);
                shortArray[i] = pcmValue;
            }
            return shortArray;
        }


        public static byte[] ConvertFloatArrayToByteArray(float[] floatArray)
        {
            int byteCount = floatArray.Length * sizeof(float);
            byte[] byteArray = new byte[byteCount];
            Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteCount);
            return byteArray;
        }

        public static byte[] ConvertShortArrayToByteArray(short[] shortArray)
        {
            byte[] byteArray = new byte[shortArray.Length * sizeof(short)];
            Buffer.BlockCopy(shortArray, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }
    }
}
