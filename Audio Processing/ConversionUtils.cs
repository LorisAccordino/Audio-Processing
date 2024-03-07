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

        public static short[] ConvertFloatArrayToShortArray(float[] floatArray, float prec)
        {
            if (prec <= 0)
            {
                throw new ArgumentException("La precisione deve essere maggiore di 0.");
            }

            short[] shortArray = new short[floatArray.Length];
            int maxShortValue = short.MaxValue;
            int minShortValue = short.MinValue;

            int precision = (int)(maxShortValue / prec);

            for (int i = 0; i < floatArray.Length; i++)
            {
                float normalizedValue = Math.Clamp(floatArray[i], -1.0f, 1.0f);
                float scaledValue = normalizedValue * maxShortValue;
                short pcmValue = (short)((int)(scaledValue / precision) * precision);
                pcmValue = (short)Math.Clamp(pcmValue, minShortValue, maxShortValue);
                shortArray[i] = pcmValue;
            }

            return shortArray;
        }




        public static byte[] ConvertShortArrayToByteArray(short[] shortArray)
        {
            byte[] byteArray = new byte[shortArray.Length * sizeof(short)];
            Buffer.BlockCopy(shortArray, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }
    }
}
