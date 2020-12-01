namespace OnPipe.Util
{
    public static class Util
    {
        private static float[] _scaleValues = new float[] { .8f, 1.1f, 1.4f };

        public static float GetRandomScaleValue()
        {
            return _scaleValues[UnityEngine.Random.Range(0, _scaleValues.Length)];
        }
    }
}
