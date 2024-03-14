namespace AudioProcessing.Common
{
    /// <summary>
    /// Provides a converter from <see cref="float"/> buffer to <see cref="byte"/> buffer and viceversa.
    /// </summary>
    public static class BufferConverter
    {
        /// <summary>
        /// Converts the input <see cref="byte"/> buffer to an output <see cref="float"/> buffer,
        /// normalized in the range [-1,+1].
        /// </summary>
        /// <param name="byteBuffer">The input <see cref="byte"/> buffer to convert in a <see cref="float"/> buffer.</param>
        /// <returns>
        /// An output <see cref="float"/> buffer containing the converted samples from the input <paramref name="byteBuffer"/>.
        /// </returns>
        public static float[] ConvertByteToFloat(byte[] byteBuffer)
        {
            int numSamples = byteBuffer.Length / sizeof(short);
            float[] floatBuffer = new float[numSamples];

            // Convert from byte to float
            for (int i = 0; i < numSamples; i++)
            {
                byte byte1 = byteBuffer[i * sizeof(short)];
                byte byte2 = byteBuffer[i * sizeof(short) + 1];

                floatBuffer[i] = ((byte2 << 8) | byte1) / short.MaxValue;
            }
            return floatBuffer;
        }

        /// <summary>
        /// Converts the input <see cref="float"/> buffer (normalized in the range [-1,+1]),
        /// to an output <see cref="byte"/> buffer.
        /// </summary>
        /// <param name="floatBuffer">The input <see cref="float"/> buffer to convert in a <see cref="byte"/> buffer.</param>
        /// <returns>
        /// An output <see cref="byte"/> buffer containing the converted samples from the input <paramref name="floatBuffer"/>.
        /// </returns>
        public static byte[] ConvertFloatToByte(float[] floatBuffer)
        {
            int numSamples = floatBuffer.Length * sizeof(short);
            byte[] byteBuffer = new byte[numSamples];

            // Convert from float to byte
            for (int i = 0; i < floatBuffer.Length; i++)
            {
                // Get the samples from the float buffer
                short sample = (short)(floatBuffer[i] * short.MaxValue);

                byteBuffer[i * sizeof(short)] = (byte)(sample & 0xFF);
                byteBuffer[i * sizeof(short) + 1] = (byte)((sample >> 8) & 0xFF);
            }
            return byteBuffer;
        }
    }
}
